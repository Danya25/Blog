import {Injectable} from '@angular/core';
import {UserInfo} from '../models/userInfo';

@Injectable({
    providedIn: 'root'
})
export class UserService {

    constructor() {
    }

    public isLoggedIn(): boolean {
        return JSON.parse(localStorage.getItem('user')) !== null;
    }

    public getUserInfo(): UserInfo {
        return JSON.parse(localStorage.getItem('user')) ?? {} as UserInfo;
    }
}
