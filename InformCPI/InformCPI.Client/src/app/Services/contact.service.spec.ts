import { TestBed, getTestBed, waitForAsync } from '@angular/core/testing';
import { HttpClientModule } from '@angular/common/http';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ContactService } from './contact.service';
import { Contact } from '../Models/Contact';

describe('ContactService', () => {
  let injector : TestBed;
  let httpClient: HttpTestingController;
  let service: ContactService;

  const baseAddress = 'https://localhost:7185/Contacts/';
  const testContact: Contact = {
    id : 1,
    name : "testName",
    email : "test@email.com",
    address : "123 testAddress street",
    phoneNum : "12345678901"
  };

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientModule,
        HttpClientTestingModule
      ]
    });
    injector = getTestBed();
    service = injector.inject(ContactService);
    httpClient = injector.inject(HttpTestingController);
  }));

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should call the correct endpoint for getting all contacts', () => {
    const apiEndpoint = baseAddress + 'GetAll';

    service.getAllContacts().subscribe(response => {
      expect(response).toBeDefined();
    })

    const req = httpClient.expectOne(apiEndpoint);

    expect(req.request.method).toBe('GET');

  })

  it('should call the correct endpoint for getting a single contact', () => {
    const apiEndpoint = baseAddress + 'Get/1';

    service.getContact(1).subscribe(response => {
      expect(response).toBeDefined();
    })

    const req = httpClient.expectOne(apiEndpoint);

    expect(req.request.method).toBe('GET');

  })

  it('should call the correct endpoint for adding a contact', () => {
    const apiEndpoint = baseAddress + 'Add';

    service.addContact(testContact).subscribe(response => {
      expect(response).toBeDefined();
    });

    const req = httpClient.expectOne(apiEndpoint);

    expect(req.request.method).toBe('POST');

  })

  it('should call the correct endpoint for editing a contact', () => {
    const apiEndpoint = baseAddress + 'Edit';

    service.editContact(testContact).subscribe(response => {
      expect(response).toBeDefined();
    });

    const req = httpClient.expectOne(apiEndpoint);

    expect(req.request.method).toBe('PUT');

  })
});
