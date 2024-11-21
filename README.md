
# **EnergySaverAPI**

### **Descrição do Projeto**

O **EnergySaverAPI** é uma API desenvolvida em **.NET Core** que visa colaborar para a **melhoria dos processos de energia sustentável**. A solução é projetada para gerenciar **postes**, **sensores** e **históricos de consumo de energia**, seguindo os princípios de arquitetura de software, como **modularidade**, **escalabilidade** e **separação de responsabilidades**.

---

## **Recursos Principais**

- **Gerenciamento de Postes**: Criação, consulta, atualização e exclusão de postes.
- **Gerenciamento de Sensores**: Suporte a sensores conectados aos postes, registrando e monitorando atividades.
- **Histórico de Consumo**: Registro e consulta dos dados de consumo energético dos postes.
- **IA Generativa**: Implementação de recursos de **IA utilizando ML.NET** para análise e predição de consumo energético.
- **Documentação Automática**: Integração com **Swagger** para documentação de APIs.
- **Padrões de Design**: Implementação de **Repository**, **Factory** e **Dependency Injection**.

---

## **Equipe de Desenvolvimento**

- **552477** - Maria Eduarda Sousa De Oliveira  
- **550712** - Matheus Wasserman Fernandes Silva  
- **99396** - Guilherme Rocha Toledo dos Santos  
- **552522** - Isadora Tatajuba Moreira Pinto  
- **551496** - Gustavo Nunes Pereira  

---

## **Instalação**

### **Pré-requisitos**

- **.NET 8.0 SDK**
- **Banco de Dados Oracle** configurado
- **Git** para controle de versão

### **Passos para Configuração**

1. **Clone este repositório**:

   ```
   git clone https://github.com/Wasserman97/EnergySaverAPI.git
   cd EnergySaverAPI
   ```

2. **Configure as variáveis de conexão** no arquivo `appsettings.json`:

   ```
   {
     "ConnectionStrings": {
       "DefaultConnection": "User Id=EnergySaverDB;Password=240497;Data Source=YOUR_ORACLE_DB_SOURCE"
     }
   }
   ```

3. **Restaure as dependências**:

   ```
   dotnet restore
   ```

4. **Aplique as migrações do banco de dados**:

   ```
   dotnet ef database update
   ```

5. **Execute a aplicação**:

   ```
   dotnet run
   ```

6. **Acesse o Swagger** para explorar as APIs:

   - URL local: [https://localhost:7029/swagger/index.html](https://localhost:7029/swagger/index.html)

---

## **Funcionalidades**

### **Endpoints Principais**

#### **Postes**
- **GET** `/api/Postes` - Lista todos os postes  
- **GET** `/api/Postes/{id}` - Consulta um poste específico  
- **POST** `/api/Postes` - Cria um novo poste  
- **PUT** `/api/Postes/{id}` - Atualiza informações de um poste  
- **DELETE** `/api/Postes/{id}` - Remove um poste  

#### **Sensores**
- **GET** `/api/Sensores` - Lista todos os sensores  
- **GET** `/api/Sensores/{id}` - Consulta um sensor específico  
- **POST** `/api/Sensores` - Cria um novo sensor  
- **PUT** `/api/Sensores/{id}` - Atualiza informações de um sensor  
- **DELETE** `/api/Sensores/{id}` - Remove um sensor  

#### **Consumo Histórico**
- **GET** `/api/ConsumoHistorico` - Lista todos os históricos de consumo  
- **GET** `/api/ConsumoHistorico/{id}` - Consulta um histórico específico  
- **GET** `/api/ConsumoHistorico/Poste/{posteId}` - Lista consumos por poste  
- **POST** `/api/ConsumoHistorico` - Registra um novo histórico de consumo  

---

## **Tecnologias Utilizadas**

- **.NET 8.0**  
- **Entity Framework Core**  
- **Oracle Database**  
- **ML.NET** para predição de consumo  
- **Swagger** para documentação  
- **xUnit + Moq** para testes unitários  

---

## **Estrutura do Projeto**

```
EnergySaverAPI/
├── Application/
│   ├── Interfaces/        # Contratos de serviço e repositórios
│   ├── Services/          # Implementação de serviços
│   └── Factories/         # Implementação de padrões de fábrica
├── Domain/
│   ├── Entities/          # Entidades principais do domínio
├── Infrastructure/
│   ├── Persistence/       # DbContext e repositórios
├── Presentation/
│   ├── Controllers/       # Endpoints da API
├── Properties/            # Configurações de lançamento
├── appsettings.json       # Configurações do projeto
├── Program.cs             # Configuração inicial do projeto
└── EnergySaverAPI.sln     # Solução do projeto
```

---

## **Testes Automatizados**

- Cobertura de testes para serviços usando **xUnit** e **Moq**.
- Comando para executar os testes:

   ```
   dotnet test
   ```

---

## **Contribuição**

Contribuições são **bem-vindas**! Por favor, siga as diretrizes de contribuição descritas no repositório.

---

## **Licença**

Este projeto está licenciado sob os termos da **MIT License**.

--- 

