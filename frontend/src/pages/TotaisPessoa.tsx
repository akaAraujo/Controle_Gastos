import { useEffect, useState } from "react";
import api from "../api/api";

interface TotalPessoa {
  pessoaId: number;
  pessoaNome: string;   // era "pessoa"
  totalRenda: number;   // era "totalReceitas"
  totalDespesas: number;
  balanco: number;      // era "saldo"
}

interface Totais {
  totalRenda: number;
  totalDespesas: number;
  balanco: number;
}

export default function TotaisPessoa() {

  const [dados, setDados] = useState<TotalPessoa[]>([]);
  const [totais, setTotais] = useState<Totais | null>(null);

  const carregar = async () => {
    try {
      const response = await api.get("/relatorios/pessoas");
      setDados(response.data.pessoas);     // 👈 aponta para o array correto
      setTotais(response.data.totais);     // 👈 aproveita os totais prontos da API
    } catch (error: any) {
      console.error("Erro:", error.response?.status, error.response?.data);
    }
  };

  useEffect(() => {
    carregar();
  }, []);

  return (
    <div>
      <h2>Totais por Pessoa</h2>

      <table>
        <thead>
          <tr>
            <th>Pessoa</th>
            <th>Receitas</th>
            <th>Despesas</th>
            <th>Saldo</th>
          </tr>
        </thead>
        <tbody>
          {dados.map((d) => (
            <tr key={d.pessoaId}>
              <td>{d.pessoaNome}</td>
              <td>{d.totalRenda}</td>
              <td>{d.totalDespesas}</td>
              <td>{d.balanco}</td>
            </tr>
          ))}
        </tbody>
      </table>

      {totais && (
        <>
          <h3>Total Geral</h3>
          <p>Receitas: {totais.totalRenda}</p>
          <p>Despesas: {totais.totalDespesas}</p>
          <p>Saldo: {totais.balanco}</p>
        </>
      )}
    </div>
  );
}