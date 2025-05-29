"use server";

export async function ServerTable() {
  await new Promise((resolve) => setTimeout(resolve, 2000));

  const res = await fetch("https://jsonplaceholder.typicode.com/posts/1", {
    cache: "no-store",
  });
  const post = await res.json();

  return (
    <header style={{ padding: "1rem", background: "#f0f0f0" }}>
      <h1>{post.title}</h1>
    </header>
  );
}
