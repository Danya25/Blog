import { Component, OnInit } from '@angular/core';
import {RouterLink, RouterLinkActive} from "@angular/router";

@Component({
  selector: 'app-nav-header',
  templateUrl: './nav-header.component.html',
  standalone: true,
  imports: [
    RouterLinkActive,
    RouterLink
  ],
  styleUrls: ['./nav-header.component.scss']
})
export class NavHeaderComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
