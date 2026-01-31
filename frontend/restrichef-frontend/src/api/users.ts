import api from "./api";

export interface RegisterUserRequest {
  nome: string;
  email: string;
  senha: string;
}

export function registerUser(data: RegisterUserRequest) {
  return api.post("/api/users", data);
}

export function getUsers() {
  return api.get("/api/users");
}
