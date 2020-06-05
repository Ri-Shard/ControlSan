import { RestauranteComponent } from './perfil/restaurante/restaurante.component';
import { ManipuladorComponent } from './perfil/manipulador/manipulador.component';
import { Routes } from '@angular/router';
import { InformateComponent } from './perfil/informate/informate.component';
import { MasComponent } from './gestiones/mas/mas.component';
import { NormatividadComponent } from './info/normatividad/normatividad.component';
import { ConsultaComponent } from './perfil/consulta/consulta.component';
import { GestionComponent } from './perfil/gestion/gestion.component';
import { ConsultarComponent } from './gestiones/consultar/consultar.component';
import { ModificarComponent } from './gestiones/modificar/modificar.component';
import { RegistroComponent } from './perfil/registro/registro.component';
import { LoginComponent } from './component/login/login.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './guards/auth.guard';
import { RegUsuarioComponent } from './components/reg-usuario/reg-usuario.component';

export const routes: Routes = [
    { path: 'Restaurante', component: RestauranteComponent, canActivate: [ AuthGuard ] },
    { path: 'Manipulador', component: ManipuladorComponent, canActivate: [ AuthGuard ]},
    { path: 'Informate', component: InformateComponent, canActivate: [ AuthGuard ]},
    { path: 'Mas', component: MasComponent, canActivate: [ AuthGuard ]},
    { path: 'Normatividad', component: NormatividadComponent, canActivate: [ AuthGuard ]},
    { path: 'Consulta', component: ConsultaComponent, canActivate: [ AuthGuard ]},
    { path: 'Gestion', component: GestionComponent, canActivate: [ AuthGuard ]},
    { path: 'Consultar', component: ConsultarComponent, canActivate: [ AuthGuard ]},
    { path: 'Modificar', component: ModificarComponent, canActivate: [ AuthGuard ]},
    { path: 'Registro', component: RegistroComponent, canActivate: [ AuthGuard ] },
    { path: 'Home', component: HomeComponent, canActivate: [ AuthGuard ]},
    { path: 'Login', component: LoginComponent },
    { path: 'RegUsuario', component: RegUsuarioComponent },
    { path: '**', redirectTo: 'Home' }
];
