import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { AngularFireAuth } from 'angularfire2/auth';
import { Router } from '@angular/router';

@Component({
  selector: 'app-reg-usuario',
  templateUrl: './reg-usuario.component.html',
  styleUrls: ['./reg-usuario.component.css']
})
export class RegUsuarioComponent implements OnInit {

  formulario: FormGroup;

  constructor( private fb: FormBuilder,
               private afAuth: AngularFireAuth,
               private router: Router ) { }

  ngOnInit() {
    this.crearFormulario();
  }

  crearFormulario() {
    this.formulario = this.fb.group({
      email: [],
      password: []
    });
  }

  registrar() {
    this.afAuth.auth.createUserWithEmailAndPassword( this.formulario.value.email, this.formulario.value.password )
    .then( rest => {
      console.log(rest);
    })
    .catch( err => {
      console.log(err);
    });
  }

  navegar() {
    this.router.navigateByUrl('/Login');
  }

}
