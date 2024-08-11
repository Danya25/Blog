import {Injectable} from '@angular/core';
import {UserInfo} from '../models/userInfo';
import {Observable} from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class UserService {

    public isLoggedIn(): boolean {
        return JSON.parse(localStorage.getItem('user') as string) !== null;
    }

    public getUserInfo(): Observable<UserInfo> {
        return new Observable<UserInfo>(t => t.next(JSON.parse(localStorage.getItem('user') as string) ?? {} as UserInfo));
    }

}
