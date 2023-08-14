using BlankApp123.Models;
using System;
using System.Media;
using System.Windows;
using System.Windows.Input;
using BlankApp123.ViewModels;

namespace BlankApp123.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Window_StartUpLocation();

            Closing += Window_Closing;
        }

        private void Window_StartUpLocation()
        {
            this.WindowStartupLocation = WindowStartupLocation.Manual;
            this.Top = SystemParameters.WorkArea.Top;
            this.Left = SystemParameters.WorkArea.Width - Width;

            this.Height = SystemParameters.WorkArea.Height;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Minimize_Window_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            string TextBox1Text = Tab1TextBox.Text;
            string TextBox2Text = Tab2TextBox.Text;


            JsonDataService.SaveNotesJsonData(TextBox1Text, TextBox2Text);
        }
    }
}
