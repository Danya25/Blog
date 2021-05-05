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
    public newestBlogs: Array<Blog> = [];
    private pageSize = 10;
    public isLoading = true;
    public isFullLoaded = false;

    constructor(private blogService: BlogService, private toastrSerivce: ToastrService) {
    }

    ngOnInit(): void {
        this.blogService.getBlogsWithPagination(this.blogs.length).subscribe(t => {
            if (t.success) {
                this.blogs = [...this.blogs, ...t.value];
                this.isLoading = false;
            } else {
                this.toastrSerivce.error('Some problem with server!');
                this.isLoading = false;
            }
        }, error => {
            console.log(error);
            this.toastrSerivce.error('Some problem with server!');
            this.isLoading = false;
        });
        this.blogService.getFiveNewestBlogs().subscribe(t => {
            if (t.success) {
                this.newestBlogs = t.value;
            } else {
                this.toastrSerivce.error('Some problem with server!');
            }
        });
    }

    public errorImageHandler(event: any): void {
        console.log(typeof (event));
        event.target.src = `../../assets/error-images/error-image.jpeg`;
    }

    public loadMoreBlogs(): void {
        this.blogService.getBlogsWithPagination(this.blogs.length, this.pageSize).subscribe(t => {
            if (t.success) {
                if (t.value.length < this.pageSize) {
                    this.isFullLoaded = true;
                }
                this.blogs = [...this.blogs, ...t.value];
            } else {
                this.toastrSerivce.error('Some problem with server!');
            }
        });
    }
}
