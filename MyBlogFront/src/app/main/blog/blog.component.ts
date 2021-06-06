import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {Blog} from '../../models/blog';
import {BlogService} from '../../services/blog.service';
import {ToastrService} from 'ngx-toastr';
import {DomSanitizer, SafeHtml} from '@angular/platform-browser';

@Component({
    selector: 'app-blog',
    templateUrl: './blog.component.html',
    styleUrls: ['./blog.component.scss']
})
export class BlogComponent implements OnInit {

    public blog: Blog = {} as Blog;
    public isLoading = true;

    constructor(private router: Router,
                private blogService: BlogService,
                private toastrSerivce: ToastrService,
                private domSanitizer: DomSanitizer) {
    }

    ngOnInit(): void {
        const blogId = this.router.url.split('/')[2];
        this.blogService.getBlogById(blogId).subscribe(t => {
            if (t.success) {
                if (t.value === null) {
                    this.router.navigate(['/']);
                    return;
                }
                const sanitizedDescription: SafeHtml = this.domSanitizer.bypassSecurityTrustHtml(t.value.description);
                this.blog = t.value;
                this.blog.description = sanitizedDescription as string;
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
        event.target.src = `../../assets/error-images/error-image.jpeg`;
    }

    public onLikeChange(event: number): void {
        this.blog.countLikes = event;
    }

}
