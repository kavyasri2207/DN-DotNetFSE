# Angular 20.0 Deep Skilling: Student Course Portal

This repository contains the implementation of the **Student Course Portal** for the Digital Nurture 5.0 .NET Full Stack Engineer Track. This project is being built incrementally across multiple hands-on exercises to demonstrate core and advanced Angular concepts.

---

## 🛠️ Hands-On 1: Environment Setup & Project Structure

### Objectives:
*   Angular CLI & Workspace Setup
*   Angular Project Structure & Files
*   Running & Building Angular Apps
*   Creating Components
*   Angular Module Overview

In this exercise, the foundational Angular workspace was scaffolded and configured for a modern, standalone-component architecture.

### Key Implementations:
1. **Workspace Scaffold**: Generated a brand new Angular project using the Angular CLI (`ng new`) configured for routing and CSS styling.
2. **File Explanations**: Documented the core configuration files (`angular.json`, `tsconfig.json`, `main.ts`, etc.) and the purpose of bundle budget thresholds in a `notes.txt` file.
3. **Core Components**: Generated four initial standalone components to serve as the building blocks for the portal:
   * `HeaderComponent`: Contains the top navigation bar with dynamic `routerLink` attributes.
   * `HomeComponent`: Acts as the landing dashboard displaying hardcoded statistics.
   * `CourseListComponent`: A placeholder page for the upcoming course grid.
   * `StudentProfileComponent`: A placeholder page for the student's personal dashboard.
4. **App Shell Architecture**: Replaced the default boilerplate in `app.component.html` with a clean `<app-header>` and `<router-outlet>` setup for seamless page transitions.

---

## 🔄 Hands-On 2: Data Binding & Component Communication

### Objectives:
*   Property Binding
*   Event Binding
*   Two-Way Binding (ngModel)
*   Lifecycle Hooks (ngOnInit, ngOnChanges, ngOnDestroy)
*   @Input and @Output Decorators
*   EventEmitter

In this exercise, interactivity was added to the portal using Angular's powerful data-binding mechanisms and lifecycle hooks.

### Key Implementations:
1. **All Four Binding Types (HomeComponent)**:
   * **Interpolation**: Rendered the dynamic `portalName` variable to the UI.
   * **Property Binding**: Bound the `[disabled]` attribute of the "Enroll Now" button to a boolean property.
   * **Event Binding**: Bound the `(click)` event of the button to an `onEnrollClick()` method to trigger UI state changes.
   * **Two-Way Binding**: Implemented a search bar using `[(ngModel)]` (Banana-in-a-box syntax) to instantly mirror user input onto the screen.
2. **Lifecycle Hooks**:
   * Implemented `ngOnInit` and `ngOnDestroy` in the `HomeComponent` to log initialization and cleanup phases to the console during route navigation.
   * Implemented `ngOnChanges` in the `CourseCardComponent` to explicitly track and log any changes to the `@Input()` payload from the parent.
3. **Parent-Child Communication (@Input / @Output)**:
   * Created a custom `CourseCardComponent` designed to accept data downwards from a parent via the `@Input() course` decorator.
   * Configured the child card to emit an `enrollRequested` event upwards via the `@Output()` decorator using an `EventEmitter<number>`.
   * Configured the parent `CourseListComponent` to loop through 5 courses using `*ngFor`, dynamically passing data down into each card, and listening for the emitted events to display the selected course ID on the screen.

---

## 📸 Simulated Output (Visual Verification)

Here is a visual mockup verifying that the Angular UI is correctly rendering the dynamic Data Bindings, the styled Navigation Bar, and the structural layouts implemented in Hands-On 1 & 2!

![Angular Portal Mockup](./assets/angular_portal_mockup.png)
