"use client";

import styles from "../../page.module.css";
import { Controller, useForm } from "react-hook-form";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";
import { useMutation, useQuery } from "@tanstack/react-query";
import axios from "axios";
import { useParams, useRouter } from "next/navigation";
import { queryClient } from "../../queryClient";
import { Select } from "@repo/ui/select";

type JobForm = {
  companyName: string;
  position: string;
  status: string;
};

export default function EditJob() {
  const router = useRouter();

  const params = useParams();
  const id = params?.id as string;
  const { data } = useQuery({
    queryKey: ["applications", id],
    queryFn: async () => {
      const { data } = await axios.get<JobForm>(`/${id}`);
      return data;
    },
  });

  const {
    control,
    getValues,
    setValue,
    formState: { errors },
  } = useForm<JobForm>({ defaultValues: data });

  const mutation = useMutation({
    mutationFn: async () => {
      await axios.put(`/${id}`, {
        status: getValues("status"),
      });
    },
    onSuccess: () => {
      // Invalidate and refetch
      queryClient.invalidateQueries({ queryKey: ["applications"] });
    },
  });

  return (
    data && (
      <div className={styles.page}>
        <main className={styles.main}>
          <div>
            Edit A Job
            <div>
              <Box
                component="form"
                sx={{ "& > :not(style)": { m: 1, width: "25ch" } }}
                noValidate
                autoComplete="off"
              >
                <Controller
                  name="companyName"
                  control={control}
                  render={({ field }) => (
                    <TextField
                      label="Company"
                      variant="outlined"
                      value={getValues("companyName")}
                      defaultValue={data?.companyName}
                      onChange={(e) => {
                        setValue("companyName", e.target.value);
                      }}
                    />
                  )}
                />
                <Controller
                  name="position"
                  control={control}
                  render={({ field }) => (
                    <TextField
                      label="Position"
                      variant="outlined"
                      value={getValues("position")}
                      defaultValue={data?.position}
                      onChange={(e) => {
                        setValue("position", e.target.value);
                      }}
                    />
                  )}
                />
                <Controller
                  name="status"
                  control={control}
                  render={({ field }) => (
                    <Select
                      label="Status"
                      value={getValues("status") ?? data?.status}
                      onChange={(e) => {
                        setValue("status", e.target.value);
                      }}
                    />
                  )}
                />
              </Box>

              <Button
                variant="contained"
                onClick={async () => {
                  await mutation.mutateAsync();
                  router.push("/");
                }}
              >
                Save
              </Button>
            </div>
          </div>
        </main>
      </div>
    )
  );
}
