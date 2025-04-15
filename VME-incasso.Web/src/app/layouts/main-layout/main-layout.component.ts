import { Component, OnInit } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { AuthService } from '../../shared/services/auth.service';

@Component({
  standalone: true,
  imports: [RouterModule],
  selector: 'app-main-layout',
  templateUrl: './main-layout.component.html',
  styleUrls: ['./main-layout.component.css'],
})
export class MainLayoutComponent implements OnInit {
  userName: string = 'Guest';

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit() {
    this.authService.getUser().subscribe(
      (user) => {
        this.userName = user.name || 'User';
      },
      (error) => {
        console.error('Error fetching user data:', error);
        this.userName = 'Guest';
      }
    );
  }

  viewProfile() {
    this.router.navigate(['/profile']);
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }
}
