import {Component, OnInit} from '@angular/core';
import {UserService} from '../../services/user.service';
import {UserInfo} from '../../models/userInfo';

@Component({
    selector: 'app-settings',
    templateUrl: './settings.component.html',
    styleUrls: ['./settings.component.scss']
})
export class SettingsComponent implements OnInit {

    public user: UserInfo = this.userSerivce.getUserInfo();

    constructor(private userSerivce: UserService) {
    }

    ngOnInit(): void {
    }

}
