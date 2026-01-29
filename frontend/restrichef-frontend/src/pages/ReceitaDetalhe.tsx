import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import api from "../api/api";


type Receita = {
  id: string;
  nome: string;
  descricao: string;
  tempo: string;
  porcoes: string;
  tags: string[];
  adequadoPara: string[];
  contemRestricoes: boolean;
};

export default function Receitas() {
    console.log("Receitas renderizou");
  const [receitas, setReceitas] = useState<Receita[]>([]);
  const navigate = useNavigate();

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

      {receitas.map((r) => (
        <div
          key={r.id}
          style={{ border: "1px solid #ccc", marginBottom: 10, padding: 10 }}
          onClick={() => navigate(`/receitas/${r.id}`)}
        >
          <h3>{r.nome}</h3>
          <p>{r.descricao}</p>
          <p>{r.tempo} • {r.porcoes}</p>

          {r.adequadoPara.length > 0 && (
            <p>{r.adequadoPara.join(", ")}</p>
          )}

          {r.contemRestricoes && (
            <strong style={{ color: "red" }}>
              Contém restrições do seu perfil
            </strong>
          )}
        </div>
      ))}
    </div>
  );
}
