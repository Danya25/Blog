import {NgModule} from '@angular/core';
import {Routes, RouterModule, UrlSegment} from '@angular/router';
import {AppLayoutComponent} from './layouts/app-layout/app-layout.component';
import {AdminLayoutComponent} from './layouts/admin-layout/admin-layout.component';
import {NotFoundComponent} from './main/not-found/not-found.component';
import {BlogsComponent} from './main/blogs/blogs.component';
import {BlogComponent} from './main/blog/blog.component';

const routes: Routes = [
    {path: 'auth', loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule)},
    {path: 'admin', component: AdminLayoutComponent},
    {
        path: '', component: AppLayoutComponent, children: [
            {path: '', component: BlogsComponent},
            {component: BlogComponent, matcher: onlyNumbers}
        ]
    },
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
