import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree} from '@angular/router';
import {Observable} from 'rxjs';
import {AuthService} from '../auth.service';

@Injectable({
    providedIn: 'root'
})
export class UnauthGuard implements CanActivate {
    constructor(private route: Router, private auth: AuthService) {
    }

    canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
        if (!this.auth.IsAuthenticated()) {
            return true;
        } else {
            this.route.navigate(['']);
            return false;
        }
    }
}
