import { Injectable } from '@angular/core';
import { AngularFireAuth } from 'angularfire2/auth';
import { User } from 'firebase';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  user: User;
  constructor( private afAuth: AngularFireAuth ) {
    afAuth.authState.subscribe( rest => {
      this.user = rest;
    });
  }

  validarLogin() {
    if ( this.user ) {
      return true;
    } else {
      return false;
    }
  }
}

