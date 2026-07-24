import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [FormsModule],
  template: `
    <div style="padding: 2rem; text-align: center; font-family: sans-serif;">
      <h1>{{ portalName }}</h1>
      <p style="font-size: 1.2rem; color: #555;">Your one-stop platform for managing your academic journey.</p>
      
      <div style="margin-top: 2rem;">
        <input [(ngModel)]="searchTerm" placeholder="Search courses..." style="padding: 8px; font-size: 16px; width: 250px;">
        <p style="color: #666; font-style: italic;">Searching for: {{ searchTerm }}</p>
      </div>

      <div style="margin-top: 1rem;">
        <button [disabled]="!isPortalActive" (click)="onEnrollClick()" style="padding: 10px 20px; font-size: 16px; cursor: pointer; background: #007bff; color: white; border: none; border-radius: 4px;">
          Enroll Now
        </button>
        <p style="color: green; font-weight: bold; margin-top: 10px;">{{ message }}</p>
      </div>

      <div style="display: flex; justify-content: center; gap: 20px; margin-top: 2rem;">
        <div style="padding: 20px; border: 1px solid #ccc; border-radius: 8px; background: #e9ecef; font-weight: bold;">Courses Available: 12</div>
        <div style="padding: 20px; border: 1px solid #ccc; border-radius: 8px; background: #e9ecef; font-weight: bold;">Enrolled: 3</div>
        <div style="padding: 20px; border: 1px solid #ccc; border-radius: 8px; background: #e9ecef; font-weight: bold;">GPA: 3.8</div>
      </div>
    </div>
  `
})
export class HomeComponent implements OnInit, OnDestroy {
  portalName = 'Student Course Portal';
  isPortalActive = true;
  message = '';
  searchTerm = '';

  // [property] is a one-way binding (Component -> DOM).
  // [(ngModel)] is a two-way binding (Component <-> DOM), meaning if the user types in the input, the component property updates instantly.

  ngOnInit() { console.log('HomeComponent initialised — courses loaded'); }
  ngOnDestroy() { console.log('HomeComponent destroyed'); }
  onEnrollClick() { this.message = 'Enrollment opened!'; }
}
