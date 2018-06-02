using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Lancamento
    {
        public DateTime Data { get; set; }
        public string Categoria { get; set; }
        public string Descricao { get; set; }
        public int Parcela { get; set; }
        public int NumParcelas { get; set; }
        public decimal Valor { get; set; }
    }
}
