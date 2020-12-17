import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IBasePost } from 'src/app/shared/interfaces';
import { PuhService } from '../puh.service';

@Component({
  selector: 'app-puh',
  templateUrl: './puh.component.html',
  styleUrls: ['./puh.component.scss']
})
export class PuhComponent implements OnInit {

  posts: IBasePost[];
  isLogged = false;
  isLoading = false;

  constructor(
    private puhService: PuhService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.isLoading = true;
    this.posts = null;
    this.posts = this.puhService.loadAllPosts();

    if (localStorage.getItem('auth')) {
      this.isLogged = true;
    }

    this.isLoading = false;
  }

  onDelete(id: string): void {
    this.puhService.deletePost(id);
    window.alert("Успешно изтрихте поста!");
    window.location.reload();
  }

  ngOnDestroy(): void {
    this.posts = null;
  }
}
