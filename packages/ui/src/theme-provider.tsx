import { ThemeProvider as MuiThemeProvider } from "@mui/material/styles";
import { sharedTheme } from "./theme";

export default function ThemeProvider({
  children,
}: {
  children: React.ReactNode;
}) {
  return <MuiThemeProvider theme={sharedTheme}>{children}</MuiThemeProvider>;
}
