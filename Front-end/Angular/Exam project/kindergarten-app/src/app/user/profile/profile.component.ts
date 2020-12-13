import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {

  email: string;

  constructor() { }

  ngOnInit(): void {
    const obj = JSON.parse(localStorage.getItem('auth'));
    this.email = obj.email;
  }
}
