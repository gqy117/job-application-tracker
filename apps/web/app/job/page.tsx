"use client";

import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";
import { useMutation } from "@tanstack/react-query";
import axios from "axios";
import { queryClient } from "../layout";

export default function AddJob() {
  const mutation = useMutation({
    mutationFn: async () => {
      // use axios to fetch data
      const { data } = await axios.post("/", {
        companyName: "Company Name",
        position: "Position",
      });
      return data;
    },
    onSuccess: () => {
      // Invalidate and refetch
      queryClient.invalidateQueries({ queryKey: ["applications"] });
    },
  });

  return (
    <div>
      Add A Job
      <div>
        <Box
          component="form"
          sx={{ "& > :not(style)": { m: 1, width: "25ch" } }}
          noValidate
          autoComplete="off"
        >
          <TextField id="outlined-basic" label="Company" variant="outlined" />
          <TextField id="outlined-basic" label="Position" variant="outlined" />
        </Box>

        <Button
          variant="contained"
          onClick={() => {
            mutation.mutate();
            console.log("mutation: ", mutation);
          }}
        >
          Submit
        </Button>
      </div>
    </div>
  );
}
