import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IBasePost } from 'src/app/shared/interfaces';
import { LionsService } from '../lions.service';

@Component({
  selector: 'app-lions',
  templateUrl: './lions.component.html',
  styleUrls: ['./lions.component.scss']
})
export class LionsComponent implements OnInit {

  posts: IBasePost[];
  isLogged = false;
  isLoading = false;

  constructor(
    private lionsService: LionsService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.isLoading = true;
    this.posts = null;
    this.posts = this.lionsService.loadAllPosts();

    if (localStorage.getItem('auth')) {
      this.isLogged = true;
    }

    this.isLoading = false;
  }

  onDelete(id: string): void {
    this.lionsService.deletePost(id);
    window.alert("Успешно изтрихте поста!");
    window.location.reload();
  }

  ngOnDestroy(): void {
    this.posts = null;
  }
}
