import { Injectable } from '@angular/core';
import { AngularFireDatabase, AngularFireList } from '@angular/fire/database';
import { Contact } from '../models/contact.model';
import { IContact } from '../shared/interfaces';

@Injectable()
export class ContactsService {

  contacts: any[] = [];

  posts: IContact[] = [];
  allPosts: AngularFireList<any>;

  constructor(private database: AngularFireDatabase) {
    this.allPosts = this.database.list('contacts');
  }

  loadAllPosts(): IContact[] {
    this.posts = [];
    this.allPosts.snapshotChanges()
      .subscribe(posts => {
        posts.forEach(post => {
          let p = new Contact();
          p._id = post.key;
          p.name = post.payload.val().title;
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
    let post = new Contact;
    let p = this.posts.find(x => x._id === id);

    post._id = p._id;
    post.content = p.content;
    post.name = p.name;
    post.created_at = p.created_at;

    return post;
  }
}
