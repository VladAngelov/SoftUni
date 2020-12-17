import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ParentsService } from '../parents.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss', '../../../form-style.scss']
})

export class CreateComponent {

  form = new FormGroup({
    title: new FormControl(''),
    content: new FormControl('')
  });

  isLoading = false;

  constructor(
    private parentsService: ParentsService,
    private router: Router
  ) { }

  submitHandler(): void {
    this.isLoading = true;
    debugger;
    const title = this.form.controls['title'].value;
    const content = this.form.controls['content'].value;
    const createdAt = new Date();
    this.parentsService.createProject(title, content, createdAt.toLocaleString());
    this.isLoading = false;
    this.router.navigate(['/list/parents']);
  }
}
