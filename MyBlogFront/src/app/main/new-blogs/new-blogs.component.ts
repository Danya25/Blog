import {Component, Input, OnInit} from '@angular/core';
import {Blog} from '../../models/blog';

@Component({
  selector: 'app-new-blogs',
  templateUrl: './new-blogs.component.html',
  styleUrls: ['./new-blogs.component.scss'],
})
export class NewBlogsComponent implements OnInit {

  @Input() latestBlogs: Blog[] = [];

  constructor() { }

  ngOnInit(): void {
  }

}