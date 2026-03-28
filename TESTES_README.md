# Documentação dos Testes - Plataforma Igreja Cristã

## Visão Geral

Este documento descreve a estrutura completa de testes unitários e de integração para o projeto Plataforma Igreja Cristã.

## Estrutura dos Testes

### Testes Unitários (`PlataformaIgrejaCrista.UnitTests`)

Os testes unitários estão organizados por funcionalidade:

#### 1. Testes de Serviços (`Services/`)

- **MemberServiceTests.cs**: Testa o serviço de membros
  - GetMembersAsync: Retorna todos os membros
  - GetByIdAsync: Retorna membro por ID
  - GetByCpfAsync: Retorna membro por CPF
  - GetByChurchAsync: Retorna membros de uma igreja
  - RemoveAsync: Remove um membro

- **ChurchServiceTests.cs**: Testa o serviço de igrejas
  - GetChurchesAsync: Retorna todas as igrejas
  - GetById: Retorna igreja por ID
  - Add: Adiciona nova igreja
  - Update: Atualiza igreja existente
  - Remove: Remove marca

- **AddressServiceTests.cs**: Testa o serviço de endereços
  - GetAddressAsync: Retorna todos os endereços
  - GetByIdAsync: Retorna endereço por ID
  - AddAsync: Adiciona novo endereço
  - UpdateAsync: Atualiza endereço existente
  - RemoveAsync: Remove um endereço

- **ProfessionServiceTests.cs**: Testa o serviço de profissões
  - GetProfessionsAsync: Retorna todas as profissões
  - GetByIdAsync: Retorna profissão por ID
  - GetByNameAsync: Retorna profissão por nome
  - AddAsync: Adiciona nova profissão
  - UpdateAsync: Atualiza profissão existente
  - RemoveAsync: Remove uma profissão

#### 2. Testes de Validação (`Validation/`)

- **DTOValidationTests.cs**: Valida os DTOs
  - Testa criação de DTOs com dados válidos
  - Valida propriedades obrigatórias
  - Testa imutabilidade de records
  - Utiliza InlineData para múltiplos cenários

#### 3. Testes de Exceções (`Exceptions/`)

- **ExceptionHandlingTests.cs**: Testa as exceções da aplicação
  - ApplicationExceptionBase
  - ConflictException
  - UnauthorizedOperationException
  - UseCaseValidationException

#### 4. Testes de Mapeamento (`Mappings/`)

- **MappingProfileTests.cs**: Valida a configuração do AutoMapper
  - Verifica se o perfil de mapeamento está configurado corretamente
  - Valida a validade da configuração do AutoMapper

### Testes de Integração (`PlataformaIgrejaCrista.IntegrationTests`)

Os testes de integração validam o funcionamento da API:

#### 1. Testes de Endpoints (`Endpoints/`)

- **MembersEndpointsTests.cs**: Testa os endpoints de membros
  - GET /members: Retorna lista de membros
  - POST /members/create: Cria novo membro (requer autenticação)

- **ChurchesEndpointsTests.cs**: Testa os endpoints de igrejas
  - GET /churches: Retorna lista de igrejas
  - POST /churches: Cria nova igreja (requer autenticação)
  - GET /churches/{id}: Retorna igreja específica

- **AddressesEndpointsTests.cs**: Testa os endpoints de endereços
  - GET /addresses: Retorna lista de endereços
  - POST /addresses: Cria novo endereço (requer autenticação)
  - PUT /addresses/{id}: Atualiza endereço (requer autenticação)

- **ProfessionsEndpointsTests.cs**: Testa os endpoints de profissões
  - GET /professions: Retorna lista de profissões
  - POST /professions: Cria nova profissão (requer autenticação)
  - PUT /professions/{id}: Atualiza profissão (requer autenticação)
  - DELETE /professions/{id}: Remove profissão (requer autenticação)

#### 2. Testes de Infraestrutura (`Infrastructure/`)

- **HttpStatusCodeTests.cs**: Valida códigos de status HTTP
  - Testa se endpoints retornam status correto
  - Valida endpoints inválidos retornam 404

#### 3. Testes Comuns (`Common/`)

