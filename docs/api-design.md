\# API Design



\## Visão Geral



A API do BakeryHub seguirá os princípios RESTful e será responsável por fornecer acesso aos recursos da plataforma para aplicações Web, Mobile e futuras integrações.



Características:



\- REST API

\- JSON como formato padrão

\- JWT Authentication

\- Versionamento por URL

\- Documentação via Swagger/OpenAPI

\- HTTPS obrigatório

\- Suporte a paginação



\---



\# Convenções



\## Base URL



http

/api/v1





Exemplos:



http

/api/v1/auth/login



/api/v1/users



/api/v1/bakeries



/api/v1/batches





\---



\## Formato de Datas



Padrão:



json

"2026-11-10T08:30:00Z"





\---



\## Identificadores



Todos os recursos utilizarão GUID.



Exemplo:



json

{

&#x20; "id": "4f3ba8bc-dad0-4a49-a87d-ba36dde86cf5"

}





\---



\## Paginação



Request:



http

GET /api/v1/bakeries?page=1\&pageSize=20





Response:



json

{

&#x20; "page": 1,

&#x20; "pageSize": 20,

&#x20; "totalItems": 300,

&#x20; "totalPages": 15,

&#x20; "items": \[]

}





\---



\# Autenticação



\## Login



\### Endpoint



http

POST /api/v1/auth/login





\### Request



json

{

&#x20; "email": "bruno@email.com",

&#x20; "password": "Senha123!"

}





\### Response



json

{

&#x20; "accessToken": "jwt-token",

&#x20; "expiresIn": 900

}





\---



\## Refresh Token



\### Endpoint



http

POST /api/v1/auth/refresh





\### Response



json

{

&#x20; "accessToken": "new-jwt-token",

&#x20; "expiresIn": 900

}





\---



\## Logout



\### Endpoint



http

POST /api/v1/auth/logout





\### Response



http

204 No Content





\---



\# Usuários



\## Registrar Usuário



\### Endpoint



http

POST /api/v1/users





\### Request



json

{

&#x20; "name": "Bruno Hazan",

&#x20; "email": "bruno@email.com",

&#x20; "password": "Senha123!"

}





\### Response



json

{

&#x20; "id": "guid",

&#x20; "name": "Bruno Hazan",

&#x20; "email": "bruno@email.com"

}





\### Status



http

201 Created





\---



\## Obter Perfil



\### Endpoint



http

GET /api/v1/users/me





\### Response



json

{

&#x20; "id": "guid",

&#x20; "name": "Bruno Hazan",

&#x20; "email": "bruno@email.com",

&#x20; "roles": \[

&#x20;   "Customer"

&#x20; ]

}





\---



\## Atualizar Perfil



\### Endpoint



http

PUT /api/v1/users/me





\### Request



json

{

&#x20; "name": "Bruno Lima Hazan"

}





\### Response



http

204 No Content





\---



\# Solicitações de Estabelecimento



\## Solicitar Habilitação



\### Endpoint



http

POST /api/v1/bakery-applications





\### Request



json

{

&#x20; "tradeName": "Padaria Central",

&#x20; "documentNumber": "12345678000199",

&#x20; "phone": "71999999999",

&#x20; "address": "Rua Exemplo, 100",

&#x20; "description": "Padaria artesanal."

}





\### Response



json

{

&#x20; "id": "guid",

&#x20; "status": "Pending"

}





\---



\## Listar Solicitações



\### Endpoint



http

GET /api/v1/bakery-applications





\### Autorização



Admin





\---



\## Aprovar Solicitação



\### Endpoint



http

POST /api/v1/bakery-applications/{id}/approve





\### Response



http

204 No Content





\---



\## Rejeitar Solicitação



\### Endpoint



http

POST /api/v1/bakery-applications/{id}/reject





\### Response



http

204 No Content





\---



\# Estabelecimentos



\## Listar Estabelecimentos



\### Endpoint



http

GET /api/v1/bakeries





\### Response



json

{

&#x20; "items": \[

&#x20;   {

&#x20;     "id": "guid",

&#x20;     "tradeName": "Padaria Central",

&#x20;     "description": "Padaria artesanal."

&#x20;   }

&#x20; ]

}





\---



\## Obter Estabelecimento



\### Endpoint



http

GET /api/v1/bakeries/{id}





\---



\## Atualizar Perfil



\### Endpoint



http

PUT /api/v1/bakeries/me





\### Autorização



Bakery





\---



\# Seguidores



\## Seguir Estabelecimento



\### Endpoint



http

POST /api/v1/bakeries/{id}/follow





\### Response



