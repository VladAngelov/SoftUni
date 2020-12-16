import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { IBasePost } from 'src/app/shared/interfaces';
import { FirefliesService } from '../fireflies.service';

@Component({
  selector: 'app-fireflies',
  templateUrl: './fireflies.component.html',
  styleUrls: ['./fireflies.component.scss']
})
export class FirefliesComponent implements OnInit {

  posts: IBasePost[];
  isLogged = false;
  isLoading = false;

  constructor(
    private firefliesService: FirefliesService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.isLoading = true;
    this.posts = null;
    this.posts = this.firefliesService.loadAllPosts();

    if (localStorage.getItem('auth')) {
      this.isLogged = true;
    }

    this.isLoading = false;
  }

  onDelete(id: string): void {
    this.firefliesService.deletePost(id);
    window.alert("Успешно изтрихте поста!");
    window.location.reload();
  }

  ngOnDestroy(): void {
    this.posts = null;
  }
}
