import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ReservedBooking } from 'src/app/core/models/booking/ReservedBooking';
import { UnReservedBooking } from 'src/app/core/models/booking/UnReservedBooking';
import { AuthenticationService } from 'src/app/core/services/Authentication.service';
import { HomeService } from 'src/app/core/services/Home.service';

@Component({
  selector: 'app-booking-list',
  templateUrl: './booking-list.component.html',
  styleUrls: ['./booking-list.component.css']
})
export class BookingListComponent implements OnInit {

  reservedBookings: ReservedBooking[];
  unReservedBooking: UnReservedBooking[];

  constructor(private service: HomeService,
    private authService: AuthenticationService) { }

  ngOnInit() {
    this.service.getReservedBooking().subscribe((data: ReservedBooking[]) => {
      this.reservedBookings = data;
    });
    this.service.getUnReservedBooking().subscribe((data: UnReservedBooking[]) => {
      this.unReservedBooking = data;
    });
  }

  getUserRole() : string{
    return this.authService.currentUser.role;
  }
}
