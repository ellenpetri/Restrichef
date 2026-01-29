import { useEffect, useRef, useState } from "react";
import { useNavigate } from "react-router-dom";
import { ChefHat, Search, User, LogOut } from "lucide-react";
import api from "../api/api";
import { COLORS } from "../styles/colors";

type Receita = {
  id: string;
  nome: string;
  descricao: string;
  tempo: string;
  porcoes: string;
  adequadoPara: string[];
  tags: string[];
  imagemUrl?: string;
};

export default function Receitas() {
  const [receitas, setReceitas] = useState<Receita[]>([]);
  const [busca, setBusca] = useState("");
  const [menuAberto, setMenuAberto] = useState(false);
  const menuRef = useRef<HTMLDivElement | null>(null);
  const navigate = useNavigate();

  useEffect(() => {
    async function carregar() {
      const response = await api.get<Receita[]>("/api/receitas");
      setReceitas(response.data);
    }

    carregar();
  }, []);

  useEffect(() => {
    function fechar(e: MouseEvent) {
      if (menuRef.current && !menuRef.current.contains(e.target as Node)) {
        setMenuAberto(false);
      }
    }

    document.addEventListener("mousedown", fechar);
    return () => document.removeEventListener("mousedown", fechar);
  }, []);

  const filtradas = receitas.filter((r) =>
    r.nome.toLowerCase().includes(busca.toLowerCase())
  );

  function sair() {
    localStorage.removeItem("token");
    navigate("/logout");
  }

  return (
    <div className="min-h-screen" style={{ backgroundColor: COLORS.background }}>
      <div className="border-b bg-white relative z-10">
        <div className="mx-auto flex max-w-6xl items-center justify-between px-6 py-6">
          <div className="flex items-center gap-3">
            <div
              className="flex h-10 w-10 items-center justify-center rounded-full"
              style={{ backgroundColor: COLORS.primary }}
            >
              <ChefHat size={20} className="text-white" />
            </div>

            <div>
              <h1
                className="text-xl font-semibold"
                style={{ color: COLORS.textTitle }}
              >
                Minhas Receitas
              </h1>
              <p className="text-sm" style={{ color: COLORS.textBody }}>
                Personalizadas para você
              </p>
            </div>
          </div>

          <div className="relative" ref={menuRef}>
            <button
              onClick={() => setMenuAberto((v) => !v)}
              className="flex h-10 w-10 items-center justify-center rounded-full"
              style={{ backgroundColor: COLORS.primary }}
            >
              <User size={20} className="text-white" />
            </button>

            {menuAberto && (
              <div className="absolute right-0 mt-3 w-64 rounded-xl border bg-white shadow-lg z-50">
                <button
                  onClick={() => navigate("/perfil-alimentar")}
                  className="flex w-full items-center gap-3 px-4 py-3 text-sm hover:bg-gray-50"
                  style={{ color: COLORS.textTitle }}
                >
                  <User size={16} />
                  Configuração do Perfil Alimentar
                </button>

                <div className="h-px bg-gray-100" />

                <button
                  onClick={sair}
                  className="flex w-full items-center gap-3 px-4 py-3 text-sm hover:bg-gray-50"
                  style={{ color: COLORS.textTitle }}
                >
                  <LogOut size={16} />
                  Sair
                </button>
              </div>
            )}
          </div>
        </div>

        <div className="mx-auto max-w-6xl px-6 pb-6">
          <div className="relative">
            <Search
              size={18}
              className="absolute left-4 top-1/2 -translate-y-1/2"
              style={{ color: COLORS.textBody }}
            />
            <input
              type="text"
              value={busca}
              onChange={(e) => setBusca(e.target.value)}
              placeholder="Buscar receitas..."
              className="w-full rounded-lg py-3 pl-11 pr-4 outline-none"
              style={{
                backgroundColor: COLORS.inputBg,
                border: `1px solid ${COLORS.inputBorder}`,
              }}
            />
          </div>
        </div>
      </div>

      <div className="mx-auto max-w-6xl px-6 py-10">
        <div className="grid gap-8 sm:grid-cols-2 lg:grid-cols-3">
          {filtradas.map((r) => (
            <button
              key={r.id}
              onClick={() => navigate(`/receitas/${r.id}`)}
              className="overflow-hidden rounded-2xl bg-white text-left shadow-sm transition hover:shadow-md"
            >
              <div className="h-44 w-full bg-gray-200">
                {r.imagemUrl ? (
                  <img
                    src={r.imagemUrl}
                    alt={r.nome}
                    className="h-full w-full object-cover"
                  />
                ) : (
                  <div
                    className="flex h-full w-full items-center justify-center text-sm"
                    style={{ color: COLORS.textBody }}
                  >
                    Imagem da receita
                  </div>
                )}
              </div>

              <div className="p-5">
                <h2
                  className="mb-1 text-lg font-semibold"
                  style={{ color: COLORS.textTitle }}
                >
                  {r.nome}
                </h2>

                <p
                  className="mb-3 text-sm"
                  style={{ color: COLORS.textBody }}
                >
                  {r.descricao}
                </p>

                <div
                  className="mb-4 flex gap-4 text-sm"
                  style={{ color: COLORS.textBody }}
                >
                  <span>⏱ {r.tempo}</span>
                  <span>👤 {r.porcoes}</span>
                </div>

                {r.adequadoPara.length > 0 && (
                  <div className="mb-3 flex flex-wrap gap-2">
                    {r.adequadoPara.map((a) => (
                      <span
                        key={a}
                        className="rounded-full px-3 py-1 text-xs font-medium"
                        style={{
                          backgroundColor: COLORS.inputBg,
                          color: COLORS.primary,
                        }}
                      >
                        {a}
                      </span>
                    ))}
                  </div>
                )}

                {r.tags.length > 0 && (
                  <div className="flex flex-wrap gap-2">
                    {r.tags.map((t) => (
                      <span
                        key={t}
                        className="rounded-full px-3 py-1 text-xs"
                        style={{
                          backgroundColor: COLORS.inputBg,
                          color: COLORS.textBody,
                        }}
                      >
                        {t}
                      </span>
                    ))}
                  </div>
                )}
              </div>
            </button>
          ))}
        </div>
      </div>
    </div>
  );
}
