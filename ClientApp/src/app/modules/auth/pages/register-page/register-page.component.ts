import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/services/auth.service';
import { User } from 'src/app/shared/models/user.model';

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.scss']
})
export class RegisterPageComponent implements OnInit {

  registerForm!: FormGroup;
  currentUser: User | undefined;

  constructor(public authService: AuthService, private router: Router) {}

  ngOnInit() {
    this.registerForm = new FormGroup({
      name: new FormControl(null, Validators.required),
      username: new FormControl(null, Validators.required),
      password: new FormControl(null, Validators.required),
      type: new FormControl('buyer', Validators.required)
    });
  }

  onSubmit(): void {
    const user = Object.assign({}, this.registerForm.value);
    this.authService.register(user).subscribe((next) => {
      this.router.navigate(['/login']);
    });
  }

  loggedIn(): boolean {
    return this.authService.loggedIn();
  }
}
