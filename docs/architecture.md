# Arquitetura

## Visão Geral

O BakeryHub será desenvolvido utilizando a abordagem de *Monólito Modular* combinada com os princípios da *Clean Architecture*.

O objetivo é manter o sistema simples o suficiente para ser desenvolvido por uma única pessoa, mas estruturado de forma profissional, permitindo evolução, manutenção e escalabilidade futura.

A arquitetura foi projetada para demonstrar boas práticas de desenvolvimento de software, separação de responsabilidades, domínio estruturado e integração com tecnologias modernas do ecossistema .NET.

---

# Princípios Arquiteturais

## Clean Architecture

O sistema será organizado em camadas com responsabilidades bem definidas.

As regras de negócio não devem depender de bibliotecas, frameworks ou tecnologias específicas.

As dependências devem apontar sempre para o centro da aplicação.

API
 ↓
Application
 ↓
Domain

Infrastructure
 ↑


O domínio representa o núcleo da solução e deve permanecer independente das tecnologias utilizadas.

---

## Monólito Modular

O BakeryHub será implementado inicialmente como um monólito modular.

Essa decisão foi tomada para reduzir a complexidade operacional e permitir foco na evolução do produto.

Benefícios:

- Menor complexidade
- Um único deploy
- Um único banco de dados
- Facilidade de desenvolvimento
- Facilidade de testes
- Possibilidade de evolução futura para microserviços

---

## Arquitetura Orientada a Eventos

Embora seja um monólito, o sistema utilizará eventos internos e mensageria para desacoplar processos assíncronos.

Exemplos:

- Criação de produção
- Agendamento de notificações
- Envio de notificações

A comunicação assíncrona permitirá demonstrar conceitos de Event Driven Architecture sem introduzir a complexidade de um ambiente baseado em microserviços.

---

# Estrutura da Solução

BakeryHub.sln

src

├── BakeryHub.Api
├── BakeryHub.Application
├── BakeryHub.Domain
├── BakeryHub.Infrastructure
├── BakeryHub.Contracts
└── BakeryHub.Worker

tests

├── BakeryHub.UnitTests
└── BakeryHub.IntegrationTests


---

# Camadas da Aplicação

## BakeryHub.Domain

Responsável pelas regras de negócio e entidades do sistema.

Não deve possuir dependências de frameworks ou tecnologias externas.

Exemplos:

User
Role
UserRole

BakeryApplication
BakeryProfile

Batch

Subscription

Notification
NotificationPreference

DeviceToken


Também conterá:

- Enums
- Regras de negócio
- Validações de domínio
- Exceções de domínio

---

## BakeryHub.Application

Responsável pelos casos de uso da aplicação.

Contém a orquestração das regras de negócio.

Exemplos:

### Commands

CreateUser

RequestBakeryApproval

ApproveBakeryApplication

CreateBatch

FollowBakery


### Queries

GetUser

GetBakery

GetActiveBatches

GetNotifications


Responsabilidades:

- Casos de uso
- Validações de aplicação
- DTOs internos
- Interfaces
- Regras de autorização

---

## BakeryHub.Infrastructure

Responsável pelas implementações técnicas.

Não contém regras de negócio.

Exemplos:

Entity Framework Core

SQL Server

RabbitMQ

Azure Blob Storage

JWT Authentication

Firebase Notifications


Responsabilidades:

- Persistência
- Mensageria
- Serviços externos
- Configurações técnicas

---

## BakeryHub.Api

Camada de apresentação HTTP.

Responsável por expor os recursos da plataforma.

Exemplos:

/api/auth

/api/users

/api/bakeries

/api/batches

/api/notifications


Responsabilidades:

- Controllers
- Middlewares
- Swagger
- Autenticação
- Autorização
- Tratamento global de exceções

---

## BakeryHub.Contracts

Responsável pelo compartilhamento de contratos utilizados pela aplicação.

Exemplos:

Requests

Responses

Commands

Events


Essa separação facilita a comunicação entre API, Worker e futuras integrações.

---

## BakeryHub.Worker

Serviço responsável pelo processamento assíncrono.

Executa tarefas que não precisam ocorrer durante a requisição HTTP.

Exemplos:

Processamento de eventos

Agendamento de notificações

Envio de notificações push

Rotinas em background


---

# Estratégia de Persistência

O sistema utilizará inicialmente um único banco de dados.

BakeryHubDb


Tecnologia prevista:

SQL Server


Benefícios:

- Simplicidade operacional
- Facilidade de manutenção
- Facilidade de desenvolvimento
- Menor custo de infraestrutura

A divisão em múltiplos bancos será avaliada apenas caso exista necessidade real de escalabilidade futura.

---

# Estratégia de Autenticação

Será utilizada autenticação baseada em JWT.

Fluxo:

Login

↓

Access Token

↓

Acesso aos recursos protegidos


Perfis suportados:

Customer

Bakery

Admin


O sistema utilizará autorização baseada em Roles e Claims.

---

# Estratégia de Mensageria

A mensageria será utilizada para processamentos assíncronos.

Tecnologia prevista:

RabbitMQ


Exemplos de eventos:

BatchCreated

BatchUpdated

BatchCompleted

NotificationScheduled

NotificationSent


---

# Estratégia de Front-End

## Portal Web

Tecnologia prevista:

React
TypeScript


Responsável por:

- Administração
- Operação dos estabelecimentos
- Gestão de produções
- Aprovação de estabelecimentos

---

## Aplicativo Mobile

Tecnologia prevista:

.NET MAUI


Responsável por:

- Consumo de notificações
- Acompanhamento de estabelecimentos
- Experiência do consumidor final

---

# Infraestrutura Planejada

Ambiente local:

Docker Compose


Serviços:

API

Worker

SQL Server

RabbitMQ

Seq


---

Ambiente cloud:

Microsoft Azure


Serviços previstos:

Azure Container Apps

Azure SQL Database

Azure Blob Storage

Azure Key Vault

Application Insights


---

# Evolução Futura

A arquitetura foi planejada para permitir evolução incremental.

Possíveis evoluções:

- Kubernetes
- AKS
- OpenTelemetry
- Redis
- Cache distribuído
- Escalonamento horizontal
- Multi-tenancy
- Microserviços

Nenhuma dessas decisões será adotada antes que exista necessidade real ou valor claro para o produto.

---

# Decisões Arquiteturais Registradas

| Decisão | Status |
|----------|----------|
| Monólito Modular | Aprovado |
| Clean Architecture | Aprovado |
| Banco de Dados Único | Aprovado |
| SQL Server | Aprovado |
| JWT Authentication | Aprovado |
| RabbitMQ | Aprovado |
| React para Portal Web | Aprovado |
| .NET MAUI para Mobile | Aprovado |
| Azure como Plataforma Cloud | Aprovado |
| Kubernetes | Postergado |
| Microserviços | Postergado |
