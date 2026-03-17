# 💰 Controle de Gastos Residenciais

![.NET](https://img.shields.io/badge/.NET-8.0-blue)
![React](https://img.shields.io/badge/React-18-blue)
![TypeScript](https://img.shields.io/badge/TypeScript-5-blue)
![SQLite](https://img.shields.io/badge/SQLite-Database-lightgrey)
![Status](https://img.shields.io/badge/status-finalizado-success)
![License](https://img.shields.io/badge/license-MIT-green)

Sistema completo para gerenciamento de gastos e receitas de pessoas, desenvolvido como teste técnico utilizando .NET e React.

---

## 📌 Objetivo

O objetivo do projeto é permitir o controle financeiro de um ambiente residencial, possibilitando:

- Cadastro de pessoas
- Cadastro de categorias
- Registro de transações (receitas e despesas)
- Consulta de totais por pessoa

Além disso, o sistema aplica regras de negócio importantes, como:

- Menores de idade só podem possuir despesas
- Categorias devem ser compatíveis com o tipo da transação
- Exclusão de pessoas remove automaticamente suas transações

---

## 🧱 Arquitetura do Projeto

O projeto foi dividido em duas partes principais:
/backend → API REST em .NET
/frontend → Interface web em React + TypeScript


---

## ⚙️ Tecnologias Utilizadas

### 🔹 Back-end
- .NET 8 (LTS)  
- ASP.NET Core Web API  
- Entity Framework Core  
- SQLite  
- Swagger (OpenAPI)  

### 🔹 Front-end
- React  
- TypeScript  
- Axios  
- React Router DOM  

---

## 📊 Modelo de Dados

### Pessoa
- Id (auto gerado)  
- Nome (máx. 200 caracteres)  
- Idade  

### Categoria
- Id (auto gerado)  
- Descrição (máx. 400 caracteres)  
- Finalidade:  
  - Despesa  
  - Receita  
  - Ambas  

### Transação
- Id (auto gerado)  
- Descrição (máx. 400 caracteres)  
- Valor (positivo)  
- Tipo:  
  - Despesa  
  - Receita  
- Categoria (FK)  
- Pessoa (FK)  

---

## 🔁 Fluxo de Funcionamento

### 1. Cadastro de Pessoa
Usuário cria uma pessoa informando nome e idade.

### 2. Cadastro de Categoria
Usuário cria categorias com finalidade (despesa, receita ou ambas).

### 3. Cadastro de Transação

Ao cadastrar uma transação, o sistema:

- Verifica se a pessoa existe  
- Verifica se a categoria existe  
- Valida regras de negócio:  
  - Menores de idade não podem possuir receitas  
  - Categoria deve ser compatível com o tipo da transação  

### 4. Relatórios

O sistema calcula:

- Total de receitas por pessoa  
- Total de despesas por pessoa  
- Saldo (receitas - despesas)  
- Total geral consolidado  

---

## 📡 Endpoints principais da API

### Pessoas
- `GET /api/pessoas`  
- `POST /api/pessoas`  
- `DELETE /api/pessoas/{id}`  

### Categorias
- `GET /api/categorias`  
- `POST /api/categorias`  

### Transações
- `GET /api/transacoes`  
- `POST /api/transacoes`  

### Relatórios
- `GET /api/reports/pessoas`  

---

## 🚀 Como executar o projeto

### 🔹 Pré-requisitos

- .NET 8 SDK  
- Node.js (v18 ou superior)  
- npm  

---

## ▶️ Executando o Back-end

1. Acesse a pasta do backend:

```bash
cd backend
dotnet restore
dotnet run
cd frontend
npm install
npm start
```
