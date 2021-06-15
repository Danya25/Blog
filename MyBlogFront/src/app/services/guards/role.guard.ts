import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree} from '@angular/router';
import {Observable} from 'rxjs';
import {RolesQuery} from '../../session/queries/roles.query';
import {AuthService} from '../auth.service';
import {map} from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class RoleGuard implements CanActivate {

    constructor(private roleQuery: RolesQuery, private route: Router, private auth: AuthService) {

    }

    canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
        let dataRoles = route.data.roles as Array<string>;

        if (this.auth.IsAuthenticated()) {
            return this.roleQuery.allRoles$.pipe(map(roles => {
                return roles.filter(role => dataRoles.indexOf(role.name) !== -1).length > 0;
            }));
        } else {
            return false;
        }
    }
}
