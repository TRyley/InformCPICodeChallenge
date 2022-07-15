import { getTestBed, TestBed, waitForAsync } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ContactService } from './Services/contact.service';
import { Contact } from './Models/Contact';
import { of } from 'rxjs';


describe('AppComponent', () => {
  let component: AppComponent;
  let service: ContactService;
  let testContacts: Contact[] = [];

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule,
      ],
      declarations: [
        AppComponent
      ],
    }).compileComponents();

    for (let i = 1; i <= 10; i++) {
      testContacts.push({
        id : i,
        name : `testName_${i}`,
        email : `testEmail_${i}`,
        phoneNum : `testPhone_${i}`,
        address : `testAddress${i}`
      });
    }
    let injector = getTestBed();
    service = injector.inject(ContactService);
    let fixture = TestBed.createComponent(AppComponent);
    component = fixture.componentInstance;
  }));

  it('should create the app', () => {
    expect(component).toBeTruthy();
  });

  it('should get all contacts on init', () => {
    let serviceSpy = spyOn(service, 'getAllContacts').and.returnValue(of(testContacts));
    component.ngOnInit();

    expect(serviceSpy).toHaveBeenCalledTimes(1);
  })

  it('should display all contacts', () => {
    spyOn(service, 'getAllContacts').and.returnValue(of(testContacts));

    expect(component.hasContacts).toBeFalsy();

    component.ngOnInit();

    expect(component.hasContacts).toBeTruthy();
  })

  it('should call correct service method on edit', () => {
    spyOn(service, 'getAllContacts').and.returnValue(of(testContacts));
    let serviceSpy = spyOn(service, 'editContact').and.callFake(() => {return of(Object)});

    const updatedContact = testContacts[1];
    updatedContact.name = "newName";

    component.onEditClick(updatedContact);

    expect(serviceSpy).toHaveBeenCalledWith(updatedContact);
  })

  it('should call correct service method on submit', () => {
    spyOn(service, 'getAllContacts').and.returnValue(of(testContacts));
    let serviceSpy = spyOn(service, 'addContact').and.callFake(() => { return of(Object) });

    const newContact = new Contact();
    newContact.name = "newName";
    newContact.email = "newEmail";
    newContact.phoneNum = "newPhoneNum";
    newContact.address = "newAddress";

    component.contactForm.setValue({
      name: newContact.name,
      email: newContact.email,
      phoneNum: newContact.phoneNum,
      address: newContact.address
    });

    component.onSubmit();

    expect(serviceSpy).toHaveBeenCalledWith(newContact);
  })

  it('should clear inputs after adding a component', () => {
    spyOn(service, 'getAllContacts').and.returnValue(of(testContacts));
    let serviceSpy = spyOn(service, 'addContact').and.callFake(() => { return of(Object) });

    component.contactForm.setValue({
      name: "name",
      email: "email",
      phoneNum: "phoneNum",
      address: "address"
    });

    component.onSubmit();

    expect(component.contactForm.get('name')?.value).toBe(null);
    expect(component.contactForm.get('email')?.value).toBe(null);
    expect(component.contactForm.get('phoneNum')?.value).toBe(null);
    expect(component.contactForm.get('address')?.value).toBe(null);
  })
});
