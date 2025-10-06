import { useEffect, useState } from "react";

export default function OrgSwitcher({ token }) {
  const [orgs, setOrgs] = useState([]);
  const [active, setActive] = useState(null);

  useEffect(() => {
    try {
      const parsed = JSON.parse(atob(token.split('.')[1]));
      let claim = parsed.org_id;
      const list = Array.isArray(claim) ? claim : (claim ? [claim] : []);
      setOrgs(list);
      const cached = localStorage.getItem("active_org");
      if (cached && list.includes(cached)) setActive(cached);
      else if (list.length) setActive(list[0]);
    } catch {
      setOrgs([]);
    }
  }, [token]);

  useEffect(() => {
    if (active) localStorage.setItem("active_org", active);
  }, [active]);

  if (!orgs.length) return null;

  return (
    <div style={{ display: "inline-flex", gap: 8, alignItems: "center" }}>
      <label htmlFor="orgsel" style={{ fontSize: 12, color: "#666" }}>Org</label>
      <select id="orgsel" value={active || ""} onChange={(e) => setActive(e.target.value)}>
        {orgs.map((o) => (
          <option key={o} value={o}>{o}</option>
        ))}
      </select>
    </div>
  );
}
