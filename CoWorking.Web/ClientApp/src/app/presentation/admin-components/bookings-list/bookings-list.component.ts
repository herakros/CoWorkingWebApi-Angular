import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookingInfo } from 'src/app/core/models/booking/BookingInfo';
import { AdminService } from 'src/app/core/services/Admin.service';

@Component({
  selector: 'app-bookings-list',
  templateUrl: './bookings-list.component.html',
  styleUrls: ['./bookings-list.component.css']
})
export class BookingsListComponent implements OnInit {

  bookings: BookingInfo[];
  constructor(private service: AdminService) { }

  ngOnInit() {
    this.service.getAllBookings().subscribe((data: BookingInfo[]) => {
      this.bookings = data;
    });
  }

  deleteBooking(id: number) {
    if(confirm("Are you sure to delete user?")){
      this.service.deleteBooking(id).subscribe(
        () => {
          this.bookings.splice(this.bookings.findIndex(x => x.id == id), 1);
        },
        err => {
          alert(err);
        }
      );
    }
  }

}
