import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {BlogService} from '../../services/blog.service';
import {AdminService} from '../../services/admin.service';
import {Blog} from '../../models/blog';
import {AngularEditorConfig} from '@kolkov/angular-editor';

@Component({
    selector: 'app-blog-creator',
    templateUrl: './blog-creator.component.html',
    styleUrls: ['./blog-creator.component.scss']
})
export class BlogCreatorComponent implements OnInit {

    public myForm: FormGroup;
    public uploadedFiles: File = null;

    public editorConfig: AngularEditorConfig = {
        editable: true,
        spellcheck: true,
        height: 'auto',
        minHeight: '0',
        maxHeight: 'auto',
        width: 'auto',
        minWidth: '0',
        translate: 'yes',
        enableToolbar: true,
        showToolbar: true,
        placeholder: 'Enter text here...',
        defaultParagraphSeparator: '',
        defaultFontName: '',
        defaultFontSize: '',
        fonts: [
            {class: 'arial', name: 'Arial'},
            {class: 'times-new-roman', name: 'Times New Roman'},
            {class: 'calibri', name: 'Calibri'},
            {class: 'comic-sans-ms', name: 'Comic Sans MS'}
        ],
        customClasses: [
            {
                name: 'quote',
                class: 'quote',
            },
            {
                name: 'redText',
                class: 'redText'
            },
            {
                name: 'titleText',
                class: 'titleText',
                tag: 'h1',
            },
        ],
        uploadUrl: 'api/Photo',
        uploadWithCredentials: false,
        sanitize: true,
        toolbarPosition: 'top',
        toolbarHiddenButtons: [
            ['bold', 'italic'],
            ['fontSize']
        ]
    };

    constructor(private adminService: AdminService) {
    }

    ngOnInit(): void {
        this.myForm = new FormGroup({
            title: new FormControl('', [Validators.required]),
            description: new FormControl('', [Validators.required]),
            photoUrl: new FormControl('')
        });
    }

    public onSubmit(): void {
        const blog: Blog = {
            id: 0,
            title: this.myForm.get('title').value,
            description: this.myForm.get('description').value,
            photoUrl: this.myForm.get('photoUrl').value
        };
        this.adminService.saveBlog(blog).subscribe(t => {
            console.log(t);
        });
    }

}
