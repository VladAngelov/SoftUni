import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IMainPagePost } from 'src/app/shared/interfaces';
import { HomeService } from '../../home.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss', '../../../../form-style.scss']
})
export class EditComponent {

  post: IMainPagePost;
  isLoading = false;

  form = new FormGroup({
    title: new FormControl(''),
    content: new FormControl('')
  });

  id: string;

  constructor(
    private homeService: HomeService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {
    this.id = null;
    this.id = activatedRoute.snapshot.params.id;
    this.post = homeService.loadPostById(this.id);
  }

  submitHandler(): void {
    this.isLoading = true;
    const title = this.form.controls['title'].value;
    const content = this.form.controls['content'].value;
    this.homeService.updateItem(this.id, title, content);
    this.isLoading = false;
    this.router.navigate(['/']);
  }
}
