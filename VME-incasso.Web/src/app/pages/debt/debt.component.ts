import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-debt',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './debt.component.html',
  styleUrls: ['./debt.component.css']
})
export class DebtComponent {
  debtModel = {
    debtorId: '',
    amount: '',
    dueDate: '',
    interestStartDate: '',
    description: ''
  };

  onSubmit(form: any) {
    if (form.valid) {
      console.log('Debt Data:', this.debtModel);
    }
  }
}
