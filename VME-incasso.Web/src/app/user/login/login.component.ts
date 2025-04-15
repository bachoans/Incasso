import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../shared/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
  ],
})
export class LoginComponent {
  username = '';
  password = '';
  error = '';
  loading = false;
  constructor(private authService: AuthService, private router: Router) {}

  login(): void {
    this.loading = true;
    this.error = '';

    this.authService.login(this.username, this.password).subscribe(
      () => {
        this.loading = false;
        this.router.navigate(['/debt']);
      },
      (err) => {
        this.loading = false;
        this.error = 'Invalid username or password';
      }
    );
  }  
}

