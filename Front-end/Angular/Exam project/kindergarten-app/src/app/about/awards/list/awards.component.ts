import {
  Component,
  OnInit
} from '@angular/core';
import { Router } from '@angular/router';

import { IBasePost } from 'src/app/shared/interfaces';
import { PostService } from 'src/app/_services/post/post-service.service';

@Component({
  selector: 'app-awards',
  templateUrl: './awards.component.html',
  styleUrls: ['./awards.component.scss']
})
export class AwardsComponent implements OnInit {

  posts: IBasePost[];
  isLogged = false;
  isLoading = false;
  path = "awards";

  constructor(
    private postService: PostService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.isLoading = true;
    debugger;
    this.posts = this.postService.getAll(this.path);

    if (localStorage.getItem('auth')) {
      this.isLogged = true;
    }

    this.isLoading = false;
  }

  onDelete(id: string): void {
    this.postService.deletePost(id);
    window.alert("Успешно изтрихте наградата!");
    window.location.reload();
  }

  ngOnDestroy(): void {
    this.posts = null;
  }
}
