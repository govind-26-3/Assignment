import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthResponseModel, Login } from '../models/login';
import { Observable } from 'rxjs/internal/Observable';
import { Register, RegistrationResponse } from '../models/register';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private baseUrl = 'https://localhost:7252/api/Auth';
//https://localhost:7252/api/Auth/login
//https://localhost:7252/api/Auth/register
  constructor(private http:HttpClient) {}

  login(loginData:Login):Observable<AuthResponseModel>{
    return this.http.post<AuthResponseModel>(`${this.baseUrl}/login`,loginData)
  }

  register(registerData: Register): Observable<RegistrationResponse> {
    return this.http.post<RegistrationResponse>(`${this.baseUrl}/register`, registerData);
  }

  isLoggedIn(): boolean {
    return localStorage.getItem('token') !== null;
  }
}
