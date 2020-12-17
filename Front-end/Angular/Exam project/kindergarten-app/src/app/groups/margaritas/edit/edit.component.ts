import { Component, OnChanges, SimpleChanges } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IMainPagePost } from 'src/app/shared/interfaces';
import { MargaritasService } from '../margaritas.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss', '../../../../form-style.scss']
})
export class EditComponent implements OnChanges {

  id: string;
  post: IMainPagePost;
  isLoading = false;

  form = new FormGroup({
    title: new FormControl(''),
    content: new FormControl('')
  });

  constructor(
    private margaritasService: MargaritasService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {
    this.id = null;
    this.id = activatedRoute.snapshot.params.id;
    this.post = margaritasService.loadPostById(this.id);
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.post = this.margaritasService.loadPostById(this.id);
  }

  submitHandler(): void {
    this.isLoading = true;
    const title = this.form.controls['title'].value;
    const content = this.form.controls['content'].value;
    this.margaritasService.updatePost(this.id, title, content);
    this.isLoading = false;
    this.router.navigate(["/groups/list/margaritas"]);
  }

  ngOnDestroy(): void {
    this.id = null;
    this.post = null;
    this.router.navigate(["/groups/list/margaritas"]);
    window.location.reload();
  }
}
