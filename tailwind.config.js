/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./Views/**/*.cshtml",    // All razor views
    "./Pages/**/*.cshtml",    // If Razor pages will be used
    "./wwwroot/**/*.cshtml",  // Any static HTML files
    "./Controllers/**/*.cs",  // If any Tailwind classes is used in C# Strings
  ],  
  theme: {
    extend: {},
  },
  plugins: [],
}

