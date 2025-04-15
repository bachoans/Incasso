import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms'; // Import FormsModule
import { CommonModule } from '@angular/common';
import { AuthService } from '../../shared/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration',
  standalone: true,
  imports: [CommonModule, FormsModule], // Add FormsModule here
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {
  registrationModel = {
    companyName: '',
    address: '',
    city: '',
    postalCode: '',
    country: '',
    companyEmail: '',
    phone: '',
    name: '',
    email: '',
    password: '',
    confirmPassword: '',
  };
  
  successMessage = '';
  errorMessage = '';

  constructor(private authService: AuthService, private router: Router) {}

  

  onSubmit(registrationForm: any): void {
    if (registrationForm.valid) {
      this.authService.register(this.registrationModel).subscribe(
        (response) => {
          this.successMessage = 'Registration successful! Redirecting to login...';
          this.errorMessage = '';
          setTimeout(() => {
            this.router.navigate(['/login']);
          }, 3000); // Redirect after 3 seconds
        },
        (error) => {
          this.successMessage = '';
          this.errorMessage = error.error?.message || 'Registration failed. Please try again.';
        }
      );
    }
}
}
