import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {User} from '../../models/user';
import {AuthService} from '../../services/auth.service';
import {ToastrService} from 'ngx-toastr';
import {Router} from '@angular/router';
import {UserInfo} from '../../models/userInfo';
import {RoleService} from '../../services/role.service';

@Component({
  selector: 'app-login',
  standalone: true,
  templateUrl: './login.component.html',
  imports: [
    ReactiveFormsModule
  ],
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public myForm: FormGroup = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required])
  });

  constructor(private authService: AuthService, private toastrService: ToastrService, private route: Router, private roleService: RoleService) {
  }

  ngOnInit(): void {
    this.setAnimationInputs();

  }

  public onSubmit(): void {

    const user: User = {
      email: this.myForm.get('email')?.value,
      password: this.myForm.get('password')?.value
    };

    this.authService.login(user).subscribe(t => {
      if (!t.success) {
        this.toastrService.error(t.exceptionMessage);
        return;
      }
      this.setUserInfo(t.value);
      this.roleService.loadRoles();

      this.toastrService.success('Log in was successful');
      this.route.navigate(['']);
    });
  }

  private setUserInfo(userInfo: UserInfo): void {
    localStorage.setItem(
      'user', JSON.stringify({email: userInfo.email, id: userInfo.id, username: userInfo.username}),
    );
    localStorage.setItem('token', userInfo.token);
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
