import { GeneroAsignado } from 'src/classes/Generos/ViewModels/genero-asignado';

export class AnimeCrear {
  public nombre: string;
  public descripcion: string;
  public fecha_publicacion: Date;
  public portada: File;
  public numero_episodios: number;
  public generosActivos: GeneroAsignado[];
}
