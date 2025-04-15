import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './shared/guards/auth.guard';

import { MainLayoutComponent } from './layouts/main-layout/main-layout.component';
import { AuthLayoutComponent } from './layouts/auth-layout/auth-layout.component';

import { LoginComponent } from './user/login/login.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { ProfileComponent } from './user/profile/profile.component';
import { DebtComponent } from './pages/debt/debt.component';
import { BuildingListComponent } from './pages/buildings-list/building-list.component';

// ✳️ New imports (adjust paths if needed)
import { UserListComponent } from './pages/user-management/user-list.component';
import { UserFormComponent } from './pages/user-management/user-form.component';
import { ClosedFilesComponent } from './pages/files/closed-files.component';
import { FilesTableComponent } from './pages/files/files-table.component';
import { CompanyManagementComponent } from './pages/admin/company/company-management.component';
import { LogsComponent } from './pages/system/logs.component';
import { PricingSettingsComponent } from './pages/admin/pricing/pricing-settings.component';
import { FileReviewComponent } from './pages/admin/files/file-review.component';
import { UserManagementComponent } from './pages/admin/user/user-management.component';
import { InterestRatesComponent } from './pages/admin/rates/interest-rates.component';

export const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },

  // Public Routes
  {
    path: '',
    component: AuthLayoutComponent,
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegistrationComponent },
    ],
  },

  // Protected Routes
  {
    path: '',
    component: MainLayoutComponent,
    canActivate: [AuthGuard],
    children: [
      { path: 'dashboard', component: DashboardComponent },
      { path: 'profile', component: ProfileComponent },
      { path: 'debt', component: DebtComponent },
      { path: 'buildings', component: BuildingListComponent },

      // 🧑‍🤝‍🧑 User Management
      { path: 'users', component: UserListComponent },
      { path: 'users/new', component: UserFormComponent },

      // 🏢 Building Management
      // { path: 'buildings/new', component: BuildingFormComponent },
      // { path: 'buildings/:id/docs', component: DocumentsComponent },

      // 💸 Debt Process
      // { path: 'debt/start', component: StartProcessComponent },
      // { path: 'debt/add-debtor', component: AddDebtorComponent },
      // { path: 'debt/add-records', component: AddDebtRecordsComponent },
      // { path: 'debt/summary', component: FileSummaryComponent },
      // { path: 'debt/tracking', component: FileTrackingComponent },

      // 📂 File Management
      { path: 'files/closed', component: ClosedFilesComponent },
      { path: 'files/list', component: FilesTableComponent },

      // 📆 Calendar
      // { path: 'calendar', component: CourtCalendarComponent },

      // 🛠️ Admin Panel
      { path: 'admin/users', component: UserManagementComponent },
      { path: 'admin/companies', component: CompanyManagementComponent },
      { path: 'admin/files', component: FileReviewComponent },
      { path: 'admin/pricing', component: PricingSettingsComponent },
      { path: 'admin/interest-rates', component: InterestRatesComponent },
      // { path: 'admin/courts', component: CourtsComponent },
      // { path: 'admin/templates', component: DocumentTemplatesComponent },

      // ⚙️ System
      //{ path: 'system/email-settings', component: EmailSettingsComponent },
      { path: 'system/logs', component: LogsComponent },
    ],
  },

  // Wildcard route
  { path: '**', redirectTo: '/login' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
