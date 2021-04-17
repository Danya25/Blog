import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {Blog} from '../../models/blog';
import {BlogService} from '../../services/blog.service';
import {ToastrService} from 'ngx-toastr';

@Component({
    selector: 'app-blog',
    templateUrl: './blog.component.html',
    styleUrls: ['./blog.component.scss']
})
export class BlogComponent implements OnInit {

    private blogId: string;
    public blog: Blog = {} as Blog;
    public isLoading = true;

    constructor(private route: Router, private blogService: BlogService, private toastrSerivce: ToastrService) {
    }

    ngOnInit(): void {
        this.blogId = this.route.url.split('/')[2];
        this.blogService.getBlogById(this.blogId).subscribe(t => {
            if (t.success) {
                this.blog = t.value;
                console.log(this.blog);
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
