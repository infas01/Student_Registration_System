using SRS.Models;
using SRS.Pages;
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
    /// Interaction logic for AdminDetailsWindow.xaml
    /// </summary>
    public partial class AdminDetailsWindow : Window
    {
        public AdminDetailsWindow()
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

        private bool IsMaximize = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximize)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    IsMaximize = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

                    IsMaximize = true;
                }
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            userCRUD.Content = new createUser();
            //this.wlcmtext.Visibility = Visibility.Collapsed;
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            //this.wlcmtext.Visibility = Visibility.Collapsed;
            userCRUD.Content = new readUser();
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            userCRUD.Content = new updateUser();
            //this.wlcmtext.Visibility = Visibility.Collapsed;
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            userCRUD.Content = new deleteUser();
            //this.wlcmtext.Visibility = Visibility.Collapsed;
           
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            var adminloginWV = new AdminLoginWindowView();
            adminloginWV.Show();
           
        }

    }

    public class Member
    {
        /*
        public string Character { get; set; }
        public Brush BgColor { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        */
    }

}
