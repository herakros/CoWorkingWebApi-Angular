import { Component, OnInit } from '@angular/core';
import { BookingInfo } from 'src/app/core/models/booking/BookingInfo';

@Component({
  selector: 'app-bookings-list',
  templateUrl: './bookings-list.component.html',
  styleUrls: ['./bookings-list.component.css']
})
export class BookingsListComponent implements OnInit {

  bookings: BookingInfo[];
  constructor() { }

  ngOnInit() {
  }

}
