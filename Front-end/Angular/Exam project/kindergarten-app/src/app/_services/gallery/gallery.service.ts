import { Injectable } from '@angular/core';
import {
  AngularFireDatabase,
  AngularFireList
} from '@angular/fire/database';
import { DomSanitizer } from '@angular/platform-browser';

import { Photo } from 'src/app/models/photo';
import { IPhoto } from 'src/app/shared/interfaces/photo';

@Injectable()
export class GalleryService {

  photos: IPhoto[] = [];

  allMainPhotos: AngularFireList<any>;

  constructor(
    private database: AngularFireDatabase,
    private sanitizer: DomSanitizer
  ) {
    this.allMainPhotos = this.database.list('gallery');
  }

  loadAllPosts(): any[] {
    this.photos = [];
    this.allMainPhotos.snapshotChanges()
      .subscribe(posts => {
        posts.forEach(post => {
          let p = new Photo();
          p._id = post.key;
          p.title = post.payload.val().title;
          p.content = this.sanitizer.bypassSecurityTrustUrl(post.payload.val().content);

          p.created_at = post.payload.val().createdAt;
          this.photos.push(p);
        });
      });
    return this.photos;
  }

  dataURItoBlob(dataURI) {
    var binary = atob(dataURI);

    var array = [];
    for (var i = 0; i < binary.length; i++) {
      array.push(binary.charCodeAt(i));
    }

    let p = new Blob([new Uint8Array(array)], {
      type: 'image/jpg'
    });

    var reader = new FileReader();
    reader.readAsDataURL(p);
    reader.onload = function (e) {
      console.log('DataURL:', e.target.result);
      debugger;
    };

    return p;
  }

  createPost(title: string, content: string, createdAt: string) {
    console.log('Content in service on create --->>> ', content);
    debugger;
    this.allMainPhotos.push({ title: title, content: content, created_at: createdAt });
  }

  deleteItem(key: string) {
    this.allMainPhotos.remove(key);
  }
}
