import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ChangeBookingDTO } from 'src/app/core/models/booking/ChangeBookingDTO';
import { AuthenticationService } from 'src/app/core/services/Authentication.service';
import { DeveloperService } from 'src/app/core/services/Developer.service';

@Component({
  selector: 'app-ChangeBookingModal',
  templateUrl: './ChangeBookingModal.component.html',
  styleUrls: ['./ChangeBookingModal.component.css']
})
export class ChangeBookingModalComponent implements OnInit {

  @Input() bookingId: number;

  myForm: FormGroup;

  constructor(public activeModal: NgbActiveModal,
    private formBuilder: FormBuilder,
    private developerService: DeveloperService,
    private authService: AuthenticationService) {
      this.createForm();
     }

  private createForm() {
    this.myForm = this.formBuilder.group({
      dateEnd: new FormControl('', [Validators.required])
    });
  }

  closeModal() {
    this.activeModal.close('Modal Closed');
  }

  submitForm() {
    if(this.myForm.valid){
      let changeBookingDate = new ChangeBookingDTO();
      changeBookingDate.bookingId = this.bookingId;
      changeBookingDate.userId = this.authService.currentUser.id;
      changeBookingDate.dateOfEnd = <Date>this.myForm.value;

      this.developerService.changeBookingDateOfEnd(changeBookingDate).subscribe(
        () => {
          this.closeModal();
        },
        err => {
          alert(err);
        }
      )
    }
  }

  ngOnInit() {
  }

}
