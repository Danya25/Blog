import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {User} from '../../models/user';
import {AuthService} from '../../services/auth.service';
import {ToastrService} from 'ngx-toastr';
import {Router} from '@angular/router';
import {UserInfo} from '../../models/userInfo';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

    public myForm: FormGroup;

    constructor(private authService: AuthService, private toastrService: ToastrService, private route: Router) {
    }

    ngOnInit(): void {
        this.myForm = new FormGroup({
            email: new FormControl('', [Validators.required, Validators.email]),
            password: new FormControl('', [Validators.required])
        });
    }

    public onSubmit(): void {
        const user: User = {
            email: this.myForm.get('email').value,
            password: this.myForm.get('password').value
        };

        this.authService.login(user).subscribe(t => {
            if (!t.success) {
                this.toastrService.error(t.exceptionMessage);
                return;
            }
            this.setUserInfoIntoLocalStorage(t.value);

            this.toastrService.success('Log in was successful');
            this.route.navigate(['']);
        });
    }

    private setUserInfoIntoLocalStorage(user: UserInfo): void {
        localStorage.setItem(
            'user', JSON.stringify({email: user.email, token: user.token, id: user.id, username: user.username}),
        );
    }

}
