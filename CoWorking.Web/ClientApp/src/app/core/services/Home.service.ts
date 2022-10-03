import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { bookingInfoUrl, reservedBookingListUrl, unReservedBookingListUrl } from 'src/app/configs/api-endpoints';
import { BookingInfoDTO } from '../models/booking/BookingInfoDTO';
import { ReservedBooking } from '../models/booking/ReservedBooking';
import { UnReservedBooking } from '../models/booking/UnReservedBooking';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private http: HttpClient) { }

  getReservedBooking() : Observable<ReservedBooking[]> {
    return this.http.get<ReservedBooking[]>(reservedBookingListUrl);
  }

  getUnReservedBooking() : Observable<UnReservedBooking[]> {
    return this.http.get<UnReservedBooking[]>(unReservedBookingListUrl);
  }

  getBookingById(id: number) : Observable<BookingInfoDTO> {
    return this.http.get<BookingInfoDTO>(bookingInfoUrl + id);
  }
}
