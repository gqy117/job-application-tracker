"use client";

import { createTheme } from "@mui/material/styles";

export const sharedTheme = createTheme({
  palette: {
    primary: {
      main: "#007bff", // Example primary color
    },
    secondary: {
      main: "#6c757d", // Example secondary color
    },
  },
  typography: {
    fontFamily: [
      "-apple-system",
      "BlinkMacSystemFont",
      '"Segoe UI"',
      "Roboto",
      '"Helvetica Neue"',
      "Arial",
      "sans-serif",
      '"Apple Color Emoji"',
      '"Segoe UI Emoji"',
      '"Segoe UI Symbol"',
    ].join(","),
  },
  spacing: 8, // Default spacing unit
  components: {
    MuiButton: {
      defaultProps: {
        variant: "contained",
      },
      styleOverrides: {
        root: {
          textTransform: "none",
        },
      },
    },
  },
});
