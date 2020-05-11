import { Component, OnInit } from '@angular/core';
import { Restaurante } from './.././../perfil/models/restaurante';
import { RestauranteService } from '../../services/restaurante.service';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';

@Component({
  selector: 'app-mas',
  templateUrl: './mas.component.html',
  styleUrls: ['./mas.component.css']
})
export class MasComponent implements OnInit {

  restaurante: Restaurante;

  constructor(private _restauranteService: RestauranteService, private modalService: NgbModal,
    private router: Router
    ) { }

  ngOnInit() {
        this.restaurante = JSON.parse(localStorage.getItem('restaurante'));
  }

  save(  restaurante: Restaurante ) {
    localStorage.setItem('restaurante', JSON.stringify(restaurante));
  }
  delete() {
    this._restauranteService.delete(this.restaurante.nit).subscribe(p => {
      const messageBox = this.modalService.open(AlertModalComponent);
      messageBox.componentInstance.title = 'Resultado Operación';
      messageBox.componentInstance.message = 'restaurante Eliminado!!! :)';
      localStorage.clear();
    });
  }


}
