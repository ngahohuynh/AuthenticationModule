import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/services/auth.service';
import { User } from 'src/app/shared/models/user.model';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss'],
})
export class LoginPageComponent implements OnInit {
  loginForm!: FormGroup;
  currentUser: User | undefined;

  constructor(public authService: AuthService, private router: Router) {}

  ngOnInit() {
    this.loginForm = new FormGroup({
      username: new FormControl(null, Validators.required),
      password: new FormControl(null, Validators.required),
    });
  }

  onSubmit(): void {
    const user = Object.assign({}, this.loginForm.value);
    this.authService.login(user).subscribe((next) => {
      this.currentUser = this.authService.currentUser;
      this.router.navigate(['/home']);
    });
  }

  loggedIn(): boolean {
    return this.authService.loggedIn();
  }
}
