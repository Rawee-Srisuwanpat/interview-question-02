import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {


  private api = environment.apiUrl;

  constructor(private http: HttpClient) {}

  login(data:any):Observable<any>{
    return this.http.post(`${this.api}/Auth/login`,data);
  }

  register(data:any):Observable<any>{
    return this.http.post(`${this.api}/Auth/register`,data);
  }

  getProfile(data:any):Observable<any>{
    return this.http.post(`${this.api}/Auth/getProfile`,data);
  }

}