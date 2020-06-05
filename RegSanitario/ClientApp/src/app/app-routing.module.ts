import { RegistroComponent } from './perfil/registro/registro.component';
import { ConsultaComponent } from './perfil/consulta/consulta.component';
import { RestauranteComponent } from './perfil/restaurante/restaurante.component';
import { GestionComponent } from './perfil/gestion/gestion.component';
import { ManipuladorComponent } from './perfil/manipulador/manipulador.component';
import { NormatividadComponent } from './info/normatividad/normatividad.component';
import { InformateComponent } from './perfil/informate/informate.component';
import { ConsultarComponent } from './gestiones/consultar/consultar.component';
import { ModificarComponent } from './gestiones/modificar/modificar.component';
import { MasComponent } from './gestiones/mas/mas.component';
import { NgModule, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
const routes: Routes = [
  {
    path: 'Restaurante',
    component: RestauranteComponent
  },
  {
    path: 'Manipulador',
    component: ManipuladorComponent
  },
  {
    path: 'Informate',
    component: InformateComponent
  },
  {
    path: 'Mas',
    component: MasComponent
  },
  {
    path: 'Normatividad',
    component: NormatividadComponent
  },
  {
    path: 'Consulta',
    component: ConsultaComponent
  },
  {
    path: 'Gestion',
    component: GestionComponent
  },
  {
    path: 'Consultar',
    component: ConsultarComponent
  },
  {
    path: 'Modificar',
    component: ModificarComponent
  },
  {
    path: 'Registro',
    component: RegistroComponent
  },
  { path: 'Home', component: HomeComponent },
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'Home'
  }
];
@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
