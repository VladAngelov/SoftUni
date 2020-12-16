import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IBasePost } from 'src/app/shared/interfaces';

import { ProjectService } from '../project.service';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.scss']
})
export class ProjectsComponent implements OnInit {

  projects: IBasePost[];
  isLogged = false;
  isLoading = false;

  constructor(
    private projectService: ProjectService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.isLoading = true;
    debugger;
    this.projects = this.projectService.loadAllProjects();

    console.log('Projects --> ', this.projects);

    if (localStorage.getItem('auth')) {
      this.isLogged = true;
    }

    this.isLoading = false;
  }

  onDelete(id: string): void {
    this.projectService.deleteProject(id);
    window.alert("Успешно изтрихте проекта!");
    this.router.navigate["/home"];
  }

  ngOnDestroy(): void {
    this.projects = null;
  }
}
