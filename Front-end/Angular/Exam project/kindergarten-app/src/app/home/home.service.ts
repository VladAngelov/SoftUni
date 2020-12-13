import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AngularFireDatabase } from '@angular/fire/database';

import { IMainPagePost } from '../shared/interfaces';
import { environment } from '../../environments/environment';

const apiUrl = environment.apiUrl;

@Injectable()
export class HomeService {

  constructor(private http: HttpClient, angularDB: AngularFireDatabase) { }

  loadMainPosts(): Observable<IMainPagePost[]> {
    return this.http.get<IMainPagePost[]>(`${apiUrl}/main-page-posts.json`);
  }

  loadMainPost(id: string): Observable<IMainPagePost> {
    return this.http.get<IMainPagePost>(`${apiUrl}/main-page-posts/${id}.json`);
  }

  createPost(title: string, content: string): void {
    fetch(`${apiUrl}/main-page-posts.json`, {
      method: 'POST',
      headers: { 'content-type': 'application/json' },
      body: JSON.stringify({ title, content }),
    })
      .catch(err => console.log(err));
  }

}
