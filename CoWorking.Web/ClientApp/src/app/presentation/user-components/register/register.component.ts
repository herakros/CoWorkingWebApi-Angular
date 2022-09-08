import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserRegister } from 'src/app/core/models/user/UserRegister';
import { AuthenticationService } from 'src/app/core/services/Authentication.service';
import { SignInUpValidator } from 'src/app/core/validators/signInUpValidator';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;
  userForRegister: UserRegister = new UserRegister();

  errorMessage: string = '';
  showError: boolean;

  constructor(private service: AuthenticationService, private router: Router) {
    this.registerForm = new FormGroup({
      name: new FormControl("", SignInUpValidator.getNameValidator(3,50)),
      surname: new FormControl("", SignInUpValidator.getNameValidator(3,50)),
      userName: new FormControl("", SignInUpValidator.getNameValidator(3,50)),
      email: new FormControl("", SignInUpValidator.getEmailValidator()),
      role: new FormControl("", [Validators.required]),
      password: new FormControl("", SignInUpValidator.getRequiredValidator())
    });
  }

  ngOnInit() {
  }

  validateControl = (controlName: string) => {
    return this.registerForm.get(controlName).invalid && this.registerForm.get(controlName).touched
  }
  hasError = (controlName: string, errorName: string) => {
    return this.registerForm.get(controlName).hasError(errorName)
  }

  submit() {
    if(this.registerForm.valid){
      this.userForRegister = Object.assign({}, this.registerForm.value);
      this.service.register(this.userForRegister).subscribe(
        () => {
          this.router.navigate(['login']);
        },
        err => {
          this.errorMessage = err;
        }
      )
    }
  }
}
