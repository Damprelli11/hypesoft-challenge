import { createContext } from "react";

export interface AuthContextData {
  isAuthenticated: boolean;
  initialized: boolean;
  token?: string;
  roles: string[];
  login: () => void;
  logout: () => void;
}

export const AuthContext = createContext<AuthContextData>({} as AuthContextData);
