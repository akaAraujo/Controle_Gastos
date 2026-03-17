import { useEffect, useState } from "react";
import api from "../api/api";

interface TotalCategoria {
  categoriaId: number;
  categoriaDescricao: string;
  totalReceita: number;
  totalDespesas: number;
  balanco: number;
}

interface Totais {
  totalReceita: number;
  totalDespesas: number;
  balanco: number;
}

export default function TotaisCategoria() {

  const [dados, setDados] = useState<TotalCategoria[]>([]);
  const [totais, setTotais] = useState<Totais | null>(null);

  const carregar = async () => {
    try {
      const response = await api.get("/relatorios/categorias");
      setDados(response.data.categorias);
      setTotais(response.data.totais);
    } catch (error: any) {
      console.error("Erro:", error.response?.status, error.response?.data);
    }
  };

  useEffect(() => {
    carregar();
  }, []);

  return (
    <div>
      <h2>Totais por Categoria</h2>

      <table>
        <thead>
          <tr>
            <th>Categoria</th>
            <th>Receitas</th>
            <th>Despesas</th>
            <th>Saldo</th>
          </tr>
        </thead>
        <tbody>
          {dados.map((d) => (
            <tr key={d.categoriaId}>
              <td>{d.categoriaDescricao}</td>
              <td>{d.totalReceita}</td>
              <td>{d.totalDespesas}</td>
              <td>{d.balanco}</td>
            </tr>
          ))}
        </tbody>
      </table>

      {totais && (
        <>
          <h3>Total Geral</h3>
          <p>Receitas: {totais.totalReceita}</p>
          <p>Despesas: {totais.totalDespesas}</p>
          <p>Saldo: {totais.balanco}</p>
        </>
      )}
    </div>
  );
}