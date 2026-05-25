🐾 CHALLENGE 2026
Projeto: CelticsTech API – Gestão Veterinária

Disciplina: DevOps Tools & Cloud Computing
Turma: 2TDS
Professor: (colocar nome)

Integrantes:

Nome Completo – RM
Nome Completo – RM
Nome Completo – RM
Nome Completo – RM


São Paulo – 2026

📑 SUMÁRIO

Introdução
Problema do Negócio
Solução Proposta
Tecnologias Utilizadas
Arquitetura da Solução
Infraestrutura DevOps
Containerização
Segurança
Persistência de Dados
Rotas da API
README Estruturado
Requisitos Atendidos
Arquitetura Macro (Cloud)
Conclusão


🧠 1. Introdução
O presente trabalho foi desenvolvido no contexto do Challenge FIAP 2026, cujo objetivo é proporcionar uma experiência prática próxima ao mercado de tecnologia. [2TDS Fever...º Semestre | PDF]
O desafio consiste na criação de soluções digitais voltadas à continuidade da saúde dos pets, promovendo inovação, escalabilidade e impacto real no mercado veterinário. [2TDS Fever...º Semestre | PDF]

🐶 2. Problema do Negócio
A jornada atual da saúde dos pets é caracterizada por ser:

Episódica
Reativa
Pouco integrada

Isso gera impactos negativos:

Falta de acompanhamento contínuo
Esquecimento de tratamentos
Baixa fidelização
Piora na qualidade de vida do animal [2TDS Fever...º Semestre | PDF]


💡 3. Solução Proposta
A solução desenvolvida é a CelticsTech API, um sistema backend para clínicas veterinárias que possibilita:

Gestão de Pets
Controle de Consultas
Cadastro de Usuários
Administração de Veterinários

A proposta busca transformar o modelo atual em:

Preventivo
Inteligente
Integrado
Escalável


⚙️ 4. Tecnologias Utilizadas

