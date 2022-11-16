import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, NgForm, FormBuilder,  FormControl  } from '@angular/forms';
import { Router } from '@angular/router';
import { Raca } from 'src/app/models/raca';
import { racaSearch } from 'src/app/models/racaSearch';
import { Veterinario } from 'src/app/models/veterinario';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-raca',
  templateUrl: './raca.component.html',
  styleUrls: ['./raca.component.css']
})
export class RacaComponent implements OnInit {
  racaForm= new FormGroup({
    breedName : new FormControl("")
  });
  isReturnItem = false;
  isLoadingResults = false;
  displayedColumns: string[] = [ 'id','name', 'temperament','life_span','weight','height','country_code'];
  dataSource: any;
  constructor(private router: Router, private api: AuthService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
  }
  addRaca(form: racaSearch) {
    console.log(form)
    this.api.getRacas(form)
      .subscribe({next:(res => {
        if (res != null)
        {
          this.dataSource = res
          console.log(res);
          this.isReturnItem = true;
        }
        else{
          this.isReturnItem = false;
        }
        this.isLoadingResults = false;
      }),error:(err =>{
        console.log(err);
        this.isLoadingResults = false;})
      });
  }

}
