import { Component, OnInit } from '@angular/core';
import { templateJitUrl } from '@angular/compiler';
import {Restaurante} from '../models/restaurante';
import {Dueño} from '../models/dueño';
import { RestauranteService } from '../../services/restaurante.service';
import { DueñoService } from '../../services/dueño.service';
import { FormGroup, FormBuilder, Validators, AbstractControl} from '@angular/forms';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
@Component({
  selector: 'app-restaurante',
  templateUrl: './restaurante.component.html',
  styleUrls: ['./restaurante.component.css']
})
export class RestauranteComponent implements OnInit {

  formGroup: FormGroup;
  restaurante: Restaurante;
  dueño: Dueño;
  // tslint:disable-next-line: max-line-length
  constructor(private _restauranteService: RestauranteService, private _dueñoService: DueñoService , private formBuilder: FormBuilder, private modalService: NgbModal) {}

  ngOnInit() {
    this.buildForm();
  }

  agregar() {
    console.log(this.restaurante);
   console.log(this.formGroup);

    this.restaurante = this.formGroup.value;
    this._restauranteService.post(this.restaurante).subscribe(p => {
      if (p != null) {
        const messageBox = this.modalService.open(AlertModalComponent);
          messageBox.componentInstance.title = 'Resultado Operación';
          messageBox.componentInstance.message = 'Solicitud Creada!!!';
        this.restaurante = p;
      } else {
        const messageBox = this.modalService.open(AlertModalComponent);
        messageBox.componentInstance.title = 'Resultado Operación';
        messageBox.componentInstance.message = 'El Nit ingresado ya se encuentra registrado ';
      }
    });
  }
  add() {
    console.log(this.dueño);

    this.dueño = this.formGroup.value;
    this._dueñoService.post(this.dueño).subscribe(p => {
      if (p != null) {
        this.dueño = p;
      } else {
        const messageBox = this.modalService.open(AlertModalComponent);
        messageBox.componentInstance.title = 'Resultado Operación';
        messageBox.componentInstance.message = 'ERROR';
      }
    });
  }
   buildForm() {
    this.formGroup = this.formBuilder.group({

      id: ['', Validators.required],
      nit: ['', Validators.required],
      nombreRestaurante: ['', Validators.required],
      direccion: ['', Validators.required],
      estado: ['Pendiente'],
      evaluacion: ['Pendiente'],
      nombre: ['', Validators.required],
      apellido: ['', Validators.required],

    });

    }
    get control() {
      return this.formGroup.controls;
    }
    onSubmit() {
      if (this.formGroup.invalid) {
      return Object.values(this.formGroup.controls).forEach(control => {
        control.markAllAsTouched();
      });
      }
      this.add();
      this.agregar();
      }

      get nitinvalido() {
        return this.formGroup.get('nit').invalid && this.formGroup.get('nit').touched;
      }
      get nombreResinvalido() {
        return this.formGroup.get('nombreRestaurante').invalid && this.formGroup.get('nombreRestaurante').touched;
      }
      get direccioninvalido() {
        return this.formGroup.get('direccion').invalid && this.formGroup.get('direccion').touched;
      }
      get IDdinvalido() {
        return this.formGroup.get('id').invalid && this.formGroup.get('id').touched;
      }
      get Apellidodinvalido() {
        return this.formGroup.get('apellido').invalid && this.formGroup.get('apellido').touched;
      }
      get Nombredinvalido() {
        return this.formGroup.get('nombre').invalid && this.formGroup.get('nombre').touched;
      }
      get Celulardinvalido() {
        return this.formGroup.get('celular').invalid && this.formGroup.get('celular').touched;
      }
      get Emaildinvalido() {
        return this.formGroup.get('email').invalid && this.formGroup.get('email').touched;
      }
}
