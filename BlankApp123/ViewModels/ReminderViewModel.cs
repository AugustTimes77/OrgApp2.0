using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlankApp123.Models;

namespace BlankApp123.ViewModels
{
    public class ReminderViewModel : BindableBase
    {
        private ReminderBook ReminderBook;
        private string context;
        private DateTime dueDate;

        public string Context
        {
            get { return context; }
            set { SetProperty(ref context, value); }
        }
        public DateTime DueDate
        {
            get { return dueDate; }
            set { SetProperty(ref dueDate, value); }
        }

        
    }
}
