# DecompApp

Este projeto tem a funcionalidade de decompor um número em todos os seus divisores e destacar os números primos.

# Descrição

O projeto foi desenvolvido em C# (.Net 6), no Visual Studio 2022;
Foram utilizados princípios de DDD e testes unitários;
Foi utilizado o novo conceito de Minimal Api's, introduzido no .Net 6

# Presentation

Foram desenvolvidos dois projetos para o acesso à funcionalidade:  

1. API - IIS local ou docker (Com documentação, utilizando o Swagger);
2. Minimal API - IIS local ou docker (Formato introduzido com o .Net 6)
3. Projeto de console.

# Docker

Para subir as imagens pelo docker compose e executar os containers das API's (raíz do projeto):

```
  docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d 
```

Para acessar:

```
  Api: http://localhost:8081/swagger/index.html
  Minimal Api: http://localhost:8082/swagger/index.html
```

# Azure

O container também está publicado no Azure e pode ser acessado na seguinte url:

```
  http://20.81.60.182/swagger/index.html
```
