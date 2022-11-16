import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Cliente } from 'src/app/models/cliente';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.css']
})
export class ClienteComponent implements OnInit {
  displayedColumns: string[] = [ 'nome','cpf', 'email','telefone','endereco','cep','bairro','cidade','acao'];
  dataSource: Cliente[] = []!;
  isLoadingResults = true;

  constructor(private router: Router, private api: AuthService) { }

  ngOnInit(): void {
    this.api.getClientes()
    .subscribe({next:( res => {
      this.dataSource = res;
      console.log(this.dataSource);
      this.isLoadingResults = false;
    }),error: (err => {
      console.log(err);
      this.isLoadingResults = false;})
   });
  }
  deleteCliente(id:number) {
    this.isLoadingResults = true;
    this.api.deleteCliente(id)
    .subscribe({next:(res => {
      this.isLoadingResults = false;
      location.reload();
    }),error:(err =>{
      console.log(err);
      this.isLoadingResults = false;})
    });
  }
}

