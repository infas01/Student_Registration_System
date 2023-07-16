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

namespace SRS.Pages
{
    /// <summary>
    /// Interaction logic for createUser.xaml
    /// </summary>
    public partial class createUser : Page
    {
        public createUser()
        {
            DataContext = new ViewModel();
            InitializeComponent();
        }

    }
}
