import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { editUserPasswordUrl, editUserPersonalInfodUrl, getUserProfileInfoUrl } from 'src/app/configs/api-endpoints';
import { UserEditPasswordDTO } from '../models/user/UserEditPasswordDTO';
import { UserEditPersonalInfoDTO } from '../models/user/UserEditPersonalInfoDTO';
import { UserProfileDTO } from '../models/user/UserProfileDTO';

@Injectable({
  providedIn: 'root'
})
export class UserService {

constructor(private http: HttpClient) { }

getUserInfo() : Observable<UserProfileDTO>{
  return this.http.get<UserProfileDTO>(getUserProfileInfoUrl);
}

editUserPassword(model: UserEditPasswordDTO) : Observable<void>{
  return this.http.put<void>(editUserPasswordUrl, model);
}

editUserPersonalInfo(model: UserEditPersonalInfoDTO) : Observable<void>{
  return this.http.put<void>(editUserPersonalInfodUrl, model);
}
}
