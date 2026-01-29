import { useState } from "react";
import { useNavigate, Link } from "react-router-dom";
import { ChefHat } from "lucide-react";
import { COLORS } from "../styles/colors";
import api from "../api/api";
import axios from "axios";

type BackendError = {
  mensagem: string;
};

export default function Cadastro() {
  const [email, setEmail] = useState("");
  const [senha, setSenha] = useState("");
  const [confirmarSenha, setConfirmarSenha] = useState("");
  const [erroSenha, setErroSenha] = useState("");
  const [erroGeral, setErroGeral] = useState("");

  const navigate = useNavigate();

  async function handleSubmit(e: React.FormEvent) {
    e.preventDefault();
    setErroSenha("");
    setErroGeral("");

    if (senha.length < 8) {
      setErroSenha("A senha deve ter no mínimo 8 caracteres");
      return;
    }

    if (senha !== confirmarSenha) {
      setErroSenha("As senhas não coincidem");
      return;
    }

    try {
      await api.post("/api/users", {
        nome: email.split("@")[0],
        email,
        senha,
      });

      navigate("/login");
    } catch (error: unknown) {
      if (axios.isAxiosError(error)) {
        const data = error.response?.data;

        if (
          typeof data === "object" &&
          data !== null &&
          "mensagem" in data &&
          typeof (data as BackendError).mensagem === "string"
        ) {
          setErroGeral((data as BackendError).mensagem);
          return;
        }
      }

      setErroGeral("Erro ao criar conta");
    }
  }

  return (
    <div
      className="min-h-screen flex items-center justify-center px-4"
      style={{ backgroundColor: COLORS.background }}
    >
      <div className="w-full max-w-md">
        <div className="text-center mb-8">
          <div
            className="mx-auto mb-4 flex h-16 w-16 items-center justify-center rounded-full"
            style={{ backgroundColor: COLORS.primary }}
          >
            <ChefHat className="h-8 w-8 text-white" />
          </div>

          <h1
            className="mb-2 text-xl font-semibold"
            style={{ color: COLORS.textTitle }}
          >
            Criar conta
          </h1>

          <p style={{ color: COLORS.textBody }}>
            Cadastre-se para acessar receitas personalizadas
          </p>
        </div>

        <div
          className="rounded-2xl p-8 shadow-lg"
          style={{ backgroundColor: COLORS.card }}
        >
          <form onSubmit={handleSubmit} className="space-y-6">
            <div>
              <label
                className="mb-2 block text-sm font-medium"
                style={{ color: COLORS.textTitle }}
              >
                E-mail
              </label>
              <input
                type="email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                className="w-full rounded-lg px-4 py-3 outline-none"
                style={{
                  backgroundColor: COLORS.inputBg,
                  border: `1px solid ${COLORS.inputBorder}`,
                }}
                required
              />
            </div>

            <div>
              <label
                className="mb-2 block text-sm font-medium"
                style={{ color: COLORS.textTitle }}
              >
                Senha
              </label>
              <input
                type="password"
                value={senha}
                onChange={(e) => setSenha(e.target.value)}
                className="w-full rounded-lg px-4 py-3 outline-none"
                style={{
                  backgroundColor: COLORS.inputBg,
                  border: erroSenha
                    ? "1px solid #EF4444"
                    : `1px solid ${COLORS.inputBorder}`,
                }}
                required
              />
            </div>

            <div>
              <label
                className="mb-2 block text-sm font-medium"
                style={{ color: COLORS.textTitle }}
              >
                Confirmar senha
              </label>
              <input
                type="password"
                value={confirmarSenha}
                onChange={(e) => setConfirmarSenha(e.target.value)}
                className="w-full rounded-lg px-4 py-3 outline-none"
                style={{
                  backgroundColor: COLORS.inputBg,
                  border: erroSenha
                    ? "1px solid #EF4444"
                    : `1px solid ${COLORS.inputBorder}`,
                }}
                required
              />
              {erroSenha && (
                <p className="mt-1 text-sm text-red-500">
                  {erroSenha}
                </p>
              )}
            </div>

            {erroGeral && (
              <p className="text-center text-sm text-red-500">
                {erroGeral}
              </p>
            )}

            <button
              type="submit"
              className="mt-4 w-full rounded-lg py-3 font-medium text-white hover:opacity-90"
              style={{ backgroundColor: COLORS.primary }}
            >
              Criar conta
            </button>
          </form>

          <div className="mt-6 text-center">
            <p style={{ color: COLORS.textBody }}>
              Já tem uma conta?{" "}
              <Link
                to="/login"
                className="font-medium hover:underline"
                style={{ color: COLORS.primary }}
              >
                Entrar
              </Link>
            </p>
          </div>
        </div>
      </div>
    </div>
  );
}
