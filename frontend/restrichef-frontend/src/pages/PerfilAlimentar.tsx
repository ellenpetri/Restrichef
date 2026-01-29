import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import api from "../api/api";

type Restricao = {
  id: string;
  nome: string;
  descricao: string;
};

export default function PerfilAlimentar() {
  const [restricoes, setRestricoes] = useState<Restricao[]>([]);
  const [selecionadas, setSelecionadas] = useState<string[]>([]);
  const navigate = useNavigate();

  useEffect(() => {
    async function carregar() {
      const [r, p] = await Promise.all([
        api.get<Restricao[]>("/api/users/restricoes"),
        api.get<{ restricaoIds: string[] }>("/api/users/perfil-alimentar"),
      ]);

      setRestricoes(r.data);
      setSelecionadas(p.data.restricaoIds ?? []);
    }

    carregar();
  }, []);

  function toggle(id: string) {
    setSelecionadas((prev) =>
      prev.includes(id) ? prev.filter((x) => x !== id) : [...prev, id]
    );
  }

  async function salvar() {
    await api.post("/api/users/perfil-alimentar", {
      restricaoIds: selecionadas,
    });

    navigate("/receitas");
  }

  return (
    <div>
      <h2>Perfil Alimentar</h2>

      {restricoes.map((r) => (
        <label key={r.id} style={{ display: "block" }}>
          <input
            type="checkbox"
            checked={selecionadas.includes(r.id)}
            onChange={() => toggle(r.id)}
          />
          {r.nome}
        </label>
      ))}

      <button onClick={salvar}>Salvar</button>
    </div>
  );
}
