import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IMainPagePost } from 'src/app/shared/interfaces';
import { HomeService } from '../../home.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class EditComponent {

  post: IMainPagePost;

  constructor(
    private homeService: HomeService,
    activatedRoute: ActivatedRoute
  ) {
    const id = activatedRoute.snapshot.params.id;
    homeService.loadMainPost(id).subscribe(post => {
      this.post = post;
    });
  }
}
