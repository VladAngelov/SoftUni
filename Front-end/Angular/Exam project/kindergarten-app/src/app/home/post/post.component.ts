import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IMainPagePost } from 'src/app/shared/interfaces';
import { HomeService } from '../home.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent implements OnInit {

  post: IMainPagePost;

  constructor(
    private homeService: HomeService,
    private activeRoute: ActivatedRoute
  ) {
    const id = activeRoute.snapshot.params.id;
    this.homeService.loadMainPost(id);
  }

  ngOnInit(): void {
    console.log('Post --> ', this.post);
  }

}
