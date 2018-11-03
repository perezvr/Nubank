using DAL;
using Model;
using System;
using System.IO;
using System.Linq;

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
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Gera uma fatura a partir de um arquivo .csv válido
        /// </summary>
        /// <param name="Caminho">Caminho do arquivo .csv</param>
        public Fatura GerarFatura(string caminho)
        {
            try
            {
                Fatura fatura = new Fatura();
                caminho = Path.GetFullPath(caminho);

                if (!File.Exists(caminho))
                    throw new BusinessException("Não foi possível encontrar o arquivo. Verifique o caminho.");

                using (var reader = new StreamReader(Path.GetFullPath(caminho)))
                {
                    Lancamento lancamento;

                    fatura.DataInicial = DateTime.Parse("2018-05-01");
                    fatura.DataFinal = DateTime.Parse("2018-05-30");
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        var descricao = values[2];

                        int parcela = NubankConverter.defineParcela(descricao);
                        int numParcelas = NubankConverter.defineNumParcelas(descricao);

                        lancamento = new Lancamento()
                        {
                            Data = DateTime.Parse(values[0]),
                            Categoria = values[1],
                            Descricao = NubankConverter.defineDescricao(descricao),
                            Parcela = parcela,
                            NumParcelas = numParcelas,
                            Valor = decimal.Parse(values[3].Replace('.', ',')),
                            Fatura = fatura,
                            Responsavel = new Responsavel() { Id = 1, }
                        };

                        fatura.Lancamentos.Add(lancamento);

                    }
                }

                return fatura;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
