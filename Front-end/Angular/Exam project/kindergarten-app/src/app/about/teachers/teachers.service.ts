import { Injectable } from '@angular/core';
import { AngularFireDatabase, AngularFireList } from '@angular/fire/database';
import { Teacher } from 'src/app/models/teacher.model';
import { ITeacher } from 'src/app/shared/interfaces';

@Injectable()
export class TeachersService {

  teachers: ITeacher[] = [];
  allTeachers: AngularFireList<any>;

  constructor(private database: AngularFireDatabase) {
    this.allTeachers = this.database.list('teachers');
  }

  loadAllTeachers(): ITeacher[] {
    this.teachers = [];
    this.allTeachers.snapshotChanges()
      .subscribe(ts => {
        ts.forEach(t => {
          let tch = new Teacher();
          tch._id = t.key;
          tch.name = t.payload.val().name;
          tch.group = t.payload.val().group;
          tch.position = t.payload.val().position;
          tch.created_at = t.payload.val().createdAt;

          this.teachers.push(tch);
        });
      });
    return this.teachers;
  }

  createTeacher(name: string, position: string, createdAt: string, group: string) {
    this.allTeachers.push({ name: name, position: position, created_at: createdAt, group: group });
  }

  updateTeacher(key: string, name: string, position: string, group: string) {
    this.allTeachers.update(key, { name: name, position: position, group: group });
  }

  deleteTeacher(key: string) {
    this.allTeachers.remove(key);
  }

  loadTeacherById(id: string): any {
    let teacher: Teacher = this.teachers.find(x => x._id === id);
    return teacher;
  }
}
