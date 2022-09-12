import { Inject } from "@angular/core";

export const baseUrl = 'https://localhost:7243' + '/api';

export const authenticationServiceUrl = baseUrl + '/Authentication/';
export const loginUrl = authenticationServiceUrl + 'login';
export const registerUrl = authenticationServiceUrl + 'registration';
export const logoutUrl = authenticationServiceUrl + 'logout';
export const refreshTokenUrl = authenticationServiceUrl + 'refresh-token';

export const adminUrl = '/admin/'
export const adminGetUsersUrl = baseUrl + adminUrl + 'users';
export const adminGetUserUrl = baseUrl + adminUrl + 'users/';
export const adminDeleteUserUrl = baseUrl + adminUrl + 'users/';
export const adminEditUserUrl = baseUrl + adminUrl + 'users';