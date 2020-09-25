import { Manga } from 'src/classes/Mangas/Entity/manga';
import { MangaCapituloPaginas } from 'src/classes/Manga_Capitulos_Paginas/Entity/manga-capitulo-paginas';

export class MangaCapitulo {
  public capituloId: number;
  public nombre: string;
  public numero_capitulo: number;
  public fecha_subida: Date;
  public mangaId: number;

  public manga: Manga;
  public paginas: MangaCapituloPaginas[];
}
