import {
  Component,
  OnInit,
  OnDestroy
} from '@angular/core';
import { Router } from '@angular/router';

import { IBasePost } from '../shared/interfaces';
import { PostService } from '../_services/post/post-service.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})

export class HomeComponent implements OnInit, OnDestroy {

  posts: IBasePost[];
  isLogged = false;
  isLoading = false;
  path = "main-page-posts";

  constructor(
    private postService: PostService,
    private router: Router) { }

  ngOnInit(): void {
    this.isLoading = true;
    this.posts = this.postService.getAll(this.path);

    if (localStorage.getItem('auth')) {
      this.isLogged = true;
    }

    this.isLoading = false;
  }

  onDelete(id: string): void {
    this.postService.deletePost(id);
    window.alert("Успешно изтрихте поста!");
    window.location.reload();
  }

  ngOnDestroy(): void {
    this.posts = null;
  }
}
