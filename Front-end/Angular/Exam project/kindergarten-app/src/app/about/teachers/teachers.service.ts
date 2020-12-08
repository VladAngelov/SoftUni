import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TeachersService {

  constructor(private http: HttpClient) { }

   loadTeachers(): Observable<any> {
    return this.http.get('https://jsonplaceholder.typicode.com/users');
   }

    loadTeacher(id: number): Observable<any> {
      return  this.http.get<any>(`https://jsonplaceholder.typicode.com/users/${id}`);
    }
  }
