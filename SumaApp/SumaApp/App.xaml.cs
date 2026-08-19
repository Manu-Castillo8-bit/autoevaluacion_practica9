using Microsoft.Extensions.DependencyInjection;

namespace SumaApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new Resta_de_edades();
        }

        
    }
}