import { HttpEvent, HttpHandler, HttpRequest, HttpErrorResponse, HttpInterceptor } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

export class ErrorHandlerService implements HttpInterceptor {
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // check to see if there's internet
    if (!window.navigator.onLine) {
      // if there is no internet, throw a HttpErrorResponse error
      // since an error is thrown, the function will terminate here
      return throwError('No hay conexion con el servidor.');
    } else {
      // else return the normal request
      return next.handle(request).pipe(
        retry(1),
        catchError((error: HttpErrorResponse) => {
          if (error.error instanceof ErrorEvent) {
            // client-side error
            return throwError(error.error.message);
          } else {
            // server-side error
            return throwError(error.error.mensaje);
          }
        })
      );
    }
  }
}
