import { Component, OnInit, OnDestroy, DoCheck } from '@angular/core';
import { AngularFireDatabase } from '@angular/fire/database';
import { Observable } from 'rxjs';
import { IMainPagePost } from '../shared/interfaces/main-page-post';
import { UserService } from '../user/user.service';
import { HomeService } from './home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit, OnDestroy, DoCheck {

  constructor(
    private homeService: HomeService,
    private userService: UserService
  ) { }

  posts: IMainPagePost[];
  isLogged = false;

  ngOnInit(): void {
    this.homeService.loadMainPosts().subscribe(mainPosts => {
      this.posts = mainPosts.slice(1);
      console.log(this.posts);
    });
  }

  ngDoCheck(): void {
    this.isLogged = this.userService.isLogged;
  }

  ngOnDestroy(): void { } // TODO: Add memory cleaner (unsubscribe)

  // onSubmit() {
  //   this.db.list('items').push({ content: this.itemValue });
  //   this.itemValue = '';
  // }
}  