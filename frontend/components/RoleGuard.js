import { useRouter } from "next/router";
export default function RoleGuard({ roles, allowed, children }) {
  const router = useRouter();
  if (!roles.some(r => allowed.includes(r))) { return <p>Access denied</p>; }
  return children;
}