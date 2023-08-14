using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlankApp123.Models;
using Newtonsoft.Json;
using Prism.Mvvm;

namespace BlankApp123.ViewModels
{
    public class NotesViewModel : BindableBase
    {
        private string _text1;
        private string _text2;

        public string Text1
        {
            get { return _text1; }
            set { SetProperty(ref _text1, value); }
        }
        public string Text2
        {
            get { return _text2; }
            set { SetProperty(ref _text2, value); }
        }

        public void LoadNotesData()
        {
            string filePath = "C:\\Programming\\C++\\Personal Projects\\BlankApp123\\BlankApp123\\Resources\\NotesText.json";
            var noteData = JsonDataService.GetNotesDataFromJsonFile(filePath);

            if (noteData != null )
            {
                var noteInfo1 = noteData.Notes[0];
                var noteInfo2 = noteData.Notes[1];

                Text1 = noteInfo1.Text;
                Text2 = noteInfo2.Text;
            }
        }

    }
}
