import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { changeBookingDateUrl, isDeveloperHasReservationUrl, isItUserBookingUrl } from 'src/app/configs/api-endpoints';
import { ChangeBookingDTO } from '../models/booking/ChangeBookingDTO';
import { UserBookingDTO } from '../models/user/UserBookingDTO';
import { UserId } from '../models/user/UserId';
import { UserReservation } from '../models/user/UserReservation';

@Injectable({
  providedIn: 'root'
})
export class DeveloperService {

  private httpOption = {
    headers: new HttpHeaders({
        Authorization: 'Bearer ' + this.getToken()
    })
  };

  private getToken(): any{
    return localStorage.getItem('token')?.toString();
  }

  constructor(private http: HttpClient) { }

  isUserHasReservation(user: UserId) : Observable<UserReservation>{
    return this.http.post<UserReservation>(isDeveloperHasReservationUrl, user, this.httpOption);
  }

  isItUserBooking(userBookingDTO: UserBookingDTO) : Observable<boolean>{
    return this.http.post<boolean>(isItUserBookingUrl, userBookingDTO, this.httpOption);
  }

  changeBookingDateOfEnd(changeBookingDTO: ChangeBookingDTO) : Observable<void>{
    return this.http.put<void>(changeBookingDateUrl, changeBookingDTO, this.httpOption);
  }

}
