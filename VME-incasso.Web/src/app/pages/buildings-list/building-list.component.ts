// src/app/pages/buildings/building-list.component.ts
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { BuildingService } from '../../shared/services/building.service';
import { Building } from '../../shared/models/building-model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-building-list',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule], // ✅ Add ReactiveFormsModule
  templateUrl: './building-list.component.html',
  styleUrls: ['./building-list.component.css']
})
export class BuildingListComponent implements OnInit {
  buildings: Building[] = [];
  buildingForm: FormGroup;
  isEditing = false;
  loading = false;

  constructor(
    private buildingService: BuildingService,
    private fb: FormBuilder,
    private toastr: ToastrService
  ) {
    this.buildingForm = this.fb.group({
      id: [0],
      name: ['', Validators.required],
      address: ['', Validators.required],
      city: ['', Validators.required],
      postalCode: ['', Validators.required],
      bankAccount: ['', Validators.required],
      interestRate: ['', Validators.required],
      penaltyRate: ['', Validators.required],
      courtJurisdiction: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.loadBuildings();
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

  submitForm(): void {
    if (this.buildingForm.invalid) return;
    this.loading = true;

    if (this.isEditing) {
      this.buildingService.updateBuilding(this.buildingForm.value).subscribe({
        next: () => {
          this.toastr.success('Building updated successfully');
          this.loadBuildings();
          this.resetForm();
        },
        error: () => {
          this.toastr.error('Failed to update building');
        }
      });
    } else {
      this.buildingService.createBuilding(this.buildingForm.value).subscribe({
        next: (newBuilding) => {
          this.toastr.success('Building added successfully');
          this.buildings.push(newBuilding);
          this.resetForm();
        },
        error: () => {
          this.toastr.error('Failed to create building');
        }
      });
    }
    this.loading = false;
  }

  editBuilding(building: Building): void {
    this.buildingForm.patchValue(building);
    this.isEditing = true;
  }

  resetForm(): void {
    this.buildingForm.reset();
    this.isEditing = false;
  }
}
