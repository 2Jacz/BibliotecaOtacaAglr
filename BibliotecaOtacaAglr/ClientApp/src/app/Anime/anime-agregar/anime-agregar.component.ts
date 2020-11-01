import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AnimeCrear } from 'src/classes/Animes/ViewModels/anime-crear';
import { GeneroAsignado } from 'src/classes/Generos/ViewModels/genero-asignado';
import { ModelErrors } from 'src/classes/Otros/modelErrors';
import { AnimeService } from 'src/Services/Anime/anime-services.service';
import { GenerosService } from 'src/Services/Generos/generos-service.service';

@Component({
  selector: 'app-anime-agregar',
  templateUrl: './anime-agregar.component.html',
  styleUrls: ['./anime-agregar.component.css']
})
export class AnimeAgregarComponent implements OnInit {
  crearAnimeForm: FormGroup = new FormGroup({
    nombre: new FormControl('', [Validators.required, Validators.minLength(6)]),
    descripcion: new FormControl('', [Validators.required, Validators.maxLength(500), Validators.minLength(15)]),
    fecha_publicacion: new FormControl(new Date()),
    portada: new FormControl(''),
    numero_episodios: new FormControl('', [Validators.required]),
    generosActivos: new FormArray([], [Validators.required])
  });
  listaGeneros: GeneroAsignado[] = [];
  listaGenerosSeleccionados: GeneroAsignado[] = [];
  modelFielsErrors: ModelErrors[] = [
    { field: 'nombre', hasError: false, descriptionError: [] },
    { field: 'descripcion', hasError: false, descriptionError: [] },
    { field: 'fecha_publicacion', hasError: false, descriptionError: [] },
    { field: 'portada', hasError: false, descriptionError: [] },
    { field: 'numero_episodios', hasError: false, descriptionError: [] },
    { field: 'generosActivos', hasError: false, descriptionError: [] }
  ];
  imageURL = '';
  cargando = false;

  constructor(private apiAnime: AnimeService, private snackbar: MatSnackBar, private apiGeneros: GenerosService) { }

  ngOnInit(): void {
    this.obtenerListaGeneros();
  }

  crearAnime(formdata) {
    this.cargando = true;
    const nuevoAnime: AnimeCrear = {
      descripcion: formdata.descripcion,
      fecha_publicacion: formdata.fecha_publicacion,
      nombre: formdata.nombre,
      numero_episodios: formdata.numero_episodios,
      portada: formdata.portada,
      generosActivos: this.listaGenerosSeleccionados
    };

    this.apiAnime.addAnime(nuevoAnime).subscribe(
      (res) => {
        this.snackbar.open(res.mensaje, '', { duration: 10000 });
        this.cargando = false;
      }, (error) => {
        this.snackbar.open(error.mensaje || 'Ocurrio un error, verifique que los datos esten correctos', '', { duration: 10000 });
        this.checkResponseErrors(error.dato);
      }
    );
  }

  visualizarPortada(event) {
    const file = (event.target as HTMLInputElement).files[0];
    this.crearAnimeForm.patchValue({ portada: file });
    const reader = new FileReader();
    reader.onload = () => { this.imageURL = reader.result as string; };
    reader.readAsDataURL(file);
  }

  selected(e) {
    this.listaGenerosSeleccionados = [];
    for (let i = 0; i < this.listaGeneros.length; i++) {
      if (this.listaGeneros[i].activo) {
        this.listaGenerosSeleccionados.push(this.listaGeneros[i]);
      }
    }


    const generos: FormArray = this.crearAnimeForm.get('generosActivos') as FormArray;
    if (e.checked) {
      generos.push(new FormControl(e.source.value));
    } else {
      let i = 0;
      generos.controls.forEach((item: FormControl) => {
        if (item.value === e.source.value) {
          generos.removeAt(i);
          return;
        }
        i++;
      });
    }
  }

  hasError = (controlName: string, errorName: string) => {
    return this.crearAnimeForm.controls[controlName].hasError(errorName);
  }

  obtenerListaGeneros() {
    this.apiGeneros.obtenerGeneros().subscribe(
      (res) => {
        if (res.estado === 200) {
          this.listaGeneros = res.dato;
        } else {
          this.snackbar.open(res.mensaje, '', { duration: 10000 });
        }
      }, (error) => {
        this.listaGeneros = [];
        this.snackbar.open(error, '', { duration: 10000 });
      }
    );
  }

  private checkResponseErrors(errors) {
    // tslint:disable-next-line: forin
    for (const campo in errors) {
      const model = this.buscarModelFieldError(campo.toLowerCase());
      if (model) {
        model.hasError = true;
        model.descriptionError = errors[campo];
      }
    }
  }

  isNotValid = (campo: string) => {
    const model = this.buscarModelFieldError(campo);
    if (model) {
      return model.hasError;
    }

    return false;
  }

  errorMessage = (campo: string) => {
    const model = this.buscarModelFieldError(campo);
    if (model) {
      return model.descriptionError;
    }

    return ['Error'];
  }

  buscarModelFieldError(campo: string) {
    for (let i = 0; i < this.modelFielsErrors.length; i++) {
      if (this.modelFielsErrors[i].field === campo) {
        return this.modelFielsErrors[i];
      }
    }

    return null;
  }
}
