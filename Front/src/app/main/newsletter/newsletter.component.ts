import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';

@Component({
  selector: 'app-newsletter',
  standalone: true,
  templateUrl: './newsletter.component.html',
  imports: [
    ReactiveFormsModule
  ],
  styleUrls: ['./newsletter.component.scss']
})
export class NewsletterComponent {

  public form: FormGroup = new FormGroup({
    email: new FormControl('', [Validators.required])
  });

  constructor() {
  }

  public onSubmit(): void {

  }
}
