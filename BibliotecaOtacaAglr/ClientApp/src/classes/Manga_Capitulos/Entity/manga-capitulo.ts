import { Manga } from 'src/classes/Mangas/Entity/manga';
import { MangaCapituloPaginas } from 'src/classes/Manga_Capitulos_Paginas/Entity/manga-capitulo-paginas';

export class MangaCapitulo {
  public CapituloId: number;
  public Nombre: string;
  public Numero_capitulo: number;
  public Fecha_subida: Date;
  public MangaId: number;

  public Manga: Manga;
  public Paginas: MangaCapituloPaginas[];
}
