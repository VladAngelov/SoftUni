import { Injectable } from '@angular/core';
import { AngularFireDatabase, AngularFireList } from '@angular/fire/database';

import { IBasePost } from '../shared/interfaces';
import { Post } from '../models/post.model';

@Injectable()
export class HomeService {

  posts: IBasePost[] = [];

  allMainPosts: AngularFireList<any>;

  constructor(private database: AngularFireDatabase) {
    this.allMainPosts = this.database.list('main-page-posts');
  }

  loadAllPosts(): IBasePost[] {
    this.posts = [];
    this.allMainPosts.snapshotChanges()
      .subscribe(posts => {
        posts.forEach(post => {
          let p = new Post();
          p._id = post.key;
          p.title = post.payload.val().title;
          p.content = post.payload.val().content;
          p.created_at = post.payload.val().createdAt;
          this.posts.push(p);
        });
      });
    console.log('Posts --> ', this.posts);
    return this.posts;
  }

  createPost(title: string, content: string, createdAt: string) {
    this.allMainPosts.push({ title: title, content: content, created_at: createdAt });
  }

  updateItem(key: string, title: string, content: string) {
    this.allMainPosts.update(key, { title: title, content: content });
  }

  deleteItem(key: string) {
    this.allMainPosts.remove(key);
  }

  loadPostById(id: string): any {
    let post = new Post;
    let p = this.posts.find(x => x._id === id);

    post._id = p._id;
    post.content = p.content;
    post.title = p.title;
    post.created_at = p.created_at;

    return post;
  }
}
