import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserLogin } from 'src/app/core/models/user/UserLogin';
import { AuthenticationService } from 'src/app/core/services/Authentication.service';
import { SignInUpValidator } from 'src/app/core/validators/signInUpValidator';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  userForLogin: UserLogin = new UserLogin();

  errorMessage: string = '';
  showError: boolean;

  constructor(private service: AuthenticationService, private router: Router) {
    this.loginForm = new FormGroup({
      email: new FormControl("", SignInUpValidator.getEmailValidator()),
      password: new FormControl("", [Validators.required])
    });
  }

  ngOnInit() {
  }

  validateControl = (controlName: string) => {
    return this.loginForm.get(controlName).invalid && this.loginForm.get(controlName).touched
  }
  hasError = (controlName: string, errorName: string) => {
    return this.loginForm.get(controlName).hasError(errorName)
  }

  submit() {
    if(this.loginForm.valid) {
      this.userForLogin = Object.assign({}, this.loginForm.value);
      this.service.login(this.userForLogin).subscribe(
        () => {
          if(this.service.currentUser.role == "Admin") {
            this.router.navigate(['admin/users']);
          }
          if(this.service.currentUser.role == "Manager") {
            this.router.navigate(['manager']);
          }
          if(this.service.currentUser.role == "Developer") {
            this.router.navigate(['developer']);
          }
        },
        err => {
          this.errorMessage = err;
        }
      )
    }
  }

}
