import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Contact } from './Models/Contact';
import { ContactService } from './Services/contact.service';
import { take } from 'rxjs/operators';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  public title = 'Contacts App';
  public hasContacts = false;
  public contacts: Contact[];

  public contactForm = new FormGroup({
    name: new FormControl(''),
    email: new FormControl(''),
    phoneNum: new FormControl(''),
    address: new FormControl(''),
  });

  constructor(private service: ContactService) {
    this.contacts = [];
  }

  ngOnInit(): void {
    this.getAll();
  }

  onEditClick(updatedContact: Contact) {
    this.service.editContact(updatedContact).subscribe(
      (response) => {
        console.log("contact successfully edited");
        this.getAll()
      },
      error => this.catchError(error));
  }

  onSubmit() {
    let newContact = new Contact();

    newContact.name = this.contactForm.get('name')?.value;
    newContact.email = this.contactForm.get('email')?.value;
    newContact.phoneNum = this.contactForm.get('phoneNum')?.value;
    newContact.address = this.contactForm.get('address')?.value;

    this.service.addContact(newContact).subscribe(
      (response) => {
        console.log("contact successfully added");
        this.getAll();

        this.contactForm.reset();
      },
      error => this.catchError(error));
  }

  private getAll() {
    this.service.getAllContacts().pipe(take(1)).subscribe((result: Contact[]) => {
      this.contacts = result;
      this.hasContacts = result.length > 0;
      console.log()
    }, error => this.catchError(error));
  }

  private catchError(error: HttpErrorResponse) {
    console.log(`An error occured: ${error.error} : ${error.message}`);
  }
}
