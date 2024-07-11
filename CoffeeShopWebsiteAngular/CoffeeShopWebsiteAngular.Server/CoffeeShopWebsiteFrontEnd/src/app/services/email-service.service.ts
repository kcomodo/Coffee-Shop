import { Injectable } from '@angular/core';
import { get } from 'https';

@Injectable({
  providedIn: 'root'
})
export class EmailServiceService {
  email: string = '';
  setEmail(emailGrabbed: string) {
    this.email = emailGrabbed;
    console.log("Setting email:",this.email)
  }
  getEmail() {
    return this.email;
  }
  constructor() { }
}
