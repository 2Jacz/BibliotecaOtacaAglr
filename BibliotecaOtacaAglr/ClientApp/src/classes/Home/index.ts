import { Anime } from '../Animes/Entity/anime';
import { AnimeEpisodios } from '../Anime_Episodios/Entity/anime-episodios';
import { Manga } from '../Mangas/Entity/manga';
import { MangaCapitulo } from '../Manga_Capitulos/Entity/manga-capitulo';

export class Index {
  public animeUltimos10EpsAgregados: AnimeEpisodios[];
  public ultimos7AnimesAgregados: Anime[];
  public mangaUltimos10CapsAgregados: MangaCapitulo[];
  public ultimos7MangasAgregados: Manga[];
}
