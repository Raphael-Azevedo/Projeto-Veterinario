import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Raca } from 'src/app/models/raca';
import { AuthService } from 'src/app/_services/auth.service';


@Component({
  selector: 'app-racas',
  templateUrl: './racas.component.html',
  styleUrls: ['./racas.component.css']
})
export class RacasComponent implements OnInit {
  displayedColumns: string[] = [ 'id','name', 'temperament','life_span','weight','height','country_code'];
  dataSource: Raca[] = []!;
  isLoadingResults = true;

  constructor(private router: Router, private api: AuthService) { }

  ngOnInit(): void {
    this.api.getRaca()
    .subscribe({next:( res => {
      this.dataSource = res;
      console.log(this.dataSource);
      this.isLoadingResults = false;
    }),error: (err => {
      console.log(err);
      this.isLoadingResults = false;})
   });
  }
}



