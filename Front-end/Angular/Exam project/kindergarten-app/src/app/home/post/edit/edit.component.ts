import {
  Component,
  OnDestroy
} from '@angular/core';
import {
  FormControl,
  FormGroup
} from '@angular/forms';
import {
  ActivatedRoute,
  Router
} from '@angular/router';
import { IMainPagePost } from 'src/app/shared/interfaces';
import { PostService } from 'src/app/_services/post/post-service.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss', '../../../../form-style.scss']
})
export class EditComponent implements OnDestroy {

  id: string;
  post: IMainPagePost;
  isLoading = false;

  form = new FormGroup({
    title: new FormControl(''),
    content: new FormControl('')
  });

  constructor(
    private postService: PostService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {
    this.id = null;
    this.id = activatedRoute.snapshot.params.id;
    this.post = postService.getById(this.id);
  }

  submitHandler(): void {
    this.isLoading = true;
    const title = this.form.controls['title'].value;
    const content = this.form.controls['content'].value;
    this.postService.updatePost(this.id, title, content);
    this.isLoading = false;
    this.router.navigate(["/"]);
  }

  ngOnDestroy(): void {
    this.id = null;
    this.post = null;
    this.router.navigate(["/"]);
  }
}
