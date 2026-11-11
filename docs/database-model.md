# Modelo Relacional do Banco de Dados

## Visão Geral

O BakeryHub utilizará inicialmente um único banco de dados relacional.

Tecnologia prevista:

SQL Server


Nome do banco:

BakeryHubDb


O modelo foi projetado para atender ao MVP e permitir evolução futura sem necessidade de alterações estruturais significativas.

---

# Convenções

## Chaves Primárias

Todas as entidades utilizarão:

uniqueidentifier (GUID)


Como chave primária.

Exemplo:

sql
Id uniqueidentifier not null


---

## Auditoria

Sempre que aplicável, as entidades possuirão:

CreatedAt
UpdatedAt


---

## Exclusão

Inicialmente será utilizado Soft Delete apenas para entidades que exijam histórico.

Nos demais casos será utilizado status ou inativação.

---

# Diagrama Geral

Users
 ├─ UserRoles
 │    └─ Roles
 │
 ├─ BakeryApplications
 │
 ├─ BakeryProfiles
 │
 ├─ Subscriptions
 │
 ├─ NotificationPreferences
 │
 ├─ Notifications
 │
 ├─ DeviceTokens
 │
 └─ RefreshTokens

BakeryProfiles
 ├─ Batches
 ├─ Subscriptions
 └─ NotificationPreferences

Batches
 └─ Notifications


---

# Identity

## Users

Responsável pelo cadastro dos usuários da plataforma.

### Estrutura

| Campo | Tipo | Obrigatório |
|---------|---------|---------|
| Id | uniqueidentifier | Sim |
| Name | nvarchar(200) | Sim |
| Email | nvarchar(255) | Sim |
| PasswordHash | nvarchar(max) | Sim |
| IsActive | bit | Sim |
| CreatedAt | datetime2 | Sim |
| UpdatedAt | datetime2 | Não |

### Índices

sql
UNIQUE(Email)


---

## Roles

Perfis de acesso do sistema.

### Estrutura

| Campo | Tipo |
|---------|---------|
| Id | uniqueidentifier |
| Name | nvarchar(100) |
| Description | nvarchar(300) |

### Registros Iniciais

Customer
Bakery
Admin


### Índices

sql
UNIQUE(Name)


---

## UserRoles

Relacionamento entre usuários e perfis.

### Estrutura

| Campo | Tipo |
|---------|---------|
| UserId | uniqueidentifier |
| RoleId | uniqueidentifier |
| AssignedAt | datetime2 |

### Chave Primária

sql
(UserId, RoleId)


---

## RefreshTokens

Controle de autenticação.

### Estrutura

| Campo | Tipo |
|---------|---------|
| Id | uniqueidentifier |
| UserId | uniqueidentifier |
| Token | nvarchar(500) |
| ExpiresAt | datetime2 |
| RevokedAt | datetime2 |
| CreatedAt | datetime2 |
| ReplacedByToken | nvarchar(500) |

### Índices

sql
INDEX(UserId)
INDEX(Token)


---

# Estabelecimentos

## BakeryApplications

Solicitações para habilitação de estabelecimentos.

### Estrutura

| Campo | Tipo |
|---------|---------|
| Id | uniqueidentifier |
| UserId | uniqueidentifier |
| TradeName | nvarchar(200) |
| DocumentNumber | nvarchar(30) |
| Phone | nvarchar(30) |
| Address | nvarchar(500) |
| Description | nvarchar(1000) |
| Status | int |
| CreatedAt | datetime2 |
| ApprovedAt | datetime2 |
| ApprovedByUserId | uniqueidentifier |

### Índices

sql
INDEX(UserId)
INDEX(Status)


---

## BakeryProfiles

Perfil operacional do estabelecimento.

### Estrutura

| Campo | Tipo |
|---------|---------|
| Id | uniqueidentifier |
| UserId | uniqueidentifier |
| TradeName | nvarchar(200) |
| Description | nvarchar(1000) |
| Phone | nvarchar(30) |
| Address | nvarchar(500) |
| LogoUrl | nvarchar(500) |
| CreatedAt | datetime2 |
| UpdatedAt | datetime2 |

### Índices

sql
UNIQUE(UserId)
INDEX(TradeName)


---

# Relacionamento entre Usuários e Estabelecimentos

## Subscriptions

Representa usuários seguindo estabelecimentos.

### Estrutura

