import { Component, OnInit, OnDestroy } from '@angular/core';
import { AngularFireDatabase } from '@angular/fire/database';
import { Observable } from 'rxjs';
import { IMainPagePost } from '../shared/interfaces/main-page-post';
import { HomeService } from './home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit, OnDestroy {

  // posts: any[];

  // constructor(db: AngularFireDatabase) {
  //   db.list('/main-page-posts')
  //     .valueChanges()
  //     .subscribe(posts => {
  //       this.posts = posts;
  //       console.log('posts from component --> ', this.posts);
  //     });
  // }

  constructor(private homeService: HomeService) { }

  posts: IMainPagePost[];

  ngOnInit(): void {
    this.homeService.loadMainPosts().subscribe(mainPosts => {
      this.posts = mainPosts.slice(1);
    });
  }

  ngOnDestroy(): void { } // TODO: Add memory cleaner (unsubscribe)

  // onSubmit() {
  //   this.db.list('items').push({ content: this.itemValue });
  //   this.itemValue = '';
  // }
}  