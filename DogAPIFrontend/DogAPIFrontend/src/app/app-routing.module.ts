import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { ProfileComponent } from './profile/profile.component';
import { BoardUserComponent } from './board-user/board-user.component';
import { BoardModeratorComponent } from './board-moderator/board-moderator.component';
import { BoardAdminComponent } from './board-admin/board-admin.component';
import { VeterinarioComponent } from './veterinario/veterinario/veterinario.component';
import { VeterinarioCreateComponent } from './veterinario/veterinario-create/veterinario-create.component';
import { VeterinarioDetailsComponent } from './veterinario/veterinario-details/veterinario-details.component';
import { PetComponent } from './pet/pet/pet.component';
import { PetCreateComponent } from './pet/pet-create/pet-create.component';
import { PetDetailComponent } from './pet/pet-detail/pet-detail.component';
import { ClienteComponent } from './cliente/cliente/cliente.component';
import { ClienteCreateComponent } from './cliente/cliente-create/cliente-create.component';
import { ClienteDetailComponent } from './cliente/cliente-detail/cliente-detail.component';
import { AtendimentoComponent } from './atendimento/atendimento/atendimento.component';
import { AtendimentoCreateComponent } from './atendimento/atendimento-create/atendimento-create.component';
import { AtendimentoDetailsComponent } from './atendimento/atendimento-details/atendimento-details.component';
import { RacaComponent } from './user/raca/raca.component';
import { RacasComponent } from './user/racas/racas.component';
import { AtendimentoUserComponent } from './user/atendimento/atendimento.component';
import { ImagemComponent } from './user/imagem/imagem.component';
import { JwtModule } from '@auth0/angular-jwt';
import { tokenGetter } from './app.module';
import { UserService } from './_services/user.service';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'profile', component: ProfileComponent },
  { path: 'user', component: BoardUserComponent },
  { path: 'mod', component: BoardModeratorComponent },
  { path: 'admin', component: BoardAdminComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'veterinarios', component: VeterinarioComponent },
  { path: 'veterinario/novo', component: VeterinarioCreateComponent },
  { path: 'veterinario/:id', component: VeterinarioDetailsComponent },
  { path: 'pets', component: PetComponent},
  { path: 'pet/novo', component: PetCreateComponent },
  { path: 'pet/:id', component: PetDetailComponent },
  { path: 'clientes', component: ClienteComponent },
  { path: 'cliente/novo', component: ClienteCreateComponent },
  { path: 'cliente/:id', component: ClienteDetailComponent },
  { path: 'atendimentos', component: AtendimentoComponent },
  { path: 'atendimento/novo', component: AtendimentoCreateComponent },
  { path: 'atendimento/:id', component: AtendimentoDetailsComponent },
  { path: 'raca', component: RacaComponent },
  { path: 'racas', component: RacasComponent },
  { path: 'user/atendimentos', component: AtendimentoUserComponent },
  { path: 'imagem', component: ImagemComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
