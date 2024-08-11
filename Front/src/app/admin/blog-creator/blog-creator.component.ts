import {Component} from '@angular/core';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {AdminService} from '../../services/admin.service';
import {Blog} from '../../models/blog';
import {AngularEditorConfig, AngularEditorModule} from '@kolkov/angular-editor';

@Component({
  selector: 'app-blog-creator',
  standalone: true,
  templateUrl: './blog-creator.component.html',
  imports: [
    ReactiveFormsModule,
    AngularEditorModule
  ],
  styleUrls: ['./blog-creator.component.scss']
})
export class BlogCreatorComponent {

  public myForm: FormGroup = new FormGroup({
    title: new FormControl('', [Validators.required]),
    description: new FormControl('', [Validators.required]),
    shortDescription: new FormControl('', [Validators.required]),
    photoUrl: new FormControl('')
  });;

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
    sanitize: false,
    toolbarPosition: 'top',
    toolbarHiddenButtons: [
      ['bold', 'italic'],
      ['fontSize']
    ]
  };

  constructor(private adminService: AdminService) {
  }

  public onSubmit(): void {
    const blog: Blog = {
      id: 0,
      title: this.myForm.get('title')?.value,
      description: this.myForm.get('description')?.value,
      shortDescription: this.myForm.get('shortDescription')?.value,
      photoUrl: this.myForm.get('photoUrl')?.value,
      isLike: false,
      countLikes: 0
    };
    this.adminService.saveBlog(blog).subscribe(t => {
      console.log(t);
    });
  }

  public onChange(event: any): void {
    console.log(this.myForm.value);
  }

}
