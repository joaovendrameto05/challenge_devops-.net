API CelticsTech - Sistema de Gestão Veterinária

1. Descrição do Projeto
Para este projeto, eu desenvolvi a CelticsTech API, que é um sistema de back-end em C# .NET 8, concebido para a gestão integral de clínicas veterinárias. Eu arquitetei a aplicação em contentores (Docker) e implementei numa infraestrutura de nuvem (Microsoft Azure). O sistema que criei expõe endpoints para o registo e gestão de Consultas, Pets, Utilizadores (Tutores) e Veterinários. Eu garanti a persistência de dados através de uma instância do Oracle Database, utilizando volumes nomeados para assegurar a integridade da informação face a reinicializações da infraestrutura.

2. Benefícios para o Negócio (Por que estruturei dessa forma)
* Alta Disponibilidade: Alojei a aplicação em infraestrutura de nuvem para permitir o acesso contínuo e a escalabilidade dos recursos mediante a procura da clínica.
* Segurança Isolada: Configurei a aplicação para executar sob um utilizador sem privilégios de raiz (non-root user) no contexto do contentor, limitando a superfície de ataque.
* Integridade e Persistência: Utilizei "Named Volumes" do Docker em conjunto com o Oracle Database para prevenir a perda do histórico clínico e dados sensíveis em caso de falha do serviço.
* Integração Normalizada: Documentei tudo via Swagger (OpenAPI) para fornecer um contrato de interface claro, facilitando a integração futura com aplicações móveis ou web.

3. Desenho Macro da Arquitetura
A arquitetura do sistema que eu desenhei segue o seguinte fluxo de requisição e persistência:
1. O cliente realiza uma requisição HTTP.
2. A requisição atravessa o Network Security Group (Firewall) da Azure, onde liberei o tráfego na porta designada (8080).
3. A requisição atinge a Máquina Virtual (Ubuntu Linux) que provisionei na Azure.
4. O tráfego é direcionado para o contentor da API (.NET 8), que processa a lógica de negócio de forma isolada.
5. A API comunica, através da rede interna do Docker que eu configurei, com o contentor do Oracle Database.
6. Os dados são lidos/escritos e armazenados fisicamente num Volume Nomeado associado ao disco da Máquina Virtual, garantindo a persistência.

4. Pré-requisitos (O que utilizei)
* Azure CLI instalado localmente no meu ambiente.
* Minha conta ativa na Microsoft Azure.
* Cliente SSH para acesso remoto.

--------------------------------------------------

5. How To: Provisionamento e Instalação

O processo abaixo descreve passo a passo como eu efetuei a criação da infraestrutura, a instalação de dependências e a execução do projeto.

Passo 5.1: Criação da Infraestrutura no Azure
Num terminal local com o meu Azure CLI autenticado, eu executei os seguintes comandos para provisionar os recursos:

# 1. Criação do Grupo de Recursos
az group create --name celtics_group --location southafricanorth

# 2. Criação da Máquina Virtual Ubuntu
az vm create \
  --resource-group celtics_group \
  --name celticsgroupvm \
  --image Ubuntu2204 \
  --admin-username admlnx \
  --generate-ssh-keys \
  --size Standard_B2as_v2

# 3. Abertura da porta para a Aplicação
az vm open-port --port 8080 --resource-group celtics_group --name celticsgroupvm


Passo 5.2: Acesso e Instalação de Dependências
Obtive o endereço IP público gerado no passo anterior e acessei a máquina virtual via SSH dessa forma:

# Acesso via SSH
ssh admlnx@<IP_PUBLICO_DA_VM>

# Atualização dos pacotes do sistema
sudo apt update && sudo apt upgrade -y

# Instalação do Docker e Git
sudo apt install docker.io docker-compose git -y

# Ativação dos serviços do Docker
sudo systemctl start docker
sudo systemctl enable docker


Passo 5.3: Execução da Aplicação (Deployment)
Dentro da Máquina Virtual, eu efetuei a clonagem e a orquestração dos contentores com os seguintes passos:

# 1. Clonei o repositório
git clone https://github.com/joaovendrameto05/challenge_devops-.net.git
cd challenge_devops-.net

# 2. Iniciei o contentor do Banco de Dados primeiramente
sudo docker-compose up -d db

# NOTA TÉCNICA: Eu adicionei um delay de 90 segundos aqui porque o Oracle Database XE 
# requer esse tempo para inicializar os seus serviços internos e o listener antes de aceitar conexões.
sleep 90

# 3. Em seguida, iniciei a API
sudo docker-compose up -d celtics-app

# 4. Verifiquei os registos (logs) para confirmar a inicialização correta
sudo docker-compose logs -f celtics-app

O sistema indicou que estava operacional quando o registo apresentou a mensagem "Application started".

--------------------------------------------------

6. How To: Como Testar a Aplicação (Rotas e CRUD)

Para realizar os testes, eu acessei a interface do Swagger através do navegador web: http://<IP_PUBLICO_DA_VM>:8080

Para testar o fluxo completo, eu segui a ordem de dependência das tabelas (Tutor -> Veterinário -> Pet -> Consulta). Garanti também de não enviar o atributo "id" no corpo da requisição POST, pois configurei para que este seja gerado automaticamente pelo banco de dados.

1. POST /api/users
{
  "name": "Maria Silva",
  "email": "maria@email.com",
  "password": "SenhaSegura123!",
  "cpf": "12345678901",
  "phone": "11999998888"
}

2. POST /api/veterinarians
{
  "name": "Dr. Carlos Silva",
  "email": "carlos.vet@clinica.com",
  "crmv": "CRM-SP 12345",
  "specialty": 0,
  "phone": "11988887777",
  "yearsExperience": 10
}

3. POST /api/pets
{
  "name": "Thor",
  "species": "Cachorro",
  "breed": "Golden Retriever",
  "ageType": 1,
  "age": 4,
  "weight": 30.5,
  "petSize": 2
}

Após as inserções, eu utilizei os métodos GET para listar os registos, PUT indicando o ID para atualizar um registo específico, e DELETE para remover, validando todo o CRUD.

--------------------------------------------------

7. Prova de Persistência Direta no Banco de Dados

Para comprovar fisicamente que a minha aplicação está a escrever os dados no Oracle Database (e atestar o funcionamento do volume nomeado), eu executei a seguinte validação diretamente no terminal da Máquina Virtual:

# 1. Acessei o terminal interativo do contentor do Oracle
sudo docker exec -it db bash

# 2. Iniciei a sessão no SQLPlus (substituindo a senha pela que configurei no docker-compose)
sqlplus system/SuaSenhaOracle123

# 3. Executei a consulta à tabela criada pelo meu Entity Framework
SELECT * FROM "tb_pets";

Os dados que eu inseri através da API foram listados no console do banco de dados, o que me provou o funcionamento correto da persistência de estado no volume associado à infraestrutura.

--------------------------------------------------

8. Destruição da Infraestrutura (Teardown)

Para evitar custos de recursos ociosos, eu realizei a destruição de todo o ambiente após a utilização.

1. Fiz a remoção dos contentores e volumes locais (na Máquina Virtual):
sudo docker-compose down -v
exit

2. Efetuei a exclusão do Grupo de Recursos (no terminal local / Azure Cloud Shell):
az group delete --name celtics_group --yes --no-wait

--------------------------------------------------
