import { Component } from '@angular/core';
import {
  FormControl,
  FormGroup
} from '@angular/forms';
import { Router } from '@angular/router';

import { PostService } from 'src/app/_services/post/post-service.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss', '../../../../form-style.scss']
})
export class CreateComponent {

  form = new FormGroup({
    title: new FormControl(''),
    content: new FormControl('')
  });

  isLoading = false;

  constructor(
    private postService: PostService,
    private router: Router
  ) { }

  submitHandler(): void {
    this.isLoading = true;
    debugger;
    const title = this.form.controls['title'].value;
    const content = this.form.controls['content'].value;
    const createdAt = new Date();
    this.postService.createPost(title, content, createdAt.toLocaleString());
    this.isLoading = false;
    this.router.navigate(['/about/list/place']);
  }

  ngOnDestroy(): void {
    window.location.reload();
  }
}
