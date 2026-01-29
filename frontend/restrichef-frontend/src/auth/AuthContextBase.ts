import { createContext } from "react";

export type AuthContextType = {
  token: string | null;
  loading: boolean;
  login: (email: string, senha: string) => Promise<void>;
  logout: () => void;
};

export const AuthContext = createContext<AuthContextType>(
  {} as AuthContextType
);
