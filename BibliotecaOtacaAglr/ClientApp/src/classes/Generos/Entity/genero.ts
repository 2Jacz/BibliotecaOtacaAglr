import { Anime } from 'src/classes/Animes/Entity/anime';
import { Manga } from 'src/classes/Mangas/Entity/manga';

export class Genero {
  public generoId: number;
  public nombre: string;

  public listaAnimes: Anime[];
  public listaMangas: Manga[];
}
