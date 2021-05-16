import {Component, OnInit} from '@angular/core';
import {UserService} from '../../services/user.service';
import {UserInfo} from '../../models/userInfo';
import {Observable} from 'rxjs';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

    public userInfo$: Observable<UserInfo> = this.userService.getUserInfo();


    constructor(public userService: UserService) {
    }


    ngOnInit(): void {
    }

    public exitFromAccount(): void {
        localStorage.clear();
    }

}
