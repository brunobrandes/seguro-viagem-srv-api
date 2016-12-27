using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguro.Viagem.Srv.DataTransferObject.Request
{
    public class InfoRequest
    {
        public Travel viagem { get; set; }
        public Client cliente { get; set; }

        public Product produto { get; set; }
        public Dictionary<int, Traveler> viajantes { get; set; }
    }
}
