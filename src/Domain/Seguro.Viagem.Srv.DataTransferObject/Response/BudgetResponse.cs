using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguro.Viagem.Srv.DataTransferObject.Response
{
    public class BudgetResponse
    {
        #region Public Properties

        public string nome_plano { get; set; }
        public string tipo_de_seguro { get; set; }
        public string apelido { get; set; }
        public decimal preco_em_reais { get; set; }
        public string seguradora_logo { get; set; }
        public string seguradora_nome { get; set; }
        public string assistencia_logo { get; set; }
        public string assistencia_nome { get; set; }
        public int idade_minima { get; set; }
        public int idade_maxima { get; set; }

        public List<Properties> propriedades { get; set; }

        #endregion

    }
    
    public class Properties
    {
        public string grupo { get; set; }
        public string codigo { get; set; }
        public string nome { get; set; }
        public string modificador { get; set; }
        public decimal valor { get; set; }
    }
}
