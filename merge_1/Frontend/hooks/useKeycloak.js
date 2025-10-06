import { useEffect, useState } from "react";
import Keycloak from "keycloak-js";
import { normalizeRoles, highestRole } from "../lib/roles";

export function useKeycloak() {
  const [keycloak,setKeycloak]=useState(null);
  const [authenticated,setAuthenticated]=useState(false);
  const [roles, setRoles] = useState([]);
  const [token, setToken] = useState(null);

  useEffect(()=>{
    const kc=new Keycloak({url:process.env.NEXT_PUBLIC_KEYCLOAK_URL,realm:process.env.NEXT_PUBLIC_KEYCLOAK_REALM,clientId:process.env.NEXT_PUBLIC_KEYCLOAK_CLIENT});
    kc.init({onLoad:"login-required",checkLoginIframe:false}).then(auth=>{
      setKeycloak(kc);setAuthenticated(auth);
      if(auth){
        const rawRoles = kc.tokenParsed?.realm_access?.roles || [];
        const norm = normalizeRoles(rawRoles);
        setRoles(norm);
        setToken(kc.token);

        const targetRole = highestRole(norm);
        if (typeof window !== "undefined") {
          if (targetRole === "admin") window.location.replace("/admin/dashboard");
          else if (targetRole === "advisor") window.location.replace("/counselor/dashboard"); // back-compat route
          else if (targetRole === "participant") window.location.replace("/student/dashboard"); // back-compat route
        }
      }
    });
  },[]);
  return {keycloak,authenticated,roles,token};
}
