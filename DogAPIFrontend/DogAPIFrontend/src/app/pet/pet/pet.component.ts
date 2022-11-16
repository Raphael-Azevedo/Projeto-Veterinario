import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Cachorro } from 'src/app/models/cachorro';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-pet',
  templateUrl: './pet.component.html',
  styleUrls: ['./pet.component.css']
})
export class PetComponent implements OnInit {
  displayedColumns: string[] = [ 'nome','tutor','raca', 'tamanho','peso','vacinas','dataDeNascimento','pedigree','porte','acao'];
  dataSource: Cachorro[] = []!;
  isLoadingResults = true;
  constructor(private router: Router, private api: AuthService) { }
  timeElapsed = Date.now();
  today = new Date(this.timeElapsed);

  ngOnInit(): void {
    this.api.getPets()
    .subscribe({next:( res => {
      this.dataSource = res;
      this.dataSource.forEach((eachObject : Cachorro) => {
        eachObject.idade = Math.abs(this.today.getFullYear() - new Date(eachObject.dataDeNascimento).getFullYear());
        eachObject.mes = Math.abs(this.today.getMonth() - new Date(eachObject.dataDeNascimento).getMonth());
      });
      console.log(this.dataSource);
      this.isLoadingResults = false;
    }),error: (err => {
      console.log(err);
      this.isLoadingResults = false;})
   });

  }
  deletePet(id:number) {
    this.isLoadingResults = true;
    this.api.deletePet(id)
    .subscribe({next:(res => {
      this.isLoadingResults = false;
      location.reload();
    }),error:(err =>{
      console.log(err);
      this.isLoadingResults = false;})
    });
  }
}

