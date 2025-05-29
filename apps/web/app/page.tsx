"use server";

import Link from "next/link";
import styles from "./page.module.css";
import { ServerTable } from "./server-table";
import { ServerTable2 } from "./server-table2";
import { Suspense } from "react";

export default async function Home() {
  return (
    <div className={styles.page}>
      <main className={styles.main}>
        <Suspense fallback={<div>Loading banner…</div>}>
          <ServerTable />
        </Suspense>
        <Suspense fallback={<div>Loading banner2…</div>}>
          <ServerTable2 />
        </Suspense>
        <Link href="/job" prefetch={true}>
          Job
        </Link>
      </main>
      <footer className={styles.footer}></footer>
    </div>
  );
}
