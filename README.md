# Hypesoft - Sistema de Gestão de Produtos

## Descrição

Este projeto é uma solução completa para gestão de produtos e categorias, desenvolvido como desafio técnico para a Hypesoft. O sistema permite criar, listar, editar e excluir produtos e categorias, com autenticação integrada via Keycloak, interface responsiva e moderna.


## Funcionalidades

### Gestão de Produtos
- ✅ Criar, listar, editar e excluir produtos
- ✅ Campos: nome, descrição, preço, categoria, quantidade em estoque
- ✅ Validação de dados obrigatórios
- ✅ Busca por nome do produto
- ✅ Filtragem por categoria

### Sistema de Categorias
- ✅ Criar, editar e excluir categorias
- ✅ Associação de produtos a categorias
- ✅ Lista simples de categorias

### Autenticação e Segurança
- ✅ Integração com Keycloak para autenticação OAuth2/OpenID Connect
- ✅ Login via Keycloak
- ✅ Proteção de rotas no frontend
- ✅ Autorização baseada em roles do Keycloak
- ✅ Logout integrado

### Interface e UX
- ✅ Design responsivo e moderno
- ✅ Tema escuro na tela de login
- ✅ Botões estilizados (verde escuro para salvar, outline roxo para login)
- ✅ Notificações com Sonner
- ✅ Validação de formulários com React Hook Form e Zod

## Tecnologias Utilizadas

### Frontend
- **React 18** com TypeScript
- **Vite** para build e dev server
- **Tailwind CSS** para estilização
- **React Router** para navegação
- **React Query** para gerenciamento de estado e API
- **Keycloak JS** para autenticação
- **React Hook Form + Zod** para formulários e validação
- **Radix UI** para componentes acessíveis
- **Lucide React** para ícones

### Backend
- **.NET 8** com C#
- **ASP.NET Core** Web API
- **MongoDB** para banco de dados
- **Clean Architecture** (Domain, Application, Infrastructure, API)
- **CQRS + Mediator** com MediatR
- **FluentValidation** para validação
- **Swagger** para documentação da API

### Infraestrutura
- **Docker Compose** para orquestração (MongoDB + Keycloak)
- **JWT** para autenticação na API

## Pré-requisitos

- Node.js 18+
- .NET 8 SDK
- Docker e Docker Compose

## Instalação e Execução

### Clone o repositório
```bash
git clone https://github.com/seu-usuario/hypesoft-challenge.git
cd hypesoft-challenge
```

### Configure o Keycloak
1. Inicie os serviços com Docker:
   ```bash
   docker-compose up -d
   ```
2. Acesse http://localhost:8080 (login: admin/admin)
3. Crie o realm "hypesoft"
4. Crie o client "frontend" (public, Standard flow, redirect URIs: http://localhost:5173/*)
5. Crie um usuário para teste

### Execute o Backend
```bash
cd Hypesoft.API
dotnet run
```
- API rodará em http://localhost:5000

### Execute o Frontend
```bash
cd frontend
npm install
npm run dev
```
- App rodará em http://localhost:5173

## Estrutura do Projeto

```
hypesoft-challenge/
├── frontend/                 # Aplicação React
│   ├── src/
│   │   ├── auth/            # Autenticação com Keycloak
│   │   ├── components/      # Componentes reutilizáveis
│   │   ├── hooks/           # Hooks customizados
│   │   ├── pages/           # Páginas da aplicação
│   │   ├── routes/          # Configuração de rotas
│   │   └── schemas/         # Validações Zod
├── Hypesoft.API/            # API .NET
│   ├── Controllers/         # Endpoints
│   ├── Middlewares/         # Middlewares customizados
│   └── Properties/          # Configurações
├── Hypesoft.Application/    # Camada de aplicação (CQRS)
├── Hypesoft.Domain/         # Entidades e regras de negócio
├── Hypesoft.Infrastructure/ # Infraestrutura (MongoDB)
└── docker-compose.yml       # Serviços Docker
```

## API Endpoints

### Produtos
- `GET /api/products` - Listar produtos
- `POST /api/products` - Criar produto
- `PUT /api/products/{id}` - Atualizar produto
- `DELETE /api/products/{id}` - Excluir produto

### Categorias
- `GET /api/categories` - Listar categorias
- `POST /api/categories` - Criar categoria
- `PUT /api/categories/{id}` - Atualizar categoria
- `DELETE /api/categories/{id}` - Excluir categoria

## Desenvolvimento

### Scripts Disponíveis
```bash
# Frontend
npm run dev      # Inicia dev server
npm run build    # Build para produção
npm run lint     # Executa ESLint

# Backend
dotnet build     # Build do projeto
dotnet test      # Executa testes
```

### Variáveis de Ambiente
- Frontend: Configure `VITE_API_URL` se necessário
- Backend: Ajuste `appsettings.json` para MongoDB e Keycloak

## Contribuição

1. Fork o projeto
2. Crie uma branch para sua feature (`git checkout -b feature/nova-feature`)
3. Commit suas mudanças (`git commit -am 'Adiciona nova feature'`)
4. Push para a branch (`git push origin feature/nova-feature`)
5. Abra um Pull Request

## Licença

Este projeto é para fins educacionais e de demonstração.

## Autor

Desenvolvido por [Renan Damprelli Cardoso da Silva](https://github.com/Damprelli11) como parte do desafio técnico Hypesoft.