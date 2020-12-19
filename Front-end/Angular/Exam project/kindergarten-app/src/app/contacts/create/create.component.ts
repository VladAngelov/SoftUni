import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { ContactsService } from '../contacts.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss', '../../../form-style.scss']
})
export class CreateComponent implements OnInit {

  form = new FormGroup({
    title: new FormControl(''),
    content: new FormControl('')
  });

  isLoading = false;

  constructor(
    private contactsService: ContactsService,
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  submitHandler(): void {
    this.isLoading = true;
    debugger;
    const name = this.form.controls['title'].value;
    const content = this.form.controls['content'].value;
    const createdAt = new Date();

    this.contactsService.createPost(name, content, createdAt.toLocaleString());

    this.isLoading = false;
    this.router.navigate(['/list/contacts']);
  }
}
