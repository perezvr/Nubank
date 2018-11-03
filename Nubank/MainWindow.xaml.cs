using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Linq;

namespace Nubank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Fatura fatura;
        public MainWindow()
        {
            InitializeComponent();

            var caminho = @"C:\Users\Renox\Downloads\nubank-2018-07.csv";
            var fc = new FaturaController();

            fatura = fc.GerarFatura(caminho);
            var x = fatura.Lancamentos.Sum(y => y.Valor);

        
            fc.Save(fatura);
            AtualizaListaDeLancamentos();


        }

        private void AtualizaListaDeLancamentos()
        {
            gridProdutos.ItemsSource = fatura.Lancamentos;
        }


    }
}
