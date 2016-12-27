using Seguro.Viagem.Srv.Domain.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguro.Viagem.Srv.Domain.Service.Factories
{
    public interface IInsuranceProviderFactory
    {
        IInsuranceProvider Create(string apiUrl, string apiKey);
    }

    public class InsuranceProviderFactory : IInsuranceProviderFactory
    {
        #region Private Fields

        private readonly IServiceProvider _serviceProvider;

        #endregion

        #region Constructor

        public InsuranceProviderFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        #endregion

        #region IInsuranceProviderFactory Members

        public IInsuranceProvider Create(string apiUrl, string apiKey)
        {
            var result = _serviceProvider.GetService(typeof(RealSeguroProvider)) as IInsuranceProvider;

            if (result == null)
            {
                throw new Exception("Get service error - Create insurance provider return null or empty.");
            }

            result.Initializer(apiUrl, apiKey);

            return result;
        }

        #endregion
    }
}
