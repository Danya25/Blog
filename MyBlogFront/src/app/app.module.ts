import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {HeaderComponent} from './views/header/header.component';
import {NavHeaderComponent} from './views/nav-header/nav-header.component';
import {AppLayoutComponent} from './layouts/app-layout/app-layout.component';
import {AuthModule} from './auth/auth.module';
import {BlogsComponent} from './main/blogs/blogs.component';
import {FooterComponent} from './views/footer/footer.component';
import {AdminLayoutComponent} from './layouts/admin-layout/admin-layout.component';
import {NotFoundComponent} from './main/not-found/not-found.component';
import {BlogComponent} from './main/blog/blog.component';
import {BlogCreatorComponent} from './admin/blog-creator/blog-creator.component';
import {ReactiveFormsModule} from '@angular/forms';
import {ToastrModule} from 'ngx-toastr';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {WelcomeComponent} from './main/welcome/welcome.component';
import {AngularEditorModule} from '@kolkov/angular-editor';
import {NewBlogsComponent} from './main/new-blogs/new-blogs.component';
import {BsDropdownModule} from 'ngx-bootstrap/dropdown';
import {SpinLoaderComponent} from './views/spin-loader/spin-loader.component';
import {SettingsComponent} from './main/settings/settings.component';
import {ErrorInterceptor} from './services/interceptors/error.interceptor';
import {TokenInterceptor} from './services/interceptors/token.interceptor';
import {JwtModule} from '@auth0/angular-jwt';
import {AdminModule} from './admin/admin.module';

export function tokenGetter(): string | null {
    return localStorage.getItem('token');
}

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
        WelcomeComponent,
        NewBlogsComponent,
        SpinLoaderComponent,
        SettingsComponent,
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        AuthModule,
        ReactiveFormsModule,
        BrowserAnimationsModule,
        ToastrModule.forRoot(),
        AdminModule,
        BsDropdownModule.forRoot(),
        JwtModule.forRoot({
            config: {
                tokenGetter
            }
        })
    ],
    providers: [
        {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
        {
            provide: HTTP_INTERCEPTORS,
            useClass: TokenInterceptor,
            multi: true
        }],
    bootstrap: [AppComponent]
})
export class AppModule {
}
