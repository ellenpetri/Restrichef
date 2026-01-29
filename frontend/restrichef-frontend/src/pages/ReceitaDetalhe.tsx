import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { ArrowLeft, Clock, Users, CheckCircle } from "lucide-react";
import api from "../api/api";
import { COLORS } from "../styles/colors";

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
  imagemUrl?: string;
};

export default function ReceitaDetalhe() {
  const { id } = useParams();
  const navigate = useNavigate();
  const [receita, setReceita] = useState<ReceitaDetalhe | null>(null);

  useEffect(() => {
    async function carregar() {
      const response = await api.get<ReceitaDetalhe>(`/api/receitas/${id}`);
      setReceita(response.data);
    }

    if (id) carregar();
  }, [id]);

  if (!receita) {
    return null;
  }

  return (
    <div style={{ backgroundColor: COLORS.background }}>
      <div className="relative h-[420px] w-full">
        {receita.imagemUrl ? (
          <img
            src={receita.imagemUrl}
            alt={receita.nome}
            className="h-full w-full object-cover"
          />
        ) : (
          <div className="h-full w-full bg-gray-300" />
        )}

        <div className="absolute inset-0 bg-black/40" />

        <div className="absolute left-6 top-6 z-10">
          <button
            onClick={() => navigate(-1)}
            className="flex items-center gap-2 text-white"
          >
            <ArrowLeft size={18} />
            Voltar
          </button>
        </div>

        {!receita.contemRestricoes && (
          <div className="absolute right-6 top-6 z-10 flex items-center gap-2 rounded-full bg-green-500 px-4 py-2 text-sm text-white">
            <CheckCircle size={16} />
            Compatível com seu perfil
          </div>
        )}

        <div className="absolute bottom-8 left-6 z-10 max-w-2xl text-white">
          <h1 className="mb-2 text-3xl font-semibold">
            {receita.nome}
          </h1>
          <p className="mb-4">{receita.descricao}</p>

          <div className="flex gap-6 text-sm">
            <div className="flex items-center gap-2">
              <Clock size={16} />
              {receita.tempo}
            </div>
            <div className="flex items-center gap-2">
              <Users size={16} />
              {receita.porcoes}
            </div>
          </div>
        </div>
      </div>

      <div className="mx-auto max-w-6xl px-6 py-12">
        <div className="grid gap-8 md:grid-cols-2">
          <div className="rounded-2xl bg-white p-6 shadow-sm">
            <h2
              className="mb-4 text-lg font-semibold"
              style={{ color: COLORS.textTitle }}
            >
              Ingredientes
            </h2>

            <ul className="space-y-3">
              {receita.ingredientes.map((i, index) => (
                <li key={index} className="flex items-start gap-3">
                  <span
                    className="mt-2 h-2 w-2 rounded-full"
                    style={{ backgroundColor: COLORS.primary }}
                  />
                  <span style={{ color: COLORS.textBody }}>
                    {i.quantidade} {i.nome}
                  </span>
                </li>
              ))}
            </ul>
          </div>

          <div className="rounded-2xl bg-white p-6 shadow-sm">
            <h2
              className="mb-4 text-lg font-semibold"
              style={{ color: COLORS.textTitle }}
            >
              Modo de Preparo
            </h2>

            <ol className="space-y-4">
              {receita.passosPreparo.map((p, index) => (
                <li key={index} className="flex gap-4">
                  <div
                    className="flex h-7 w-7 shrink-0 items-center justify-center rounded-full text-sm font-medium text-white"
                    style={{ backgroundColor: COLORS.primary }}
                  >
                    {index + 1}
                  </div>
                  <p style={{ color: COLORS.textBody }}>{p}</p>
                </li>
              ))}
            </ol>
          </div>
        </div>

        {receita.adequadoPara.length > 0 && (
          <div className="mt-10 rounded-2xl bg-white p-6 shadow-sm">
            <h2
              className="mb-4 text-lg font-semibold"
              style={{ color: COLORS.textTitle }}
            >
              Adequado para
            </h2>

            <div className="flex flex-wrap gap-3">
              {receita.adequadoPara.map((a) => (
                <span
                  key={a}
                  className="rounded-full px-4 py-2 text-sm"
                  style={{
                    backgroundColor: COLORS.inputBg,
                    color: COLORS.primary,
                  }}
                >
                  {a}
                </span>
              ))}
            </div>
          </div>
        )}
      </div>
    </div>
  );
}
