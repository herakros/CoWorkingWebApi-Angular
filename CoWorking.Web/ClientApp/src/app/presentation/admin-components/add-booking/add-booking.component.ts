import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AdminService } from 'src/app/core/services/Admin.service';

@Component({
  selector: 'app-add-booking',
  templateUrl: './add-booking.component.html',
  styleUrls: ['./add-booking.component.css']
})
export class AddBookingComponent implements OnInit {

  bookingForm: FormGroup;

  constructor(private authService: AdminService,
    private router: Router) { }

  ngOnInit() {
  }

}
