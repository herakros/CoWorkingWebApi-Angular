import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { UserEditPasswordDTO } from 'src/app/core/models/user/UserEditPasswordDTO';
import { UserService } from 'src/app/core/services/User.service';
import { SignInUpValidator } from 'src/app/core/validators/signInUpValidator';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent implements OnInit {

  editPasswordForm: FormGroup;
  userEditPasswordDTO: UserEditPasswordDTO;

  constructor(private service: UserService, private router: Router) {
    this.editPasswordForm = new FormGroup({
      currentPassword: new FormControl("", SignInUpValidator.getRequiredValidator()),
      changedPassword: new FormControl("", SignInUpValidator.getPasswordValidator(3,50))
    });
   }

  ngOnInit() {
  }

  submit(){
    if(this.editPasswordForm.valid){
      this.userEditPasswordDTO = Object.assign({}, this.editPasswordForm.value);
      this.service.editUserPassword(this.userEditPasswordDTO).subscribe(
        () => {
          alert("Successful!");
          this.router.navigate(['user-profile']);
        },
        err => {
          alert(err);
        }
      )
    }
  }

}
