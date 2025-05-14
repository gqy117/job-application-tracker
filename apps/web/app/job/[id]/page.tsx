"use client";
import { Table } from "@repo/ui/table";
import { useQuery } from "@tanstack/react-query";
import axios from "axios";

export default function EditJob({
  params: { id },
}: {
  params: { id: string };
}) {
  const query = useQuery({
    queryKey: ["applications"],
    queryFn: async () => {
      const { data } = await axios.get(`/${id}`);
      return data;
    },
  });

  return (
    <div>
      Edit A Job
      <Table />
    </div>
  );
}
