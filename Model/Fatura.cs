using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Fatura
    {
        public List<Lancamento> Lancamentos { get; set; }

        public Fatura()
        {
            Lancamentos = new List<Lancamento>();
        }
    }
}
