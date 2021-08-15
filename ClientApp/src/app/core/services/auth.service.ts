import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from 'src/app/shared/models/user.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl = 'api/auth/';
  public currentUser: User | undefined;

  constructor(private http: HttpClient) { }

  login(model: any): Observable<void> {
    return this.http.post<any>(this.baseUrl + 'login/', model)
      .pipe(
        map(
          (response: any) => {
            const userToken = response;
            if (userToken) {
              localStorage.setItem('token', userToken.token);
              localStorage.setItem('user', JSON.stringify(userToken.user));
              this.currentUser = userToken.user;
            }
          }
        )
      );
  }

  register(model: User): Observable<User> {
    return this.http.post<User>(this.baseUrl + 'register', model);
  }

  loggedIn(): boolean {
    const token = localStorage.getItem('token');
    return !!token;
  }

  logout(): void {
    localStorage.removeItem('token');
    localStorage.removeItem('user');
  }

}
