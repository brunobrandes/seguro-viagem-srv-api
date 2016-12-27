using Seguro.Viagem.Srv.Domain.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Seguro.Viagem.Srv.DataTransferObject.Request;
using Seguro.Viagem.Srv.DataTransferObject.Response;
using Seguro.Viagem.Srv.Domain.Service.Serializer;

namespace Seguro.Viagem.Srv.Domain.Service
{
    public class RealSeguroProvider : IInsuranceProvider
    {
        #region Private Fields
        
        private string _apiUrl;
        private string _apiKey;

        #endregion

        #region Constructor

        public RealSeguroProvider()
        {
            
        }

        #endregion

        #region Private Methods

        private async Task<string> GetHttpResponseMessageContent(HttpResponseMessage httpResponseMessage)
        {
            if (httpResponseMessage != null)
            {
                if (httpResponseMessage.Content != null)
                {
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        var content = await httpResponseMessage.Content.ReadAsStringAsync();

                        if (string.IsNullOrEmpty(content))
                        {
                            throw new Exception("Unexpected get http response message content async - http response message content is empty.");
                        }

                        return content;
                    }
                    else
                    {
                        throw new Exception($"Unexpected get http response message content async - http response status code '{httpResponseMessage.StatusCode}'");
                    }
                }
                else
                {
                    throw new Exception("Unexpected get http response message content async- http response message content is null.");
                }
            }
            else
            {
                throw new Exception("Unexpected get http response message content async - http response message is null.");
            }
        }

        #endregion

        #region IInsuranceProvider Members

        public async Task<List<BudgetResponse>> CreateBudgetAsync(BudgetRequest request)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Token token={_apiKey}");

                var budgetRequestJson = SrvJson<BudgetRequest>.Serialize(request);

                var httpResponseMessage = await httpClient.PostAsync(new Uri($"{_apiUrl}/selecionar.json"),
                    new StringContent(budgetRequestJson, Encoding.UTF8, "application/json"));

                var budgetResponseJson = await GetHttpResponseMessageContent(httpResponseMessage);

                return SrvJson<List<BudgetResponse>>.Deserialize(budgetResponseJson);
            }
        }

        public async Task<InfoResponse> InfoProductTravelers(InfoRequest request)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Token token={_apiKey}");

                var infoRequestJson = SrvJson<InfoRequest>.Serialize(request);

                var httpResponseMessage = await httpClient.PostAsync(new Uri($"{_apiUrl}/pagar.json"),
                    new StringContent(infoRequestJson, Encoding.UTF8, "application/json"));

                var infoResponseJson = await GetHttpResponseMessageContent(httpResponseMessage);

                return SrvJson<InfoResponse>.Deserialize(infoResponseJson);
            }
        }

        public void Initializer(string apiUrl, string apiKey)
        {
            _apiUrl = apiUrl;
            _apiKey = apiKey;
        }

        #endregion
    }
}
