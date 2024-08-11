import {Component, OnInit} from '@angular/core';
import {UserService} from '../../services/user.service';
import {UserInfo} from '../../models/userInfo';
import {Observable} from 'rxjs';
import {AsyncPipe} from "@angular/common";

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  standalone: true,
  imports: [
    AsyncPipe
  ],
  styleUrls: ['./settings.component.scss']
})
export class SettingsComponent implements OnInit {

    public user$: Observable<UserInfo> = this.userSerivce.getUserInfo();

    constructor(private userSerivce: UserService) {
    }

    ngOnInit(): void {
    }

}
