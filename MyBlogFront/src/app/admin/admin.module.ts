import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {BlogCreatorComponent} from './blog-creator/blog-creator.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {ReactiveFormsModule} from '@angular/forms';
import {AngularEditorModule} from '@kolkov/angular-editor';
import {HttpClientModule} from '@angular/common/http';


@NgModule({
    declarations: [BlogCreatorComponent],
    imports: [
        CommonModule, BrowserAnimationsModule, ReactiveFormsModule, AngularEditorModule, HttpClientModule
    ]
})
export class AdminModule {
}
