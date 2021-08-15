import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AuthService } from 'src/app/core/services/auth.service';
import { HomeService } from 'src/app/core/services/home.service';
import { User } from 'src/app/shared/models/user.model';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss']
})
export class HomePageComponent implements OnInit {

  currentUser: User | undefined;
  message!: Observable<string>;

  constructor(private authService: AuthService, private homeService: HomeService) { }

  ngOnInit() {
    this.currentUser = this.authService.currentUser;
    this.message = this.homeService.getMessage().pipe(
      map(response => response.message)
    );
  }

}
