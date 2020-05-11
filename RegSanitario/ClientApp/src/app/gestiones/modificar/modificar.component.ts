import { Component, OnInit } from '@angular/core';
import { Restaurante } from 'src/app/perfil/models/restaurante';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { RestauranteService } from 'src/app/services/restaurante.service';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'app-modificar',
  templateUrl: './modificar.component.html',
  styleUrls: ['./modificar.component.css']
})
  export class ModificarComponent implements OnInit {

    formGroup: FormGroup;
    restaurante: Restaurante;
    // tslint:disable-next-line: max-line-length
    nit: string; public _nombreRes: string; public _direccion: string; public _estado: string; public _evaluacion: string; public _id: string;
        constructor(
      private restauranteService: RestauranteService,
      private formBuilder: FormBuilder,
      private modalService: NgbModal) { }
    ngOnInit() {
      this.restaurante = JSON.parse(localStorage.getItem('restaurante')) ;
        if (this.restaurante != null) {
          this.PintarInput(this.restaurante);
          this.buildForm();
          const messageBox = this.modalService.open(AlertModalComponent);
          messageBox.componentInstance.title = 'Resultado Operación';
          messageBox.componentInstance.message = 'Realice las modificaciones';
        }
}

    private PintarInput(restaurante1: Restaurante) {
      this._nombreRes = restaurante1.nombreRestaurante;
      this._estado = restaurante1.estado;
      this._evaluacion = restaurante1.evaluacion;
      this._direccion = restaurante1.direccion;
      this._id = restaurante1.id;
      this.nit = restaurante1.nit;
    }


    private buildForm() {
      this.formGroup = this.formBuilder.group({
        nit: this.nit,
        nombreres: [this._nombreRes, Validators.required],
        estado: [this._estado, Validators.required],
        evaluacion: [this._evaluacion, Validators.required],
        direccion: [this._direccion, Validators.required],
        id: [this._id, Validators.required],

      });
    }
    onSubmit() {
      if (this.formGroup.invalid) {
        return;
      }
      this.add();
    }


    add() {
      this.restaurante = this.formGroup.value;
      this.restauranteService.put(this.restaurante).subscribe(p => {
        if (p != null) {
          const messageBox = this.modalService.open(AlertModalComponent);
          messageBox.componentInstance.title = 'Resultado Operación';
          messageBox.componentInstance.message = 'restaurante Modificado!!! :)';
          this.restaurante = p;
        }
      });

    }

    get control() { return this.formGroup.controls; }
  }
