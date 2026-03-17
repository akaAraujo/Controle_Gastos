import { useEffect, useState } from "react";
import { Transacao } from "../models/Transacao";
import { Pessoa } from "../models/Pessoa";
import { Categoria } from "../models/Categoria";

import { listarTransacoes, criarTransacao } from "../services/transacaoService";
import { listarPessoas } from "../services/pessoaService";
import { listarCategorias } from "../services/categoriaService";

export default function Transacoes() {

  const [transacoes, setTransacoes] = useState<Transacao[]>([]);
  const [pessoas, setPessoas] = useState<Pessoa[]>([]);
  const [categorias, setCategorias] = useState<Categoria[]>([]);

  const [descricao, setDescricao] = useState("");
  const [valor, setValor] = useState(0);
  const [tipo, setTipo] = useState(0);
  const [categoriaId, setCategoriaId] = useState(0);
  const [pessoaId, setPessoaId] = useState(0);

  const carregar = async () => {

    const t = await listarTransacoes();
    const p = await listarPessoas();
    const c = await listarCategorias();

    setTransacoes(t);
    setPessoas(p);
    setCategorias(c);
  };

  useEffect(() => {
    carregar();
  }, []);

  const salvar = async () => {

    const nova: Transacao = {
      id: 0,
      descricao,
      valor,
      tipo,
      categoriaId,
      pessoaId
    };

    await criarTransacao(nova);

    carregar();
  };

  return (

    <div>

      <h2>Transações</h2>

      <input
        placeholder="Descrição"
        onChange={(e) => setDescricao(e.target.value)}
      />

      <input
        type="number"
        placeholder="Valor"
        onChange={(e) => setValor(Number(e.target.value))}
      />

      <select onChange={(e) => setTipo(Number(e.target.value))}>
        <option value="0">Despesa</option>
        <option value="1">Receita</option>
      </select>

      <select onChange={(e) => setPessoaId(Number(e.target.value))}>

        <option>Selecione Pessoa</option>

        {pessoas.map((p) => (

          <option key={p.id} value={p.id}>
            {p.nome}
          </option>

        ))}

      </select>

      <select onChange={(e) => setCategoriaId(Number(e.target.value))}>

        <option>Selecione Categoria</option>

        {categorias.map((c) => (

          <option key={c.id} value={c.id}>
            {c.descricao}
          </option>

        ))}

      </select>

      <button onClick={salvar}>Salvar</button>

      <ul>

        {transacoes.map((t) => (

          <li key={t.id}>
            {t.descricao} - {t.valor} - {t.tipo}
          </li>

        ))}

      </ul>

    </div>

  );
}