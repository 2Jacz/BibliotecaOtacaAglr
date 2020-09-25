import { Paginador } from 'src/classes/Otros/paginador';
import { Anime } from '../Entity/anime';

export class AnimePaginado {
  public datos: Anime[];
  public pagina: Paginador;
}
