import { Manga } from '../Mangas/Entity/manga';
import { MangaCapitulo } from '../Manga_Capitulos/Entity/manga-capitulo';

export class HomeAnime {
  public animeUltimos12EpsAgregados: HomeAnimeEpisodiosIndex[] = [];
  public ultimos9AnimesAgregados: HomeAnimeIndex[] = [];
}

export class HomeAnimeIndex {
  public animeId: number;

  public nombre: string;

  public portada: string;
}

export class HomeAnimeEpisodiosIndex {
  public episodioId: number;

  public numero_episodio: number;

  public nombre_anime: string;

  public anime_portada: string;
}

export class HomeManga {
  public mangaUltimos12CapsAgregados: MangaCapitulo[] = [];
  public ultimos9MangasAgregados: Manga[] = [];
}
