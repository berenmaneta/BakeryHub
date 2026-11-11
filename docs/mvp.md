# MVP - Minimum Viable Product

## Objetivo

O objetivo da primeira versão do BakeryHub é validar a proposta de valor da plataforma, permitindo que consumidores acompanhem estabelecimentos e recebam notificações quando uma produção estiver próxima da conclusão.

A versão inicial deve entregar o fluxo completo de cadastro, aprovação de estabelecimentos, criação de produções e envio de notificações, priorizando simplicidade, usabilidade e confiabilidade.

---

## Escopo da Primeira Versão

A versão 1.0 será considerada concluída quando um usuário puder:

1. Criar uma conta na plataforma.
2. Realizar autenticação.
3. Solicitar cadastro como estabelecimento.
4. Ter sua solicitação aprovada por um administrador.
5. Seguir um estabelecimento.
6. Configurar sua preferência de notificação.
7. Receber notificações referentes às produções do estabelecimento.
8. Consultar informações básicas sobre produções ativas.

---

# Perfis de Usuário

## Cliente

Responsável por acompanhar estabelecimentos e receber notificações.

### Funcionalidades

- Criar conta
- Realizar login
- Editar perfil
- Consultar estabelecimentos
- Seguir estabelecimentos
- Deixar de seguir estabelecimentos
- Configurar antecedência da notificação
- Visualizar histórico de notificações

---

## Estabelecimento

Responsável por informar produções à plataforma.

### Funcionalidades

- Solicitar habilitação como estabelecimento
- Editar perfil do estabelecimento
- Criar produções
- Consultar produções em andamento
- Consultar histórico de produções
- Finalizar produções manualmente

---

## Administrador

Responsável pela governança da plataforma.

### Funcionalidades

- Aprovar solicitações de estabelecimento
- Rejeitar solicitações de estabelecimento
- Consultar usuários
- Consultar estabelecimentos
- Monitorar informações básicas da plataforma

---

# Fluxos do MVP

## Fluxo 1 – Cadastro e Autenticação

1. Usuário cria uma conta.
2. Usuário realiza login.
3. Sistema gera e retorna o token de autenticação.

---

## Fluxo 2 – Solicitação de Estabelecimento

1. Usuário autenticado solicita habilitação como estabelecimento.
2. Sistema registra a solicitação.
3. Administrador analisa a solicitação.
4. Administrador aprova ou rejeita o pedido.
5. Em caso de aprovação, o usuário recebe o perfil de estabelecimento.

---

## Fluxo 3 – Acompanhamento de Produção

1. Cliente localiza um estabelecimento.
2. Cliente passa a seguir o estabelecimento.
3. Cliente configura quantos minutos antes deseja ser notificado.
4. Estabelecimento cria uma nova produção.
5. Sistema calcula a previsão de conclusão.
6. Sistema agenda a notificação.
7. Cliente recebe o alerta no momento configurado.

---

## Fluxo 4 – Encerramento da Produção

1. Estabelecimento encerra uma produção.
2. Sistema registra a conclusão.
3. Produção deixa de ser apresentada como ativa.

---

# Funcionalidades Incluídas

## Gestão de Usuários

- Cadastro
- Login
- Controle de perfis
- Atualização de dados básicos

---

## Gestão de Estabelecimentos

- Solicitação de habilitação
- Aprovação
- Rejeição
- Manutenção do perfil

---

## Gestão de Produções

- Cadastro de produção
- Atualização de status
- Encerramento de produção
- Histórico básico

---

## Gestão de Seguidores

- Seguir estabelecimento
- Deixar de seguir estabelecimento

---

## Notificações

- Configuração da antecedência
- Geração de notificações
- Histórico básico

---

# Funcionalidades Fora do Escopo

Os itens abaixo não fazem parte da versão 1.0.

## Comercial

- Pagamentos
- Assinaturas
- Marketplace
- Sistema de vendas

---

## Social

- Avaliações
- Comentários
- Compartilhamento em redes sociais
- Chat

---

## Geolocalização

- Busca por proximidade
- Mapa interativo
- Rotas

---

## Inteligência de Negócio

- Dashboards avançados
- Relatórios analíticos
- Indicadores de comportamento

---

## Inteligência Artificial

- Recomendações
- Previsão de demanda
- Chatbots

---

## Infraestrutura Avançada

As tecnologias abaixo poderão ser utilizadas durante o desenvolvimento, porém não fazem parte dos critérios funcionais de aceitação do MVP:

- Kubernetes
- Observabilidade avançada
- Cache distribuído
- Escalabilidade automática
- Multi-região

---

# Critérios de Aceitação do MVP

A versão 1.0 será considerada concluída quando for possível demonstrar o seguinte cenário:

1. Um usuário cria uma conta.
2. O usuário solicita habilitação como estabelecimento.
3. Um administrador aprova a solicitação.
4. Outro usuário cria uma conta como cliente.
5. O cliente segue o estabelecimento.
6. O cliente configura uma antecedência de notificação.
7. O estabelecimento cria uma produção.
8. O sistema calcula a previsão de conclusão.
9. O cliente recebe a notificação no momento esperado.

Se todo esse fluxo puder ser executado com sucesso, o MVP estará concluído.

---

# Próxima Etapa

Após a conclusão do MVP serão avaliadas melhorias como:

- Aplicativo mobile com .NET MAUI
- Mensageria baseada em eventos
- Integração com Azure
- Observabilidade
- Deploy em containers
- Kubernetes
- Escalabilidade horizontal
- Funcionalidades analíticas
