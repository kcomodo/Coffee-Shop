import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';

//default components whenever created
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  //Declare variables, these variables are assigned through the html fields. ([ngModel])
  //ngModel binds an input, select, textarea (or custom form control) to a property on the scope
  //Responsible for binding the view into the model, which other directives such as input, textarea or select require.
  firstname: string = '';
  lastname: string = '';
  email: string = '';
  phone: string = '';
  password: string = '';

  //Inject the AuthService and Router into the constructor
  constructor(private authService: AuthService, private router: Router) { }
  //onRegister is called by pressing the register button through html, it will call authService methods specifically registerUser
  //assign the input values using ngModel onto the parameters
  onRegister(): void {
    this.authService.registerUser(this.firstname, this.lastname, this.email, this.phone, this.password).subscribe();
  }

}
