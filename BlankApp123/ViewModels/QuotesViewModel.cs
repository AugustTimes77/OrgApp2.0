using BlankApp123.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Mvvm;
using Newtonsoft.Json;

namespace BlankApp123.ViewModels
{
    public class QuotesViewModel : BindableBase
    {
        private string _quote;
        private string _author;

        public string Quote
        {
            get { return _quote; }
            set { SetProperty(ref _quote, value); }
        }
        public string Author
        {
            get { return _author; }
            set { SetProperty(ref _author, value); }
        }


        public void LoadQuotesData()
        {
            string filePath = "C:\\Programming\\C++\\Personal Projects\\BlankApp123\\BlankApp123\\Resources\\Quotes.json";
            var quoteData = JsonDataService.GetQuotesDataFromJsonFile(filePath);

            if(quoteData != null )
            {
                int QuotesLength = quoteData.Quotes.Count();
                Random random = new Random();
                int randomNumber = random.Next(0, QuotesLength);


                var quote = quoteData.Quotes[randomNumber];

                Quote = quote.Quote;
                Author = "-" + quote.Author;
            }
        }

    }
}
