import {
  Component,
  OnInit
} from '@angular/core';
import { IBasePost } from 'src/app/shared/interfaces';
import { PostService } from 'src/app/_services/post/post-service.service';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.scss']
})
export class NewsComponent implements OnInit {

  posts: IBasePost[];
  isLogged = false;
  isLoading = false;
  path = "news";

  constructor(private postService: PostService) { }

  ngOnInit(): void {
    this.isLoading = true;
    this.posts = this.postService.getAll(this.path);

    if (localStorage.getItem('auth')) {
      this.isLogged = true;
    }

    this.isLoading = false;
  }

  onDelete(id: string): void {
    this.postService.deletePost(id);
    window.alert("Успешно изтрихте новината!");
    window.location.reload();
  }

  ngOnDestroy(): void {
    this.posts = null;
  }
}
