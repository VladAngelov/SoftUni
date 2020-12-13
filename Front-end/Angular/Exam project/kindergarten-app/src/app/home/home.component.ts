import { Component, OnInit, OnDestroy } from '@angular/core';
import { StorageService } from '../core/storage.service';
import { IMainPagePost } from '../shared/interfaces/main-page-post';
import { UserService } from '../user/user.service';
import { HomeService } from './home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit, OnDestroy {

  constructor(
    private homeService: HomeService,
    private userService: UserService,
    private storage: StorageService
  ) { }

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

  ngOnDestroy(): void { } // TODO: Add memory cleaner (unsubscribe)

  // onSubmit() {
  //   this.db.list('items').push({ content: this.itemValue });
  //   this.itemValue = '';
  // }
}  