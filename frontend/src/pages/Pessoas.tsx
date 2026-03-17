import { useEffect, useState } from "react";
import { Pessoa } from "../models/Pessoa";
import { listarPessoas, criarPessoa, deletarPessoa } from "../services/pessoaService";

export default function Pessoas() {

  const [pessoas, setPessoas] = useState<Pessoa[]>([]);
  const [nome, setNome] = useState("");
  const [idade, setIdade] = useState(0);

  const carregar = async () => {
    const data = await listarPessoas();
    setPessoas(data);
  };

  useEffect(() => {
    carregar();
  }, []);

  const salvar = async () => {
    await criarPessoa({ id: 0, nome, idade });
    carregar();
  };

  return (
    <div>

      <h2>Pessoas</h2>

      <input
        placeholder="Nome"
        onChange={(e) => setNome(e.target.value)}
      />

      <input
        placeholder="Idade"
        type="number"
        onChange={(e) => setIdade(Number(e.target.value))}
      />

      <button onClick={salvar}>Salvar</button>

      <ul>
        {pessoas.map((p) => (
          <li key={p.id}>
            {p.nome} - {p.idade}
            <button onClick={() => deletarPessoa(p.id)}>Excluir</button>
          </li>
        ))}
      </ul>

    </div>
  );
}