import Box from "@mui/material/Box";
import InputLabel from "@mui/material/InputLabel";
import MenuItem from "@mui/material/MenuItem";
import FormControl from "@mui/material/FormControl";
import MuiSelect, { SelectChangeEvent } from "@mui/material/Select";

export function Select({
  label,
  value,
  onChange,
}: {
  label: string;
  value?: string;
  onChange: (event: SelectChangeEvent) => void;
}) {
  return (
    <Box sx={{ minWidth: 120 }}>
      <FormControl fullWidth>
        <InputLabel id="demo-simple-select-label">Status</InputLabel>
        <MuiSelect
          labelId="demo-simple-select-label"
          id="demo-simple-select"
          value={value}
          label={label}
          onChange={onChange}
        >
          <MenuItem value={"Interview"}>Interview</MenuItem>
          <MenuItem value={"Offer"}>Offer</MenuItem>
          <MenuItem value={"Rejected"}>Rejected</MenuItem>
        </MuiSelect>
      </FormControl>
    </Box>
  );
}
