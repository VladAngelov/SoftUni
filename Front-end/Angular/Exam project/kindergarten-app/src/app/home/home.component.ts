import { Component, OnInit, OnDestroy, OnChanges, SimpleChanges } from '@angular/core';
import { Observable } from 'rxjs';
import { Post } from '../models/post.model';
import { IBasePost } from '../shared/interfaces';
import { IMainPagePost } from '../shared/interfaces/main-page-post';
import { HomeService } from './home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit, OnDestroy, OnChanges {

  posts: Post[] = [];
  isLogged = false;

  constructor(private homeService: HomeService) {
    let postsFromService = this.homeService.loadMainPosts();
    postsFromService.then(x => {
      this.posts = x;
    });
  }
  ngOnChanges(changes: SimpleChanges): void {

  }

  ngOnInit(): void {

    if (localStorage.getItem('auth')) {
      this.isLogged = true;
    }
  }

  ngOnDestroy(): void {

  }
}  