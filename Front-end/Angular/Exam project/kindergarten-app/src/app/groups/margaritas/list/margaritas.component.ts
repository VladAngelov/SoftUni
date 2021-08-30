import {
  Component,
  OnInit
} from '@angular/core';
import { Router } from '@angular/router';

import { IBasePost } from 'src/app/shared/interfaces';
import { PostService } from 'src/app/_services/post/post-service.service';

@Component({
  selector: 'app-margaritas',
  templateUrl: './margaritas.component.html',
  styleUrls: ['./margaritas.component.scss']
})
export class MargaritasComponent implements OnInit {

  posts: IBasePost[];
  isLogged = false;
  isLoading = false;
  path = "groups/margaritas";

  constructor(
    private postService: PostService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.isLoading = true;
    this.posts = null;
    this.posts = this.postService.getAll(this.path);

    if (localStorage.getItem('auth')) {
      this.isLogged = true;
    }

    this.isLoading = false;
  }

  onDelete(id: string): void {
    this.postService.deletePost(id);
    window.alert("Успешно изтрихте поста!");
    window.location.reload();
  }

  ngOnDestroy(): void {
    this.posts = null;
  }
}
