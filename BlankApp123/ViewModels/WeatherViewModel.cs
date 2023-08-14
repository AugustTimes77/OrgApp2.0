using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlankApp123.Models;
using System.Windows;

namespace BlankApp123.ViewModels
{
    public class WeatherViewModel : BindableBase
    {
        private string maxTemp;
        private string minTemp;
        private string tempsToDisplay;
        private string codeDisplay;
        

        public string MaxTemp
        {
            get { return maxTemp; }
            set { SetProperty(ref maxTemp, value); }
        }
        public string MinTemp
        {
            get { return minTemp; }
            set { SetProperty(ref minTemp, value); }
        }

        public string TempsToDisplay
        {
            get { return tempsToDisplay; }
            set { SetProperty(ref tempsToDisplay, value); }
        }
        public string CodeDisplay
        {
            get { return codeDisplay; }
            set { SetProperty(ref codeDisplay, value); }
        }



        private WeatherAPIService weatherAPIService;

        public WeatherViewModel(WeatherAPIService weatherAPIService)
        {
            this.weatherAPIService = weatherAPIService;
        }

        public async Task LoadWeatherData()
        {
            WeatherData data = await weatherAPIService.GetWeatherDataAsync();

            if(data == null)
            {
                TempsToDisplay = "Temps: N/A";
                CodeDisplay = "N/A";
                MaxTemp = "H: N/A";
                MinTemp = "L: N/A";
            }
            else
            {
                MaxTemp = "H:" + data.MaxTemp;
                MinTemp = "L:" + data.MinTemp;
                TempsToDisplay = "H:" + data.MaxTemp + "° L:" + data.MinTemp + "°";
                CodeDisplay = weatherAPIService.GetWeatherForDay(data.CodeWeather);
            }
            
        }
    }
}
