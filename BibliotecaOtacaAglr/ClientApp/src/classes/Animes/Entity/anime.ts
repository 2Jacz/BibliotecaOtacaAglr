import { AnimeEpisodios } from 'src/classes/Anime_Episodios/Entity/anime-episodios';
import { AnimeGeneros } from './anime-generos';

export class Anime {
  public animeId: number;
  public nombre: string;
  public descripcion: string;
  public fecha_publicacion: Date;
  public portada: any;
  public numero_episodios: number;
  public fecha_subida: Date;
  public generos: AnimeGeneros[];
  public episodios: AnimeEpisodios[];
}
