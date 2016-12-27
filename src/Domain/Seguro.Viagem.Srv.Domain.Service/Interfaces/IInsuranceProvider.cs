using Seguro.Viagem.Srv.DataTransferObject.Request;
using Seguro.Viagem.Srv.DataTransferObject.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Seguro.Viagem.Srv.Domain.Service.Interfaces
{
    public interface IInsuranceProvider
    {
        void Initializer(string apiUrl, string apiKey);

        Task<List<BudgetResponse>> CreateBudgetAsync(BudgetRequest request);

        Task<InfoResponse> InfoProductTravelers(InfoRequest request);
    }
}
