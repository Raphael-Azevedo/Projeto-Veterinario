import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Atendimento } from 'src/app/models/atendimento';
import { AuthService } from 'src/app/_services/auth.service';
import { TokenStorageService } from 'src/app/_services/token-storage.service';

@Component({
  selector: 'app-atendimento',
  templateUrl: './atendimento.component.html',
  styleUrls: ['./atendimento.component.css']
})
export class AtendimentoUserComponent implements OnInit {
  displayedColumns: string[] = [ 'nome','veterinario', 'dataDeAtendimento','horarioDeAtendimento','diagnostico','comentario'];
  dataSource: Atendimento[] = []!;
  isLoadingResults = true;
  isLoggedIn = false;
  showAdminBoard = false;
  showModeratorBoard = false;
  username: string = "";

  constructor(private router: Router, private api: AuthService, private tokenStorageService: TokenStorageService) { }

  ngOnInit(): void {
    this.isLoggedIn = !!this.tokenStorageService.getToken();

    if (this.isLoggedIn) {
      const user = this.tokenStorageService.getUser();
      this.username = user.email;
    }
    this.api.getAtendimentosUser(this.username)
    .subscribe({next:( res => {
      this.dataSource = res;
      this.dataSource.forEach((eachObject : Atendimento) => {
        eachObject.horarioDeAtendimento = new Date(eachObject.dataDeAtendimento).getTime();
      });
      console.log(this.dataSource);
      this.isLoadingResults = false;
    }),error: (err => {
      console.log(err);
      this.isLoadingResults = false;})
   });
  }
  deleteAtendimento(id:number) {
    this.isLoadingResults = true;
    this.api.deleteAtendimento(id)
    .subscribe({next:(res => {
      this.isLoadingResults = false;
      location.reload();
    }),error:(err =>{
      console.log(err);
      this.isLoadingResults = false;})
    });
  }
}


