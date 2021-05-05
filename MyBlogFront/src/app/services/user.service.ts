import {Injectable} from '@angular/core';
import {UserInfo} from '../models/userInfo';
import {Roles, RoleStore} from '../session/stores/roles.store';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Answer} from '../models/answer';
import {tap} from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class UserService {

    public isLoggedIn(): boolean {
        return JSON.parse(localStorage.getItem('user')) !== null;
    }

    public getUserInfo(): UserInfo {
        return JSON.parse(localStorage.getItem('user')) ?? {} as UserInfo;
    }

}
