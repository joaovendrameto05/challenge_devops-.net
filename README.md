# 🐾 API CelticsTech - Gestão Veterinária Avançada

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker&logoColor=white)
![Oracle](https://img.shields.io/badge/Oracle-F80000?style=for-the-badge&logo=oracle&logoColor=white)
![Azure](https://img.shields.io/badge/Microsoft_Azure-0089D6?style=for-the-badge&logo=microsoft-azure&logoColor=white)
![Ubuntu](https://img.shields.io/badge/Ubuntu-E95420?style=for-the-badge&logo=ubuntu&logoColor=white)

## 📖 Descrição do Projeto
A **CelticsTech API** é um sistema de back-end robusto focado na gestão completa de clínicas veterinárias. O projeto foi construído utilizando **C# .NET 8**, conteinerizado com **Docker** e implementado em infraestrutura de nuvem na **Microsoft Azure**. 

O sistema realiza o gerenciamento completo (CRUD) de Consultas, Pets, Usuários e Veterinários. Visando a resiliência e integridade dos dados clínicos, a aplicação utiliza um banco de dados **Oracle** executado em container, com persistência garantida através de **Named Volumes** (Volumes Nomeados).

## 🏢 Benefícios para o Negócio
* **Escalabilidade em Nuvem:** Hospedada em uma Máquina Virtual na Azure, a API está preparada para escalar conforme o aumento do fluxo de atendimentos da clínica.
* **Segurança e Isolamento (Non-Root User):** Seguindo as melhores práticas de DevSecOps, a aplicação roda dentro do container Docker com privilégios restritos (usuário `app`), mitigando riscos de vulnerabilidades e invasões.
* **Persistência de Dados Segura:** O uso de volumes mapeados garante que, mesmo que o container do banco de dados seja reiniciado ou atualizado, o histórico médico dos pets e dados de clientes jamais sejam perdidos.
* **Integração Facilitada:** A interface OpenAPI (Swagger) oferece uma documentação viva e interativa, permitindo que times de Front-end ou Mobile consumam a API sem atrito.

## 🏗️ Desenho Macro da Arquitetura
A arquitetura do projeto segue um fluxo moderno e isolado:
1. O **Cliente (Navegador/Mobile)** faz uma requisição HTTP.
2. A requisição passa pelo **Firewall (Azure Network Security Group)** que libera o tráfego nas portas essenciais (ex: 8080).
3. O tráfego atinge a **Azure VM (Ubuntu 24.04 LTS)** onde o Docker Engine atua como orquestrador.
4. O **Container da API (.NET 8)** recebe a requisição (rodando de forma segura como *Non-Root*).
5. A API se comunica via rede interna do Docker com o **Container do Oracle Database**.
6. Os dados do Oracle são salvos fisicamente em um **Volume Nomeado (`celtics_oracle_volume`)** no disco da Máquina Virtual.

## 📍 Rotas da API (Swagger)
A documentação interativa está disponível na raiz da aplicação. As principais entidades gerenciadas incluem:
* `[GET, POST, PUT, DELETE] /api/pets` - Gestão de animais (Cachorros, Gatos, etc).
* `[GET, POST, PUT, DELETE] /api/consultations` - Agendamentos e prontuários.
* `[GET, POST, PUT, DELETE] /api/users` - Gestão de tutores (clientes).
* `[GET, POST, PUT, DELETE] /api/veterinarians` - Gestão da equipe médica e especialidades.

---

## ✅ Requisitos Acadêmicos Atendidos (Checklist)
Este projeto foi desenvolvido em estrita conformidade com as regras estabelecidas nas disciplinas de DevOps:
- [x] **2.1. Execução em Background:** Utilização de `docker-compose up -d`.
- [x] **2.2. Usuário Non-Root:** Implementado no Dockerfile via `USER $APP_UID`.
- [x] **2.3. Persistência de Dados:** Implementado banco **Oracle** em container.
- [x] **2.4. Volumes Nomeados:** Utilização de *Named Volume* (`oracle_data`) no docker-compose.
- [x] **CRUD Completo:** Rotas testadas via Swagger provando inserção, leitura, atualização e exclusão.

---

## 🚀 Passo a Passo: Provisionamento da Infraestrutura (Azure CLI)
Toda a infraestrutura foi provisionada via linha de comando (Azure CLI). Abaixo estão os comandos exatos utilizados para preparar o servidor:

```bash
# 1. Criação do Grupo de Recursos
az group create --name celtics_group --location southafricanorth

# 2. Criação da Máquina Virtual (Ubuntu Linux)
az vm create \
  --resource-group celtics_group \
  --name celticsgroupvm \
  --image Ubuntu2204 \
  --admin-username admlnx \
  --generate-ssh-keys \
  --size Standard_B2as_v2

# 3. Abertura da porta 8080 para a Aplicação
az vm open-port --port 8080 --resource-group celtics_group --name celticsgroupvm

# 4. Conexão na VM via SSH
ssh admlnx@<IP_PUBLICO_GERADO>

# 5. Instalação das Dependências (Docker e Git)
sudo apt update && sudo apt upgrade -y
sudo apt install docker.io docker-compose git -y
sudo systemctl start docker
sudo systemctl enable docker
sudo usermod -aG docker $USER