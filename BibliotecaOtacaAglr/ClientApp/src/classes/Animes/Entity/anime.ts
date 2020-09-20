import { AnimeEpisodios } from 'src/classes/Anime_Episodios/Entity/anime-episodios';
import { AnimeGeneros } from './anime-generos';

export class Anime {
  public AnimeId: number;
  public Nombre: string;
  public Descripcion: string;
  public Fecha_publicacion: Date;
  public Portada: any;
  public Numero_Episodios: number;
  public Fecha_subida: Date;
  public Generos: AnimeGeneros[];
  public Episosdios: AnimeEpisodios[];
}
