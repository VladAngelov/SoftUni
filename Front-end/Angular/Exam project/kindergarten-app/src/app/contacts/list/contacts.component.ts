import {
  Component,
  OnInit
} from '@angular/core';
import { Router } from '@angular/router';

import { IContact } from 'src/app/shared/interfaces';
import { ContactsService } from 'src/app/_services/contacts/contacts.service';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.scss']
})
export class ContactsComponent implements OnInit {

  contacts: IContact[];
  isLogged = false;
  isLoading = false;
  path = "contacts";

  constructor(
    private contactsService: ContactsService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.isLoading = true;
    this.contacts = null;
    this.contacts = this.contactsService.getAll();

    if (localStorage.getItem('auth')) {
      this.isLogged = true;
    }

    this.isLoading = false;
  }

  onDelete(id: string): void {
    this.contactsService.deleteContact(id);
    window.alert("Успешно изтрихте контакта!");
    window.location.reload();
  }

  ngOnDestroy(): void {
    this.contacts = null;
  }
}
