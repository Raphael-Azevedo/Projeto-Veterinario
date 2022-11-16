import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, NgForm, FormBuilder,  FormControl  } from '@angular/forms';
import { Router } from '@angular/router';
import { Cliente } from 'src/app/models/cliente';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-cliente-create',
  templateUrl: './cliente-create.component.html',
  styleUrls: ['./cliente-create.component.css']
})
export class ClienteCreateComponent implements OnInit {
  ClientForm = new FormGroup({
    nome : new FormControl(""),
    cpf : new FormControl(""),
    email : new FormControl(""),
    telefone : new FormControl(),
    endereco : new FormControl(""),
    cep : new FormControl(),
    bairro : new FormControl(""),
    cidade : new FormControl(""),
  });


  isLoadingResults = false;

  constructor(private router: Router, private api: AuthService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
  }
  addCliente(form: Cliente) {
    this.isLoadingResults = true;
    this.api.addCliente(form)
      .subscribe({next:(res => {
        this.isLoadingResults = false;
        this.router.navigate(['/clientes']);
      }),error:(err =>{
        console.log(err);
        this.isLoadingResults = false;})
      });
  }

}
