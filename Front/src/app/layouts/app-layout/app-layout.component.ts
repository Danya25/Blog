import { Component, OnInit } from '@angular/core';
import {HeaderComponent} from "../../views/header/header.component";
import {NavHeaderComponent} from "../../views/nav-header/nav-header.component";
import {RouterOutlet} from "@angular/router";
import {FooterComponent} from "../../views/footer/footer.component";

@Component({
  selector: 'app-layout',
  templateUrl: './app-layout.component.html',
  standalone: true,
  imports: [
    HeaderComponent,
    NavHeaderComponent,
    RouterOutlet,
    FooterComponent
  ],
  styleUrls: ['./app-layout.component.scss']
})
export class AppLayoutComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
