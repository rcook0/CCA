import RoleGuard from "../../components/RoleGuard";
import { useEffect,useState } from "react";
import { useT } from "../../i18n/provider";

export default function SyncStatusPage({ token, roles }){
  const [status,setStatus]=useState(null);
  const t = useT();
  async function fetchStatus(){const res=await fetch(`${process.env.NEXT_PUBLIC_API_URL}/admin/sync-status`,{headers:{Authorization:`Bearer ${token}`}});setStatus(await res.json());}
  async function runSyncNow(){const res=await fetch(`${process.env.NEXT_PUBLIC_API_URL}/admin/sync-now`,{method:"POST",headers:{Authorization:`Bearer ${token}`}});setStatus(await res.json());alert("✅ Sync completed");}
  useEffect(()=>{fetchStatus();},[token]);
  return(<RoleGuard roles={roles} allowed={["admin"]}>
    <main style={{ padding: 40 }}>
      <h1>🔄 {t("sync.status")}</h1>
      {status ? (
        <div style={{ border: "1px solid #ccc", padding: "1rem", maxWidth: "400px" }}>
          <p><b>{t("sync.lastRun")}:</b> {new Date(status.lastRun).toLocaleString()}</p>
          <p><b>{t("sync.usersSynced")}:</b> {status.usersSynced}</p>
          {status.lastError 
            ? <p style={{ color: "red" }}>❌ {t("sync.error")}: {status.lastError}</p>
            : <p style={{ color: "green" }}>✅ {t("sync.success")}</p>}
        </div>
      ) : (<p>Loading...</p>)}
      <button onClick={runSyncNow} style={{ marginTop: "1rem", padding: "0.5rem", background: "#0070f3", color: "white", border: "none", borderRadius: "4px" }}>
        Sync Now
      </button>
    </main>
  </RoleGuard>);
}
