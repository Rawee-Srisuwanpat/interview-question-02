import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, throwError } from 'rxjs';


export const authInterceptor: HttpInterceptorFn = (req, next) => {

  const router = inject(Router);
  const token = localStorage.getItem('token');

  if (
    req.url.includes('/login') ||
    req.url.includes('/register')
  ) {
    return next(req);
  }

  let request = req;

  if (token) {

    request = req.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`
      }
    });

  }
  
  return next(request).pipe(

    catchError(error => {

      if (error.status === 401) {

        localStorage.clear();

        router.navigate(['/']);

      }

      return throwError(() => error);

    })

  );


  //return next(req);
};