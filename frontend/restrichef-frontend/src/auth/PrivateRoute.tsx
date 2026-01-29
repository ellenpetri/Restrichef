import { Navigate } from "react-router-dom";
import { useAuth } from "./useAuth";
import type { ReactNode } from "react";

export default function PrivateRoute({ children }: { children: ReactNode }) {
  const { token, loading } = useAuth();

  if (loading) {
    return null;
  }

  if (!token) {
    return <Navigate to="/" replace />;
  }

  return <>{children}</>;
}
