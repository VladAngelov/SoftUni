import { Component, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ITeacher } from 'src/app/shared/interfaces';
import { TeachersService } from '../teachers.service';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.scss']
})
export class DetailComponent implements OnDestroy {

  teacher: ITeacher;
  id: string;
  constructor(
    private teachersService: TeachersService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {
    this.id = null;
    this.id = activatedRoute.snapshot.params.id;
    this.teacher = teachersService.loadTeacherById(this.id);
  }

  onDelete(id: string): void {
    this.teachersService.deleteTeacher(id);
    window.alert("Успешно премахнахте служителя!");
    this.router.navigate(["/about/teachers"]);
  }

  ngOnDestroy(): void {
    this.teacher = null;
  }
}
