import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ITeacher } from 'src/app/shared/interfaces';
import { TeachersService } from '../teachers.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss', '../../../../form-style.scss']
})
export class EditComponent {

  id: string;
  teacher: ITeacher;
  isLoading = false;

  form = new FormGroup({
    name: new FormControl(''),
    position: new FormControl(''),
    group: new FormControl('')
  });

  constructor(
    private teacherService: TeachersService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {
    this.id = null;
    this.id = activatedRoute.snapshot.params.id;

    this.teacher = teacherService.loadTeacherById(this.id);
  }

  submitHandler(): void {
    this.isLoading = true;
    const name = this.form.controls['name'].value;
    const position = this.form.controls['position'].value;
    const group = this.form.controls['group'].value;

    this.teacherService.updateTeacher(this.id, name, position, group);
    this.isLoading = false;
    this.router.navigate(["/about/teachers"]);
  }

  ngOnDestroy(): void {
    this.id = null;
    this.teacher = null;
    this.router.navigate(["/about/teachers"]);
    window.location.reload();
  }
}
