import { Link } from "react-router-dom";

export default function Navbar() {
  return (
    <nav>
      <Link to="/">Pessoas</Link> | 
      <Link to="/categorias">Categorias</Link> | 
      <Link to="/transacoes">Transações</Link> | 
      <Link to="/totais">Totais</Link>
    </nav>
  );
}