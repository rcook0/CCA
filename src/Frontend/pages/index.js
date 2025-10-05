export default async function Home() {
  const res = await fetch(`${process.env.NEXT_PUBLIC_API_URL}/users`);
  const users = await res.json();

  return (
    <main style={{ padding: 40 }}>
      <h1>MyCCA Modernized</h1>
      <p>Fetched {users.length} users from the API:</p>
      <ul>
        {users.map(u => (
          <li key={u.id}>{u.firstName} {u.lastName} ({u.email})</li>
        ))}
      </ul>
    </main>
  );
}
