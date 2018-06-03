using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class FaturaController
    {
        FaturaDAL faturaDAL = null;

        public FaturaController()
        {
            faturaDAL = new FaturaDAL();
        }

        public void Save(Fatura Fatura)
        {
            try
            {
                if (faturaDAL.FindById(Fatura.Id) == null)
                    faturaDAL.Add(Fatura);
                else
                    faturaDAL.Update(Fatura);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
