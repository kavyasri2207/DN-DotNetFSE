import { Component, Input, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-course-card',
  standalone: true,
  template: `
    <div style="border: 1px solid #ddd; padding: 15px; margin: 10px 0; border-radius: 8px; background: #fff; box-shadow: 0 2px 4px rgba(0,0,0,0.1);">
      <h3 style="margin-top: 0; color: #333;">{{ course.name }} ({{ course.code }})</h3>
      <p style="margin: 5px 0; color: #666;">Course ID: <strong>{{ course.id }}</strong></p>
      <p style="margin: 5px 0 15px 0; color: #666;">Credits: <strong>{{ course.credits }}</strong></p>
      <button (click)="enrollRequested.emit(course.id)" style="padding: 8px 15px; background: #28a745; color: white; border: none; border-radius: 4px; cursor: pointer; font-weight: bold;">
        Enroll
      </button>
    </div>
  `
})
export class CourseCardComponent implements OnChanges {
  @Input() course!: { id: number, name: string, code: string, credits: number };
  @Output() enrollRequested = new EventEmitter<number>();

  ngOnChanges(changes: SimpleChanges) {
    if (changes['course']) {
      console.log('Course changed:', changes['course'].previousValue, '->', changes['course'].currentValue);
    }
  }
}
