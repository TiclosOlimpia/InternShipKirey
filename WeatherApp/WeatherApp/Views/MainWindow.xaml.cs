using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using WeatherApp.ViewModels;

namespace WeatherApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [Dependency]
        public MainViewModel ViewModel
        {
            set => DataContext = value;
        }
        public MainWindow()
        {
            InitializeComponent();

            Title = "Weather app";
        }
    }
}
