import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, NgForm, FormBuilder,  FormControl  } from '@angular/forms';
import { Router } from '@angular/router';
import { Cachorro } from 'src/app/models/cachorro';
import { AuthService } from 'src/app/_services/auth.service';
import {MatCalendarCellClassFunction} from '@angular/material/datepicker';

@Component({
  selector: 'app-pet-create',
  templateUrl: './pet-create.component.html',
  styleUrls: ['./pet-create.component.css']
})
export class PetCreateComponent implements OnInit {
  petForm= new FormGroup({
    nome : new FormControl(""),
    tutorCpf : new FormControl(""),
    nomeRaca : new FormControl(""),
    tamanho : new FormControl(),
    peso : new FormControl(),
    vacinas : new FormControl(""),
    dataDeNascimento : new FormControl(new Date().toJSON()),
    pedigree : new FormControl(""),
    porte : new FormControl(""),
  });


  isLoadingResults = false;

  constructor(private router: Router, private api: AuthService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
  }
  addPet(form: Cachorro) {
    this.isLoadingResults = true;
    console.log(form);
    this.api.addPet(form)
      .subscribe({next:(res => {
        this.isLoadingResults = false;
        this.router.navigate(['/pets']);
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
