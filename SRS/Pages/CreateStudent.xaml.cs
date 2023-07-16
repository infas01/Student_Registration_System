using SRS.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SRS.Pages
{
    /// <summary>
    /// Interaction logic for CreateStudent.xaml
    /// </summary>
    public partial class CreateStudent : Page
    {
        public CreateStudent()
        {
            InitializeComponent();
        }

        private void AddModuleButton_Click(object sender, RoutedEventArgs e)
        {
            var AMwv = new AddModuleWindowView();
            AMwv.Show();
        }

        private void UpdateModuleButton_Click_1(object sender, RoutedEventArgs e)
        {
            var UMwv = new UpdateModuleWindowView();
            UMwv.Show();
        }
    }
}
