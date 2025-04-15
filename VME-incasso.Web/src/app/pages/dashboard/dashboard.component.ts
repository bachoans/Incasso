import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { BuildingService } from '../../shared/services/building.service';
import { Building } from '../../shared/models/building-model';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../../shared/services/auth.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
  standalone: true,
  imports: [CommonModule, FormsModule],
})
export class DashboardComponent {
  user = {
    firstName: 'John',
    companyName: 'ABC Building Management',
    address: '123 Main St',
    postalCode: '12345',
    city: 'Bruges',
    phone: '+123456789',
    email: 'admin@abc.com',
    colleagues: [
      { firstName: 'Jane', lastName: 'Doe', status: 'Active' },
      { firstName: 'Mark', lastName: 'Smith', status: 'Pending' }
    ],
    buildings: [
      { name: 'Building A' },
      { name: 'Building B' },
      { name: 'Building C' }
    ]
  };

   constructor(
      private buildingService: BuildingService,
          private toastr: ToastrService,
        private authService: AuthService) {}

  ngOnInit(): void {
    this.loadBuildings();
   
  }

  buildings: Building[] = [];
  userInfo: any[] = [];
  loading = false;
  newColleagueEmail = '';

  startNewRecovery() {
    console.log('Start New Recovery clicked');
    // Add logic to navigate or open the debt recovery process
  }

  viewFiles() {
    console.log('View Files clicked');
    // Add logic to navigate to the file list
  }

  editField(field: string) {
    console.log(`Edit ${field} clicked`);
    // Add logic to edit the specified field
  }

  removeColleague(colleague: any) {
    console.log(`Remove colleague: ${colleague.firstName} ${colleague.lastName}`);
    // Add logic to remove a colleague
  }

  addColleague() {
    console.log(`Add colleague: ${this.newColleagueEmail}`);
    // Add logic to add a colleague
    this.newColleagueEmail = '';
  }

  loadBuildings(): void {
    this.loading = true;
    this.buildingService.getBuildings().subscribe({
      next: (data) => {
        this.buildings = data;
        this.loading = false;
      },
      error: () => {
        this.toastr.error('Failed to load buildings');
        this.loading = false;
      }
    });
  }

  loadProfileInfo(): void{
    this.authService.getUser().subscribe(
      (user) => {
        this.userInfo = user
      },
      (error) => {
        console.error('Error fetching user data:', error);
      }
    );
  }
}
