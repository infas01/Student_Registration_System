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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SRS.Views
{
    /// <summary>
    /// Interaction logic for StudentWindowView.xaml
    /// </summary>
    public partial class StudentWindowView : Window
    {
        public StudentViewModel SVM { get; set; }
        public StudentResultsViewModel SRVM { get; set; }
        public StudentWindowView(StudentViewModel studentMainViewModel, StudentResultsViewModel SRVM)
        {
            DataContext = studentMainViewModel;
            SVM = studentMainViewModel;
            InitializeComponent();
            this.SRVM = SRVM;
            dropdownContent.Height = 0;
        }

        private readonly Duration openCloseDuration = new Duration(TimeSpan.FromSeconds(0.5));

        private void OpenDropdown(object sender, RoutedEventArgs e)
        {
            dropdownInnerContent.Measure(new Size(dropdownContent.MaxWidth, dropdownContent.MaxHeight));
            DoubleAnimation heightAnimation = new DoubleAnimation(0, dropdownInnerContent.DesiredSize.Height, openCloseDuration);
            dropdownContent.BeginAnimation(HeightProperty, heightAnimation);
        }

        private void CloseDropdown(object sender, RoutedEventArgs e)
        {
            DoubleAnimation heightAnimation = new DoubleAnimation(0, openCloseDuration);
            dropdownContent.BeginAnimation(HeightProperty, heightAnimation);
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            CloseDropdown(sender, e);
            //studentDetails.Content = new StudentHomePage();
        }

        private void PIButton_Click(object sender, RoutedEventArgs e)
        {
            studentDetails.Content = new StudentPersonalInformationPage(SVM);
        }
        

        private void AcademicButton_Click(object sender, RoutedEventArgs e)
        {
            studentDetails.Content = new StudentAcademicPage(SRVM);
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            studentDetails.Content = new StudentAboutPage();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var mwV = new MainWindowView();
            mwV.Show();
        }
    }
}
