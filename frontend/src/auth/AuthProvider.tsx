import type { ReactNode } from "react";
import { useEffect, useState } from "react";
import Keycloak from "keycloak-js";
import { AuthContext } from "./AuthContext";

const keycloak = new Keycloak({
  url: "http://localhost:8080",
  realm: "hypesoft",
  clientId: "frontend",
});

export function AuthProvider({ children }: { children: ReactNode }) {
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const [initialized, setInitialized] = useState(false);
  const [token, setToken] = useState<string | undefined>();
  const [roles, setRoles] = useState<string[]>([]);

  useEffect(() => {
    const initKeycloak = async () => {
      keycloak.onAuthSuccess = () => {
        console.log("Auth success");
        setIsAuthenticated(true);
        setToken(keycloak.token);
        setRoles(keycloak.tokenParsed?.realm_access?.roles || []);
        sessionStorage.removeItem('loginCalled');
      };

      keycloak.onAuthError = () => {
        console.log("Auth error");
        setIsAuthenticated(false);
      };

      keycloak.onAuthRefreshSuccess = () => {
        console.log("Token refreshed");
        setToken(keycloak.token);
      };

      keycloak.onAuthRefreshError = () => {
        console.log("Token refresh error");
      };

      keycloak.onAuthLogout = () => {
        console.log("Logged out");
        setIsAuthenticated(false);
        setToken(undefined);
        setRoles([]);
      };

      keycloak.onTokenExpired = () => {
        console.log("Token expired, refreshing...");
        keycloak.updateToken(70).catch(() => {
          console.log("Failed to refresh token");
        });
      };

      try {
        const authenticated = await keycloak.init({
          onLoad: "check-sso",
          pkceMethod: "S256",
        });
        console.log("Keycloak init result:", authenticated);
        setIsAuthenticated(authenticated);
        setToken(keycloak.token);
        setRoles(keycloak.tokenParsed?.realm_access?.roles || []);
        setInitialized(true);
      } catch (error: unknown) {
        console.error("Keycloak init error:", error);
        if (error instanceof Error && error.message?.includes("initialized")) {
          console.log("Keycloak already initialized, checking auth state");
          setIsAuthenticated(keycloak.authenticated ?? false);
          setToken(keycloak.token);
          setRoles(keycloak.tokenParsed?.realm_access?.roles || []);
        }
        setInitialized(true);
      }
    };

    initKeycloak();
  }, []);

  function login() {
    if (!initialized) return;
    console.log("Calling keycloak.login");
    keycloak.login();
  }

  function logout() {
    if (!initialized) return;
    console.log("Calling keycloak.logout");
    keycloak.logout();
  }

  return (
    <AuthContext.Provider
      value={{ isAuthenticated, initialized, token, roles, login, logout }}
    >
      {children}
    </AuthContext.Provider>
  );
}
