import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { enviroment } from '../../enviroments/enviroment.development';
import { Observable,map } from 'rxjs';
import { LoginRequest} from '../../interfaces/login-requests';
import { AuthResponse } from '../../interfaces/auth-response';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  apiUrl: string = enviroment.apiUrl;
  private tokenKey = 'token';

  constructor(private http: HttpClient) {}
  login(data: LoginRequest): Observable<AuthResponse> {
    let params = new HttpParams()
    .set('Email', data.email)
    .set('Password', data.password);

  // Send the data as query parameters
  return this.http
    .post<AuthResponse>(`${this.apiUrl}/Account/login`, null, { params })
    .pipe(
      map((response) => {
        if (response.isSucces) {
          localStorage.setItem(this.tokenKey, response.token);
          console.log('Token:', response.token);
        }
        return response;
      })
    );
  }
    
}
