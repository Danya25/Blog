import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Blog} from '../models/blog';
import {Answer} from '../models/answer';
import {BlogLike} from '../models/blogLike';
import {environment} from '../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class BlogService {

    constructor(private http: HttpClient) {
    }

    public getBlogById(id: string): Observable<Answer<Blog>> {
        return this.http.get<Answer<Blog>>(environment.apiUrl + `api/Blog/GetBlogById/${id}`);
    }

    public getBlogs(): Observable<Answer<Array<Blog>>> {
        return this.http.get<Answer<Array<Blog>>>(environment.apiUrl + 'api/Blog/GetBlogs');
    }

    public getFiveNewestBlogs(): Observable<Answer<Array<Blog>>> {
        return this.http.get<Answer<Array<Blog>>>(environment.apiUrl + 'api/Blog/GetFiveNewestBlogs');
    }

    public getBlogsWithPagination(currentCount: number, pageSize: number = 10): Observable<Answer<Array<Blog>>> {
        return this.http.get<Answer<Array<Blog>>>(environment.apiUrl + `api/Blog/GetBlogsPagination?CurrentCount=${currentCount}&PageSize=${pageSize}`);
    }

    public likeBlog(blogLike: BlogLike): Observable<Answer<boolean>> {
        return this.http.post<Answer<boolean>>(environment.apiUrl + 'api/Blog/LikeBlog', blogLike);
    }
}
