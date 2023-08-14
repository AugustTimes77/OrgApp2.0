using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace BlankApp123.Models
{

    public class QuotesData
    {
        public List<Quotes> Quotes { get; set; }
    }

    public class Quotes
    {
        public string Quote { get; set; }
        public string Author { get; set; }
    }



}
