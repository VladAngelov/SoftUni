import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IContact } from 'src/app/shared/interfaces';
import { ContactsService } from '../contacts.service';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.scss']
})
export class ContactsComponent implements OnInit {

  contacts: IContact[];
  isLogged = false;
  isLoading = false;

  constructor(
    private contactsService: ContactsService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.isLoading = true;
    this.contacts = null;
    this.contacts = this.contactsService.loadAllPosts();

    if (localStorage.getItem('auth')) {
      this.isLogged = true;
    }

    this.isLoading = false;
  }

  onDelete(id: string): void {
    this.contactsService.deletePost(id);
    window.alert("Успешно изтрихте контакта!");
    window.location.reload();
  }

  ngOnDestroy(): void {
    this.contacts = null;
  }
}
