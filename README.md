# ApiSprint5
A APISprint5 é um projeto proposto pelo programa de bolsa da Compass UOL .NET, com os seguintes requisitos: 
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
- Antes de rodar o projeto instale o SqlServer Express.
- Com o projeto aberto configure o banco de dados utilizando o seguinte comando: Update-database


### Link da Documentação:
https://documenter.getpostman.com/view/18840205/UVXnHaTY



### Pré-requisitos:
* Visual Studio 2019
* SqlServer Express
* .NET Core 3.1
* Postman
