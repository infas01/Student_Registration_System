using SRS.Models;
using SRS.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace SRS.Pages
{
    public partial class updateUser : Page
    {
        public updateUser()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }
        
        private UserM selectedData;

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the selected row from the DataGrid
            selectedData = (UserM)UsersDataGridView.SelectedItem;

            // Set the SelectedUser property in the ViewModel
            ((ViewModel)DataContext).SelectedUser = selectedData;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (selectedData != null)
            {
                // Set the values of the textboxes to the selected user's properties
                typeUsername.Text = selectedData.Username;
                typePassword.Text = selectedData.Password;
            }
            else
            {
                typeUsername.Text = string.Empty;
                typePassword.Text = string.Empty;
            }
        }
        
    }
}
