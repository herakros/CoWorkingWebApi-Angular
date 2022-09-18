import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BookingInfoDTO } from 'src/app/core/models/booking/BookingInfoDTO';
import { HomeService } from 'src/app/core/services/Home.service';

@Component({
  selector: 'app-booking-view',
  templateUrl: './booking-view.component.html',
  styleUrls: ['./booking-view.component.css']
})
export class BookingViewComponent implements OnInit {

  bookingId: number;
  bookingInfo: BookingInfoDTO;

  commentForm: FormGroup;
  comment: string;

  constructor(private homeService: HomeService,
    private activateRoute: ActivatedRoute,
    private router: Router) {
      this.commentForm = new FormGroup({
        text: new FormControl("", [Validators.required])
      });
     }

  ngOnInit() {
    this.activateRoute.paramMap.subscribe((x) => {
      if(x.has('id')) {
        this.bookingId = Number(x.get('id'));
        if(this.bookingId) {
          this.homeService.getBookingById(this.bookingId).subscribe((data: BookingInfoDTO) => {
            this.bookingInfo = data;
          });
        }
      }
      else {
        this.router.navigate(['home/bookings']);
      }
    })
  }

  addComment() {
    if(this.commentForm.valid){
      this.comment = <string>this.commentForm.value;

    }
  }
}
