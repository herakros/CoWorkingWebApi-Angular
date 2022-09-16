import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { bookingInfoUrl, reservedBookingListUrl, unReservedBookingListUrl } from 'src/app/configs/api-endpoints';
import { ReservedBooking } from '../models/booking/ReservedBooking';
import { UnReservedBooking } from '../models/booking/UnReservedBooking';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  private httpOption = {
    headers: new HttpHeaders({
        Authorization: 'Bearer ' + this.getToken()
    })
  };

  private getToken(): any{
    return localStorage.getItem('token')?.toString();
  }

  constructor(private http: HttpClient) { }

  getReservedBooking() : Observable<ReservedBooking[]> {
    return this.http.get<ReservedBooking[]>(reservedBookingListUrl, this.httpOption);
  }

  getUnReservedBooking() : Observable<UnReservedBooking[]> {
    return this.http.get<UnReservedBooking[]>(unReservedBookingListUrl, this.httpOption);
  }

  getBookingById(id: number) : Observable<void> {
    return this.http.get<void>(bookingInfoUrl + id, this.httpOption);
  }
}
