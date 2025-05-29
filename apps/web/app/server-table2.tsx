"use server";

export async function ServerTable2() {
  await new Promise((resolve) => setTimeout(resolve, 2000));

  const res = await fetch("https://jsonplaceholder.typicode.com/posts/2", {
    cache: "no-store",
  });
  const post = await res.json();

  return (
    <header style={{ padding: "1rem", background: "red" }}>
      <h1>{post.title}</h1>
    </header>
  );
}
