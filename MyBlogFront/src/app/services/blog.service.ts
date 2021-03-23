import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Blog} from '../models/blog';
import {Answer} from '../models/answer';

@Injectable({
    providedIn: 'root'
})
export class BlogService {

    constructor(private http: HttpClient) {
    }

    public getBlogById(id: string): Observable<Answer<Blog>> {
        return this.http.get<Answer<Blog>>(`api/Blog/GetBlogById/${id}`);
    }

    public getBlogs(): Observable<Answer<Array<Blog>>> {
        return this.http.get<Answer<Array<Blog>>>('api/Blog/GetBlogs');
    }
}
