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
    /// Interaction logic for UserLoginWindowView.xaml
    /// </summary>
    public partial class UserLoginWindowView : Window
    {
        public UserLoginWindowView()
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

        //private void Login_Click(object sender, RoutedEventArgs e)
        //{

        //    using (var dbContext = new DatabaseContext())
        //    {
        //        var users = dbContext.Users.ToList();
        //        var students = dbContext.Students.ToList();

        //        bool userFound = false;
        //        bool studentFound = false;

        //        foreach (var user in users)
        //        {
        //            if (user.Username == typeUsername.Text && user.Password == typePassword.Password)
        //            {
        //                var uDW = new UserDetailsWindow();
        //                uDW.Show();
        //                //uDW.textUsername.Text = user.Username;
        //                this.Close();
        //                userFound = true;
        //                break; // Exit the loop after successful user login

        //            }
        //        }

        //        if (!userFound)
        //        {
        //            foreach (var student in students)
        //            {
        //                if (student.Username == typeUsername.Text && student.Password == typePassword.Password)
        //                {
        //                    var sWV = new StudentWindowView();
        //                    sWV.Show();
        //                    //uDW.textUsername.Text = user.Username;
        //                    this.Close();
        //                    studentFound = true;
        //                    return; // Exit the method after successful student login
        //                }
        //            }
        //        }
        //        if (!userFound && !studentFound)
        //        {
        //            MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
        //        }
                
        //    }
        //}

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var mainWV = new MainWindowView();
            mainWV.Show();
            this.Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
