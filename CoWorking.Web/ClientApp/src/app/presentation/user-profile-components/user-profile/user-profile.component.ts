import { Component, OnInit } from '@angular/core';
import { UserProfileDTO } from 'src/app/core/models/user/UserProfileDTO';
import { UserService } from 'src/app/core/services/User.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

  userInfo: UserProfileDTO;
  constructor(private userService: UserService) { }

  ngOnInit() {
    this.userService.getUserInfo().subscribe((data: UserProfileDTO) => {
      this.userInfo = data;
    });
  }

}
