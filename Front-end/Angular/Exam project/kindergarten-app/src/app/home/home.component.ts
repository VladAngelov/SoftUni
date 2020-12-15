import { Component, OnInit, OnDestroy, OnChanges, SimpleChanges, EventEmitter, Output, Input } from '@angular/core';
import { Router } from '@angular/router';
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
export class HomeComponent implements OnInit, OnDestroy {

  posts: IBasePost[];
  isLogged = false;
  isLoading = false;

  constructor(
    private homeService: HomeService,
    private router: Router) { }

  ngOnInit(): void {
    this.isLoading = true;
    this.posts = this.homeService.loadAllPosts();
    this.isLoading = false;

    if (localStorage.getItem('auth')) {
      this.isLogged = true;
    }
  }

  onDelete(id: string): void {
    this.homeService.deleteItem(id);
    window.alert("Успешно изтрихте поста!");
    this.router.navigate["/"];
  }
  ngOnDestroy(): void {
    this.posts = null;
  }
}  