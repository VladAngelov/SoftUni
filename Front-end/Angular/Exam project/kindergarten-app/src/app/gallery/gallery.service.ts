import { Injectable } from '@angular/core';
import { AngularFireDatabase, AngularFireList } from '@angular/fire/database';
import { DomSanitizer } from '@angular/platform-browser';
import { Photo } from '../models/photo';
import { IPhoto } from '../shared/interfaces/photo';

@Injectable()
export class GalleryService {

  posts: IPhoto[] = [];

  allMainPosts: AngularFireList<any>;

  constructor(
    private database: AngularFireDatabase,
    private sanitizer: DomSanitizer
  ) {
    this.allMainPosts = this.database.list('gallery');
  }

  loadAllPosts(): any[] {
    this.posts = [];
    this.allMainPosts.snapshotChanges()
      .subscribe(posts => {
        posts.forEach(post => {
          let p = new Photo();
          p._id = post.key;
          p.title = post.payload.val().title;
          p.content = this.sanitizer.bypassSecurityTrustUrl(post.payload.val().content);

          p.created_at = post.payload.val().createdAt;
          this.posts.push(p);
        });
      });
    return this.posts;
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
    debugger;
    this.allMainPosts.push({ title: title, content: content, created_at: createdAt });
  }

  deleteItem(key: string) {
    this.allMainPosts.remove(key);
  }
}
