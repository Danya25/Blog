import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {AuthService} from '../../services/auth.service';
import {ToastrService} from 'ngx-toastr';
import {Router} from '@angular/router';
import {User} from '../../models/user';

@Component({
    selector: 'app-registration',
    templateUrl: './registration.component.html',
    styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

    public myForm: FormGroup;

    constructor(private authService: AuthService, private toastrService: ToastrService, private route: Router) {
    }

    ngOnInit(): void {
        this.setAnimationInputs();

        this.myForm = new FormGroup({
            email: new FormControl('', [Validators.required, Validators.email]),
            displayName: new FormControl('', [Validators.required]),
            password: new FormControl('', [Validators.required])
        });
    }

    public onSubmit(): void {
        const user: User = {
            email: this.myForm.get('email').value,
            displayName: this.myForm.get('displayName').value,
            password: this.myForm.get('password').value
        };

        this.authService.registration(user).subscribe(t => {
            if (!t.success) {
                this.toastrService.error(t.exceptionMessage);
                return;
            }
            this.toastrService.success('Registration was successful');
            this.route.navigate(['/auth/login']);
        });
    }

    private setAnimationInputs(): void {
        const elems = document.getElementsByClassName('input100');
        for (let i = 0; i < elems.length; i++) {
            elems[i].addEventListener('blur', (event) => {
                const elem = elems[i];
                // @ts-ignore
                if (elem.value.trim() != '') {
                    elems[i].classList.add('has-val');
                } else {
                    elems[i].classList.remove('has-val');
                }
            });
        }
    }

}
