import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../auth/useAuth";

export default function Login() {
  const [email, setEmail] = useState("");
  const [senha, setSenha] = useState("");
  const [erro, setErro] = useState("");

  const { login, token } = useAuth();
  const navigate = useNavigate();

  useEffect(() => {
    if (token) {
      navigate("/receitas");
    }
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
    <form onSubmit={handleSubmit}>
      <h2>Login</h2>

      <input
        type="email"
        placeholder="E-mail"
        value={email}
        onChange={(e) => setEmail(e.target.value)}
      />

      <input
        type="password"
        placeholder="Senha"
        value={senha}
        onChange={(e) => setSenha(e.target.value)}
      />

      {erro && <p>{erro}</p>}

      <button type="submit">Entrar</button>
    </form>
  );
}
