import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Veterinario } from 'src/app/models/veterinario';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-veterinario',
  templateUrl: './veterinario.component.html',
  styleUrls: ['./veterinario.component.css']
})
export class VeterinarioComponent implements OnInit {
  displayedColumns: string[] = [ 'nome','crmv', 'email','telefone','endereco','cep','bairro','cidade','acao'];
  dataSource: Veterinario[] = []!;
  isLoadingResults = true;

  constructor(private router: Router, private api: AuthService) { }

  ngOnInit(): void {
    this.api.getVeterinarios()
    .subscribe({next:( res => {
      this.dataSource = res;
      console.log(this.dataSource);
      this.isLoadingResults = false;
    }),error: (err => {
      console.log(err);
      this.isLoadingResults = false;})
   });
  }
  deleteProduto(id:number) {
    this.isLoadingResults = true;
    this.api.deleteVeterinario(id)
    .subscribe({next:(res => {
      this.isLoadingResults = false;
      location.reload();
    }),error:(err =>{
      console.log(err);
      this.isLoadingResults = false;})
    });
  }
}



