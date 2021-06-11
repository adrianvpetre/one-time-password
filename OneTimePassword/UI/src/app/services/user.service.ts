import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Password } from '../models/password';
import {User} from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private readonly apiUrl = environment.apiUrl;

  constructor(private readonly http: HttpClient) { }
  
  public GetUsers(): Observable<User[]> {
    const url = `${this.apiUrl}api/Users`;
    return this.http.get<User[]>(url);
  }

  public GetUserPassword(id: number): Observable<Password> {
    const url =`${this.apiUrl}api/Users/${id}/Password`;
    return this.http.get<Password>(url);
  }

}
