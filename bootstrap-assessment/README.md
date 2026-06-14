# Bootstrap 5 Exercises Assessment

This repository contains the solutions to the Cognizant Bootstrap 5 Assessment.

## Getting Started (Exercise 1.2, 19.1)

1. Open your terminal in this folder (`bootstrap-assessment`).
2. Run `npm install` to download Bootstrap, Bootstrap Icons, and Sass.
3. Run `npm run css-build` to compile the custom Sass into CSS.
4. Open `index.html` in your web browser to view all the completed exercises.

## Exercise 2.1: Bootstrap Structure and Files

When you download Bootstrap or install it via npm, the structure typically includes:

- **`css/`**: Contains the compiled and minified CSS files (like `bootstrap.min.css`) which provide the core styling, grid system, and utility classes. Also includes source maps and sometimes grid/utility specific files.
- **`js/`**: Contains the compiled JavaScript plugins (like `bootstrap.bundle.min.js`). The bundle includes Popper.js, which is required for dropdowns, popovers, and tooltips.
- **`icons/`** (if Bootstrap Icons are downloaded separately): A collection of SVGs and icon fonts that can be used independently or alongside Bootstrap components for scalable vector graphics.

## Exercise 19.1 & 19.2: Sass Customization

- An npm project is set up with a `package.json` file.
- The `scss/custom.scss` file overrides Bootstrap's default `$primary` color and `$border-radius` variables before importing the main Bootstrap Sass file.
- We compile this via the `npm run css-build` command using the installed `sass` package.

Enjoy reviewing the exercises in `index.html`!
