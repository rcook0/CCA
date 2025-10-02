import { useEffect, useState } from "react";
import Keycloak from "keycloak-js";
const ROLE_PRIORITY = ["admin","counselor","student"];
export function useKeycloak() {
  const [keycloak,setKeycloak]=useState(null);const [authenticated,setAuthenticated]=useState(false);
  useEffect(()=>{
    const kc=new Keycloak({url:process.env.NEXT_PUBLIC_KEYCLOAK_URL,realm:process.env.NEXT_PUBLIC_KEYCLOAK_REALM,clientId:process.env.NEXT_PUBLIC_KEYCLOAK_CLIENT});
    kc.init({onLoad:"login-required",checkLoginIframe:false}).then(auth=>{
      setKeycloak(kc);setAuthenticated(auth);
      if(auth&&typeof window!=="undefined"){
        const roles=kc.tokenParsed?.realm_access?.roles||[];
        const targetRole=ROLE_PRIORITY.find(r=>roles.includes(r));
        if(targetRole==="admin")window.location.replace("/admin/dashboard");
        else if(targetRole==="counselor")window.location.replace("/counselor/dashboard");
        else if(targetRole==="student")window.location.replace("/student/dashboard");
      }
    });
  },[]);
  return {keycloak,authenticated};
}