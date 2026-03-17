import api from "../api/api";
import { Categoria } from "../models/Categoria";

export const listarCategorias = async (): Promise<Categoria[]> => {

  const response = await api.get("/categorias");

  return response.data;

};

export const criarCategoria = async (categoria: Categoria) => {

  return await api.post("/categorias", categoria);

};