import { Injectable } from '@angular/core';
import { AngularFireDatabase, AngularFireList } from '@angular/fire/database';
import { Post } from '../models/post.model';
import { IBasePost } from '../shared/interfaces';

@Injectable()
export class NewsService {

  posts: IBasePost[] = [];
  allPosts: AngularFireList<any>;

  constructor(private database: AngularFireDatabase) {
    this.allPosts = this.database.list('news');
  }

  loadAllPosts(): IBasePost[] {
    this.posts = [];
    this.allPosts.snapshotChanges()
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
    return this.posts;
  }

  createPost(title: string, content: string, createdAt: string) {
    this.allPosts.push({ title: title, content: content, created_at: createdAt });
  }

  updatePost(key: string, title: string, content: string) {
    this.allPosts.update(key, { title: title, content: content });
  }

  deletePost(key: string) {
    this.allPosts.remove(key);
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
