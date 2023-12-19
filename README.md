# Projeto Api modelo 3 camadas

- Criação de Api com 3 camadas, utlizando padrão REST com todos os métodos CRUD.
- Utilizado o Padrão Repository Pattern.
- Efetuado Injeção de Dependencia na comunicação das camadas.
- Camada Business isolada de qualquer outra camada.
- Utilizado métodos assincronos.
- Regra básica consiste em não incluir um carro com o mesmo modelo.
## Pacotes utilizados
### Camada Data
- Microsoft.EntityFrameworkCore.SqlServer (6.0.25)
- Microsoft.EntityFrameworkCore.Tools (6.0.25)
### Camada Business
- FluentValidation (11.8.1)
### Camada API
- AutoMapper (12.0.1)
- AutoMapper.Extensions.Microsoft.DependencyInjection (12.0.1)
- Microsoft.EntityFrameworkCore.Design (6.0.25)
- Swashbuckle.AspNetCore (6.5.0)
## .NET SDK
- .NET 6.0
