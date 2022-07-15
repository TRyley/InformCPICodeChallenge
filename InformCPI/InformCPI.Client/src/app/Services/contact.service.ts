import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Contact } from '../Models/Contact';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  private baseAddress = 'https://localhost:7185/Contacts/'
  constructor(private http: HttpClient) { }

  public getAllContacts(): Observable<Contact[]> {
    return this.http.get<Contact[]>(this.baseAddress + 'GetAll');
  }

  public getContact(id: number): Observable<Contact> {
    return this.http.get<Contact>(this.baseAddress + `Get/${id}`);
  }

  public addContact(newContact: Contact): Observable<Object> {
    return this.http.post(this.baseAddress + `Add`, newContact);
  }

  public editContact(updatedContact: Contact): Observable<Object> {
    return this.http.put(this.baseAddress + `Edit`, updatedContact);
  }
}
