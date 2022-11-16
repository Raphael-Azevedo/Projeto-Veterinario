import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, NgForm, FormBuilder,  FormControl  } from '@angular/forms';
import { Router } from '@angular/router';
import { Atendimento } from 'src/app/models/atendimento';
import { Veterinario } from 'src/app/models/veterinario';
import { AuthService } from 'src/app/_services/auth.service';
import {MatCalendarCellClassFunction} from '@angular/material/datepicker';
import { Cachorro } from 'src/app/models/cachorro';

@Component({
  selector: 'app-atendimento-create',
  templateUrl: './atendimento-create.component.html',
  styleUrls: ['./atendimento-create.component.css']
})
export class AtendimentoCreateComponent implements OnInit {
  atendimentoForm= new FormGroup({
    cachorroId : new FormControl(),
    veterinarioId : new FormControl(),
    diagnostico : new FormControl(""),
    comentario : new FormControl(""),
    dataDeAtendimento : new FormControl(new Date().toJSON()),
  });
  dataSource: Cachorro[] = []!;
  dataSourc: Veterinario[] = []!;

  isLoadingResults = false;

  constructor(private router: Router, private api: AuthService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.api.getPets()
    .subscribe({next:( res => {
      this.dataSource = res;
      console.log(this.dataSource);
      this.isLoadingResults = false;
    }),error: (err => {
      console.log(err);
      this.isLoadingResults = false;})
   });
   this.api.getVeterinarios()
   .subscribe({next:( res => {
     this.dataSourc = res;
     console.log(this.dataSource);
     this.isLoadingResults = false;
   }),error: (err => {
     console.log(err);
     this.isLoadingResults = false;})
  });
  }
  addAtendimento(form: Atendimento) {
    this.isLoadingResults = true;
    this.api.addAtendimento(form)
      .subscribe({next:(res => {
        this.isLoadingResults = false;
        this.router.navigate(['/atendimentos']);
      }),error:(err =>{
        console.log(err);
        this.isLoadingResults = false;})
      });
  }

  dateClass: MatCalendarCellClassFunction<Date> = (cellDate, view) => {
    // Only highligh dates inside the month view.
    if (view === 'month') {
      const date = cellDate.toJSON();
    }

    return '';
  };

}
