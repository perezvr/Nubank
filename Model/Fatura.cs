using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("Fatura")]
    public class Fatura
    {
        [Key]
        public int Id { get; set; }

        public List<Lancamento> Lancamentos { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public Fatura()
        {
            Lancamentos = new List<Lancamento>();
        }
    }
}
