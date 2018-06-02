using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("Lancamento")]
    public class Lancamento
    {
        [Key]
        public int Id { get; set; }

        public DateTime Data { get; set; }
        public string Categoria { get; set; }
        public string Descricao { get; set; }
        public int Parcela { get; set; }
        public int NumParcelas { get; set; }
        public decimal Valor { get; set; }

        [ForeignKey("Fatura_Id")]
        public virtual Fatura Fatura { get; set; }
    }
}
