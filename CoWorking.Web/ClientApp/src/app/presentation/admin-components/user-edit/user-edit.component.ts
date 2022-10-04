import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthorizationRoles } from 'src/app/configs/authorization-roles';
import { UserInfoDTO } from 'src/app/core/models/user/UserInfoDTO';
import { AdminService } from 'src/app/core/services/Admin.service';
import { SignInUpValidator } from 'src/app/core/validators/signInUpValidator';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.css']
})
export class UserEditComponent implements OnInit {

  formUser: FormGroup;
  userId: string;
  user: UserInfoDTO;

  public get userRoles(): typeof AuthorizationRoles {
    return AuthorizationRoles;
  }

  constructor(private service: AdminService,
    private router: Router,
    private activateRoute: ActivatedRoute) { }

  ngOnInit() {
    this.formUser = new FormGroup({
      name: new FormControl("", SignInUpValidator.getNameValidator(3,50)),
      surname: new FormControl("", SignInUpValidator.getNameValidator(3,50)),
      userName: new FormControl("", SignInUpValidator.getUserNameValidator(3,50)),
      email: new FormControl("", SignInUpValidator.getEmailValidator()),
      role: new FormControl("",  SignInUpValidator.getRequiredValidator())
    });

    this.activateRoute.paramMap.subscribe((x) => {
      if(x.has('id')) {
        this.userId = x.get('id') || "";
        if(this.userId) {
          this.service.getUser(this.userId).subscribe((user: UserInfoDTO) => {
            console.log(user);
            this.formUser.get('name')?.patchValue(user.name);
            this.formUser.get('surname')?.patchValue(user.surname);
            this.formUser.get('userName')?.patchValue(user.userName);
            this.formUser.get('email')?.patchValue(user.email);
            this.formUser.get('role')?.patchValue(AuthorizationRoles[user.role]);
          });
        }
      }
      else {
        this.router.navigate(['admin/users']);
      }
    })
  }

  editUser() {
      this.user = <UserInfoDTO>this.formUser.value;
      this.user.id = this.userId;

      this.service.editUser(this.user).subscribe(
        () => {
          this.router.navigate(['admin/users']);
          alert('Successfully');
        },
        err => {
          alert(err);
        }
      )
    }
}
