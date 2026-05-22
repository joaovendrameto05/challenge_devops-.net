# Clyvo Vet - Infraestrutura Digital (Grupo Celtics)

## 1. Descrição do Projeto
A solução consiste em uma API RESTful desenvolvida em .NET 8, focada em resolver a fragmentação da jornada de saúde animal (desafio Clyvo Vet). O projeto foi conteinerizado via Docker e integrado a um banco de dados Oracle, com a infraestrutura provisionada e hospedada na nuvem pública da Microsoft Azure (Ubuntu 24.04 LTS).

## 2. Benefícios para o Negócio (Clyvo Vet & Clínicas)
* **Previsibilidade e Continuidade:** O armazenamento centralizado e persistente do histórico de saúde evita o abandono de tratamentos e garante intervenções preventivas.
* **Escalabilidade em Nuvem:** A arquitetura baseada em containers permite escalar a aplicação facilmente para suportar uma rede nacional de clínicas e parceiros ecossistêmicos.
* **Alta Disponibilidade (SLA):** Com a infraestrutura na Azure e gestão via Docker Compose, as clínicas parceiras ganham acesso contínuo aos prontuários, aumentando o LTV (Lifetime Value) dos clientes.

## 3. Desenho Macro da Arquitetura
*(Adicione aqui a imagem do Draw.io ou Visual Paradigm ou o link para visualizar o diagrama criado pelo grupo)*

## 4. Rotas da API (Endpoints)
* **`GET /api/pets`** - Consulta a base de dados para listar todos os pets.
* **`POST /api/pets`** - Insere um novo registro de pet/histórico de saúde.
* **`PUT /api/pets/{id}`** - Atualiza informações clínicas de um pet existente.
* **`DELETE /api/pets/{id}`** - Remove um registro do ecossistema.

## 5. Arquitetura DevOps
* **Automação (IaC):** `azure-deploy.sh` (Script Azure CLI para provisionamento da VM, VNet e NSG).
* **Containerização:** `Dockerfile` (Garantindo execução segura em ambiente não-root via `USER app`).
* **Orquestração:** `docker-compose.yml` (Gerencia a comunicação entre a API e o Oracle Database, garantindo persistência via volume nomeado).

## 6. Instalação da Solução (How To)
Para realizar o deploy do projeto em um ambiente Linux Ubuntu, siga as instruções:

1. **Acesso à Infraestrutura Azure:**
   Conecte-se à máquina virtual utilizando o protocolo SSH e as credenciais configuradas:
   ```bash
   ssh admlnx@102.37.100.47