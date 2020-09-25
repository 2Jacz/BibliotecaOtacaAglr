import { MangaCapitulo } from 'src/classes/Manga_Capitulos/Entity/manga-capitulo';
import { MangaGeneros } from './manga-generos';

export class Manga {
  public mangaId: number;
  public nombre: string;
  public descripcion: string;
  public fecha_publicacion: Date;
  public portada: any;
  public fecha_subida: Date;

  public generos: MangaGeneros[];
  public capitulos: MangaCapitulo[];

}
