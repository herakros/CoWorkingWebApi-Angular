import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { UserEditPersonalInfoDTO } from 'src/app/core/models/user/UserEditPersonalInfoDTO';
import { UserProfileDTO } from 'src/app/core/models/user/UserProfileDTO';
import { UserService } from 'src/app/core/services/User.service';
import { SignInUpValidator } from 'src/app/core/validators/signInUpValidator';

@Component({
  selector: 'app-change-user-info',
  templateUrl: './change-user-info.component.html',
  styleUrls: ['./change-user-info.component.css']
})
export class ChangeUserInfoComponent implements OnInit {

  userInfoForm: FormGroup;
  userInfoDTO: UserEditPersonalInfoDTO;
  userProfileDTO: UserProfileDTO = new UserProfileDTO();

  constructor(private service: UserService,
    private router: Router) {
      this.userInfoForm = new FormGroup({
        userName: new FormControl('', SignInUpValidator.getUserNameValidator(3,50)),
        name: new FormControl('', SignInUpValidator.getNameValidator(3,50)),
        surname: new FormControl('', SignInUpValidator.getNameValidator(3,50))
      });
  }

  ngOnInit() {
    this.service.getUserInfo().subscribe((data: UserProfileDTO) => {
      this.userProfileDTO = data;
      this.userInfoForm.patchValue(this.userProfileDTO)
    })
  }

  submit(){
    if(this.userInfoForm.valid){
      this.userInfoDTO = Object.assign({}, this.userInfoForm.value);
      this.service.editUserPersonalInfo(this.userInfoDTO).subscribe(
        () => {
          alert("Successful");
          this.router.navigate(['user-profile']);
        },
        err =>{
          alert(err);
        }
      )
    }
  }

}
