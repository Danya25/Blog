import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Blog} from '../models/blog';
import {Observable} from 'rxjs';
import {environment} from '../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class AdminService {

    constructor(private http: HttpClient) {
    }

    public saveBlog(blog: Blog): Observable<any> {
        return this.http.post(environment.apiUrl + 'api/Admin/SaveBlog', blog);
    }

}
