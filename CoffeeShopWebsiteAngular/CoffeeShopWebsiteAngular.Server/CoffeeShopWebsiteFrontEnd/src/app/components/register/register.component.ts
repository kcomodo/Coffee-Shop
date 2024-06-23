import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  firstname: string = '';
  lastname: string = '';
  email: string = '';
  phone: string = '';
  password: string = '';

  constructor(private authService: AuthService, private router: Router) { }
  onRegister(): void {
    this.authService.registerUser(this.firstname, this.lastname, this.email, this.phone, this.password).subscribe();
  }

}
