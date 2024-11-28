import { HttpClient, HttpHeaders, HttpParams} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { enviroment } from '../../enviroments/enviroment.development';
import { Observable,map } from 'rxjs';
import { LoginRequest} from '../../interfaces/login-requests';
import { AuthResponse } from '../../interfaces/auth-response';
import {jwtDecode} from 'jwt-decode';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
 
  apiUrl: string = enviroment.apiUrl;
  private tokenKey = 'token';

  constructor(private http: HttpClient) {}
  login(data: LoginRequest): Observable<AuthResponse> {
  const params = new HttpParams()
  .set('Email',data.email)
  .set('Password', data.password);
    // fix for data sending; the login request from interface has different structure
  return this.http
      .post<AuthResponse>(`${this.apiUrl}/Account/login`, data, {params})
      .pipe(
        map((response) => {
          if (response.isSuccess) {
            console.log(response.token); // delete this later; for debugging
            localStorage.setItem(this.tokenKey, response.token);
          }else{
            console.log("token not received or unsuccessful login");
          }
          return response;
        })
      );
  }

  getUserDetail = () => {
    const token = this.getToken();
    if (!token) return null;
    const decodedToken: any = jwtDecode(token);
    const userDetail = {
      id: decodedToken.nameid,
      fullName: decodedToken.name,
      email: decodedToken.email,
      roles: decodedToken.role || [],
    };

    return userDetail;
  };

  isLoggedIn=():boolean =>{
    const token = this.getToken();
    if(!token) return false;

    return !this.isTokenExpired();
  }

  private isTokenExpired() {
    const token = this.getToken();
    if (!token) return true;
    const decoded = jwtDecode(token);
    const isTokenExpired = Date.now() >= decoded['exp']! * 1000;
    if (isTokenExpired) this.logout();
    if(isTokenExpired) this.logout();
    return isTokenExpired;
  }

  logout = (): void => {
    localStorage.removeItem(this.tokenKey);
  };

  private getToken = ():string|null => localStorage.getItem(this.tokenKey) || '';
    
}


