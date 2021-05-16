import {Injectable} from '@angular/core';
import {Answer} from '../models/answer';
import {Roles, RoleStore} from '../session/stores/roles.store';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {RolesQuery} from '../session/queries/roles.query';
import {distinctUntilChanged, filter, map, tap} from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class RoleService {

    constructor(private roleStore: RoleStore, private roleQuery: RolesQuery, private http: HttpClient) {
    }

    public getRoles(): Observable<Roles[]> {
        return this.http.get<Answer<Roles[]>>('api/User/GetRoles').pipe(
            map(result => result.value),
            tap(roles => this.roleStore.loadRoles(roles))
        );
    }
}
