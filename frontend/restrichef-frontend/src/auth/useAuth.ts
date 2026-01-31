import { useContext } from "react";
import { AuthContext } from "./AuthContextBase";
import type { AuthContextType } from "./AuthContextBase";

export function useAuth(): AuthContextType {
  return useContext(AuthContext);
}
