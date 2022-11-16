import { NullVisitor } from '@angular/compiler/src/render3/r3_ast';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Image } from 'src/app/models/image';
import { NomeRaca } from 'src/app/models/nomeRaca';
import { AuthService } from 'src/app/_services/auth.service';


@Component({
  selector: 'app-imagem',
  templateUrl: './imagem.component.html',
  styleUrls: ['./imagem.component.css']
})
export class ImagemComponent implements OnInit {
  displayedColumns: string[] = [ 'id','url', 'breeds'];
  dataSource: Image[] = []!;
  isLoadingResults = true;
  racaName : any ;
  constructor(private router: Router, private api: AuthService) { }

  ngOnInit(): void {
    this.racaName = new NomeRaca;
    this.api.getImagem()
    .subscribe({next:( res => {
      this.dataSource = res;
      this.dataSource.forEach(ele =>{
        if (ele.breeds[0] != null){
          ele.breeds = ele.breeds[0]
        }
        else{
          ele.breeds = this.racaName
        }
      });
      console.log(this.dataSource);
      this.isLoadingResults = false;
    }),error: (err => {
      console.log(err);
      this.isLoadingResults = false;})
   });
  }
}

