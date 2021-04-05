import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {AuthComponent} from './auth.component';
import {LoginComponent} from './login/login.component';
import {RegistrationComponent} from './registration/registration.component';
import {AuthRoutingModule} from './auth-routing.module';
import {ReactiveFormsModule} from '@angular/forms';


@NgModule({
    declarations: [AuthComponent, LoginComponent, RegistrationComponent],
    imports: [CommonModule, AuthRoutingModule, ReactiveFormsModule]
})
export class AuthModule {
}
