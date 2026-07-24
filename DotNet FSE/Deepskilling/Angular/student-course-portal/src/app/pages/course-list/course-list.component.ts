import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CourseCardComponent } from '../../components/course-card/course-card.component';

@Component({
  selector: 'app-course-list',
  standalone: true,
  imports: [CommonModule, CourseCardComponent],
  template: `
    <div style="padding: 2rem;">
      <h2>Course List</h2>
      <div style="display: grid; grid-template-columns: repeat(auto-fill, minmax(300px, 1fr)); gap: 1.5rem;">
        <app-course-card *ngFor="let c of courses" [course]="c" (enrollRequested)="onEnroll($event)"></app-course-card>
      </div>
      <div *ngIf="selectedCourseId" style="margin-top: 20px; padding: 15px; background: #e2e3e5; border: 1px solid #d6d8db; border-radius: 4px; font-weight: bold; color: #383d41;">
        ✅ Selected course ID: {{ selectedCourseId }}
      </div>
    </div>
  `
})
export class CourseListComponent {
  selectedCourseId: number | null = null;
  courses = [
    { id: 101, name: 'Introduction to Angular', code: 'ANG101', credits: 3 },
    { id: 102, name: 'Advanced TypeScript', code: 'TS202', credits: 4 },
    { id: 103, name: 'State Management with NgRx', code: 'NGRX301', credits: 3 },
    { id: 104, name: 'Web API Design', code: 'API201', credits: 3 },
    { id: 105, name: 'Full Stack Architecture', code: 'FSA401', credits: 5 }
  ];

  onEnroll(courseId: number) {
    console.log('Enrolling in course:', courseId);
    this.selectedCourseId = courseId;
  }
}
