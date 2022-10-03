import { Component, OnInit } from '@angular/core';
import { UserInfoDTO } from 'src/app/core/models/user/UserInfoDTO';
import { AdminService } from 'src/app/core/services/Admin.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

  users: UserInfoDTO[];

  constructor(private service: AdminService) { }

  ngOnInit() {
    this.service.getAllUsers().subscribe((data: UserInfoDTO[]) => {
        this.users = data;
    });
  }

  setUserRoles(){
    
  }

  deleteUser(id: string) {
    if(confirm("Are you sure to delete user?")){
      this.service.deleteUser(id).subscribe(
        () => {
          this.users.splice(this.users.findIndex(x => x.id == id), 1);
        },
        err => {
          alert(err);
        }
      );
    }
  }

}
