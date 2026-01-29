import { useEffect, useState } from "react";
import { useNavigate, Link } from "react-router-dom";
import { ChefHat } from "lucide-react";
import { useAuth } from "../auth/useAuth";
import { COLORS } from "../styles/colors";

export default function Login() {
  const [email, setEmail] = useState("");
  const [senha, setSenha] = useState("");
  const [erro, setErro] = useState("");

  const { login, token } = useAuth();
  const navigate = useNavigate();

  useEffect(() => {
    if (token) navigate("/receitas");
  }, [token, navigate]);

  async function handleSubmit(e: React.FormEvent) {
    e.preventDefault();
    setErro("");

    try {
      await login(email, senha);
      navigate("/perfil-alimentar");
    } catch {
      setErro("E-mail ou senha inválidos");
    }
  }

  return (
    <div
      className="min-h-screen flex items-center justify-center px-4"
      style={{ backgroundColor: COLORS.background }}
    >
      <div className="w-full max-w-md">
        {/* Header */}
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
            Bem-vindo de volta!
          </h1>

          <p style={{ color: COLORS.textBody }}>
            Entre para acessar suas receitas personalizadas
          </p>
        </div>

        {/* Card */}
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
                placeholder="seu@email.com"
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
                placeholder="••••••••"
                className="w-full rounded-lg px-4 py-3 outline-none"
                style={{
                  backgroundColor: COLORS.inputBg,
                  border: `1px solid ${COLORS.inputBorder}`,
                }}
                required
              />
            </div>

            {erro && (
              <p className="text-center text-sm text-red-500">
                {erro}
              </p>
            )}

            <button
              type="submit"
              className="mt-4 w-full rounded-lg py-3 font-medium text-white hover:opacity-90"
              style={{ backgroundColor: COLORS.primary }}
            >
              Entrar
            </button>
          </form>

          <div className="mt-6 text-center">
            <p style={{ color: COLORS.textBody }}>
              Não tem uma conta?{" "}
              <Link
                to="/cadastro"
                className="font-medium hover:underline"
                style={{ color: COLORS.primary }}
              >
                Cadastre-se
              </Link>
            </p>
          </div>
        </div>
      </div>
    </div>
  );
}
