import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { GalleryService } from '../gallery.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent {

  form = new FormGroup({
    title: new FormControl('')
  });

  isLoading = false;

  imageError: string;
  isImageSaved: boolean;
  cardImageBase64: string;
  dataUri: any;
  convImg: any;

  content: string = '';

  constructor(
    private galleryService: GalleryService,
    private router: Router
  ) { }

  ngOnInit() {
  }

  getBase64(event) {
    debugger;
    this.isLoading = true;
    let file = event.target.files[0];
    let reader = new FileReader();
    reader.readAsDataURL(file);
    try {
      this.content = reader.result.valueOf().toString();
      reader.onload = function () {
        let content = reader.result.toString();
      };
    } catch {
      reader.onerror = function (error) {
        return `Error: ${error}`;
      };
    }
  }

  removeImage() {
    this.cardImageBase64 = null;
    this.isImageSaved = false;
  }

  submitHandler(): void {
    this.isLoading = true;
    debugger;
    const title = this.form.controls['title'].value;
    const createdAt = new Date();
    this.galleryService.createPost(title, this.content, createdAt.toLocaleString());
    this.isLoading = false;
    this.router.navigate(['/list/gallery']);
  }

  ngOnDestroy(): void {
    window.location.reload();
  }
}

