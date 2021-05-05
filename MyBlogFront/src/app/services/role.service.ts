import {Injectable} from '@angular/core';
import {Answer} from '../models/answer';
import {Roles, RoleStore} from '../session/stores/roles.store';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {RolesQuery} from '../session/queries/roles.query';
import {distinctUntilChanged, filter, map} from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class RoleService {

    constructor(private roleStore: RoleStore, private roleQuery: RolesQuery, private http: HttpClient) {
        this.loadRoles();
    }

    private loadRoles(): void {
        this.http.get<Answer<Roles[]>>('api/User/GetRoles').subscribe(response => {
            this.roleStore.loadRoles(response.value);
        });
    }

    public getRoles(): Observable<Roles[]> {
        return this.roleQuery.allRoles$.pipe(filter(t => t.length !== 0), distinctUntilChanged());
    }
}
