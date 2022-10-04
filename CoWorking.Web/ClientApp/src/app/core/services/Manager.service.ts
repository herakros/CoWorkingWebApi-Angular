import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { subscribeUserUrl } from 'src/app/configs/api-endpoints';
import { UserSubscribeToBooking } from '../models/user/UserSubscribeToBooking';

@Injectable({
  providedIn: 'root'
})
export class ManagerService {

  constructor(private http: HttpClient) { }

  subscribeUser(model: UserSubscribeToBooking) : Observable<void>{
    return this.http.post<void>(subscribeUserUrl, model);
  }

}
