using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    class Util
    {
    }

    public class NubankConverter
    {
        public static int defineParcela(string descricao)
        {
            try
            {
                int.TryParse(descricao.Substring(descricao.LastIndexOf(' '), descricao.LastIndexOf('/') - descricao.LastIndexOf(' ')), out int parcela);
                return parcela;
            }
            catch
            { return 0; }
        }

        public static int defineNumParcelas(string descricao)
        {
            try
            {
                int.TryParse(descricao.Substring(descricao.LastIndexOf('/') + 1), out int numParcelas);
                return numParcelas;
            }
            catch (Exception)
            { return 0; }

        }

        public static string defineDescricao(string descricao)
        {
            try
            {
                return !descricao.IndexOf('/').Equals(-1)
                    ? descricao.Substring(0, descricao.LastIndexOf(' '))
                    : descricao;
            }
            catch (IndexOutOfRangeException)
            {
                return descricao;
            }
            catch
            {
                return string.Empty;
            }
        }
    }

    /// <summary>
    /// Classe customizada para lançamento de exceções.
    /// </summary>
    public class BusinessException : Exception
    {
        public BusinessException(string mensagem) : base(mensagem) { }
    }
}
