import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, NgForm, FormBuilder, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { Usuario } from '../models/usuario';
import { AuthService } from '../_services/auth.service';



@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  token : any;
  loginForm= new FormGroup({
    email : new FormControl(""),
    password : new FormControl(""),
    confirmPassword: new FormControl(""),
    dataSource : new FormControl(Usuario),
  });
  dataSource : any;
  isSuccessful = false;
  isSignUpFailed = false;
  errorMessage = '';

  constructor(private router: Router, private api: AuthService,
     private formBuilder: FormBuilder) { }

  ngOnInit() {
     this.loginForm = this.formBuilder.group({
    'email' : [null, [Validators.required, Validators.email]],
    'password' : [null, Validators.required],
    'confirmPassword' : [null, Validators.required],
  });
  }

  addLogin(loginForm: Usuario) {
    this.api.register(loginForm)
    .subscribe({next:(res => {
      console.log(res);
      this.dataSource = res;
      this.isSuccessful = true;
      this.isSignUpFailed = false;
    }),error:(err => {
      console.log(err);
      this.errorMessage = err.error.message;
      this.isSignUpFailed = true;})
    });
  }
}
