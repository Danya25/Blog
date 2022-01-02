import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';

@Component({
    selector: 'app-newsletter',
    templateUrl: './newsletter.component.html',
    styleUrls: ['./newsletter.component.scss']
})
export class NewsletterComponent implements OnInit {

    public form: FormGroup;
    constructor() {
    }

    ngOnInit(): void {
        this.form = new FormGroup({
            email: new FormControl('', [Validators.required])
        });
    }

    public onSubmit(): void {

    }
}
