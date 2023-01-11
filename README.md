Projeto desenvolvido em .net core 2.2 com o intuito de demonstrar a utilização de 
mensageria, micro serviços, arquitetura orientada a eventos e fluxos mediadores com total desacoplamento
entre todos os objetos e processos.

## Diagrama
<img src="https://user-images.githubusercontent.com/73493014/110170081-68d30580-7dd8-11eb-8620-c114d29658f2.png" width="700" align="center">

## Conceitos e patterns incluídos
* Utilização de classes e mapeamentos genéricos;
* Microserviços;
* Mensageria;
* Métodos comuns de interação de API;
* Arquitetura orientada a eventos;
* Mediator pattern;
* CQRS pattern

## Ferramentas/Frameworks 

* Docker Compose (gerenciador de containers)
* MediatR
* RabbitMQ
* Azure Function - RabbitMQTrigger consumer
* IoC Dependency Injection Microsoft
* MongoDB
* Postman

## Configurando os ambientes com docker compose

### Instalar o docker Windows
link: https://hub.docker.com/editions/community/docker-ce-desktop-windows/

### Criando os containers 
Após o docker ser instalado, entre na pasta do projeto e execute `docker-compose up -d` dentro da pasta do projeto para criar as bases locais do mongo-express e rabbitMQ.
Isso executará o arquivo **`docker-compose.yml`** contém todas as imagens necessárias para criação das bases locais.

### Curl da requisição para inserir um produto na fila 
`curl --location --request POST 'https://localhost:44379/products/sendQueue' \  
--header 'Content-Type: application/json' \  
--data-raw '{  
    "skuPartner": "1",    
    "description": "teste",   
    "image":"image.com",      
    "price": 10.1,      
    "availability": true      
}'`
 
 
