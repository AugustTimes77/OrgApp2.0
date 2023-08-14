using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.IO;

namespace BlankApp123.Models
{
    public class WeatherAPIService
    {

        public async Task<WeatherData> GetWeatherDataAsync()
        {

            using (HttpClient client = new HttpClient())
            {
                string API_key = File.ReadAllText(Path.Combine("C:/Programming/C++/Personal Projects/API_KEYSTUFF", "BlankApp123API.txt"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync(API_key);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();

                        var data = JsonConvert.DeserializeObject<RootObject>(json);

                        double maxTemp = data.daily.temperature_2m_max[0];
                        double minTemp = data.daily.temperature_2m_min[0];

                        double forecastNum = data.daily.weathercode[0];


                        WeatherData weatherData = new WeatherData
                        {
                            MaxTemp = Convert.ToString(maxTemp),
                            MinTemp = Convert.ToString(minTemp),
                            CodeWeather = Convert.ToInt32(forecastNum)
                        };
                        return weatherData;
                    }
                    else
                    {
                        return null;
                    }
                }

                catch (HttpRequestException ex)
                {
                    return null;
                }

                catch (Exception ex)
                {
                    return null;
                }



            }


        }

        public class RootObject
        {
            public Daily daily { get; set; }
            //public Hourly hourly { get; set; }
        }

        public class Daily
        {
            public double[] temperature_2m_max { get; set; }
            public double[] temperature_2m_min { get; set; }
            public double[] weathercode { get; set; }
        }
        //public class Hourly
        //{
        //    public double[] weathercode { get; set; }
        //}

        public string GetWeatherForDay(int numCode)
        {
            string toReturn;
            switch (numCode)
            {
                case 0:
                    toReturn = "Clear Skies";
                    break;
                case 1:
                    toReturn = "Mainly Clear";
                    break;
                case 2:
                    toReturn = "Partly Cloudy";
                    break;
                case 3:
                    toReturn = "Overcast";
                    break;
                case 45:
                case 48:
                    toReturn = "Fog";
                    break;
                case 51:
                case 53:
                case 55:
                case 56:
                case 57:
                    toReturn = "Drizzle";
                    break;
                case 61:
                case 63:
                case 65:
                case 66:
                case 67:
                    toReturn = "Rain";
                    break;
                case 71:
                case 73:
                case 75:
                case 77:
                    toReturn = "Snow";
                    break;
                case 80:
                case 81:
                case 82:
                    toReturn = "Rain Showers";
                    break;
                case 85:
                case 86:
                    toReturn = "Snow Showers";
                    break;
                case 95:
                    toReturn = "Thunderstorms";
                    break;
                case 96:
                case 99:
                    toReturn = "Thunderstorm w/ hail";
                    break;
                default:
                    toReturn = "N/A";
                    break;
            }

            return toReturn;
        }
    }

    public class WeatherData
    {
        public string MaxTemp { get; set; }
        public string MinTemp { get; set; }
        public int CodeWeather { get; set; }
    }
}
