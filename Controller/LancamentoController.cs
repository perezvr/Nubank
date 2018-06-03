using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class LancamentoController
    {
        LancamentoDAL lancamentoDAL = null;

        public LancamentoController()
        {
            lancamentoDAL = new LancamentoDAL();
        }

        public void Save(Lancamento lancamento)
        {
            try
            {
                if (lancamentoDAL.FindById(lancamento.Id) == null)
                    lancamentoDAL.Add(lancamento);
                else
                    lancamentoDAL.Update(lancamento);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
