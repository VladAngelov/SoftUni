import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IBasePost } from 'src/app/shared/interfaces';
import { ParentsService } from '../parents.service';

@Component({
  selector: 'app-parents',
  templateUrl: './parents.component.html',
  styleUrls: ['./parents.component.scss']
})
export class ParentsComponent implements OnInit {

  posts: IBasePost[];
  isLogged = false;
  isLoading = false;

  constructor(
    private parentsService: ParentsService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.isLoading = true;
    debugger;
    this.posts = this.parentsService.loadAllProjects();

    if (localStorage.getItem('auth')) {
      this.isLogged = true;
    }

    this.isLoading = false;
  }

  onDelete(id: string): void {
    this.parentsService.deleteProject(id);
    window.alert("Успешно изтрихте проекта!");
    window.location.reload();
  }

  ngOnDestroy(): void {
    this.posts = null;
  }
}
