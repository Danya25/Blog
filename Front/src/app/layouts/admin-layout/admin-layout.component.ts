import {Component, OnInit} from '@angular/core';
import {RoleService} from '../../services/role.service';
import {RolesQuery} from '../../session/queries/roles.query';
import {filter, switchMap} from 'rxjs/operators';
import {BlogCreatorComponent} from "../../admin/blog-creator/blog-creator.component";
import {UserListComponent} from "../../admin/user-list/user-list.component";

@Component({
  selector: 'app-admin-layout',
  templateUrl: './admin-layout.component.html',
  standalone: true,
  imports: [
    BlogCreatorComponent,
    UserListComponent
  ],
  styleUrls: ['./admin-layout.component.scss']
})
export class AdminLayoutComponent implements OnInit {

  constructor(private roleService: RoleService, private roleQuery: RolesQuery) {
  }

  ngOnInit(): void {

  }

}
