import {Component, Input, OnInit} from '@angular/core';
import {Blog} from '../../models/blog';

@Component({
    selector: 'app-new-blogs',
    templateUrl: './new-blogs.component.html',
    styleUrls: ['./new-blogs.component.scss'],
})
export class NewBlogsComponent implements OnInit {

    @Input() public newestBlogs: Blog[] = [];

    constructor() {
    }

    ngOnInit(): void {
    }

    public errorImageHandler(event: any): void {
        console.log(typeof (event));
        event.target.src = `../../assets/error-images/preview-error.jpg`;
    }
}
