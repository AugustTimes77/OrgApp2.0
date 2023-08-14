using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlankApp123.Models
{
    public class JsonDataService
    {

        public static void SaveNotesJsonData(string textBox1, string textBox2)
        {
            string filePath = "C:\\Programming\\C++\\Personal Projects\\BlankApp123\\BlankApp123\\Resources\\NotesText.json";

            Note note = new Note
            {
                Tab = 1,
                Text = textBox1,
            };
            Note note2 = new Note
            {
                Tab = 2,
                Text = textBox2,
            };

            NotesData notesData = new NotesData
            {
                Notes = new List<Note> { note, note2 }
            };

            string jsonNoteSaveData = JsonConvert.SerializeObject(notesData, Formatting.Indented);

            File.WriteAllText(filePath, jsonNoteSaveData);
        }

        public static NotesData GetNotesDataFromJsonFile(string filePath)
        {
            try
            {
                string jsonNoteData = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<NotesData>(jsonNoteData);
            }
            catch (Exception ex)
            {
                return default;
            }
        }
        

        public static QuotesData GetQuotesDataFromJsonFile(string filePath)
        {
            try
            {
                string jsonData = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<QuotesData>(jsonData);
            }
            catch (Exception ex)
            {
                return default;
            }
        }
    }
}
