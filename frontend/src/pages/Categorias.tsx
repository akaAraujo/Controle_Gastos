import { useEffect, useState } from "react";
import { Categoria } from "../models/Categoria";
import { FinalidadeCategoria } from "../models/FinalidadeCategoria";
import { listarCategorias, criarCategoria } from "../services/categoriaService";

export default function Categorias() {

  const [categorias, setCategorias] = useState<Categoria[]>([]);

  const [descricao, setDescricao] = useState("");

  const [finalidade, setFinalidade] = useState<FinalidadeCategoria>(
    FinalidadeCategoria.Despesa
  );

  const carregar = async () => {

    try {

      const data = await listarCategorias();

      setCategorias(data);

    } catch (error) {

      console.error("Erro ao buscar categorias", error);

    }

  };

  useEffect(() => {

    carregar();

  }, []);

  const salvar = async () => {

    try {

      const novaCategoria: Categoria = {

        descricao: descricao,
        finalidade: finalidade

      };

      await criarCategoria(novaCategoria);

      setDescricao("");

      setFinalidade(FinalidadeCategoria.Despesa);

      carregar();

    } catch (error: any) {

      console.error("Erro ao salvar categoria", error.response?.data);

    }

  };

  return (

    <div>

      <h2>Categorias</h2>

      <div>

        <input
          type="text"
          placeholder="Descrição"
          value={descricao}
          onChange={(e) => setDescricao(e.target.value)}
        />

      </div>

      <div>

        <select
          value={finalidade}
          onChange={(e) => setFinalidade(Number(e.target.value))}
        >

          <option value={FinalidadeCategoria.Despesa}>
            Despesa
          </option>

          <option value={FinalidadeCategoria.Receita}>
            Receita
          </option>

          <option value={FinalidadeCategoria.Ambas}>
            Ambas
          </option>

        </select>

      </div>

      <button onClick={salvar}>
        Salvar
      </button>

      <h3>Lista de Categorias</h3>

      <ul>

        {categorias.map((categoria) => (

          <li key={categoria.id}>

            {categoria.descricao} - {" "}

            {categoria.finalidade === FinalidadeCategoria.Despesa && "Despesa"}

            {categoria.finalidade === FinalidadeCategoria.Receita && "Receita"}

            {categoria.finalidade === FinalidadeCategoria.Ambas && "Ambas"}

          </li>

        ))}

      </ul>

    </div>

  );

}