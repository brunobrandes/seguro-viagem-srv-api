using Seguro.Viagem.Srv.DataTransferObject;
using Seguro.Viagem.Srv.DataTransferObject.Request;
using Seguro.Viagem.Srv.DataTransferObject.Response;
using Seguro.Viagem.Srv.Domain.Enum;
using Seguro.Viagem.Srv.Domain.Service.Factories;
using Seguro.Viagem.Srv.Domain.Service.Serializer;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguro.Viagem.Srv.Example.ConsoleApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();

            container.RegisterSingleton<IServiceProvider>(container);
            container.RegisterSingleton<IInsuranceProviderFactory, InsuranceProviderFactory>();

            var insuranceProviderFactory = container.GetInstance<IInsuranceProviderFactory>();

            var budgetRequest = GetBudgetRequest();

            var insuranceProvider = insuranceProviderFactory.Create("https://www.seguroviagem.srv.br/seguro-viagem",
                "YOUR_TOKEN");

            var budgetResponse = insuranceProvider.CreateBudgetAsync(budgetRequest).Result;

            var jsonBudgetResponse = SrvJson<List<BudgetResponse>>.Serialize(budgetResponse);

            var infoRequest = GetInfoRequest(budgetRequest.viagem, budgetRequest.cliente);

            var infoResponse = insuranceProvider.InfoProductTravelers(infoRequest).Result;

            var jsonInfoResponse = SrvJson<InfoResponse>.Serialize(infoResponse);

            System.Console.Write($"Url para pagamento: {infoResponse.url}");
        }

        #region Private Methods

        private static BudgetRequest GetBudgetRequest()
        {
            return new BudgetRequest
            {
                viagem = new Travel { destino = Destiny.Brazil, partida = "15/01/2017", retorno = "25/01/2017" },
                cliente = new Client { nome = "Test", telefone = "(11) 55551234", email = "fulano@real-compare.com" },
                lead_tag = "tag-123456"
            };
        }

        private static InfoRequest GetInfoRequest(Travel viagem, Client cliente)
        {
            var infoRequest = new InfoRequest
            {
                viagem = viagem,
                cliente = cliente,
                produto = new Product { apelido = "vital-card_brasil_MTc2IDEyMzYxNzM1NzguMA" },
                viajantes = new Dictionary<int, Traveler>()
            };

            infoRequest.viajantes.Add(0, new Traveler { nome_completo = "Viajante 1", passaporte_cpf = "51315227819", dia = "12", mes = "11", ano = "2002" });

            return infoRequest;

        }

        #endregion
    }
}
