import { Anime } from '../Animes/Entity/anime';
import { AnimeEpisodios } from '../Anime_Episodios/Entity/anime-episodios';
import { Manga } from '../Mangas/Entity/manga';
import { MangaCapitulo } from '../Manga_Capitulos/Entity/manga-capitulo';

export class Index {
  public AnimeUltimos10EpsAgregados: AnimeEpisodios[];
  public Ultimos7AnimesAgregados: Anime[];
  public MangaUltimos10CapsAgregados: MangaCapitulo[];
  public Ultimos7MangasAgregados: Manga[];
}
