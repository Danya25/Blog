import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {User} from '../models/user';
import {Observable} from 'rxjs';
import {Answer} from '../models/answer';
import {UserInfo} from '../models/userInfo';

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    constructor(private http: HttpClient) {
    }

    public login(user: User): Observable<Answer<UserInfo>> {
        return this.http.post<Answer<UserInfo>>('api/Auth/Login', user);
    }

    public registration(user: User): Observable<Answer<any>> {
        return this.http.post<Answer<any>>('apu/Auth/Registration', user);
    }
}
