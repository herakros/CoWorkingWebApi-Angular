import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { addBookingUrl, adminDeleteUserUrl, adminEditUserUrl, adminGetUsersUrl, adminGetUserUrl } from 'src/app/configs/api-endpoints';
import { CreateBooking } from '../models/booking/CreateBooking';
import { UserInfoDTO } from '../models/user/UserInfoDTO';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  private httpOption = {
    headers: new HttpHeaders({
        Authorization: 'Bearer ' + this.getToken()
    })
  };

  private getToken(): any{
    return localStorage.getItem('token')?.toString();
  }

  constructor(private http: HttpClient) { }

  getAllUsers() : Observable<UserInfoDTO[]> {
    return this.http.get<UserInfoDTO[]>(adminGetUsersUrl, this.httpOption);
  }

  getUser(id: string) : Observable<UserInfoDTO> {
    return this.http.get<UserInfoDTO>(adminGetUserUrl + id, this.httpOption);
  }

  deleteUser(id: string) {
    return this.http.delete(adminDeleteUserUrl + id, this.httpOption);
  }

  editUser(user: UserInfoDTO) {
    return this.http.put(adminEditUserUrl, user, this.httpOption);
  }

  createBooking(booking: CreateBooking) : Observable<void>{
    return this.http.post<void>(addBookingUrl, booking, this.httpOption);
  }

}
