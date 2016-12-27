using Seguro.Viagem.Srv.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguro.Viagem.Srv.DataTransferObject
{
    public class Travel
    {
        /// <summary>
        /// País ou continente destino.
        /// </summary>
        public Destiny destino { get; set; }

        /// <summary>
        /// Data de início da viagem. 
        /// </summary>
        public string partida { get; set; }

        /// <summary>
        /// Data de fim da viagem - quando os passageiros estarão na cidade de origem. 
        /// </summary>
        public string retorno { get; set; }
    }
}
