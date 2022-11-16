import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, NgForm, FormBuilder,  FormControl  } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Atendimento } from 'src/app/models/atendimento';
import { Veterinario } from 'src/app/models/veterinario';
import { AuthService } from 'src/app/_services/auth.service';
import {MatCalendarCellClassFunction} from '@angular/material/datepicker';
import { Cachorro } from 'src/app/models/cachorro';

@Component({
  selector: 'app-atendimento-details',
  templateUrl: './atendimento-details.component.html',
  styleUrls: ['./atendimento-details.component.css']
})
export class AtendimentoDetailsComponent implements OnInit {
  id = Number;
  atendimentoForm= new FormGroup({
    atendimentoId : new FormControl(),
    cachorroId : new FormControl(),
    veterinarioId : new FormControl(),
    diagnostico : new FormControl(""),
    comentario : new FormControl(""),
    dataDeAtendimento : new FormControl(new Date().toJSON()),
  });
  dataSource: Cachorro[] = []!;
  dataSourc: Veterinario[] = []!;

  isLoadingResults = false;

  constructor(private router: Router,private route: ActivatedRoute, private api: AuthService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.getAtendimento(this.route.snapshot.params['id']);

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

  getAtendimento(id:number) {
    this.api.getAtendimento(id).subscribe(data => {
      console.log(data)
      this.id = data.atendimentoId;
      this.atendimentoForm.setValue({
        atendimentoId: data.atendimentoId,
        cachorroId: data.pet.cachorroId,
        veterinarioId: data.veterinario.veterinarioId,
        diagnostico: data.diagnostico,
        comentario: data.comentario,
        dataDeAtendimento: data.dataDeAtendimento,
      });
    });
  }

  addAtendimento(form: Atendimento) {
    console.log(form);
    this.isLoadingResults = true;
    this.api.updateAtendimento(this.id, form)
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
