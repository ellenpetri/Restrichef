import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import Login from "../pages/Login";
import Cadastro from "../pages/Cadastro";
import PerfilAlimentar from "../pages/PerfilAlimentar";
import Receitas from "../pages/Receitas";
import ReceitaDetalhe from "../pages/ReceitaDetalhe";
import PrivateRoute from "../auth/PrivateRoute";
import Logout from "../pages/Logout";

export default function AppRoutes() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Navigate to="/login" />} />
        <Route path="/login" element={<Login />} />
        <Route path="/cadastro" element={<Cadastro />} />
        <Route path="/logout" element={<Logout />} />

        <Route
          path="/perfil-alimentar"
          element={
            <PrivateRoute>
              <PerfilAlimentar />
            </PrivateRoute>
          }
        />

        <Route
          path="/receitas"
          element={
            <PrivateRoute>
              <Receitas />
            </PrivateRoute>
          }
        />

        <Route
          path="/receitas/:id"
          element={
            <PrivateRoute>
              <ReceitaDetalhe />
            </PrivateRoute>
          }
        />
      </Routes>
    </BrowserRouter>
  );
}
