import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, NgForm, FormBuilder,  FormControl  } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Cachorro } from 'src/app/models/cachorro';
import { AuthService } from 'src/app/_services/auth.service';
import {MatCalendarCellClassFunction} from '@angular/material/datepicker';

@Component({
  selector: 'app-pet-detail',
  templateUrl: './pet-detail.component.html',
  styleUrls: ['./pet-detail.component.css']
})
export class PetDetailComponent implements OnInit {
  id = Number;
  petForm= new FormGroup({
    cachorroId : new FormControl(),
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

  constructor(private router: Router, private route: ActivatedRoute, private api: AuthService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.getPet(this.route.snapshot.params['id']);
  }

  getPet(id:number) {
    this.api.getPet(id).subscribe(data => {
      console.log(data)
      this.id = data.cachorroId;
      this.petForm.setValue({
        cachorroId: data.cachorroId,
        nome: data.nome,
        tutorCpf: data.tutor.cpf,
        nomeRaca: data.raca.name,
        tamanho: data.tamanho,
        peso: data.peso,
        vacinas : data.vacinas,
        dataDeNascimento : data.dataDeNascimento,
        pedigree : data.pedigree,
        porte : data.porte
      });
    });
  }
  upgradePet(form: Cachorro) {
    this.isLoadingResults = true;
    console.log(form);
    this.api.updatePet(this.id, form)
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
