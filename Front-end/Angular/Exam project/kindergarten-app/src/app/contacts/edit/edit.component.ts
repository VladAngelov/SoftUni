import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IContact } from 'src/app/shared/interfaces';
import { ContactsService } from '../contacts.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss', '../../../form-style.scss']
})
export class EditComponent {

  id: string;
  name: string;
  contact: IContact;
  isLoading = false;

  form = new FormGroup({
    title: new FormControl(''),
    content: new FormControl('')
  });

  constructor(
    private contactsService: ContactsService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {
    this.id = null;
    this.id = activatedRoute.snapshot.params.id;
    this.contact = contactsService.loadPostById(this.id);
  }

  submitHandler(): void {
    this.isLoading = true;
    const title = this.form.controls['title'].value;
    const content = this.form.controls['content'].value;
    this.contactsService.updatePost(this.id, title, content);
    this.isLoading = false;
    this.router.navigate(["/list/contacts"]);
    window.location.reload();
  }

  ngOnDestroy(): void {
    this.id = null;
    this.contact = null;
    this.router.navigate(["/list/contacts"]);
  }
}
