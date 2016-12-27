using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguro.Viagem.Srv.DataTransferObject
{
    public class Traveler
    {
        /// <summary>
        /// Nome completo do viajante
        /// </summary>
        public string nome_completo { get; set; }

        /// <summary>
        /// CPF válido do viajante ou responsável pelo mesmo se for menor de idade. Informar apenas números.
        /// </summary>
        public string passaporte_cpf { get; set; }

        /// <summary>
        /// dia
        /// </summary>
        public string dia { get; set; }

        /// <summary>
        /// mes
        /// </summary>
        public string mes { get; set; }

        /// <summary>
        /// ano
        /// </summary>
        public string ano { get; set; }

    }
}

