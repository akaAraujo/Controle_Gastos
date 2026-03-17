import { BrowserRouter, Routes, Route } from "react-router-dom";
import Pessoas from "./pages/Pessoas";
import Categorias from "./pages/Categorias";
import Transacoes from "./pages/Transacoes";
import TotaisPessoa from "./pages/TotaisPessoa";
import TotaisCategoria from "./pages/TotaisCategoria";
import Navbar from "./components/Navbar";

function App() {

  return (

    <BrowserRouter>

      <Navbar />

      <Routes>

        <Route path="/" element={<Pessoas />} />

        <Route path="/categorias" element={<Categorias />} />

        <Route path="/transacoes" element={<Transacoes />} />

        <Route path="/totais" element={<TotaisPessoa />} />

        <Route path="/totais-categoria" element={<TotaisCategoria />} />
      </Routes>

    </BrowserRouter>

  );
}

export default App;