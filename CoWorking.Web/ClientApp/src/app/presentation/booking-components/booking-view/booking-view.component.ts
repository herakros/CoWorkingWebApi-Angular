import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BookingInfoDTO } from 'src/app/core/models/booking/BookingInfoDTO';
import { AddCommentDTO } from 'src/app/core/models/comment/AddCommentDTO';
import { AuthenticationService } from 'src/app/core/services/Authentication.service';
import { DeveloperService } from 'src/app/core/services/Developer.service';
import { CommentService } from 'src/app/core/services/Comment.service';
import { HomeService } from 'src/app/core/services/Home.service';
import { UserBookingDTO } from 'src/app/core/models/user/UserBookingDTO';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ChangeBookingModalComponent } from '../ChangeBookingModal/ChangeBookingModal.component';

@Component({
  selector: 'app-booking-view',
  templateUrl: './booking-view.component.html',
  styleUrls: ['./booking-view.component.css']
})
export class BookingViewComponent implements OnInit {

  bookingId: number;
  bookingInfo: BookingInfoDTO;

  isUserReservation: boolean;

  commentForm: FormGroup;
  comment: AddCommentDTO = new AddCommentDTO();

  constructor(private homeService: HomeService,
    private activateRoute: ActivatedRoute,
    private router: Router,
    private authService: AuthenticationService,
    private commentService: CommentService,
    private developerService: DeveloperService,
    private modalService: NgbModal) {
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

    let model = new UserBookingDTO();
    model.userId = this.authService.currentUser.id,
    model.bookingId = this.bookingId

    this.developerService.isItUserBooking(model).subscribe((data: boolean) => {
      if(data){
        this.isUserReservation = true;
      }
      else{
        this.isUserReservation = false;
      }
    })
  }

  addComment() {
    if(this.commentForm.valid){
      this.comment = Object.assign({}, this.commentForm.value);
      this.comment.bookingId = this.bookingId;
      this.comment.userId = this.authService.currentUser.id;
      this.commentService.addComment(this.comment).subscribe(
        (data) => {
          console.log(data);
          this.bookingInfo.comments.push(data);

          this.commentForm.reset();
        },
        err => {
          alert(err.error);
        });
    }
  }

  openFormModal() {
    const modalRef = this.modalService.open(ChangeBookingModalComponent);
    modalRef.componentInstance.bookingId = this.bookingId;
    modalRef.result.then();
  }
}
