import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {User} from '../models/user';
import {Observable} from 'rxjs';
import {Answer} from '../models/answer';
import {UserInfo} from '../models/userInfo';
import {JwtHelperService} from '@auth0/angular-jwt';
import {tap} from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    constructor(private http: HttpClient, private jwtHelper: JwtHelperService) {
    }

    public login(user: User): Observable<Answer<UserInfo>> {
        return this.http.post<Answer<UserInfo>>('api/Auth/Login', user);
    }

    public registration(user: User): Observable<Answer<any>> {
        return this.http.post<Answer<any>>('api/Auth/Registration', user);
    }


    public IsAuthenticated(): boolean {
        const token = localStorage.getItem('token');
        return !this.jwtHelper.isTokenExpired(token);
    }
}
