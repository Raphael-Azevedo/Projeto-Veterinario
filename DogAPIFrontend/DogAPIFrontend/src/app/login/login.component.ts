import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { TokenStorageService } from '../_services/token-storage.service';
import { FormGroup, Validators, NgForm, FormBuilder, FormControl } from '@angular/forms';
import { Usuario } from '../models/usuario';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  token : any;
  loginForm= new FormGroup({
    email : new FormControl(""),
    password : new FormControl(""),
    dataSource : new FormControl(Usuario),
  });
  dataSource : any;
  isLoadingResults = false;

  isLoggedIn = false;
  isLoginFailed = false;
  errorMessage = '';
  roles: string[] = [];

  constructor(private authService: AuthService, private tokenStorage: TokenStorageService,private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
   'email' : [null, Validators.required],
   'password' : [null, Validators.required]
 });
 if (this.tokenStorage.getToken()) {
  this.isLoggedIn = true;
  this.roles = this.tokenStorage.getUser().email;
}
 }

  reloadPage(): void {
    window.location.reload();
  }
  addLogin(form: Usuario) {
    this.isLoadingResults = true;
    this.authService.login(form)
    .subscribe({next:(res => {
      console.log(res);
      this.tokenStorage.saveToken(res.token);
      this.tokenStorage.saveUser(res);
      this.dataSource = res;
      this.isLoadingResults = false;
      this.isLoginFailed = false;
      this.isLoggedIn = true;
      this.roles = this.tokenStorage.getUser().roles;
      location.reload();
    }),error:(err =>{
      console.log(err);
      this.errorMessage = err.error.message;
      this.isLoginFailed = true;})
    });
  }

}
