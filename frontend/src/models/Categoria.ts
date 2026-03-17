import { FinalidadeCategoria } from "./FinalidadeCategoria";

export interface Categoria {
  id?: number;
  descricao: string;
  finalidade: FinalidadeCategoria;
}