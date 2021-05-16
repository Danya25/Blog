import {Component, OnInit} from '@angular/core';
import {RoleService} from '../../services/role.service';
import {RolesQuery} from '../../session/queries/roles.query';
import {filter, switchMap} from 'rxjs/operators';

@Component({
    selector: 'app-admin-layout',
    templateUrl: './admin-layout.component.html',
    styleUrls: ['./admin-layout.component.scss']
})
export class AdminLayoutComponent implements OnInit {

    constructor(private roleService: RoleService, private roleQuery: RolesQuery) {
    }

    ngOnInit(): void {

    }

}
