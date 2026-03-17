import api from "../api/api";
import { Pessoa } from "../models/Pessoa";

export const listarPessoas = async (): Promise<Pessoa[]> => {
  const response = await api.get("/pessoas");
  return response.data;
};

export const criarPessoa = async (pessoa: Pessoa) => {
  return api.post("/pessoas", pessoa);
};

export const deletarPessoa = async (id: number) => {
  return api.delete(`/pessoas/${id}`);
};