import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CreateBooking } from 'src/app/core/models/booking/CreateBooking';
import { AdminService } from 'src/app/core/services/Admin.service';

@Component({
  selector: 'app-add-booking',
  templateUrl: './add-booking.component.html',
  styleUrls: ['./add-booking.component.css']
})
export class AddBookingComponent implements OnInit {

  bookingForm: FormGroup;
  private createBooking: CreateBooking;

  constructor(private service: AdminService,
    private router: Router) {
      this.bookingForm = new FormGroup({
        name: new FormControl("", [Validators.required]),
        description: new FormControl("", [Validators.required])
      });
     }

  ngOnInit() {
  }

  submit(){
    if(this.bookingForm.valid) {
      this.createBooking = <CreateBooking>this.bookingForm.value;

      this.service.createBooking(this.createBooking).subscribe(
        () => {
          this.router.navigate(['admin/bookings']);
          alert('Successfully');
        },
        err => {
          alert(err);
        }
      )
    }
  }

}
