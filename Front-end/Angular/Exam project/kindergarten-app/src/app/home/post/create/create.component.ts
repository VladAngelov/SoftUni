import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { title } from 'process';
import { titleValidator } from 'src/app/shared/validators';

import { HomeService } from '../../home.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss', '../../../../form-style.scss',]
})
export class CreateComponent implements OnInit {

  form = new FormGroup({
    title: new FormControl(''),
    content: new FormControl('')
  });

  isLoading = false;

  constructor(
    private fb: FormBuilder,
    private homeService: HomeService,
    private router: Router
  ) {
    // debugger;
    // this.form = this.fb.group({
    //   title: ['', [Validators.required, Validators.minLength(6), titleValidator(title)]],
    //   content: ['', [Validators.required]]
    // })
  }

  ngOnInit(): void {
  }

  submitHandler(): void {
    this.isLoading = true;
    debugger;
    const title = this.form.controls['title'].value;
    const content = this.form.controls['content'].value;
    const createdAt = new Date();

    this.homeService.createPost(title, content, createdAt.toLocaleString());

    this.isLoading = false;
  }
}
