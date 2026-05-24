Projeto: API CelticsTech (Veterinária)
Este projeto consiste em uma API desenvolvida em C# .NET 8 para gerenciamento de dados veterinários, conteinerizada com Docker e utilizando persistência de dados com Oracle Database.

Arquitetura do Sistema
Backend: C# .NET 8

Banco de Dados: Oracle XE (via Docker)

Orquestração: Docker Compose

Documentação: Swagger (OpenAPI)

Infraestrutura: Azure VM (Ubuntu 24.04 LTS)

Pré-requisitos
Para rodar este projeto, você precisará de:

.NET SDK 8.0 instalado localmente.

Docker Desktop (ou Docker Engine) instalado.

Acesso a uma instância de máquina virtual (Azure VM).

Git configurado.

Passo a Passo: Configuração e Deploy
1. Preparação do Ambiente Local
Antes de realizar o deploy, garantimos que o projeto estivesse limpo e sem conflitos de referências anteriores (como pastas de migração corrompidas ou referências cruzadas):

Limpeza: Removemos as pastas bin, obj e a pasta Migrations (para garantir que o banco seja criado dinamicamente).

Dependências: Configuramos o arquivo celticsTech.csproj para incluir os pacotes necessários:

XML
<PackageReference Include="Oracle.EntityFrameworkCore" Version="8.23.60" />
<PackageReference Include="Swashbuckle.AspNetCore" Version="6.5.0" />
Configuração de Banco: No Program.cs, implementamos o comando db.Database.EnsureCreated() para criar as tabelas automaticamente no Oracle ao iniciar a aplicação, eliminando a necessidade de pastas de migração.

2. Sincronização (Git)
Após as correções, realizamos o versionamento:

Bash
git add .
git commit -m "Correção final do projeto e configuração Oracle"
git push origin main
3. Deploy na Azure VM
Acesse a sua VM via terminal (Cloud Shell ou SSH) e siga os passos abaixo:

Atualizar o código:

Bash
cd ~/challenge_devops-.net
git pull
Limpar volumes anteriores:
O volume celtics_oracle_volume garante a persistência dos dados entre reinicializações dos containers.

Bash
sudo docker compose down -v
Subir a infraestrutura:

Bash
sudo docker compose up -d --build
Monitorar a inicialização:
O banco Oracle pode levar alguns minutos para carregar na primeira vez.

Bash
sudo docker compose logs -f celtics-app
Aguarde a mensagem "Application started" aparecer no terminal.

Demonstração do CRUD (Swagger)
A aplicação utiliza o Swagger para interface. Acesse via navegador:
http://<IP_DA_SUA_VM>:8080/

Roteiro de Testes para Vídeo:
Create (POST): Clique em /api/pets -> Try it out. Insira o JSON do primeiro pet e clique em Execute. Repita o processo com um segundo pet.

Read (GET): Vá em /api/pets (sem ID) -> Try it out -> Execute. Mostre a lista com os dados inseridos.

Update (PUT): Vá em /api/pets/{id}. Insira o ID e o JSON atualizado. Clique em Execute.

Delete (DELETE): Vá em /api/pets/{id}. Insira o ID e clique em Execute. Verifique no GET se o item foi removido.