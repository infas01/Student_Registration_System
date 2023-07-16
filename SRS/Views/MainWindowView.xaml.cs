using SRS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SRS.Views
{
    /// <summary>
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            DataContext = new ViewModel();
            InitializeComponent();
        }

        private void Move_Window(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void adminLogin_Click(object sender, RoutedEventArgs e)
        {
            /*
            tbHello.Text = "Hiiii I am Button";
            tbHello.FontSize = 42;
            MessageBox.Show("Hello! I am the Button");
            */
            this.Hide();
            var adminloginWV = new AdminLoginWindowView();
            adminloginWV.Show();
        }

        private void studentLogin_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var userloginWV = new UserLoginWindowView();
            userloginWV.Show();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var StudentW = new StudentLogin();
            StudentW.Show();
        }
    }
}
