# ApiSprint5
A APISprint5 é um projeto proposto pelo programa de bolsa da Compass UOL .NET, com o s seguintes propósitos: 
- Relacionar Clientes e Cidade utilizando API Rest .NET 5, Entity Framerwork e SQL Server local.
- Realizar o mapeamento (por meio de DTos), utilizando o AutoMapper.
- Utilizar dois endpoints: um para clientes e outro para cidades.
- Cada endpoint deverá criar, listar todos os registros, editar registro por id, remover registro por id e buscar registro por id.
- Receber somente o CEP como informação de endereço no endpoint de criar ou editar um novo cliente.
- Utilizar a API externa do Viacep para preencher o endereço do cliente e popular a entidade cidade quando houver necessidade de nova inclusão.
- Utilizar Fluent Validation para validar no mínimo 1 campo (de cada classe) que esteja vazio ou inválido e retornar a mensagem de validação.
- Realizar testes de Integração do contexto de clientes.
 
### Como Utilizar a APISprint5:

- Baixe o projeto,
- Abra arquivo ApiSprint5.sln no Visual Studio 2019,
- Com o projeto aberto configure o banco de dados utilizando os seguintes comandos:
    - Add-Migration NewMigration -Project ApiCliente.Infrastructure
    - Update-database


### Link da Documentação:


### Pré-requisitos:
* Visual Studio 2019
* .NET Core 3.1
* Postman
