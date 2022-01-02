import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {BlogCreatorComponent} from './blog-creator/blog-creator.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {ReactiveFormsModule} from '@angular/forms';
import {AngularEditorModule} from '@kolkov/angular-editor';
import {HttpClientModule} from '@angular/common/http';
import {AdminLayoutComponent} from '../layouts/admin-layout/admin-layout.component';
import { UserListComponent } from './user-list/user-list.component';


@NgModule({
    declarations: [BlogCreatorComponent, AdminLayoutComponent, UserListComponent],
    exports: [],
    imports: [CommonModule, BrowserAnimationsModule, ReactiveFormsModule, AngularEditorModule, HttpClientModule]
})
export class AdminModule {
}
