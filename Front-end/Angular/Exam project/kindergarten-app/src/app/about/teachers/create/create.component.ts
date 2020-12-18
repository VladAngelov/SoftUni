import { Component, OnDestroy } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { TeachersService } from '../teachers.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss', '../../../../form-style.scss']
})
export class CreateComponent implements OnDestroy {

  isLoading = false;

  form = new FormGroup({
    name: new FormControl(''),
    position: new FormControl(''),
    group: new FormControl('')
  });

  constructor(
    private teachersService: TeachersService,
    private router: Router
  ) { }

  submitHandler(): void {
    this.isLoading = true;
    const name = this.form.controls['name'].value;
    const position = this.form.controls['position'].value;
    const group = this.form.controls['group'].value;
    const createdAt = new Date();

    this.teachersService.createTeacher(name, position, createdAt.toLocaleString(), group);
    this.isLoading = false;
    this.router.navigate(['/about/teachers']);
  }

  ngOnDestroy(): void {
    window.location.reload();
  }
}
