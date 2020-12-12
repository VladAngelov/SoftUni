import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AngularFireDatabase } from '@angular/fire/database';

import { IMainPagePost } from '../shared/interfaces';
import { environment } from '../../environments/environment';

const apiUrl = environment.apiUrl;

@Injectable()
export class HomeService {

  constructor(private http: HttpClient) { }

  loadMainPosts(): Observable<IMainPagePost[]> {
    return this.http.get<IMainPagePost[]>(`${apiUrl}/main-page-posts.json`);
  }

}
