import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, range } from 'rxjs';
import { AngularFireDatabase } from '@angular/fire/database';

import { IBasePost, IMainPagePost } from '../shared/interfaces';
import { environment } from '../../environments/environment';
import { map } from 'rxjs/operators';
import { Post } from '../models/post.model';

const apiUrl = environment.apiUrl;

@Injectable()
export class HomeService {

  mainPosts: Post[] = [];

  constructor(private http: HttpClient, private database: AngularFireDatabase) { }

  async loadMainPosts(): Promise<Post[]> {
    await fetch(`${apiUrl}/main-page-posts.json`)
      .then(x => x.json())
      .then(x => {
        for (const [key, value] of Object.entries(x)) {

          let props = Object.values(value);

          let id = key;
          let content = props[0];
          let title = props[2];
          let created_at = props[1];

          let post = new Post();

          post._id = id;
          post.content = content;
          post.title = title;
          post.created_at = created_at;

          this.mainPosts.push(post);
        }
      });
    return this.mainPosts;
  }

  loadMainPost(id: string): Observable<IBasePost> {
    return this.http.get<IBasePost>(`${apiUrl}/main-page-posts/${id}.json`, { withCredentials: true });
  }

  createPost(title: string, content: string, createdAt: string): void {
    fetch(`${apiUrl}/main-page-posts.json`, {
      method: 'POST',
      headers: { 'content-type': 'application/json' },
      body: JSON.stringify({ title, content, createdAt }
      ),
    })
      .catch(err => console.log(err));
  }

}


