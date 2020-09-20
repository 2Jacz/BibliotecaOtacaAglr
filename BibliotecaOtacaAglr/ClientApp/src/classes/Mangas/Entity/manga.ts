import { MangaCapitulo } from 'src/classes/Manga_Capitulos/Entity/manga-capitulo';
import { MangaGeneros } from './manga-generos';

export class Manga {
  public MangaId: number;
  public Nombre: string;
  public Descripcion: string;
  public Fecha_publicacion: Date;
  public Portada: any;
  public Fecha_subida: Date;

  public Generos: MangaGeneros[];
  public Capitulos: MangaCapitulo[];

}
