import {Store, StoreConfig} from '@datorama/akita';
import {Injectable} from '@angular/core';

export interface Roles {
    name: string;
}

export interface RoleState {
    roles: Roles[];
}

export function createInitialState(): RoleState {
    return {roles: []};
}

@StoreConfig({name: 'roles'})
@Injectable({ providedIn: 'root' })
export class RoleStore extends Store<RoleState> {

    constructor() {
        super(createInitialState());
    }

    public loadRoles(roles: Roles[]): void {
        this.update({roles});
    }
}
