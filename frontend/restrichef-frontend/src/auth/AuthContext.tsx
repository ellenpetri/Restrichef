import { useState } from "react";
import type { ReactNode } from "react";
import api from "../api/api";
import { AuthContext } from "./AuthContextBase";

export function AuthProvider({ children }: { children: ReactNode }) {
  const [token, setToken] = useState<string | null>(() => {
    return localStorage.getItem("token");
  });

  const [loading] = useState(false);

  async function login(email: string, senha: string) {
    const response = await api.post("/api/users/login", { email, senha });
    const tokenRecebido = response.data.token;

    localStorage.setItem("token", tokenRecebido);
    setToken(tokenRecebido);
  }

  function logout() {
    localStorage.removeItem("token");
    setToken(null);
  }

  return (
    <AuthContext.Provider value={{ token, loading, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
}
