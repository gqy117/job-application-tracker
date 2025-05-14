"use client";

import styles from "../page.module.css";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";
import { useMutation } from "@tanstack/react-query";
import axios from "axios";

import { queryClient } from "../queryClient";
import { useRouter } from "next/navigation";
import { useState } from "react";

export default function AddJob() {
  const router = useRouter();
  const [companyName, setCompanyName] = useState("");
  const [position, setPosition] = useState("");

  const mutation = useMutation({
    mutationFn: async () => {
      await axios.post("/", {
        companyName,
        position,
      });
    },
    onSuccess: () => {
      // Invalidate and refetch
      queryClient.invalidateQueries({ queryKey: ["applications"] });
    },
  });

  return (
    <div className={styles.page}>
      <main className={styles.main}>
        <div>
          Add A Job
          <div>
            <Box
              component="form"
              sx={{ "& > :not(style)": { m: 1, width: "25ch" } }}
              noValidate
              autoComplete="off"
            >
              <TextField
                id="outlined-basic"
                label="Company"
                variant="outlined"
                onChange={(e) => {
                  setCompanyName(e.target.value);
                }}
                value={companyName}
              />
              <TextField
                id="outlined-basic"
                label="Position"
                variant="outlined"
                value={position}
                onChange={(e) => {
                  setPosition(e.target.value);
                }}
              />
            </Box>

            <Button
              variant="contained"
              onClick={async () => {
                await mutation.mutateAsync();
                router.push("/");
              }}
            >
              Submit
            </Button>
          </div>
        </div>
      </main>
    </div>
  );
}
