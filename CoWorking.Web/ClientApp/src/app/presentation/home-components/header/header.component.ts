import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthorizationRoles } from 'src/app/configs/authorization-roles';
import { UserId } from 'src/app/core/models/user/UserId';
import { UserReservation } from 'src/app/core/models/user/UserReservation';
import { AuthenticationService } from 'src/app/core/services/Authentication.service';
import { DeveloperService } from 'src/app/core/services/Developer.service';
import { EventEmitterService } from 'src/app/core/services/EventEmitter.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  isUserAuthorization: boolean;
  AuthorizationRoles: AuthorizationRoles;

  constructor(private authService: AuthenticationService,
    private router: Router,
    private developerService: DeveloperService,
    private eventEmitterService: EventEmitterService) {
      if(this.eventEmitterService.subsVar == undefined) {
        this.eventEmitterService.subsVar = this.eventEmitterService.
        invokeComponentFunction.subscribe(() => {
          this.ngOnInit();
        });
      }
  }

  ngOnInit() {
    if(!this.authService.currentUser.isAuth){
      this.isUserAuthorization = true;
    }
    else{
      this.isUserAuthorization = false;
    }
  }

  logout() {
    this.authService.logout().subscribe(
      () => {
        this.ngOnInit();
        this.router.navigate(['']);
      }
    )
  }

  getRole() : string {
    return this.authService.currentUser.role;
  }

  isUserHasReservation() {
    let user = new UserId();
    user.id = this.authService.currentUser.id;

    this.developerService
    .isUserHasReservation(user)
    .subscribe((data: UserReservation) => {
      if(data.isReservation){
        this.router.navigate([`/home/bookings/${data.bookingId}`]);
      }
      else{
        alert("You don`t have any reservation!");
      }
    });
  }

}
