import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { isDeveloperHasReservationUrl } from 'src/app/configs/api-endpoints';
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

}
