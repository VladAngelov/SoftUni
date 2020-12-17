import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { SunService } from '../sun.service';

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
    private sunService: SunService,
    private router: Router
  ) { }

  submitHandler(): void {
    this.isLoading = true;
    const title = this.form.controls['title'].value;
    const content = this.form.controls['content'].value;
    const createdAt = new Date();
    this.sunService.createPost(title, content, createdAt.toLocaleString());
    this.isLoading = false;
    this.router.navigate(['/groups/list/sun']);
  }

  ngOnDestroy(): void {
    window.location.reload();
  }
}
