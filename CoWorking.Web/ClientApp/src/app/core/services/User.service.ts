import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { getUserProfileInfoUrl } from 'src/app/configs/api-endpoints';
import { UserProfileDTO } from '../models/user/UserProfileDTO';

@Injectable({
  providedIn: 'root'
})
export class UserService {

constructor(private http: HttpClient) { }

getUserInfo() : Observable<UserProfileDTO>{
  return this.http.get<UserProfileDTO>(getUserProfileInfoUrl);
}

}
