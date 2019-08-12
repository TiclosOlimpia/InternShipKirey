
using Kirey.Utils.Mvvm.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WeatherApp.Models;
using WeatherApp.Models.City;
using WeatherApp.Models.Forecast;
using WeatherApp.Services.Implementations;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Fields
        private readonly IWeatherService _weatherService;

        public string Title;

        #endregion


        #region Property Changed Area
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        #endregion

        #region Properties and Fields
        private bool showForecast;

        public bool ShowForecast
        {
            get { return showForecast; }
            set { showForecast = value; OnPropertyChanged("ShowForecast"); }
        }

        private string cityInput;

        public string CityInput
        {
            get { return cityInput; }
            set { cityInput = value; OnPropertyChanged("CityInput"); GetCities(value); }
        }

        private City selectedCity;

        public City SelectedCity
        {
            get { return selectedCity; }
            set { selectedCity = value; OnPropertyChanged(nameof(SelectedCity)); }
        }

        private ObservableCollection<City> cities;

        public ObservableCollection<City> Cities
        {
            get { return cities; }
            set { cities = value; OnPropertyChanged(nameof(Cities)); }
        }

        private ObservableCollection<Forecast> forecasts;

        public ObservableCollection<Forecast> Forecasts
        {
            get { return forecasts; }
            set { forecasts = value; OnPropertyChanged(nameof(Forecasts)); }
        }

        #endregion

        #region Implementation

        public async void GetCities(object param)
        {

            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                Cities = new ObservableCollection<City>
                {
                    new City{Version=2, AdministrativeArea = new Area {ID= "123", LocalizedName="Iasi"}, Country = new Area {ID= "233", LocalizedName="Romania"}, Key= "287994", LocalizedName="Iasi"}
                };
            }
            else
            {

                if (string.IsNullOrWhiteSpace(CityInput))
                    return;

                var cities = await _weatherService.SearchCitiesAsync(CityInput);
                Cities?.Clear();
                foreach (var item in cities)
                    Cities.Add(item);

                ShowForecast = Cities?.Count > 0 ? true : false;
            }
        }

        public async Task GetForecasts()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                Forecasts = new ObservableCollection<Forecast>();
            }
            else
            {
                var forecasts = await _weatherService.GetForecastsAsync(SelectedCity.Key);
                Forecasts = new ObservableCollection<Forecast>(forecasts);
            }

        }

        #endregion

        #region Constructor

        public MainViewModel()
        {
            Cities = new ObservableCollection<City>();
            Forecasts = new ObservableCollection<Forecast>();

            SearchCityCommand = new DelegateCommand(GetCities, o => true);
            //GetForecastCommand = new DelegateCommand(o => GetForecasts(), o => true);
            GetForecastCommand = new DelegateCommand<string>(async (s) => { await GetForecasts(); }, //execute
                (s) => { return !string.IsNullOrEmpty(SelectedCity?.Key); });//can execute

            PropertyChanged += OnPropertyChanged;


            // in design time

            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                Forecasts = new ObservableCollection<Forecast>()
                {
                    new Forecast()
                    {
                        Date = DateTime.Now.AddDays(1),
                        Temperature = new Temperature()
                        {
                            Minimum = new Range{Value = 23, Unit= "C", UnitType=1},
                            Maximum = new Range{Value = 33, Unit= "C", UnitType=1}
                        }
                    },
                };
            }
        }

        public MainViewModel(IWeatherService weatherService) : this()
        {
            this._weatherService = weatherService;
        }
        #endregion

        public ICommand SearchCityCommand { get; set; }

        public DelegateCommand GetForecastCommand { get; set; }

        public void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            GetForecastCommand.OnCanExecuteChanged();
        }

    }
}
