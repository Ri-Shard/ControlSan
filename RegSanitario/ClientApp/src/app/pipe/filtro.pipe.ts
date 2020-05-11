import { Pipe, PipeTransform } from '@angular/core';
import { Restaurante } from '../perfil/models/restaurante';


@Pipe({
  name: 'filtro'
})
export class FiltroPipe implements PipeTransform {

  transform(restaurante: Restaurante[], searchText: string): any {
    if (searchText == null) {  return restaurante; }
    return restaurante.filter(p =>
      p.nit.toLowerCase()
      .indexOf(searchText.toLowerCase()) !== -1);
  }

}
