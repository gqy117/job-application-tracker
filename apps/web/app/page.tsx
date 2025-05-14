"use client";

import Image, { type ImageProps } from "next/image";
import styles from "./page.module.css";
import { Table } from "@repo/ui/table";
import { useQuery } from "@tanstack/react-query";
import axios from "axios";
import Button from "@mui/material/Button";
import { useRouter } from "next/navigation";

type Props = Omit<ImageProps, "src"> & {
  srcLight: string;
  srcDark: string;
};

const ThemeImage = (props: Props) => {
  const { srcLight, srcDark, ...rest } = props;

  return (
    <>
      <Image {...rest} src={srcLight} className="imgLight" />
      <Image {...rest} src={srcDark} className="imgDark" />
    </>
  );
};

export default function Home() {
  const { data: rows = [] } = useQuery({
    queryKey: ["applications"],
    queryFn: async () => {
      const { data } = await axios.get(`/`);
      return data;
    },
  });

  const router = useRouter();

  const onAddApplicationClicked = () => {
    router.push("/job");
  };

  return (
    <div className={styles.page}>
      <main className={styles.main}>
        <ThemeImage
          className={styles.logo}
          srcLight="Datacom.svg"
          srcDark="Datacom.svg"
          alt="Datacom logo"
          width={240}
          height={100}
          priority
        />
        <Table
          rows={rows}
          onEditClicked={(row) => router.push(`/job/${row.id}`)}
        />

        <Button onClick={onAddApplicationClicked}>Add Application</Button>
      </main>
      <footer className={styles.footer}></footer>
    </div>
  );
}
