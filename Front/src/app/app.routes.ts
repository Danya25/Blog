import {Routes, UrlSegment} from '@angular/router';
import {UnauthGuard} from "./services/guards/unauth.guard";
import {AdminLayoutComponent} from "./layouts/admin-layout/admin-layout.component";
import {hasRole, RoleGuard} from "./services/guards/role.guard";
import {AuthGuard, hasAuth} from "./services/guards/auth.guard";
import {Roles} from "./models/roles";
import {SupportComponent} from "./main/support/support.component";
import {AppLayoutComponent} from "./layouts/app-layout/app-layout.component";
import {BlogsComponent} from "./main/blogs/blogs.component";
import {SettingsComponent} from "./main/settings/settings.component";
import {BlogComponent} from "./main/blog/blog.component";
import {SpinLoaderComponent} from "./views/spin-loader/spin-loader.component";
import {NotFoundComponent} from "./main/not-found/not-found.component";
import {LoginComponent} from "./auth/login/login.component";
import {RegistrationComponent} from "./auth/registration/registration.component";

export const routes: Routes = [
  {
    path: 'auth', canActivate: [UnauthGuard], children: [
      {path: 'login', component: LoginComponent},
      {path: 'registration', component: RegistrationComponent},
      {path: '**', redirectTo: '/auth/login'}]
  },
  {
    path: 'admin', component: AdminLayoutComponent,
    canActivate: [hasAuth, hasRole],
    data: {roles: [Roles.admin]},
  },
  {
    path: 'support', component: SupportComponent, canActivate: [AuthGuard]
  },
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
