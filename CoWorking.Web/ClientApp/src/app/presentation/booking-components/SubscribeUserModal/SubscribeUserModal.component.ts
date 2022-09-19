import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { UserSubscribeToBooking } from 'src/app/core/models/user/UserSubscribeToBooking';
import { ManagerService } from 'src/app/core/services/Manager.service';

@Component({
  selector: 'app-SubscribeUserModal',
  templateUrl: './SubscribeUserModal.component.html',
  styleUrls: ['./SubscribeUserModal.component.css']
})
export class SubscribeUserModalComponent implements OnInit {

  @Input() bookingId: number;

  myForm: FormGroup;
  userSubscribe: UserSubscribeToBooking;

  constructor(public activeModal: NgbActiveModal,
    private formBuilder: FormBuilder,
    private service: ManagerService) {
    this.createForm();
  }

  private createForm() {
    this.myForm = this.formBuilder.group({
      username: new FormControl("", [Validators.required]),
      dateStart: new FormControl("", [Validators.required]),
      dateEnd: new FormControl("", [Validators.required])
    });
  }

  submitForm() {
    if(this.myForm.valid){
      this.userSubscribe = <UserSubscribeToBooking>this.myForm.value;
      this.userSubscribe.bookingId = this.bookingId;

      this.service.subscribeUser(this.userSubscribe).subscribe(
        () => {
          alert("Succesful");
          this.closeModal();
        },
        err => {
          alert(err);
        }
      )
    }
  }

  closeModal() {
    this.activeModal.close('Modal Closed');
  }

  ngOnInit() {
  }
}
