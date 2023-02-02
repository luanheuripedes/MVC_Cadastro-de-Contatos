# Cadastro-de-Contatos-MVC

Projeto criado com o intuído de aprender sobre Razor MVC. Basicamente é um cadastro de contatos, onde existem 2 níveis de usuários o 'Administrador' e o 'Padrão'.

## Administrador
Este perfil de usuário tem acesso aos usuários cadastrados no sistema, cadastra novos usuários, edita os usuários existentes e deleta os usuários. Além disso, pode visualizar contatos que cada usuário do sistema cadastrou.

## Padrão 
Este perfil consegue somente cadastrar, editar e excluir os contatos que por ele foram inseridos.

## 🛠️ Construído com
* ASP.NET Core 6 Razor MVC
* AutoMapper
* Entity Framework Core
* MailKit e MimeKit
* MySQL

# Camadas do projeto

## Arquitetura apresentada no Livro de DDD do Eric Evans. Existem outras abordagens dessa arquitetura. Ela consiste em dividir as responsabilidades da aplicação deixando tudo bem separado, onde nenhuma camada fica com responsabilidades a mais e se houver algum erro fica fácil de rastrear. Uma 'tentativa' de implementação dessa arquitetura. 

## Domain
Camada onde estão as entidades de sistema. Possui apenas um diretório:
### Entities
Diretório onde contém uma classe abstrata chamada 'Base' onde só possui um Id e outras duas classes referentes ao Usuário e Contato.


## Service
Camada responsável pelas regras de negócio. Regras de como o sistema no negócio vai funcionar com os seus comportamentos. Possui os seguintes diretórios:
### DTOs
  Contém os data object transfer
### Services 
  Contém as interfaces e implementação dos serviços de Usuário e Contato.
  
## Infrastructure
Camada responsável por se comunicar com o banco de dados realizando as operações de CRUD. Possui os seguintes diretórios:
### Context
  A classe BancoContext é parte integrante do Entity Framework. Uma instância de BancoContext apresenta uma sessão com o banco de dados que pode ser usada para consultar e salvar instâncias de suas entidades em um banco de dados. DbContext é uma combinação dos padrões Unit Of Work e Repositorie.
### Migrations
  Como o banco foi gerado a partir do data base first, todo e qualquer modificação na estrutura do banco é salvo nesse diretório.
### Configuration
  Diretório onde estão as classes de configuração para gerar o banco utilizando o data base first do Entity Framework Core.
### Repositories
  Diretório onde estão as classes de operação com o banco de dados de Contato e Usuário


### ControleDeContatos
É a camada de apresentação, onde foi utilizado a template Razor MVC. Aqui estão todas as controllers e views do sistema.
