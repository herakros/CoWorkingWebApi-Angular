import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';
import { map, Observable } from 'rxjs';
import { UserAuthorizationResponse } from '../models/user/UserAuthorizationResponse';
import { UserLogin } from '../models/user/UserLogin';
import { UserInfo } from '../models/user/UserInfo';
import { authenticationServiceUrl, loginUrl, logoutUrl, refreshTokenUrl, registerUrl } from 'src/app/configs/api-endpoints';
import { UserRegister } from '../models/user/UserRegister';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

private readonly userId: string = 'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier';
private readonly userName: string = 'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name';
private readonly userRole: string = 'http://schemas.microsoft.com/ws/2008/06/identity/claims/role';

private jwtHelperService = new JwtHelperService();

public currentUser: UserInfo;

constructor(private http: HttpClient, private router: Router) {
  const user = localStorage.getItem('user');

    if(user) {
      this.currentUser = JSON.parse(user);
    }
    else {
      this.currentUser = new UserInfo();
    }
  }

  public login(user: UserLogin) : Observable<void> {
    return this.http.post<UserAuthorizationResponse>(loginUrl, user).pipe(map((tokens: UserAuthorizationResponse) => {
      this.setTokensInLocalStorage(tokens);
    }))
  }

  public register(user: UserRegister) : Observable<void> {
    return this.http.post<void>(registerUrl, user);
  }

  private setTokensInLocalStorage(tokens: UserAuthorizationResponse){

    if(tokens.token && tokens.refreshToken) {
      const decodedToken = this.jwtHelperService.decodeToken(tokens.token);

      this.currentUser.id = decodedToken[this.userId];
      this.currentUser.username = decodedToken[this.userName];
      this.currentUser.role = decodedToken[this.userRole];

      localStorage.setItem('token', tokens.token);
      localStorage.setItem('refreshToken', tokens.refreshToken);
      localStorage.setItem('user', JSON.stringify(this.currentUser));

      this.router.navigate(['']);
    }
  }

  public logout(): Observable<void> {

    let tokens: UserAuthorizationResponse = new UserAuthorizationResponse();
    tokens.token = localStorage.getItem('token')?.toString()!;
    tokens.refreshToken = localStorage.getItem('refreshToken')?.toString()!;

    return this.http.post<UserAuthorizationResponse>(logoutUrl, tokens).pipe(map(() => {
      localStorage.removeItem('token');
      localStorage.removeItem('refreshToken');
      localStorage.removeItem('user');
      this.currentUser = new UserInfo();
    }));
  }

  public refreshToken() : Observable<UserAuthorizationResponse> {

    let tokens: UserAuthorizationResponse = new UserAuthorizationResponse();
    tokens.token = localStorage.getItem('token')?.toString()!;
    tokens.refreshToken = localStorage.getItem('refreshToken')?.toString()!;

    return this.http.post<UserAuthorizationResponse>(refreshTokenUrl, tokens).pipe(map((tokens: UserAuthorizationResponse) => {

      if(tokens.token && tokens.refreshToken) {
        const decodedToken = this.jwtHelperService.decodeToken(tokens.token);

        this.currentUser.id = decodedToken[this.userId];
        this.currentUser.username = decodedToken[this.userName];
        this.currentUser.role = decodedToken[this.userRole];

        localStorage.setItem('token', tokens.token);
        localStorage.setItem('refreshToken', tokens.refreshToken);
        localStorage.setItem('user', JSON.stringify(this.currentUser));
      }

      return tokens;
    }));
  }
}
