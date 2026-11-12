# Modelo de Domínio

## Visão Geral

O domínio do BakeryHub é centrado na comunicação entre estabelecimentos e consumidores por meio de notificações relacionadas a produções em andamento.

O objetivo do modelo é representar os principais conceitos do negócio e suas relações, servindo como base para a implementação da aplicação, banco de dados, APIs e integrações.

Este documento descreve as entidades do domínio, suas responsabilidades e os relacionamentos existentes entre elas.

---

# Entidades

## User

Representa uma pessoa que utiliza a plataforma.

Um usuário pode atuar como:

- Consumidor
- Estabelecimento
- Administrador

A definição dos perfis é realizada através da associação com Roles.

### Responsabilidades

- Autenticação
- Gerenciamento de perfil
- Gerenciamento de acessos
- Relacionamento com estabelecimentos

### Principais Atributos

Id
Name
Email
PasswordHash
CreatedAt
IsActive


---

## Role

Representa um perfil de acesso do sistema.

### Papéis previstos

Customer
Bakery
Admin


### Responsabilidades

- Controle de permissões
- Autorização de acesso

### Principais Atributos

Id
Name
Description


---

## UserRole

Representa o relacionamento entre usuários e perfis.

Um usuário pode possuir mais de um perfil.

### Exemplos

Bruno
 └── Customer

Padaria Central
 └── Bakery

Administrador Geral
 └── Admin


### Principais Atributos

UserId
RoleId
AssignedAt


---

## BakeryApplication

Representa uma solicitação para habilitação de um usuário como estabelecimento.

A aprovação é obrigatória para que o usuário obtenha acesso às funcionalidades de estabelecimento.

### Status possíveis

Pending
Approved
Rejected


### Responsabilidades

- Armazenar a solicitação
- Registrar análise administrativa
- Controlar aprovação ou rejeição

### Principais Atributos

Id

UserId

TradeName

DocumentNumber

Phone

Address

Description

Status

CreatedAt

ApprovedAt

ApprovedByUserId


---

## BakeryProfile

Representa o perfil comercial do estabelecimento.

É criado após a aprovação da solicitação.

### Responsabilidades

- Identificação do estabelecimento
- Dados públicos
- Dados operacionais

### Principais Atributos

Id

UserId

TradeName

Description

Phone

Address

LogoUrl

CreatedAt


---

## Subscription

Representa o relacionamento entre um consumidor e um estabelecimento.

Permite que um usuário receba notificações de um determinado estabelecimento.

### Exemplo

João segue Padaria Central


### Responsabilidades

- Controlar acompanhamento de estabelecimentos

### Principais Atributos

Id

CustomerUserId

BakeryProfileId

CreatedAt


---

## Batch

Representa uma produção realizada por um estabelecimento.

É a entidade principal do negócio.

### Exemplos

Pão Francês

Baguete

Pão Integral

Sonho

Croissant


### Status possíveis

Scheduled
InProgress
Completed
Canceled


### Responsabilidades

- Controlar o ciclo da produção
- Calcular previsão de conclusão
- Disparar eventos de negócio

### Principais Atributos

Id

BakeryProfileId

ProductId

StartTime

DurationMinutes

EstimatedReadyAt

CompletedAt

Status

CreatedAt

UpdatedAt


---

## NotificationPreference

Representa a configuração personalizada de notificação de um usuário.

Um mesmo usuário pode possuir configurações diferentes para cada estabelecimento.

### Exemplos

Padaria Central
 └── Avisar 10 minutos antes

Padaria do Bairro
 └── Avisar 20 minutos antes


### Responsabilidades

- Personalizar o momento de recebimento da notificação

### Principais Atributos

Id

UserId

BakeryProfileId

MinutesBefore


---

## Notification

Representa um registro de comunicação realizada pelo sistema.

### Responsabilidades

- Auditoria
- Histórico
- Rastreabilidade

### Status possíveis

Pending
Scheduled
Sent
Failed


### Principais Atributos

Id

UserId

BatchId

Title

Message

ScheduledAt

SentAt

Status


---

## DeviceToken

Representa um dispositivo habilitado para receber notificações push.

Um usuário pode possuir diversos dispositivos.

### Exemplos

Android

iPhone

Tablet


### Responsabilidades

- Registrar dispositivos
- Permitir envio de notificações

### Principais Atributos

Id

UserId

Token

Platform

CreatedAt

LastUsedAt


---

# Relacionamentos

## User e Role

Relacionamento:

N : N


Representado por:

UserRole


---

## User e BakeryApplication

Relacionamento:

1 : N


Um usuário pode realizar múltiplas solicitações ao longo do tempo.

---

## User e BakeryProfile

Relacionamento:

1 : 1


Um estabelecimento possui exatamente um perfil comercial.

---

## User e Subscription

Relacionamento:

1 : N


Um usuário pode seguir vários estabelecimentos.

---

## BakeryProfile e Subscription

Relacionamento:

1 : N


Um estabelecimento pode possuir diversos seguidores.

---

## BakeryProfile e Batch

Relacionamento:

1 : N


Um estabelecimento pode criar inúmeras produções.

---

## User e NotificationPreference

Relacionamento:

1 : N


Cada usuário pode possuir várias preferências.

---

## BakeryProfile e NotificationPreference

Relacionamento:

1 : N


Cada estabelecimento pode possuir diversas configurações de usuários.

---

## User e Notification

Relacionamento:

1 : N


Um usuário pode receber diversas notificações.

---

## Batch e Notification

Relacionamento:

1 : N


Uma produção pode gerar várias notificações.

---

## User e DeviceToken

Relacionamento:

1 : N


Um usuário pode possuir múltiplos dispositivos.

---

# Diagrama Conceitual

User
│
├── UserRole
│      └── Role
│
├── BakeryApplication
│
├── Subscription
│
├── Notification
│
├── NotificationPreference
│
└── DeviceToken

BakeryProfile
│
├── User
│
├── Subscription
│
├── Batch
│
└── NotificationPreference

Batch
│
└── Notification


---

# Regras de Negócio

## RN-001

Somente usuários ativos podem acessar o sistema.

---

## RN-002

Somente usuários com o perfil Bakery podem criar produções.

---

## RN-003

O perfil Bakery somente pode ser atribuído após aprovação de uma solicitação válida.

---

## RN-004

Uma produção deve possuir duração prevista maior que zero.

---

## RN-005

A previsão de conclusão da produção deve ser calculada a partir do horário de início e do tempo de duração.

---

## RN-006

Notificações somente devem ser enviadas para usuários que seguem o estabelecimento responsável pela produção.

---

## RN-007

O momento da notificação deve respeitar a configuração definida pelo usuário.

---

## RN-008

Todos os envios de notificação devem ser registrados para fins de auditoria e rastreabilidade.

---

## RN-009

Uma produção concluída não pode retornar ao status de produção em andamento.

---

## RN-010

Usuários podem possuir múltiplos dispositivos cadastrados para recebimento de notificações push.

---

# Próxima Etapa

Com a definição do modelo de domínio concluída, o próximo passo será a elaboração do modelo relacional do banco de dados, identificando:

- Tabelas
- Chaves primárias
- Chaves estrangeiras
- Índices
- Restrições
- Estratégias de persistência

Esse modelo servirá de base para a implementação do Entity Framework Core e da camada de Infraestrutura.