- **ApiHealthTests.cs**: Valida a saúde da API
  - Testa se todos os endpoints estão respondendo
  - Valida tipo de conteúdo JSON
  - Testa acesso ao Swagger

## Estrutura de Arquivos

```
PlataformaIgrejaCrista.UnitTests/
├── Services/
│   ├── MemberServiceTests.cs
│   ├── ChurchServiceTests.cs
│   ├── AddressServiceTests.cs
│   └── ProfessionServiceTests.cs
├── Validation/
│   └── DTOValidationTests.cs
├── Exceptions/
│   └── ExceptionHandlingTests.cs
├── Mappings/
│   └── MappingProfileTests.cs
└── UnitTest1.cs (testes principais)

PlataformaIgrejaCrista.IntegrationTests/
├── Endpoints/
│   ├── MembersEndpointsTests.cs
│   ├── ChurchesEndpointsTests.cs
│   ├── AddressesEndpointsTests.cs
│   └── ProfessionsEndpointsTests.cs
├── Infrastructure/
│   └── HttpStatusCodeTests.cs
├── Common/
│   └── ApiHealthTests.cs
├── TestFixture.cs
└── UnitTest1.cs
```

## Como Executar os Testes

### Executar todos os testes

```bash
dotnet test
```

### Executar apenas testes unitários

```bash
dotnet test PlataformaIgrejaCrista.UnitTests/PlataformaIgrejaCrista.UnitTests.csproj
```

### Executar apenas testes de integração

```bash
dotnet test PlataformaIgrejaCrista.IntegrationTests/PlataformaIgrejaCrista.IntegrationTests.csproj
```

### Executar um teste específico

```bash
dotnet test --filter "FullyQualifiedName~MemberServiceTests"
```

### Executar com relatório de cobertura

```bash
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
```

## Dependências de Teste

### Testes Unitários

- **xUnit**: Framework de testes
- **Moq**: Biblioteca de mocking
- **FluentAssertions**: Assertions fluentes
- **AutoMapper**: Para testes de mapeamento

### Testes de Integração

- **xUnit**: Framework de testes
- **FluentAssertions**: Assertions fluentes
- **Microsoft.AspNetCore.Mvc.Testing**: WebApplicationFactory para testes de API
- **Moq**: Biblioteca de mocking (se necessário)

## Padrões de Teste Utilizados

### Arrange-Act-Assert (AAA)

Todos os testes seguem o padrão AAA:

- **Arrange**: Preparação dos dados de teste
- **Act**: Execução da ação
- **Assert**: Validação dos resultados

### Exemplo

```csharp
[Fact]
public async Task GetMembersAsync_Should_Return_All_Members()
{
    // Arrange
    var members = new List<Member> { ... };
    _memberRepositoryMock.Setup(r => r.GetAllAsync())
        .ReturnsAsync(members);

    // Act
    var result = await _memberService.GetMembersAsync();

    // Assert
    result.Should().HaveCount(2);
}
```

## Cobertura de Testes

A suíte de testes cobre:

- ✅ Happy paths (cenários de sucesso)
- ✅ Validações de erro (campos inválidos)
- ✅ Autenticação e autorização
- ✅ Endpoints da API
- ✅ Serviços de aplicação
- ✅ Mapeamento de DTOs
- ✅ Tratamento de exceções
- ✅ Status HTTP

## Boas Práticas

1. **Nomenclatura**: Os testes seguem o padrão `Método_Cenário_ComportamentoEsperado`
2. **Isolamento**: Cada teste é independente e pode ser executado isoladamente
3. **Velocidade**: Testes unitários usam mocks para evitar I/O
4. **Clareza**: Código de teste é claro e legível
5. **Manutenibilidade**: Uso de fixtures para compartilhar contexto

## Próximas Melhorias

- [ ] Testes de performance
- [ ] Testes de segurança
- [ ] Testes de banco de dados com TestContainers
- [ ] Testes E2E com Selenium
- [ ] CI/CD com GitHub Actions

## Contribuindo

Ao adicionar novos testes:

1. Siga o padrão AAA
2. Use nomenclatura clara
3. Adicione comentários quando necessário
4. Garanta que os testes são independentes
5. Mantenha a cobertura de testes acima de 80%
