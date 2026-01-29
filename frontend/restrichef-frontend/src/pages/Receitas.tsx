import { useEffect, useState } from "react";
import api from "../api/api";

type Receita = {
  id: string;
  nome: string;
  descricao: string;
};

export default function Receitas() {
  const [receitas, setReceitas] = useState<Receita[]>([]);

  useEffect(() => {
    async function carregar() {
      const response = await api.get<Receita[]>("/api/receitas");
      setReceitas(response.data);
    }

    carregar();
  }, []);

  return (
    <div>
      <h2>Receitas</h2>

      {receitas.length === 0 && <p>Nenhuma receita encontrada.</p>}

      {receitas.map((r) => (
        <div key={r.id} style={{ marginBottom: 10 }}>
          <strong>{r.nome}</strong>
          <p>{r.descricao}</p>
        </div>
      ))}
    </div>
  );
}
