import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { IBasePost } from '../shared/interfaces';
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

    if (localStorage.getItem('auth')) {
      this.isLogged = true;
    }
    this.isLoading = false;
  }

  onDelete(id: string): void {
    this.homeService.deleteItem(id);
    window.alert("Успешно изтрихте поста!");
    window.location.reload();
  }
  ngOnDestroy(): void {
    this.posts = null;
  }
}  