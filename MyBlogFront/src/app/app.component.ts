import {Component, OnInit} from '@angular/core';
import {filter, switchMap} from 'rxjs/operators';
import {UserService} from './services/user.service';
import {RolesQuery} from './session/queries/roles.query';
import {RoleService} from './services/role.service';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent{
    title = 'MyBlogFront';
}
