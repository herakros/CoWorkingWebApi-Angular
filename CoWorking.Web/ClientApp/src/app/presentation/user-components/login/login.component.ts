import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthorizationRoles } from 'src/app/configs/authorization-roles';
import { UserLogin } from 'src/app/core/models/user/UserLogin';
import { AuthenticationService } from 'src/app/core/services/Authentication.service';
import { EventEmitterService } from 'src/app/core/services/EventEmitter.service';
import { SignInUpValidator } from 'src/app/core/validators/signInUpValidator';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  userForLogin: UserLogin = new UserLogin();

  constructor(private service: AuthenticationService,
    private router: Router,
    private eventEmitterService: EventEmitterService) {
    this.loginForm = new FormGroup({
      email: new FormControl("", SignInUpValidator.getEmailValidator()),
      password: new FormControl("", SignInUpValidator.getRequiredValidator())
    });
  }

  ngOnInit() {
  }

  submit() {
    if(this.loginForm.valid) {
      this.userForLogin = Object.assign({}, this.loginForm.value);
      this.service.login(this.userForLogin).subscribe(
        () => {
          if(this.service.currentUser.role.toString() === AuthorizationRoles[AuthorizationRoles.Admin].toString()) {
            this.router.navigate(['admin/users']);
            this.eventEmitterService.onComponentInvoke();
          }
          if(this.service.currentUser.role.toString() === AuthorizationRoles[AuthorizationRoles.Manager].toString()
          || this.service.currentUser.role.toString() === AuthorizationRoles[AuthorizationRoles.Developer].toString()) {
            this.router.navigate(['home']);
            this.eventEmitterService.onComponentInvoke();
          }
        },
        err => {
          alert(err);
        }
      )
    }
  }

}
