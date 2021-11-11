# DecompApp

Este projeto tem a funcionalidade de decompor um número em todos os seus divisores e destacar os números primos.

# Descrição

O projeto foi desenvolvido em C# (.Net 6), no Visual Studio 2022.  
Foram utilizados princípios de DDD e testes unitários.

# Presentation

Foram desenvolvidos dois projetos para o acesso à funcionalidade:  

1. API - IIS local ou docker (Com documentação, utilizando o Swagger);
2. Projeto de console.

# Docker

Para criar a imagem e executar o container da API (raíz do projeto):

```
  docker build -t decomp-image -f dockerfile .
```

```
  docker run -d -p 8080:80 --name decomp-image decomp-image
```

Para acessar:

```
  http://localhost:8080/swagger/index.html
```

# Azure

O container também está publicado no Azure e pode ser acessado na seguinte url:

```
  http://20.81.60.182/swagger/index.html
```
