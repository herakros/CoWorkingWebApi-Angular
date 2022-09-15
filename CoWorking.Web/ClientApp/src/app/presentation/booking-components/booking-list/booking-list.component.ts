import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ReservedBooking } from 'src/app/core/models/booking/ReservedBooking';
import { UnReservedBooking } from 'src/app/core/models/booking/UnReservedBooking';
import { HomeService } from 'src/app/core/services/Home.service';

@Component({
  selector: 'app-booking-list',
  templateUrl: './booking-list.component.html',
  styleUrls: ['./booking-list.component.css']
})
export class BookingListComponent implements OnInit {

  reservedBookings: ReservedBooking[];
  unReservedBooking: UnReservedBooking[];

  constructor(private service: HomeService, private router: Router) { }

  ngOnInit() {
    this.service.getReservedBooking().subscribe((data: ReservedBooking[]) => {
      this.reservedBookings = data;
      console.log("re")
      console.log(data)
    });
    this.service.getUnReservedBooking().subscribe((data: UnReservedBooking[]) => {
      this.unReservedBooking = data;
      console.log("un")
      console.log(data)
    });
  }

}
