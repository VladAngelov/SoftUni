import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TeachersService } from '../teachers.service';
import { tap, switchMap} from 'rxjs/operators';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.scss']
})
export class DetailComponent  implements OnInit{

  teacher: any;

  constructor(
    private teachersService: TeachersService,
    private route: ActivatedRoute
    ) { }

  ngOnInit(): void {
      this.route.params.pipe(
        tap(() => this.teacher = null),
        switchMap (({ id }) => this.teachersService.loadTeacher(id)))
        .subscribe(teacher => {
          this.teacher = teacher;
        });      
      };
  }
