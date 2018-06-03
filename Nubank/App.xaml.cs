using Controller;
using System.Windows;

namespace Nubank
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ContextController.CreateDatabase();
        }
    }
}
