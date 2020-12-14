import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
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

  form: FormGroup;

  isLoading = false;

  constructor(
    private fb: FormBuilder,
    private homeService: HomeService,
    private router: Router
  ) {
    // this.form = this.fb.group({
    //   title: ['', [Validators.required, Validators.minLength(6), titleValidator(title)]],
    //   content: ['', [Validators.required]]
    // })
  }

  ngOnInit(): void {
  }

  submitHandler(): void {
    // const data = this.form.value;
    // this.isLoading = true;

    // const title = this.form.controls['title'].value;
    // const content = this.form.controls['content'].value;

    // this.homeService.createPost(title, content);
  }
}
