import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { GalleryService } from '../gallery.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss', '../../../form-style.scss']
})
export class CreateComponent {

  form = new FormGroup({
    title: new FormControl('')
  });

  isLoading = false;

  imageError: string;

  dataUri: any;
  convImg: any;

  content: string = '';

  constructor(
    private galleryService: GalleryService,
    private router: Router
  ) { }

  getBase64(event) {
    console.log('Event --->>> ', event)
    debugger;
    this.isLoading = true;
    let file = event.target.files[0];
    let reader = new FileReader();

    console.log('File --->>> ', file)
    debugger;
    reader.readAsDataURL(file);
    try {
      this.content = reader.result.valueOf().toString();

      console.log('THIS.CONTENT --->>> ', this.content);
      debugger;

      if (this.content === null || this.content === '') {
        window.alert('Избери отново снимката');
        console.log('Избери отново снимката');
        return 'Избери отново снимката';
      }

      reader.onload = function () {
        let content = reader.result.toString();
        console.log('Content in try-catch in function --->>> ', content);
        debugger;
      };
    } catch {
      reader.onerror = function (error) {
        console.log('Error --->>> ', error);
        debugger;
        return `Error: ${error}`;
      };
    }
  }

  submitHandler(): void {
    this.isLoading = true;
    debugger;
    const title = this.form.controls['title'].value;
    const createdAt = new Date();
    console.log(this.content);
    debugger;
    if (this.content === null || this.content === '') {
      window.alert('Избери отново снимката');
      console.log('Избери отново снимката');
      window.location.reload();
    }
    this.galleryService.createPost(title, this.content, createdAt.toLocaleString());
    this.isLoading = false;
    this.router.navigate(['/list/gallery']);
  }

  ngOnDestroy(): void {
    window.location.reload();
  }
}

