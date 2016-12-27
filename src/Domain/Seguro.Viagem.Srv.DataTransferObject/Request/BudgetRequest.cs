using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguro.Viagem.Srv.DataTransferObject.Request
{
    public class BudgetRequest
    {
        public Travel viagem { get; set; }
        public Client cliente { get; set; }
        public string lead_tag { get; set; }
    }
}
