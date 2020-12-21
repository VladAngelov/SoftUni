import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { IPhoto } from 'src/app/shared/interfaces/photo';
import { GalleryService } from '../gallery.service';

@Component({
  selector: 'app-gallery',
  templateUrl: './gallery.component.html',
  styleUrls: ['./gallery.component.scss']
})
export class GalleryComponent {

  posts: any[];
  isLogged = false;
  isLoading = false;

  constructor(
    private galleryService: GalleryService,
    private router: Router,

  ) {
    this.isLoading = true;
    this.posts = this.galleryService.loadAllPosts();


    if (localStorage.getItem('auth')) {
      this.isLogged = true;
    }
    this.isLoading = false;
  }


  formatImage(img: any): any {
    return img;
  }

  onDelete(id: string): void {
    this.galleryService.deleteItem(id);
    window.alert("Успешно изтрихте снимката!");
    window.location.reload();
  }
  ngOnDestroy(): void {
    this.posts = null;
  }
}