| Campo | Tipo |
|---------|---------|
| Id | uniqueidentifier |
| CustomerUserId | uniqueidentifier |
| BakeryProfileId | uniqueidentifier |
| CreatedAt | datetime2 |

### Restrições

sql
UNIQUE(CustomerUserId, BakeryProfileId)


### Índices

sql
INDEX(CustomerUserId)
INDEX(BakeryProfileId)


---

## NotificationPreferences

Preferências de antecedência das notificações.

### Estrutura

| Campo | Tipo |
|---------|---------|
| Id | uniqueidentifier |
| UserId | uniqueidentifier |
| BakeryProfileId | uniqueidentifier |
| MinutesBefore | int |

### Restrições

sql
UNIQUE(UserId, BakeryProfileId)


### Regras

MinutesBefore > 0


### Índices

sql
INDEX(UserId)
INDEX(BakeryProfileId)


---

# Produção

## Batches

Representa uma produção realizada por um estabelecimento.

### Estrutura

| Campo | Tipo |
|---------|---------|
| Id | uniqueidentifier |
| BakeryProfileId | uniqueidentifier |
| ProductName | nvarchar(200) |
| StartTime | datetime2 |
| DurationMinutes | int |
| EstimatedReadyAt | datetime2 |
| CompletedAt | datetime2 |
| Status | int |
| CreatedAt | datetime2 |
| UpdatedAt | datetime2 |

### Status

Scheduled = 1
InProgress = 2
Completed = 3
Canceled = 4


### Regras

DurationMinutes > 0


### Índices

sql
INDEX(BakeryProfileId)
INDEX(Status)
INDEX(EstimatedReadyAt)


---

# Notificações

## Notifications

Histórico completo de notificações.

### Estrutura

| Campo | Tipo |
|---------|---------|
| Id | uniqueidentifier |
| UserId | uniqueidentifier |
| BatchId | uniqueidentifier |
| Title | nvarchar(200) |
| Message | nvarchar(1000) |
| ScheduledAt | datetime2 |
| SentAt | datetime2 |
| Status | int |

### Status

Pending = 1
Scheduled = 2
Sent = 3
Failed = 4


### Índices

sql
INDEX(UserId)
INDEX(BatchId)
INDEX(Status)
INDEX(ScheduledAt)


---

## DeviceTokens

Dispositivos habilitados para push notifications.

### Estrutura

| Campo | Tipo |
|---------|---------|
| Id | uniqueidentifier |
| UserId | uniqueidentifier |
| Token | nvarchar(max) |
| Platform | nvarchar(50) |
| CreatedAt | datetime2 |
| LastUsedAt | datetime2 |

### Plataformas Previstas

Android
iOS


### Índices

sql
INDEX(UserId)


---

# Relacionamentos

## Users → UserRoles

1:N


---

## Roles → UserRoles

1:N


---

## Users → BakeryApplications

1:N


---

## Users → BakeryProfiles

1:1


---

## BakeryProfiles → Batches

1:N


---

## Users → Subscriptions

1:N


---

## BakeryProfiles → Subscriptions

1:N


---

## Users → NotificationPreferences

1:N


---

## BakeryProfiles → NotificationPreferences

1:N


---

## Users → Notifications

1:N


---

## Batches → Notifications

1:N


---

## Users → DeviceTokens

1:N


---

## Users → RefreshTokens

1:N


---

# Estratégia de Índices

Índices de busca frequente:

Email
TradeName
Status
EstimatedReadyAt
ScheduledAt


Índices de relacionamentos:

UserId
BakeryProfileId
BatchId


Objetivos:

- Melhorar consultas
- Reduzir tempo de busca
- Facilitar filtros e paginação

---

# Estratégia de Migrations

Todas as alterações estruturais deverão ser realizadas através do Entity Framework Core Migrations.

Exemplo:

bash
dotnet ef migrations add InitialCreate


bash
dotnet ef database update


---

# Estratégia de Evolução

O modelo foi desenhado para suportar futuras funcionalidades:

- Aplicativo mobile
- Mensageria com RabbitMQ
- Azure Service Bus
- Analytics
- Multi-tenancy
- Kubernetes
- Escalabilidade horizontal

sem necessidade de mudanças significativas na estrutura principal do banco.

---

# Próxima Etapa

Após a validação do modelo relacional, o próximo passo será a definição da API da plataforma.

Documento previsto:

docs/api-design.md


Esse documento definirá:

- Endpoints
- Requests
- Responses
- Paginação
- Versionamento
- Estratégias de autenticação e autorização
