# celticsTech API

## Visão Geral

A **celticsTech API** é um sistema de gerenciamento veterinário desenvolvido com **ASP.NET Core 8**, **Entity Framework Core**, **Oracle Database** e **Docker**.

O projeto foi desenvolvido seguindo princípios de arquitetura REST e arquitetura em camadas utilizando:

* Controllers
* Services
* Repositories
* DTOs
* Middleware
* Entity Framework Core

A API permite o gerenciamento de:

* Usuários
* Pets
* Veterinários
* Consultas

---

# Tecnologias

## Backend

* ASP.NET Core 8
* C#
* Entity Framework Core
* Oracle Database
* Swagger / OpenAPI
* Docker
* Docker Compose

## Arquitetura

* API REST
* Repository Pattern
* Service Layer Pattern
* DTO Pattern
* Middleware Global de Exceções

---

# Estrutura do Projeto

```txt
celticsTech
│
├── Controllers
├── Data
├── DTOs
│   ├── Request
│   └── Response
├── Enums
├── Exceptions
├── Middlewares
├── Migrations
├── Models
├── Repositories
├── Services
├── appsettings.json
├── Dockerfile
├── docker-compose.yml
└── Program.cs
```

---

# Funcionalidades Principais

## Usuários

* Criar usuário
* Atualizar usuário
* Deletar usuário
* Buscar por ID
* Buscar por email
* Buscar por nome

## Pets

* Criar pet
* Atualizar pet
* Deletar pet
* Buscar por espécie
* Buscar por porte

## Veterinários

* Criar veterinário
* Atualizar veterinário
* Deletar veterinário
* Buscar por especialidade
* Buscar por nome

## Consultas

* Criar consulta
* Atualizar consulta
* Deletar consulta
* Buscar consulta por ID

---

# Status HTTP

A API utiliza respostas REST padronizadas.

| Status Code | Descrição              |
| ----------- | ---------------------- |
| 200         | Sucesso                |
| 201         | Criado                 |
| 204         | Sem Conteúdo           |
| 400         | Requisição Inválida    |
| 404         | Recurso Não Encontrado |
| 500         | Erro Interno           |

---

# Middleware Global de Exceções

O projeto implementa um middleware global para tratamento de exceções.

Exemplo de resposta:

```json
{
  "statusCode": 404,
  "message": "Pet não encontrado",
  "timestamp": "2026-05-16T19:00:00"
}
```

---

# Banco de Dados

## Oracle Database

O projeto utiliza Oracle Database executando em container Docker.

### Imagem Docker

```txt
gvenzl/oracle-free
```

---

# Executando o Projeto

## Requisitos

* .NET 8 SDK
* Docker Desktop
* Visual Studio 2022

---

# Executando Localmente

## 1. Clonar repositório

```bash
git clone VOU ADD
```

---

## 2. Abrir o projeto

Abra a solução no:

```txt
Visual Studio 2022
```

---

## 3. Iniciar Oracle Database

```bash
docker compose up -d
```

---

## 4. Aplicar migrations

```powershell
Update-Database
```

---

## 5. Executar API

Utilize o perfil do Visual Studio:

```txt
https
```

Swagger:

```txt
https://localhost:7143
```

---

# Executando com Docker Compose

Toda a aplicação pode ser executada utilizando Docker Compose.

## Iniciar containers

```bash
docker compose up -d --build
```

---

## Swagger

```txt
http://localhost:8080
```

---

# Docker Compose

```yaml
services:
  oracle-db:
    image: gvenzl/oracle-free:latest

  celticstech-api:
    build:
      context: .
      dockerfile: Dockerfile
```

---

# Endpoints da API

# Usuários

| Método | Endpoint                                                             |
| ------ | -------------------------------------------------------------------- |
| GET    | /api/users                                                           |
| GET    | /api/users/{id}                                                      |
| GET    | /api/users/email?email=[example@email.com](mailto:example@email.com) |
| GET    | /api/users/search?name=Yuri                                          |
| POST   | /api/users                                                           |
| PUT    | /api/users/{id}                                                      |
| DELETE | /api/users/{id}                                                      |

---

# Pets

| Método | Endpoint                     |
| ------ | ---------------------------- |
| GET    | /api/pets                    |
| GET    | /api/pets/{id}               |
| GET    | /api/pets/search?species=Dog |
| GET    | /api/pets/search?petSize=BIG |
| POST   | /api/pets                    |
| PUT    | /api/pets/{id}               |
| DELETE | /api/pets/{id}               |

---

# Veterinários

| Método | Endpoint                                                  |
| ------ | --------------------------------------------------------- |
| GET    | /api/veterinarians                                        |
| GET    | /api/veterinarians/{id}                                   |
| GET    | /api/veterinarians/search/name?name=Carlos                |
| GET    | /api/veterinarians/search/specialty?specialty=CARDIOLOGIA |
| POST   | /api/veterinarians                                        |
| PUT    | /api/veterinarians/{id}                                   |
| DELETE | /api/veterinarians/{id}                                   |

---

# Consultas

| Método | Endpoint                |
| ------ | ----------------------- |
| GET    | /api/consultations      |
| GET    | /api/consultations/{id} |
| POST   | /api/consultations      |
| PUT    | /api/consultations/{id} |
| DELETE | /api/consultations/{id} |

---

# Exemplos de Requisições

## Criar Usuário

```json
{
  "name": "Yuri",
  "email": "yuri@email.com",
  "password": "123456",
  "cpf": "12345678901",
  "phone": "11999999999"
}
```

---

## Criar Pet

```json
{
  "name": "Thor",
  "species": "Dog",
  "breed": "Golden Retriever",
  "ageType": "ANOS",
  "age": 5,
  "weight": 30,
  "petSize": "BIG"
}
```

---

## Criar Veterinário

```json
{
  "name": "Dr. Carlos",
  "email": "carlos@vet.com",
  "crmv": "CRMV12345",
  "specialty": "CARDIOLOGIA",
  "phone": "11988887777",
  "yearsExperience": 12
}
```

---

## Criar Consulta

```json
{
  "userId": 1,
  "petId": 1,
  "veterinarianId": 1,
  "consultationDate": "2026-05-16T19:30:00",
  "symptoms": "Pet apresenta tosse e cansaço.",
  "diagnosis": "Possível problema respiratório.",
  "treatment": "Medicação e repouso por 7 dias.",
  "observations": "Retorno em uma semana.",
  "status": "SCHEDULED"
}
```

---

# Relacionamento das Entidades

```txt
User
 └── Pet
      └── Consultation
           └── Veterinarian
```

---

# Segurança e Validações

A API valida:

* Email duplicado
* CPF duplicado
* CRMV duplicado
* Campos obrigatórios
* Validação de enums
* Chaves estrangeiras inválidas

---

# Recursos DevOps

O projeto inclui:

* Dockerfile
* Docker Compose
* Container Oracle
* Volume persistente
* Arquitetura multi-container
* Containerização ASP.NET Core

---

# Melhorias Futuras

* Autenticação JWT
* Deploy Azure
* Pipeline CI/CD
* Testes Unitários
* Testes de Integração
* Paginação
* Logging
* Monitoramento

---

# Autores

Desenvolvido pela equipe celticsTech (YuriXD).

---