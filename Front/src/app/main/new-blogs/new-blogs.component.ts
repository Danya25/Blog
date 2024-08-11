import {Component, Input, OnInit} from '@angular/core';
import {Blog} from '../../models/blog';
import {RouterLink} from "@angular/router";
import {NgForOf} from "@angular/common";

@Component({
  selector: 'app-new-blogs',
  templateUrl: './new-blogs.component.html',
  standalone: true,
  styleUrls: ['./new-blogs.component.scss'],
  imports: [
    RouterLink,
    NgForOf
  ]
})
export class NewBlogsComponent {

  @Input() public newestBlogs: Blog[] = [];

  constructor() {
  }


  public errorImageHandler(event: any): void {
    event.target.src = `../../assets/error-images/error-image.jpeg`;
  }
}
