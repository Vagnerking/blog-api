# Blog API (.NET 6)

API REST para gerenciamento de posts e comentários.

## Pré-Requisitos

* .NET 6 SDK
* Visual Studio 2022 ou VS Code
* SQL Server / SQLite

## Configurações para Teste Local

1. Digite no prompt da sua IDE:

   ```cmd
   set ASPNETCORE_ENVIRONMENT=Local
   ```

2. Para baixar os pacotes do projeto (apenas VS Code) rode um:

   ```bash
   dotnet restore
   ```

3. Para atualizar/criar o banco de dados SQLite basta rodar o comando:

   ```bash
   dotnet ef database update
   ```

4. Para rodar a aplicação:

   * No VS Code:

     ```bash
     dotnet run
     ```
   * No Visual Studio é só pressionar F5 após abrir a solution.

## Endpoints

* A API estará disponível em:

  ```
  https://localhost:7059
  ```

* Já o swagger / documentação:

  ```
  https://localhost:7059/swagger/index.html
  ```
  
  
## Próximos passos se tivesse mais tempo


- Adição de JWT ou um Token genérico apenas para criar postagens, atualiza-las ou excluí-las, os gets poderiam ficar livres. 
- Paginação.
- Criação de testes unitários para os controllers, services e repositórios.
- Docker para sempre rodar a aplicação com um banco SQL ou Postgres.
