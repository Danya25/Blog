import {Injectable} from '@angular/core';
import {HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from '@angular/common/http';
import {Observable} from 'rxjs';
import {JwtHelperService} from '@auth0/angular-jwt';
import {Router} from '@angular/router';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

    constructor(private jwtService: JwtHelperService, private route: Router) {
    }

    intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
        const token = localStorage.getItem('token');

        if (this.jwtService.isTokenExpired(token)) {
            localStorage.clear();
            this.route.navigate(['/']);
        }
        
        return next.handle(request);
    }
}