http

204 No Content





\---



\## Deixar de Seguir



\### Endpoint



http

DELETE /api/v1/bakeries/{id}/follow





\### Response



http

204 No Content





\---



\## Listar Estabelecimentos Seguidos



\### Endpoint



http

GET /api/v1/users/me/subscriptions





\---



\# Preferências de Notificação



\## Criar ou Atualizar Preferência



\### Endpoint



http

PUT /api/v1/notification-preferences/{bakeryId}





\### Request



json

{

&#x20; "minutesBefore": 10

}





\### Response



http

204 No Content





\---



\## Listar Preferências



\### Endpoint



http

GET /api/v1/users/me/notification-preferences





\---



\# Produções



\## Criar Produção



\### Endpoint



http

POST /api/v1/batches





\### Autorização



Bakery





\### Request



json

{

&#x20; "productName": "Pão Francês",

&#x20; "startTime": "2026-11-10T08:00:00Z",

&#x20; "durationMinutes": 30

}





\### Response



json

{

&#x20; "id": "guid",

&#x20; "estimatedReadyAt": "2026-11-10T08:30:00Z"

}





\---



\## Obter Produção



\### Endpoint



http

GET /api/v1/batches/{id}





\---



\## Listar Produções Ativas



\### Endpoint



http

GET /api/v1/batches/active





\---



\## Listar Produções de um Estabelecimento



\### Endpoint



http

GET /api/v1/bakeries/{id}/batches





\---



\## Finalizar Produção



\### Endpoint



http

POST /api/v1/batches/{id}/complete





\### Autorização



Bakery





\### Response



http

204 No Content





\---



\## Cancelar Produção



\### Endpoint



http

POST /api/v1/batches/{id}/cancel





\### Response



http

204 No Content





\---



\# Notificações



\## Listar Notificações



\### Endpoint



http

GET /api/v1/notifications





\### Response



json

{

&#x20; "items": \[

&#x20;   {

&#x20;     "id": "guid",

&#x20;     "title": "Produção quase concluída",

&#x20;     "message": "Pão Francês ficará pronto em 10 minutos.",

&#x20;     "sentAt": "2026-11-10T08:20:00Z"

&#x20;   }

&#x20; ]

}





\---



\## Marcar como Lida



\### Endpoint



http

POST /api/v1/notifications/{id}/read





\### Response



http

204 No Content





\---



\# Dispositivos



\## Registrar Dispositivo



\### Endpoint



http

POST /api/v1/devices





\### Request



json

{

&#x20; "token": "firebase-device-token",

&#x20; "platform": "Android"

}





\### Response



http

201 Created





\---



\## Remover Dispositivo



\### Endpoint



http

DELETE /api/v1/devices/{id}





\### Response



http

204 No Content





\---



\# Administração



\## Listar Usuários



\### Endpoint



http

GET /api/v1/admin/users





\### Autorização



Admin





\---



\## Listar Estabelecimentos



\### Endpoint



http

GET /api/v1/admin/bakeries





\### Autorização



Admin





\---



\## Dashboard Administrativo



\### Endpoint



http

GET /api/v1/admin/dashboard





\### Response



json

{

&#x20; "users": 1000,

&#x20; "bakeries": 50,

&#x20; "activeBatches": 30,

&#x20; "notificationsSent": 15000

}





\---



\# Padrão de Erros



\## Validation Error



json

{

&#x20; "type": "validation",

&#x20; "errors": \[

&#x20;   {

&#x20;     "field": "email",

&#x20;     "message": "Email inválido."

&#x20;   }

&#x20; ]

}





\### Status



http

400 Bad Request





\---



\## Unauthorized



json

{

&#x20; "message": "Usuário não autenticado."

}





\### Status



http

401 Unauthorized





\---



\## Forbidden



json

{

&#x20; "message": "Acesso negado."

}





\### Status



http

403 Forbidden





\---



\## Not Found



json

{

&#x20; "message": "Recurso não encontrado."

}





\### Status



http

404 Not Found





\---



\# Versionamento



A API será versionada via URL.



Exemplos:



http

/api/v1/users



/api/v2/users





Benefícios:



\- Compatibilidade retroativa

\- Evolução controlada

\- Facilidade de manutenção



\---



\# Próxima Etapa



Com os documentos de domínio, arquitetura, banco de dados e API definidos, a fase de planejamento é considerada concluída.



O próximo passo será:



1\. Criar a Solution .NET

2\. Criar os projetos da arquitetura

3\. Configurar referências entre projetos

4\. Configurar Docker

5\. Iniciar a implementação da camada Domain

