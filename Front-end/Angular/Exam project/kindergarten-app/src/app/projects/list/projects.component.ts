import {
  Component,
  OnInit
} from '@angular/core';
import { Router } from '@angular/router';

import { IBasePost } from 'src/app/shared/interfaces';
import { PostService } from 'src/app/_services/post/post-service.service';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.scss']
})
export class ProjectsComponent implements OnInit {

  projects: IBasePost[];
  isLogged = false;
  isLoading = false;
  path = "projects";

  constructor(
    private postService: PostService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.isLoading = true;
    debugger;
    this.projects = this.postService.getAll(this.path);

    if (localStorage.getItem('auth')) {
      this.isLogged = true;
    }

    this.isLoading = false;
  }

  onDelete(id: string): void {
    this.postService.deletePost(id);
    window.alert("Успешно изтрихте проекта!");
    window.location.reload();
  }

  ngOnDestroy(): void {
    this.projects = null;
  }
}
