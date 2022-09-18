import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { ReservedBooking } from 'src/app/core/models/booking/ReservedBooking';
import { UnReservedBooking } from 'src/app/core/models/booking/UnReservedBooking';
import { AuthenticationService } from 'src/app/core/services/Authentication.service';
import { HomeService } from 'src/app/core/services/Home.service';
import { SubscribeUserModelComponent } from '../SubscribeUserModel/SubscribeUserModel.component';

@Component({
  selector: 'app-booking-list',
  templateUrl: './booking-list.component.html',
  styleUrls: ['./booking-list.component.css']
})
export class BookingListComponent implements OnInit {

  reservedBookings: ReservedBooking[];
  unReservedBooking: UnReservedBooking[];

  constructor(private service: HomeService,
    private authService: AuthenticationService,
    private modalService: NgbModal) { }

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

  openFormModal(bookingId: number) {
    const modalRef = this.modalService.open(SubscribeUserModelComponent);
    modalRef.componentInstance.bookingId = bookingId;
    modalRef.result.then();
  }
}
