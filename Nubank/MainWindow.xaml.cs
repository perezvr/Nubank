using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nubank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Lancamento lancamento;
            Fatura fatura = new Fatura();

            try
            {
                using (var reader = new StreamReader(@"C:\Users\Renox\Downloads\nubank-2018-06.csv"))
                {
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        var descricao = values[2];

                        int parcela = defineParcela(descricao);
                        int numParcelas = defineNumParcelas(descricao);

                        lancamento = new Lancamento()
                        {
                            Data = DateTime.Parse(values[0]),
                            Categoria = values[1],
                            Descricao = defineDescricao(descricao),
                            Parcela = parcela,
                            NumParcelas = numParcelas,
                            Valor = decimal.Parse(values[3].Replace('.', ',')),
                            Fatura = fatura,
                        };

                        fatura.Lancamentos.Add(lancamento);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private int defineParcela(string descricao)
        {
            try
            {
                int.TryParse(descricao.Substring(descricao.LastIndexOf(' '), descricao.LastIndexOf('/') - descricao.LastIndexOf(' ')), out int parcela);
                return parcela;
            }
            catch
            { return 0; }
        }

        private int defineNumParcelas(string descricao)
        {
            try
            {
                int.TryParse(descricao.Substring(descricao.LastIndexOf('/') + 1), out int numParcelas);
                return numParcelas;
            }
            catch (Exception)
            { return 0; }

        }

        private string defineDescricao(string descricao)
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
}
