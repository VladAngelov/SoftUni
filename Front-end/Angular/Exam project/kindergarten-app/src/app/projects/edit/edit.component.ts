import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IMainPagePost } from 'src/app/shared/interfaces';
import { ProjectService } from '../project.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss', '../../../form-style.scss']
})
export class EditComponent {

  id: string;
  project: IMainPagePost;
  isLoading = false;

  form = new FormGroup({
    title: new FormControl(''),
    content: new FormControl('')
  });

  constructor(
    private projectService: ProjectService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {
    this.id = null;
    this.id = activatedRoute.snapshot.params.id;
    this.project = projectService.loadProjectById(this.id);
  }

  submitHandler(): void {
    this.isLoading = true;
    const title = this.form.controls['title'].value;
    const content = this.form.controls['content'].value;
    this.projectService.updateProject(this.id, title, content);
    this.isLoading = false;
    this.router.navigate(["/"]);
    window.location.reload();
  }

  ngOnDestroy(): void {
    this.id = null;
    this.project = null;
    this.router.navigate(["/"]);
  }
}
