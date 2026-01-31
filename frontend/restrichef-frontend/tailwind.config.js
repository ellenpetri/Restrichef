 /** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./index.html",
    "./src/**/*.{ts,tsx}"
  ],
  theme: {
    extend: {
      colors: {
        primary: "#16A34A",
        "input-background": "#FFFFFF"
      }
    }
  },
  plugins: []
};
