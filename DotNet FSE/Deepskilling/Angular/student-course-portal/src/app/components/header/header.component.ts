import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterLink],
  template: `
    <nav style="display: flex; justify-content: space-between; align-items: center; padding: 1rem; background-color: #f8f9fa; border-bottom: 2px solid #ddd;">
      <h2 style="margin: 0;">Student Course Portal</h2>
      <ul style="list-style: none; display: flex; gap: 15px; margin: 0; padding: 0;">
        <li><a routerLink="/" style="text-decoration: none; color: #007bff; font-weight: bold;">Home</a></li>
        <li><a routerLink="/courses" style="text-decoration: none; color: #007bff; font-weight: bold;">Courses</a></li>
        <li><a routerLink="/profile" style="text-decoration: none; color: #007bff; font-weight: bold;">Profile</a></li>
      </ul>
    </nav>
  `
})
export class HeaderComponent { }
