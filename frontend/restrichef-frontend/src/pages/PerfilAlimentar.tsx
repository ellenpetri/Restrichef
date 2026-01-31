import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import api from "../api/api";
import { COLORS } from "../styles/colors";

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

    localStorage.setItem("perfil_alimentar_configurado", "true");
    navigate("/receitas");
  }

  return (
    <div
      className="min-h-screen px-4 py-8"
      style={{ backgroundColor: COLORS.background }}
    >
      <div className="mx-auto max-w-3xl">
        <div className="mb-8 text-center">
          <h1
            className="mb-3 text-3xl font-semibold"
            style={{ color: COLORS.textTitle }}
          >
            Configure seu perfil alimentar
          </h1>
          <p
            className="mx-auto max-w-2xl text-base"
            style={{ color: COLORS.textBody }}
          >
            Selecione suas restrições alimentares para personalizar as receitas
            de acordo com suas necessidades. Você poderá alterar essas
            configurações a qualquer momento.
          </p>
        </div>

        <div
          className="rounded-2xl p-6 shadow-lg"
          style={{ backgroundColor: COLORS.card }}
        >
          <h2
            className="mb-5 text-lg font-semibold"
            style={{ color: COLORS.textTitle }}
          >
            Restrições alimentares
          </h2>

          <div className="grid gap-3 md:grid-cols-2">
            {restricoes.map((r) => {
              const ativa = selecionadas.includes(r.id);

              return (
                <button
                  key={r.id}
                  type="button"
                  onClick={() => toggle(r.id)}
                  className="flex items-start gap-3 rounded-xl border p-4 text-left transition"
                  style={{
                    backgroundColor: ativa
                      ? COLORS.inputBg
                      : COLORS.card,
                    borderColor: ativa
                      ? COLORS.primary
                      : COLORS.inputBorder,
                  }}
                >
                  <div
                    className="mt-1 flex h-5 w-5 items-center justify-center rounded-full border-2"
                    style={{
                      borderColor: ativa
                        ? COLORS.primary
                        : COLORS.inputBorder,
                    }}
                  >
                    {ativa && (
                      <div
                        className="h-2.5 w-2.5 rounded-full"
                        style={{ backgroundColor: COLORS.primary }}
                      />
                    )}
                  </div>

                  <div>
                    <p
                      className="text-base font-medium"
                      style={{ color: COLORS.textTitle }}
                    >
                      {r.nome}
                    </p>
                    <p
                      className="text-sm"
                      style={{ color: COLORS.textBody }}
                    >
                      {r.descricao}
                    </p>
                  </div>
                </button>
              );
            })}
          </div>
        </div>

        <div className="mt-8 flex justify-center">
          <button
            onClick={salvar}
            className="rounded-lg px-10 py-3 text-base font-medium text-white hover:opacity-90"
            style={{ backgroundColor: COLORS.primary }}
          >
            Salvar e continuar
          </button>
        </div>
      </div>
    </div>
  );
}
