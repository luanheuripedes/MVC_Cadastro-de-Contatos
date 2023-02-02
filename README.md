# Cadastro-de-Contatos-MVC

Projeto criado com o intuido de aprender sobre Razor MVC. Basicamente é um cadastro de contatos, onde existem 2 níveis de usuarios o 'Administrador' e o 'Padrão'.

## Administrador
Este perfil de usuário tem acesso aos usuario cadastrados no sistema, cadastra novos usuarios, edita os usuarios existentes e deleta os usuarios. Além disso, pode visualizar contatos que cada usuario do sistema cadastrou.

## Padrão 
Este perfil consegue somente cadastrar, editar e excluir os contatos que por ele foram inseridos.

## 🛠️ Construído com
* ASP.NET Core 6 Razor MVC
* AutoMapper
* Entity Framework Core
* MailKit e MimeKit
* MySQL

## Camadas do projeto

### Arquitetura apresentada no Livro de DDD do Eric Evans. Existem outras abordagens dessa arquitetura. Ela consiste em dividir as responsabilidades da aplicação deixando tudo bem separado, onde nenhuma camada fica com responsabilidades a mais e se houver algum erro fica fácil de rastrear. Uma 'tentativa' de implementação dessa arquitetura. 

### Domain
Camada onde estão as entidades de sistema. Usuário e Contato.

### Service
Camada responsável pelas regras de negocio. Regras de como o sistema no negocio vai funcionar com os seus comportamentos.

### Infrastructure
Camada responsável por se comunicar com o banco de dados realizando as operações de CRUD.

### ControleDeContatos
É a camada de apresentação, onde foi utilizado a template Razor MVC. Aqui estão todas as controllers e viwes do sistema.

