import {RoleState, RoleStore} from '../stores/roles.store';
import {Query} from '@datorama/akita';
import {Injectable} from '@angular/core';

@Injectable({providedIn: 'root'})
export class RolesQuery extends Query<RoleState> {
    allRoles$ = this.select(state => state.roles);

    constructor(store: RoleStore) {
        super(store);
    }
}
