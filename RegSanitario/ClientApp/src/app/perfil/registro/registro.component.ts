import { Component, OnInit } from '@angular/core';
import { templateJitUrl } from '@angular/compiler';
import {Restaurante} from '../models/restaurante';
import { RestauranteService } from '../../services/restaurante.service';


@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css']
})
export class RegistroComponent implements OnInit {

  constructor() { }
  ngOnInit(): void  {
  }
}
