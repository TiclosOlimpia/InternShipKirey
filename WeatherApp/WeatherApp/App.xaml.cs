
using System.Windows;
using WeatherApp.DI;
using WeatherApp.Services.Implementations;
using WeatherApp.Services.Interfaces;
using WeatherApp.Views;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DependencyInjector.Register<IWeatherService, WeatherServiceTest>();
            MainWindow = DependencyInjector.Retrieve<MainWindow>();
            MainWindow.Show();
        }
    }
}
