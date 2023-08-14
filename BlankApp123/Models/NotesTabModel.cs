using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankApp123.Models
{

    public class NotesData
    {
        public List<Note> Notes { get; set; }
    }

    public class Note
    {
        public int Tab { get; set; }
        public string Text { get; set; }
    }

}
