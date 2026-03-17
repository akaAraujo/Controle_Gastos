# 💰 Controle de Gastos

![.NET](https://img.shields.io/badge/.NET-8.0-blue)
![React](https://img.shields.io/badge/React-18-blue)
![TypeScript](https://img.shields.io/badge/TypeScript-5-blue)
![SQLite](https://img.shields.io/badge/SQLite-Database-lightgrey)

Sistema completo para gerenciamento de gastos e receitas de pessoas, desenvolvido como teste técnico utilizando .NET e React.

---

## 📌 Objetivo

O objetivo do projeto é permitir o controle financeiro, possibilitando:

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
- Total por categoria

---

## 📡 Endpoints principais da API

### Pessoas
- `GET /api/pessoas`
- `GET /api/pessoas/{id}` 
- `POST /api/pessoas`
- `PUT /api/pessoas/{ip}`
- `DELETE /api/pessoas/{id}`  

### Categorias
- `GET /api/categorias`  
- `POST /api/categorias`  

### Transações
- `GET /api/transacoes`  
- `POST /api/transacoes`  

### Relatórios
- `GET /api/reports/pessoas`
- `GET /api/reports/categorias`  

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
```
2. Restaure as dependências:
```bash 
dotnet restore
```
3. Execute o projeto:
```bash 
dotnet run
```

## ▶️ Executando o Front-end

1. Acesse a pasta do frontend:

```bash 
cd frontend
```
2. Instale as dependências:
```bash 
npm install
```
3. Execute a aplicação:
```bash 
npm start
```
