import {Component, OnInit} from '@angular/core';
import {BlogService} from '../../services/blog.service';
import {Blog} from '../../models/blog';
import {ToastrService} from 'ngx-toastr';

@Component({
    selector: 'app-blogs',
    templateUrl: './blogs.component.html',
    styleUrls: ['./blogs.component.scss']
})
export class BlogsComponent implements OnInit {
    public blogs: Array<Blog> = [];
    public isLoading = true;

    constructor(private blogService: BlogService, private toastrSerivce: ToastrService) {
    }

    ngOnInit(): void {
        this.blogService.getBlogs().subscribe(t => {
            if (t.success) {
                this.blogs = t.value;
                this.isLoading = false;
            } else {
                this.toastrSerivce.error('Some problem with server!');
            }
        }, error => {
            console.log(error);
            this.toastrSerivce.error('Some problem with server!');
        });
    }

    public errorImageHandler(event: any): void {
        console.log(typeof (event));
        event.target.src = `../../assets/error-images/error-image.jpeg`;
    }

}
