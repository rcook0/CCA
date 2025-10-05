export const ROLE_MAP = { student: "participant", counselor: "advisor", admin: "admin" };
export const PRIORITY = ["admin", "advisor", "participant"];

export function normalizeRoles(rawRoles = []) {
  const mapped = rawRoles.map((r) => ROLE_MAP[r] ?? r);
  return [...new Set(mapped)];
}

export function highestRole(roles = []) {
  const norm = normalizeRoles(roles);
  const winner = PRIORITY.find((r) => norm.includes(r));
  return winner || "participant";
}
