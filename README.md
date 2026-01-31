# Restrichef 🍽️
Aplicação Web Full Stack para Apoio a Pessoas com Restrições Alimentares

==================================================

SOBRE O PROJETO

O Restrichef é uma aplicação web full stack desenvolvida como Trabalho de Conclusão de Curso (TCC) da Pós-Graduação em Desenvolvimento Full Stack.

O objetivo da aplicação é auxiliar pessoas com restrições e preferências alimentares — como intolerâncias, alergias ou escolhas de estilo de vida (ex.: celíacos, veganos e vegetarianos) — a encontrarem receitas compatíveis com seu perfil alimentar, de forma automática, segura e personalizada.

A solução elimina a necessidade de filtragens manuais repetitivas e reduz o risco de consumo de alimentos incompatíveis com o perfil do usuário.

--------------------------------------------------

FUNCIONALIDADES PRINCIPAIS

- Cadastro e autenticação de usuários
- Configuração do perfil alimentar (restrições e preferências)
- Filtragem automática de receitas conforme o perfil do usuário
- Listagem personalizada de receitas
- Visualização detalhada de ingredientes e modo de preparo
- Segurança de acesso baseada em autenticação JWT

--------------------------------------------------

ARQUITETURA DA SOLUÇÃO

A aplicação segue o modelo cliente–servidor, com separação clara de responsabilidades.

Frontend
- React + Vite
- SPA (Single Page Application)
- Consumo da API via HTTP
- Responsável apenas pela camada de apresentação

Backend
- API REST desenvolvida em C# com .NET
- Centralização das regras de negócio
- Filtragem de receitas baseada no perfil alimentar
- Autenticação via JWT

Banco de Dados
- SQL Server
- Persistência relacional
- Acesso exclusivo pelo backend

Toda a aplicação é executada em containers Docker, garantindo padronização do ambiente.

--------------------------------------------------

TECNOLOGIAS UTILIZADAS

Frontend:
- React
- TypeScript
- Vite
- Axios

Backend:
- C#
- .NET
- Entity Framework Core

Banco de Dados:
- SQL Server

Infraestrutura:
- Docker
- Docker Compose

Versionamento:
- Git
- GitHub

--------------------------------------------------

COMO EXECUTAR O PROJETO (DOCKER)

Pré-requisitos:
- Docker instalado
- Docker Compose instalado

Não é necessário instalar Node.js, .NET ou SQL Server localmente.

Passo 1 — Clonar o repositório
git clone https://github.com/ellenpetri/Restrichef.git

Passo 2 — Acessar a pasta do backend
cd Restrichef/backend/Restrichef.Api

Passo 3 — Subir a aplicação com Docker
docker compose up -d

Esse comando irá:
- Criar e iniciar o banco de dados SQL Server
- Criar e iniciar a API backend
- Criar e iniciar o frontend
- Configurar automaticamente a comunicação entre os serviços

Passo 4 — Acessar a aplicação

Frontend:
http://localhost:3000

Backend (health check):
http://localhost:5000/health

Encerrar a aplicação:
docker compose down

--------------------------------------------------

ORGANIZAÇÃO DO REPOSITÓRIO

ORGANIZAÇÃO DO REPOSITÓRIO

Restrichef/

- backend/
  - Restrichef.Api
    (API em .NET)

- frontend/
  - restrichef-frontend
    (Aplicação React)


--------------------------------------------------

CONTEXTO ACADÊMICO

Este projeto foi desenvolvido como parte do Trabalho de Conclusão de Curso da Pós-Graduação em Desenvolvimento Full Stack, com foco na aplicação prática dos conceitos de:

- Arquitetura de software
- Desenvolvimento backend e frontend
- Integração entre sistemas
- Organização do ciclo de desenvolvimento
- Boas práticas de versionamento e documentação

O repositório público serve como evidência prática da implementação descrita no trabalho acadêmico.

--------------------------------------------------

AUTORA

Ellen Carolina Petri
Pós-Graduação em Desenvolvimento Full Stack
Orientador: Alexandre Agustini
Ano: 2026
