import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BookingInfoDTO } from 'src/app/core/models/booking/BookingInfoDTO';
import { AdminService } from 'src/app/core/services/Admin.service';

@Component({
  selector: 'app-edit-booking',
  templateUrl: './edit-booking.component.html',
  styleUrls: ['./edit-booking.component.css']
})
export class EditBookingComponent implements OnInit {

  bookingForm: FormGroup;
  bookingId: number;
  booking: BookingInfoDTO;

  constructor(private service: AdminService,
    private router: Router,
    private activateRoute: ActivatedRoute) { }

  ngOnInit() {
    this.bookingForm = new FormGroup({
      name: new FormControl("", [Validators.required]),
      description: new FormControl("", [Validators.required]),
      dateStart: new FormControl("", [Validators.required]),
      dateEnd: new FormControl("", [Validators.required])
    });

    this.activateRoute.paramMap.subscribe((x) => {
      if(x.has('id')) {
        this.bookingId = Number(x.get('id'));
        if(this.bookingId) {
          this.service.getBookingById(this.bookingId).subscribe((booking: BookingInfoDTO) => {
            this.bookingForm.get('name')?.patchValue(booking.name);
            this.bookingForm.get('description')?.patchValue(booking.description);
            this.bookingForm.get('dateStart')?.patchValue(booking.dateStart);
            this.bookingForm.get('dateEnd')?.patchValue(booking.dateEnd);
          });
        }
      }
      else {
        this.router.navigate(['admin/bookings']);
      }
    })
  }

  editBooking() {
    if(this.bookingForm.valid) {
      this.booking = <BookingInfoDTO>this.bookingForm.value;
      this.booking.id = this.bookingId;

      this.service.editBooking(this.booking).subscribe(
        () => {
          this.router.navigate(['admin/bookings']);
          alert('Successfully');
        },
        err => {
          alert(err);
        }
      );
    }
  }

}
