import { Anime } from 'src/classes/Animes/Entity/anime';
import { AnimeEpisodioServidores } from 'src/classes/Anime_Episodio_Servidores/Entity/anime-episodio-servidores';

export class AnimeEpisodios {
  public EpisodioId: number;
  public Titulo_episodio: string;
  public Numero_episodio: number;
  public UrlServidores: AnimeEpisodioServidores[];
  public Nombre_archivo: string;
  public Fecha_subida: Date;
  public AnimeId: number;

  public Anime: Anime;
}
