import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { adminBookingsUrl, adminUsersUrl } from 'src/app/configs/api-endpoints';
import { BookingInfo } from '../models/booking/BookingInfo';
import { BookingInfoDTO } from '../models/booking/BookingInfoDTO';
import { CreateBooking } from '../models/booking/CreateBooking';
import { UserInfoDTO } from '../models/user/UserInfoDTO';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private http: HttpClient) { }

  getAllUsers() : Observable<UserInfoDTO[]> {
    return this.http.get<UserInfoDTO[]>(adminUsersUrl);
  }

  getUser(id: string) : Observable<UserInfoDTO> {
    return this.http.get<UserInfoDTO>(adminUsersUrl + id);
  }

  deleteUser(id: string) {
    return this.http.delete(adminUsersUrl + id);
  }

  editUser(user: UserInfoDTO) {
    return this.http.put(adminUsersUrl, user);
  }

  createBooking(booking: CreateBooking) : Observable<void> {
    return this.http.post<void>(adminBookingsUrl, booking);
  }

  getAllBookings() : Observable<BookingInfo[]> {
    return this.http.get<BookingInfo[]>(adminBookingsUrl);
  }

  deleteBooking(id: number) {
    return this.http.delete(adminBookingsUrl + id);
  }

  editBooking(booking: BookingInfoDTO) {
    return this.http.put(adminBookingsUrl, booking);
  }

  getBookingById(id: number) : Observable<BookingInfoDTO>{
    return this.http.get<BookingInfoDTO>(adminBookingsUrl + id);
  }

}
