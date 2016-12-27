# C# Real Seguro Viagem

A C# wrapper for the [seguroviagem.srv.br](https://www.seguroviagem.srv.br/).</br>

## Installation

To install Seguro.Viagem.Srv.Api, run the following command in the [Package Manager Console](https://docs.nuget.org/consume/package-manager-console)
>PM> Install-Package Seguro.Viagem.Srv.Api

### Begin

"Real Seguro Viagem has developed a practical way for you to create websites, applications and integrations with other systems allowing you to
register new budgets and inform travelers and the chosen plan."</br>

To begin, you need to have an [seguroviagem.srv.br/afiliados](https://www.seguroviagem.srv.br/afiliados) account.

### Structure 

The solution structure (.sln) is based in [The Onion Architecture](http://bit.ly/1r54LZv)

[DataTranferObject (DTO)](https://en.wikipedia.org/wiki/Data_transfer_object) project, contains the call parameters used as either parameters in the URL or JSON keys in the POST body

* Budget
    * [BudgetRequest](http://bit.ly/2hrofIV)
    * [BudgetResponse](http://bit.ly/2hriifh)

* Info
	* [InfoRequest](http://bit.ly/2hnp186)
	* [InfoResponse](http://bit.ly/2i7Zkat)
		
[RealSeguroProvider](http://bit.ly/2ikiOZ0) class implements the application services.

### Usage

1. Using [Dependency Injection](https://en.wikipedia.org/wiki/Dependency_injection), the configuration of the application with [Simple Injector](https://simpleinjector.org/index.html) might look something like this:

  ```csharp
     var container = new Container();

     container.RegisterSingleton<IServiceProvider>(container);
     container.RegisterSingleton<IInsuranceProviderFactory, InsuranceProviderFactory>();
  ```

2. Get container InsuranceProvider app service factory 

  ```csharp
  var insuranceProviderFactory = container.GetInstance<IInsuranceProviderFactory>();
  ```

3. Create insurance provider  

  ```csharp
  var insuranceProvider = insuranceProviderFactory.Create("https://www.seguroviagem.srv.br/seguro-viagem",
    "YOUR_TOKEN");
  ```

4. Create budget request

  ```csharp
  var budgetRequest = new BudgetRequest
  {
    viagem = new Travel { destino = Destiny.Brazil, partida = "11/06/2016", retorno = "21/06/2016" },
    cliente = new Client { nome = "Test", telefone = "(11) 55551234", email = "fulano@real-compare.com" },
    lead_tag = "tag-123456"
  };
  ```

5. Create budget by http post method

  ```csharp
  var budgetResponse = await insuranceProvider.CreateBudgetAsync(budgetRequest);
  ```

  Use [SrvJson](http://bit.ly/2iwcoth) to Serialize/Deserialize response.

  ```csharp
  var json = SrvJson<List<BudgetResponse>>.Serialize(budgetResponse);
  ```

  json property value:

```json
  [
  {
    "nome_plano": "Brasil",
    "tipo_de_seguro": "padrao",
    "apelido": "vital-card_brasil_MTc2IDEyMzYxNzM1NzguMA",
    "preco_em_reais": 58.0,
    "seguradora_logo": "https://d2co66ly98117g.cloudfront.net/fornecedores/logo/31/preview/qbe.png",
    "seguradora_nome": "Qbe",
    "assistencia_logo": "https://d2co66ly98117g.cloudfront.net/fornecedores/logo/31/preview/vital-card-logo.png",
    "assistencia_nome": "Vital Card",
    "idade_minima": 0,
    "idade_maxima": 100,
    "propriedades": [
      {
        "valor": 0.0
      },
      {
        "valor": 0.0
      },
      {
        "valor": 0.0
      },
      {
        "valor": 0.0
      },
      {
        "grupo": "assistencia-medica",
        "codigo": "a-med-enf",
        "nome": "Assistência Médica Acidente e Doença (por evento)",
        "modificador": "BRL",
        "valor": 5000.0
      },...
```

6. Create info request

  ```csharp
  var infoRequest == new InfoRequest
  {
    viagem = budgetRequest.viagem,
    cliente = budgetRequest.cliente,
    produto = new Product { apelido = "vital-card_brasil_XXXXXXX" },
    viajantes = new Dictionary<int, Traveler>()
  };
  ```

7. Inform product and travelers by http post method

  ```csharp
  var infoResponse = insuranceProvider.InfoProductTravelers(infoRequest)
  ```
  
  ```csharp
  var json = SrvJson<InfoResponse>.Serialize(infoResponse);
  ```

  json property value:
  
  ```json
  {
    "url": "https://www.seguroviagem.srv.br/payment/xxxx/xxxxxx"
  }
  ```

[Download the examples](http://bit.ly/2i89esV) for test your application :) </br>

### TODO

- [ ] Write unit tests

### License

This software is open source, licensed under the Apache License. </br>
See [LICENSE.me](http://bit.ly/2i02fUJ) for details.
