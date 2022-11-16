import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, NgForm, FormBuilder,  FormControl  } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Veterinario } from 'src/app/models/veterinario';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-veterinario-details',
  templateUrl: './veterinario-details.component.html',
  styleUrls: ['./veterinario-details.component.css']
})
export class VeterinarioDetailsComponent implements OnInit {
  id = Number;
  vetForm= new FormGroup({
    veterinarioId: new FormControl(),
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
  constructor(private router: Router, private route: ActivatedRoute,
    private api: AuthService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.getVeterinario(this.route.snapshot.params['id']);
  }

  getVeterinario(id:number) {
    this.api.getVeterinario(id).subscribe(data => {
      console.log(data)
      this.id = data.veterinarioId;
      this.vetForm.setValue({
        veterinarioId: data.veterinarioId,
        nome: data.nome,
        crmv: data.crmv,
        email: data.email,
        telefone: data.telefone,
        endereco: data.endereco,
        cep : data.cep,
        bairro : data.bairro,
        cidade : data.cidade,
        consultorio : data.consultorio
      });
    });
  }

  updateVeterinario(form: Veterinario) {
    console.log(form);
    this.isLoadingResults = true;
    this.api.updateVeterinario(this.id, form)
    .subscribe({next:(res => {
      this.isLoadingResults = false;
      this.router.navigate(['/veterinarios'])
    }),error:(err =>{
      console.log(err);
      this.isLoadingResults = false;})
    });
   }
}
