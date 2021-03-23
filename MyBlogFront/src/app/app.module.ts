import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {HttpClientModule} from '@angular/common/http';
import {HeaderComponent} from './views/header/header.component';
import {NavHeaderComponent} from './views/nav-header/nav-header.component';
import {AppLayoutComponent} from './layouts/app-layout/app-layout.component';
import {AuthModule} from './auth/auth.module';
import { BlogsComponent } from './main/blogs/blogs.component';
import { FooterComponent } from './views/footer/footer.component';
import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';
import { NotFoundComponent } from './main/not-found/not-found.component';
import { BlogComponent } from './main/blog/blog.component';
import { BlogCreatorComponent } from './admin-pages/blog-creator/blog-creator.component';
import {ReactiveFormsModule} from '@angular/forms';
import {ToastrModule} from 'ngx-toastr';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { WelcomeComponent } from './main/welcome/welcome.component';
import {AngularEditorModule} from '@kolkov/angular-editor';

@NgModule({
    declarations: [
        AppComponent,
        HeaderComponent,
        NavHeaderComponent,
        AppLayoutComponent,
        BlogsComponent,
        FooterComponent,
        AdminLayoutComponent,
        NotFoundComponent,
        BlogComponent,
        BlogCreatorComponent,
        WelcomeComponent,
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        AuthModule,
        ReactiveFormsModule,
        BrowserAnimationsModule,
        ToastrModule.forRoot(),
        AngularEditorModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule {
}
