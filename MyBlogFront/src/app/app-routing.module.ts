import {NgModule} from '@angular/core';
import {RouterModule, Routes, UrlSegment} from '@angular/router';
import {AppLayoutComponent} from './layouts/app-layout/app-layout.component';
import {AdminLayoutComponent} from './layouts/admin-layout/admin-layout.component';
import {NotFoundComponent} from './main/not-found/not-found.component';
import {BlogsComponent} from './main/blogs/blogs.component';
import {BlogComponent} from './main/blog/blog.component';
import {UnauthGuard} from './services/guards/unauth.guard';
import {SpinLoaderComponent} from './views/spin-loader/spin-loader.component';
import {SettingsComponent} from './main/settings/settings.component';

const routes: Routes = [
    {path: 'auth', canActivate: [UnauthGuard], loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule)},
    {path: 'admin', component: AdminLayoutComponent},
    {
        path: '', component: AppLayoutComponent, children: [
            {path: '', component: BlogsComponent},
            {path: 'settings', component: SettingsComponent},
            {component: BlogComponent, matcher: onlyNumbers}
        ]
    },
    {path: 'test', component: SpinLoaderComponent},
    {path: '**', component: NotFoundComponent}
];

export function onlyNumbers(url: UrlSegment[]) {
    const regex = new RegExp('^[0-9]+$');
    if (url.length !== 2 || url[0].path !== 'blog') {
        return null;
    }
    return regex.test(url[1].path) ? {consumed: url} : null;
}

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {
}
