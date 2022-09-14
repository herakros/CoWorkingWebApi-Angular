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
  userForRegister: UserRegister;

  constructor(private service: AuthenticationService, private router: Router) {
    this.registerForm = new FormGroup({
      name: new FormControl("", SignInUpValidator.getNameValidator(3,50)),
      surname: new FormControl("", SignInUpValidator.getNameValidator(3,50)),
      userName: new FormControl("", SignInUpValidator.getUserNameValidator(3,50)),
      email: new FormControl("", SignInUpValidator.getEmailValidator()),
      role: new FormControl("", SignInUpValidator.getRequiredValidator()),
      password: new FormControl("", SignInUpValidator.getPasswordValidator(8,50))
    });
  }

  ngOnInit() {
  }

  submit() {
    if(this.registerForm.valid){
      this.userForRegister = Object.assign({}, this.registerForm.value);
      this.service.register(this.userForRegister).subscribe(
        () => {
          this.router.navigate(['login']);
        },
        err => {
          alert(err);
        }
      )
    }
  }
}
