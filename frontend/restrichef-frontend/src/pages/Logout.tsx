import { useNavigate } from "react-router-dom";
import { LogOut } from "lucide-react";
import { COLORS } from "../styles/colors";

export default function Logout() {
  const navigate = useNavigate();

  return (
    <div
      className="flex min-h-screen items-center justify-center"
      style={{ backgroundColor: COLORS.background }}
    >
      <div className="w-full max-w-md rounded-2xl bg-white p-8 text-center shadow-lg">
        <div
          className="mx-auto mb-6 flex h-16 w-16 items-center justify-center rounded-full"
          style={{ backgroundColor: COLORS.primary }}
        >
          <LogOut size={28} className="text-white" />
        </div>

        <h1
          className="mb-3 text-xl font-semibold"
          style={{ color: COLORS.textTitle }}
        >
          Até logo!
        </h1>

        <p className="mb-6 text-sm" style={{ color: COLORS.textBody }}>
          Você saiu da sua conta com sucesso. Para acessar suas receitas novamente,
          faça login.
        </p>

        <button
          onClick={() => navigate("/login")}
          className="w-full rounded-lg py-3 text-sm font-medium text-white transition-opacity hover:opacity-90"
          style={{ backgroundColor: COLORS.primary }}
        >
          Fazer Login
        </button>
      </div>
    </div>
  );
}
