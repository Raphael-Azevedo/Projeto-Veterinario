import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, NgForm, FormBuilder,  FormControl  } from '@angular/forms';
import { Router } from '@angular/router';
import { Veterinario } from 'src/app/models/veterinario';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-veterinario-create',
  templateUrl: './veterinario-create.component.html',
  styleUrls: ['./veterinario-create.component.css']
})
export class VeterinarioCreateComponent implements OnInit {
  vetForm= new FormGroup({
    nome : new FormControl(""),
    crmv : new FormControl(""),
    email : new FormControl(""),
    telefone : new FormControl(),
    endereco : new FormControl(""),
    cep : new FormControl(),
    bairro : new FormControl(""),
    cidade : new FormControl(""),
    consultorio : new FormControl(""),
  });


  isLoadingResults = false;

  constructor(private router: Router, private api: AuthService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
  }
  addVeterinario(form: Veterinario) {
    this.isLoadingResults = true;
    this.api.addVeterinario(form)
      .subscribe({next:(res => {
        this.isLoadingResults = false;
        this.router.navigate(['/veterinarios']);
      }),error:(err =>{
        console.log(err);
        this.isLoadingResults = false;})
      });
  }

}
