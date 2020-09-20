import { Anime } from 'src/classes/Animes/Entity/anime';
import { Manga } from 'src/classes/Mangas/Entity/manga';

export class Genero {
  public GeneroId: number;
  public Nombre: string;

  public ListaAnimes: Anime[];
  public ListaMangas: Manga[];
}
