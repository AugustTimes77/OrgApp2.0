using Prism.Mvvm;
using BlankApp123.Models;
using System;
using System.IO;
using System.Windows;

namespace BlankApp123.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        private string _todaysDate = DateTime.Now.ToShortDateString();
        public string TodaysDate { get { return _todaysDate; } }

        private WeatherViewModel weatherViewModel;
        public WeatherViewModel WeatherViewModel
        {
            get { return weatherViewModel; }
            set { SetProperty(ref weatherViewModel, value); }
        }

        private QuotesViewModel quotesViewModel;
        public QuotesViewModel QuotesViewModel
        {
            get { return quotesViewModel; }
            set { SetProperty(ref quotesViewModel, value); }
        }

        private ReminderViewModel reminderViewModel;
        public ReminderViewModel ReminderViewModel
        {
            get { return reminderViewModel; }
            set { SetProperty(ref reminderViewModel, value); }
        }

        private NotesViewModel notesViewModel;
        public NotesViewModel NotesViewModel
        {
            get { return notesViewModel; }
            set { SetProperty(ref notesViewModel, value); }
        }

        private TimerViewModel timerViewModel;
        public TimerViewModel TimerViewModel
        {
            get { return timerViewModel; }
            set { SetProperty(ref timerViewModel, value); }
        }


        

        public MainWindowViewModel()
        {
            WeatherAPIService weatherAPIService = new WeatherAPIService();
            WeatherViewModel = new WeatherViewModel(weatherAPIService);

            QuotesViewModel = new QuotesViewModel();

            ReminderViewModel = new ReminderViewModel();

            NotesViewModel = new NotesViewModel();

            TimerViewModel = new TimerViewModel();

            Initialize();
        }

        private async void Initialize()
        {
            await WeatherViewModel.LoadWeatherData();
            QuotesViewModel.LoadQuotesData();
            NotesViewModel.LoadNotesData();

        }



    }
}
