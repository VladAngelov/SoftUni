import {
  Component,
  OnInit
} from '@angular/core';

import { IBasePost } from 'src/app/shared/interfaces';
import { PostService } from 'src/app/_services/post/post-service.service';

@Component({
  selector: 'app-fireflies',
  templateUrl: './fireflies.component.html',
  styleUrls: ['./fireflies.component.scss']
})
export class FirefliesComponent implements OnInit {

  posts: IBasePost[];
  isLogged = false;
  isLoading = false;
  path = "groups/fireflies";

  constructor(private postService: PostService) { }

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
