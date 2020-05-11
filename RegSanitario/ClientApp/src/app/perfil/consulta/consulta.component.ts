import { Component, OnInit } from '@angular/core';
import { Restaurante } from '../models/restaurante';
import { RestauranteService } from '../../services/restaurante.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-consulta',
  templateUrl: './consulta.component.html',
  styleUrls: ['./consulta.component.css']
})
export class ConsultaComponent implements OnInit {

  restaurantes: Restaurante[];
  restaurante: Restaurante;
  searchText: string;
  constructor(private _restauranteService: RestauranteService,
    private router: Router
    ) { }

  ngOnInit() {
    this._restauranteService.get().subscribe(c => {
      this.restaurantes = c;
    });
  }

  showr() {
    document.getElementById('form2').style.display = 'block';
    document.getElementById('form1').style.display = 'none';

  }
  showm() {
    document.getElementById('form1').style.display = 'block';
    document.getElementById('form2').style.display = 'none';

  }

}
