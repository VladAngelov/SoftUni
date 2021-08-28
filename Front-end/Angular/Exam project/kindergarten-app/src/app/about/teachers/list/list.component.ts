import {
  Component,
  OnDestroy,
  OnInit
} from '@angular/core';

import { ITeacher } from 'src/app/shared/interfaces';
import { TeachersService } from '../../../_services/teachers/teachers.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit, OnDestroy {

  teachers: ITeacher[] = [];
  isLogged = false;

  constructor(private teacherService: TeachersService) {
    if (localStorage.getItem('auth')) {
      this.isLogged = true;
    }
  }

  ngOnInit(): void {
    this.teachers = this.teacherService.loadAllTeachers();
  }

  onDelete(id: string): void {
    this.teacherService.deleteTeacher(id);
    window.alert("Успешно премахнахте служителя!");
    window.location.reload();
  }

  ngOnDestroy(): void {
    this.teachers = [];
  }
}
