import api from "../api/api";
import { Transacao } from "../models/Transacao";

export const listarTransacoes = async (): Promise<Transacao[]> => {
  const response = await api.get("/transacoes");
  return response.data;
};

export const criarTransacao = async (transacao: Transacao) => {
  return api.post("/transacoes", transacao);
};