.NET 8 (C#)
Docker
Oracle Database
Microsoft Azure
Ubuntu Server
Swagger


🏗️ 5. Arquitetura da Solução
A arquitetura do sistema segue um modelo moderno baseado em cloud:

Cliente envia requisição HTTP
Azure libera acesso via firewall
VM Linux recebe tráfego
Docker executa containers
API processa requisições
Banco Oracle armazena dados


☁️ 6. Infraestrutura DevOps
Esta é a parte principal do projeto.
A infraestrutura foi criada utilizando Azure CLI, conforme exigido no desafio. [2TDS Fever...º Semestre | PDF]
Etapas realizadas:

Criação de Resource Group
Criação da Máquina Virtual Linux
Abertura da porta 8080
Instalação do Docker
Instalação do Git


💻 Script utilizado:
Shellaz group create --name celtics_group --location southafricanorthaz vm create \  --resource-group celtics_group \  --name celticsgroupvm \  --image Ubuntu2204 \  --admin-username admlnx \  --generate-ssh-keysaz vm open-port --port 8080sudo apt update && sudo apt install docker.io docker-compose -y``Mostrar mais linhas

🐳 7. Containerização
O sistema foi completamente containerizado:

Container da API (.NET)
Container do Banco Oracle


✅ Boas práticas aplicadas:
✔ Execução em background (docker-compose up -d)
✔ Uso de usuário non-root
✔ Separação por serviços
✔ Orquestração com Docker Compose [2TDS Fever...º Semestre | PDF]

🔐 8. Segurança
Práticas de segurança implementadas:

Execução sem privilégios root
Isolamento de containers
Firewall configurado na Azure


💾 9. Persistência de Dados
A persistência é garantida por volume nomeado Docker:
celtics_oracle_volume

Isso assegura:

Integridade dos dados
Persistência após reinicializações
Segurança no armazenamento


🔗 10. Rotas da API
A aplicação possui CRUD completo:

/api/pets
/api/consultations
/api/users
/api/veterinarians

Com documentação via Swagger.

📘 11. README Estruturado
Descrição
Sistema backend para gestão veterinária baseado em cloud.
Benefícios

Escalabilidade
Segurança
Persistência
Integração fácil

Execução
Shelldocker-compose up -dMostrar mais linhas

✅ 12. Requisitos Atendidos
De acordo com o desafio DevOps: [2TDS Fever...º Semestre | PDF]
✔ Execução em background
✔ Usuário non-root
✔ Banco containerizado
✔ Volume persistente
✔ Deploy em nuvem
✔ CRUD completo funcionando

🧩 13. Arquitetura Macro
Fluxo geral:
Cliente → Azure → VM → Docker → API → Banco

🎯 14. Conclusão
O projeto demonstra domínio completo de práticas modernas de:

DevOps
Computação em nuvem
Containerização
Arquitetura distribuída

Além disso, soluciona um problema relevante do mercado veterinário, agregando valor real para clínicas e usuários.

🚀 COMO GERAR O ARQUIVO FINAL (IMPORTANTE)
✅ Passo a passo:

Abrir Word
Colar tudo
Inserir estilos:

Título 1 → Seções


Inserir sumário automático:

Referências → Sumário


Exportar:

Arquivo → Exportar → PDF




🔥 SE QUISER GANHAR MAIS PONTO (RECOMENDO MUITO)
Posso ainda gerar pra você:
✅ Diagrama profissional (Draw.io pronto)
✅ Versão com normas ABNT
✅ Roteiro do vídeo (que eles pedem na entrega)
✅ Slides do pitch
Só falar:
👉 “quero o pacote completo FIAP”
FontesForneça seus comentários sobre o BizChatYou said: Quero o pacote completo FIAPCopilot said: CopilotPerfeito 🔥 agora você vai ter o PACOTE COMPLETO FIAP nível 10/10 — exatamente o que o professor espera ver (DevOps completo, apresentação, documentação e arquitetura).
Vou te entregar TUDO PRONTO pra copia + uso direto:

📦 ✅ 1. DIAGRAMA DE ARQUITETURA (para o Word / Draw.io)
🎯 COMO DESENHAR (copia isso no Draw.io ou PowerPoint)
Estrutura:
[ Cliente / Browser ]
          ↓
[ Azure Firewall / NSG ]
          ↓
[ Máquina Virtual (Ubuntu) ]
          ↓
   [ Docker Engine ]
      ↓        ↓
[ API .NET ]  [ Oracle DB ]
                   ↓
          [ Volume Persistente ]


💡 Legenda pra colocar no trabalho:

🔵 Cliente → acesso via HTTP
🟢 Azure → controle de rede
🟠 VM → processamento
🐳 Docker → containers
🔴 Oracle → banco de dados
💾 Volume → persistência


🎥 ✅ 2. ROTEIRO DO VÍDEO (OBRIGATÓRIO NA ENTREGA)
🎬 INTRO (15s)
"Oi professor, esse é o projeto CelticsTech API desenvolvido para o Challenge FIAP 2026. Vou demonstrar a infraestrutura DevOps em nuvem."

☁️ PARTE 1 — Azure CLI (mostra terminal)
✅ Executa:
Shellaz group create ...az vm create ...Mostrar mais linhas
Fala:
"Neste momento estou criando a infraestrutura totalmente via CLI, conforme exigido pelo desafio."

🐳 PARTE 2 — Docker (mostra VM)
✅ Executa:
Shelldocker-compose up -d``Mostrar mais linhas
Fala:
"A aplicação está rodando em background com Docker."

🧪 PARTE 3 — TESTE DA API

Abre Swagger
Faz:

GET
POST
PUT
DELETE



Fala:
"Aqui estou provando o CRUD completo funcionando."

💾 PARTE 4 — PERSISTÊNCIA
👉 Faça:

Inserir dado
Derrubar container
Subir de novo

Fala:
"Mesmo após reiniciar o container, os dados permanecem salvos devido ao volume persistente."

❌ PARTE 5 — DELETAR VM (OBRIGATÓRIO)
Shellaz group delete --name celtics_groupMostrar mais linhas
Fala:
"Finalizando com a remoção dos recursos conforme exigido."

🎤 ✅ 3. SLIDES DO PITCH (PRONTO)
Slide 1 – Nome
CelticsTech API
Gestão Veterinária Inteligente

Slide 2 – Problema

Jornada fragmentada
Falta continuidade
Baixa fidelização


Slide 3 – Solução

API completa
CRUD veterinário
Infraestrutura em nuvem


Slide 4 – Tecnologias

.NET 8
Docker
Oracle
Azure


Slide 5 – Arquitetura
(Coloca o diagrama que te dei)

Slide 6 – Benefícios

Escalabilidade
Segurança
Persistência
Integração


Slide 7 – Diferencial

Non-root user ✅
Docker ✅
Cloud ✅


Slide 8 – Conclusão
"Solução real, escalável e aplicável ao mercado."