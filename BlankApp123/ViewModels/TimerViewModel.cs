using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;

namespace BlankApp123.ViewModels
{
    public class TimerViewModel : BindableBase
    {

        public DelegateCommand SubmitCommand { get; set; }

        public TimerViewModel()
        {
            SubmitCommand = new DelegateCommand(Submit);
        }

        void Submit()
        {
            MessageBox.Show("Button is working");
        }

        bool CanSubmit(object parameter)
        {
            return true;
        }

    }
}
