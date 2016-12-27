using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguro.Viagem.Srv.DataTransferObject
{
    public class Client
    {
        /// <summary>
        /// Nome completo do cliente
        /// </summary>
        public string nome { get; set; }

        /// <summary>
        /// Telefone (preferencialmente celular) do cliente. 
        /// </summary>
        public string telefone { get; set; }

        /// <summary>
        /// E-mail válido do cliente. 
        /// </summary>
        public string email { get; set; }
    }
}
