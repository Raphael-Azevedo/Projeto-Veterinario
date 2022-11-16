import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';
import { ProfileComponent } from './profile/profile.component';
import { BoardAdminComponent } from './board-admin/board-admin.component';
import { BoardModeratorComponent } from './board-moderator/board-moderator.component';
import { BoardUserComponent } from './board-user/board-user.component';

import { authInterceptorProviders } from './_helpers/auth.interceptor';
import { VeterinarioComponent } from './veterinario/veterinario/veterinario.component';
import { VeterinarioDetailsComponent } from './veterinario/veterinario-details/veterinario-details.component';
import { VeterinarioCreateComponent } from './veterinario/veterinario-create/veterinario-create.component';
import { ClienteComponent } from './cliente/cliente/cliente.component';
import { ClienteDetailComponent } from './cliente/cliente-detail/cliente-detail.component';
import { ClienteCreateComponent } from './cliente/cliente-create/cliente-create.component';
import { PetComponent } from './pet/pet/pet.component';
import { PetDetailComponent } from './pet/pet-detail/pet-detail.component';
import { PetCreateComponent } from './pet/pet-create/pet-create.component';
import { AtendimentoComponent } from './atendimento/atendimento/atendimento.component';
import { AtendimentoDetailsComponent } from './atendimento/atendimento-details/atendimento-details.component';
import { AtendimentoCreateComponent } from './atendimento/atendimento-create/atendimento-create.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatTabsModule } from '@angular/material/tabs';
import { MatInputModule } from '@angular/material/input';
import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { RacasComponent } from './user/racas/racas.component';
import { RacaComponent } from './user/raca/raca.component';
import { ImagemComponent } from './user/imagem/imagem.component';
import { AtendimentoUserComponent } from './user/atendimento/atendimento.component';
import { JwtModule } from '@auth0/angular-jwt';
import { AuthInterceptor } from './_helpers/auth.interceptor';
import { AuthInterceptorProvider } from './_services/auth.interceptor';

export function tokenGetter() {
  return sessionStorage.getItem("auth-token");
}
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    ProfileComponent,
    BoardAdminComponent,
    BoardModeratorComponent,
    BoardUserComponent,
    VeterinarioComponent,
    VeterinarioDetailsComponent,
    VeterinarioCreateComponent,
    ClienteComponent,
    ClienteDetailComponent,
    ClienteCreateComponent,
    PetComponent,
    PetDetailComponent,
    PetCreateComponent,
    AtendimentoComponent,
    AtendimentoDetailsComponent,
    AtendimentoCreateComponent,
    RacasComponent,
    RacaComponent,
    ImagemComponent,
    AtendimentoUserComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatPaginatorModule,
    MatSortModule,
    MatTableModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatTabsModule,
    MatInputModule,
    MatRadioModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatFormFieldModule,
  ],
  providers: [AuthInterceptorProvider],
  bootstrap: [AppComponent]
})
export class AppModule { }
