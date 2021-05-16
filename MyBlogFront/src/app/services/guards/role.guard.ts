import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree} from '@angular/router';
import {Observable} from 'rxjs';
import {RoleService} from '../role.service';
import {RolesQuery} from '../../session/queries/roles.query';
import {AuthService} from '../auth.service';
import {filter, map, switchMap} from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class RoleGuard implements CanActivate {

    constructor(private roleService: RoleService, private roleQuery: RolesQuery, private route: Router, private auth: AuthService) {

    }

    canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
        if (this.auth.IsAuthenticated()) {
            return this.roleService.getRoles().pipe(map((roles) => {
                if (roles.some(a => a.name === 'Admin')) {
                    return true;
                }
                this.route.navigate(['/']);
                return false;
            }));
        } else {
            return false;
        }
    }
}
