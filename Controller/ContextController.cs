using ArmazemModel.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ContextController
    {
        public static void CreateDatabase()
        {
            try
            {
                NubankContext context = new NubankContext();
                context.Database.CreateIfNotExists();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
