import { Anime } from 'src/classes/Animes/Entity/anime';
import { AnimeEpisodioServidores } from 'src/classes/Anime_Episodio_Servidores/Entity/anime-episodio-servidores';

export class AnimeEpisodios {
  public episodioId: number;
  public titulo_episodio: string;
  public numero_episodio: number;
  public urlServidores: AnimeEpisodioServidores[] = [];
  public nombre_archivo: string;
  public fecha_subida: Date;
  public animeId: number;

  public anime: Anime = new Anime();
}
