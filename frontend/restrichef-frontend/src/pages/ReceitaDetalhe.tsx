import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import api from "../api/api";

type Ingrediente = {
  nome: string;
  quantidade: string;
};

type ReceitaDetalhe = {
  id: string;
  nome: string;
  descricao: string;
  tempo: string;
  porcoes: string;
  ingredientes: Ingrediente[];
  passosPreparo: string[];
  adequadoPara: string[];
  contemRestricoes: boolean;
};

export default function ReceitaDetalhe() {
  const { id } = useParams();
  const [receita, setReceita] = useState<ReceitaDetalhe | null>(null);

  useEffect(() => {
    async function carregar() {
      const response = await api.get<ReceitaDetalhe>(`/api/receitas/${id}`);
      setReceita(response.data);
    }

    if (id) {
      carregar();
    }
  }, [id]);

  if (!receita) {
    return <p>Carregando receita...</p>;
  }

  return (
    <div>
      <h2>{receita.nome}</h2>
      <p>{receita.descricao}</p>

      <p>
        {receita.tempo} • {receita.porcoes}
      </p>

      {receita.adequadoPara.length > 0 && (
        <p>{receita.adequadoPara.join(", ")}</p>
      )}

      {receita.contemRestricoes && (
        <strong style={{ color: "red" }}>
          Contém restrições do seu perfil
        </strong>
      )}

      <h3>Ingredientes</h3>
      <ul>
        {receita.ingredientes.map((i, index) => (
          <li key={index}>
            {i.quantidade} - {i.nome}
          </li>
        ))}
      </ul>

      <h3>Modo de preparo</h3>
      <ol>
        {receita.passosPreparo.map((p, index) => (
          <li key={index}>{p}</li>
        ))}
      </ol>
    </div>
  );
}
