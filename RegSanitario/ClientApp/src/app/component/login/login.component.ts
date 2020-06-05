import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { AngularFireAuth } from 'angularfire2/auth';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  formulario: FormGroup;
  constructor(private fb: FormBuilder,
              private router: Router,
              private afAuth: AngularFireAuth) { }

  ngOnInit() {
    this.crearFormulario();
  }

  crearFormulario() {
    this.formulario = this.fb.group({
      email: [],
      password: []
    });
  }

  login() {
    this.afAuth.auth.signInWithEmailAndPassword( this.formulario.value.email, this.formulario.value.password )
    .then( rest => {
      console.log(rest);
    })
    .catch( err => {
      console.log(err);
    });
  }

  navegar() {
    this.router.navigateByUrl('/RegUsuario');
  }

}
