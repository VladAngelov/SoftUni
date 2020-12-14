import { Component, OnInit, OnDestroy } from '@angular/core';
import { IMainPagePost } from '../shared/interfaces/main-page-post';
import { HomeService } from './home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit, OnDestroy {

  constructor(private homeService: HomeService) { }

  posts: IMainPagePost[];
  isLogged = false;

  ngOnInit(): void {
    this.homeService.loadMainPosts().subscribe(mainPosts => {
      this.posts = mainPosts.slice(1);
      console.log(this.posts);
    });

    if (localStorage.getItem('auth')) {
      this.isLogged = true;
    }
  }

  ngOnDestroy(): void { }
}  