import {Injectable} from '@angular/core';
import {Answer} from '../models/answer';
import {Roles, RoleStore} from '../session/stores/roles.store';
import {HttpClient} from '@angular/common/http';
import {RolesQuery} from '../session/queries/roles.query';
import {map, tap} from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class RoleService {

    constructor(private roleStore: RoleStore, private roleQuery: RolesQuery, private http: HttpClient) {
    }

    public loadRoles(): void {
        this.http.get<Answer<Roles[]>>('api/User/GetRoles').pipe(
            map(result => result.value)).subscribe(roles => this.roleStore.updateRoles(roles));
    }
}

