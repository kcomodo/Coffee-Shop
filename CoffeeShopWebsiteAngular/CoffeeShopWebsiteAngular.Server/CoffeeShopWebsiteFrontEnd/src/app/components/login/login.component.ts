import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  email: string = '';
  password: string = '';


  emailFormControl = new FormControl('', [Validators.required, Validators.email]);
  passwordFormControl = new FormControl('', [Validators.required]);

  constructor(private authService: AuthService, private router: Router) { }
  onLogin(): void {
    this.authService.validateLogin(this.email, this.password).subscribe(
      (response) => {
        console.log('True', response);
        // Handle successful login, e.g., redirect to dashboard
        this.router.navigate(['home']);
      },
      (error) => {
        console.error('Login failed', error);
        // Handle login error, e.g., display error message
        alert('Invalid email or password');
        console.error("email typed in", this.email);
        console.error("password typed in", this.password);
        console.error("email from control", error);
      }
    );
  }
}
