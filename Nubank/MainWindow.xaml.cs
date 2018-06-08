using Controller;
using Model;
using System;
using System.IO;
using System.Windows;

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

            var caminho = @"C:\Users\Renox\Downloads\nubank-2018-06.csv";
            var fc = new FaturaController();

            var fatura = fc.GerarFatura(caminho);
        }

 

    }
}
