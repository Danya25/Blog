import {Component, OnInit} from '@angular/core';
import {filter, switchMap} from 'rxjs/operators';
import {RolesQuery} from './session/queries/roles.query';
import {RoleService} from './services/role.service';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
    title = 'MyBlogFront';

    constructor(private roleQuery: RolesQuery, private roleService: RoleService) {
    }

    ngOnInit(): void {
        /// TODO
/*        this.roleQuery.allRoles$.pipe(
            filter(t => t.length === 0),
            switchMap(t => this.roleService.getRoles())
        ).subscribe(result => {
        });*/
    }

}
