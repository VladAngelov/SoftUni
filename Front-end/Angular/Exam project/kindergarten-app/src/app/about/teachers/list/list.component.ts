import { Component, OnInit } from '@angular/core';
import { TeachersService } from '../teachers.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit{

  teachersList = null;

  constructor(private teacherService: TeachersService) { }

  ngOnInit(): void {
    this.teacherService.loadTeachers().subscribe( 
      teachersList => this.teachersList = teachersList
      );
  }
}
