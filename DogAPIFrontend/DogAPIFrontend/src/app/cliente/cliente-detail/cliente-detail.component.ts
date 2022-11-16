import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, NgForm, FormBuilder,  FormControl  } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Cliente } from 'src/app/models/cliente';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-cliente-detail',
  templateUrl: './cliente-detail.component.html',
  styleUrls: ['./cliente-detail.component.css']
})
export class ClienteDetailComponent implements OnInit {
  id = Number;
  clienteForm= new FormGroup({
    clienteId: new FormControl(),
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
  constructor(private router: Router, private route: ActivatedRoute,
    private api: AuthService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.getCliente(this.route.snapshot.params['id']);
  }

  getCliente(id:number) {
    this.api.getCliente(id).subscribe(data => {
      console.log(data)
      this.id = data.clienteId;
      console.log(data.clienteId)
      this.clienteForm.setValue({
        clienteId: data.clienteId,
        nome: data.nome,
        cpf: data.cpf,
        email: data.email,
        telefone: data.telefone,
        endereco: data.endereco,
        cep : data.cep,
        bairro : data.bairro,
        cidade : data.cidade,
      });
    });
  }

  updateCliente(form: Cliente) {
    console.log(form);
    this.isLoadingResults = true;
    this.api.updateCliente(this.id, form)
    .subscribe({next:(res => {
      this.isLoadingResults = false;
      this.router.navigate(['/clientes'])
    }),error:(err =>{
      console.log(err);
      this.isLoadingResults = false;})
    });
   }
}
