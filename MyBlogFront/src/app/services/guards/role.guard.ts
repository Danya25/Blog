import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree} from '@angular/router';
import {Observable} from 'rxjs';
import {RoleService} from '../role.service';
import {RolesQuery} from '../../session/queries/roles.query';
import {AuthService} from '../auth.service';
import {map} from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class RoleGuard implements CanActivate {

    constructor(private roleService: RoleService, private roleQuery: RolesQuery, private route: Router, private auth: AuthService) {

    }

    canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
        let dataRoles = route.data.roles as Array<string>;

        if (this.auth.IsAuthenticated()) {
            return this.roleService.getRoles().pipe(map((roles) => {
                if (roles.filter(role => dataRoles.indexOf(role.name) !== -1).length > 0) {
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
