import RoleGuard from "../../components/RoleGuard";
import { useEffect,useState } from "react";
export default function SyncStatusPage({token,roles}){
  const [status,setStatus]=useState(null);
  async function fetchStatus(){const res=await fetch(`${process.env.NEXT_PUBLIC_API_URL}/admin/sync-status`,{headers:{Authorization:`Bearer ${token}`}});setStatus(await res.json());}
  async function runSyncNow(){const res=await fetch(`${process.env.NEXT_PUBLIC_API_URL}/admin/sync-now`,{method:"POST",headers:{Authorization:`Bearer ${token}`}});setStatus(await res.json());alert("✅ Sync completed");}
  useEffect(()=>{fetchStatus();},[token]);
  return(<RoleGuard roles={roles} allowed={["admin"]}><main><h1>🔄 User Sync Status</h1>{status?<div><p><b>Last Run:</b>{new Date(status.lastRun).toLocaleString()}</p><p><b>Users Synced:</b>{status.usersSynced}</p>{status.lastError?<p style={{color:"red"}}>❌{status.lastError}</p>:<p style={{color:"green"}}>✅ Success</p>}</div>:<p>Loading...</p>}<button onClick={runSyncNow}>Sync Now</button></main></RoleGuard>);}
