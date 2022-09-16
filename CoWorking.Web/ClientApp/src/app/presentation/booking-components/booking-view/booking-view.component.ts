import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HomeService } from 'src/app/core/services/Home.service';

@Component({
  selector: 'app-booking-view',
  templateUrl: './booking-view.component.html',
  styleUrls: ['./booking-view.component.css']
})
export class BookingViewComponent implements OnInit {

  bookingId: number;

  constructor(private homeService: HomeService,
    private activateRoute: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    this.activateRoute.paramMap.subscribe((x) => {
      if(x.has('id')) {
        this.bookingId = Number(x.get('id'));
        if(this.bookingId) {
          this.homeService.getBookingById(this.bookingId).subscribe(
            () => {

            },
            err => {
              alert(err);
            }
          );
        }
      }
      else {
        this.router.navigate(['home/bookings']);
      }
    })
  }
}
