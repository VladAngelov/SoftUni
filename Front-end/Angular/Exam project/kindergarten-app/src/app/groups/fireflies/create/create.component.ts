import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

import { FirefliesService } from '../fireflies.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss', '../../../../form-style.scss']
})
export class CreateComponent implements OnInit {

  form = new FormGroup({
    title: new FormControl(''),
    content: new FormControl('')
  });

  isLoading = false;

  constructor(
    private firefliesService: FirefliesService,
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  submitHandler(): void {
    this.isLoading = true;
    debugger;
    const title = this.form.controls['title'].value;
    const content = this.form.controls['content'].value;
    const createdAt = new Date();
    this.firefliesService.createPost(title, content, createdAt.toLocaleString());
    this.isLoading = false;
    this.router.navigate(['/groups/list/fireflies']);
  }
}
