import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {AuthService} from '../../services/auth.service';
import {Router} from '@angular/router';
import {BlogService} from '../../services/blog.service';
import {BlogLike} from '../../models/blogLike';
import {debounce} from 'rxjs/operators';
import {interval} from 'rxjs';

@Component({
    selector: 'app-like-button',
    templateUrl: './like-button.component.html',
    styleUrls: ['./like-button.component.scss']
})
export class LikeButtonComponent implements OnInit {

    @Input() likeStatus: boolean = false;
    @Input() countLikes: number = 0;
    @Output() onLikeChange = new EventEmitter<number>();
    @Input() blogId: number = 0;

    constructor(private authService: AuthService, private blogService: BlogService, private router: Router) {
    }

    ngOnInit(): void {
    }

    public onLike(): void {
        if (!this.authService.IsAuthenticated()) {
            this.router.navigate(['/auth']);
            return;
        }
        if (this.likeStatus) {
            this.countLikes -= 1;
        } else {
            this.countLikes += 1;
        }
        this.onLikeChange.emit(this.countLikes);

        this.likeStatus = !this.likeStatus;
        const blogLike: BlogLike = {
            likeStatus: this.likeStatus,
            blogId: this.blogId
        };
        this.blogService.likeBlog(blogLike).pipe(
            debounce(() => interval(1000)),
        ).subscribe(t => console.log(t));

    }
}
