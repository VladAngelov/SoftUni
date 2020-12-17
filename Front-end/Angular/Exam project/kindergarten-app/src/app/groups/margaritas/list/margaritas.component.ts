import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IBasePost } from 'src/app/shared/interfaces';
import { MargaritasService } from '../margaritas.service';

@Component({
  selector: 'app-margaritas',
  templateUrl: './margaritas.component.html',
  styleUrls: ['./margaritas.component.scss']
})
export class MargaritasComponent implements OnInit {

  posts: IBasePost[];
  isLogged = false;
  isLoading = false;

  constructor(
    private margaritasService: MargaritasService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.isLoading = true;
    this.posts = null;
    this.posts = this.margaritasService.loadAllPosts();

    if (localStorage.getItem('auth')) {
      this.isLogged = true;
    }

    this.isLoading = false;
  }

  onDelete(id: string): void {
    this.margaritasService.deletePost(id);
    window.alert("Успешно изтрихте поста!");
    window.location.reload();
  }

  ngOnDestroy(): void {
    this.posts = null;
  }
}
