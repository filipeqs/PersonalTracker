import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';
import { NavigationExtras, Router } from '@angular/router';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor(private router: Router) {}

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(
            catchError((error) => {
                if (error) {
                    if (error.status == 400) {
                        if (error.error.errors) throw error.error;
                        else console.error(error.error.message, error.error.statusCode);
                    }

                    if (error.status === 401)
                        console.error(error.error.message, error.error.statusCode);

                    if (error.status === 404) this.router.navigateByUrl('/not-found');

                    if (error.status === 500) {
                        const navigationExtras: NavigationExtras = {
                            state: { error: error.error },
                        };

                        this.router.navigateByUrl('server-error', navigationExtras);
                    }
                }
                return throwError(() => error);
            }),
        );
    }
}
