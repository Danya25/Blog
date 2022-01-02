import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule} from '@angular/forms';
import {LikeButtonComponent} from '../views/like-button/like-button.component';

@NgModule({
    declarations: [LikeButtonComponent],
    imports: [CommonModule],
    exports: [CommonModule, FormsModule, LikeButtonComponent]
})
export class SharedModule {
}
