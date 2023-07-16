using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace SRS.Password
{
    public static class BindingPassword
    {
        public static readonly DependencyProperty BindablePasswordProperty =
            DependencyProperty.RegisterAttached("BindablePassword", typeof(string), 
                typeof(BindingPassword), new PropertyMetadata(string.Empty, OnBindablePasswordChanged));

        public static string GetBindablePassword(DependencyObject obj)
        {
            return (string)obj.GetValue(BindablePasswordProperty);
        }

        public static void SetBindablePassword(DependencyObject obj, string value)
        {
            obj.SetValue(BindablePasswordProperty, value);
        }

        private static void OnBindablePasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PasswordBox pBox)
            {
                pBox.PasswordChanged -= P_change;
                pBox.PasswordChanged += P_change;
            }
        }

        private static void P_change(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox pBox)
            {
                SetBindablePassword(pBox, pBox.Password);
            }
        }
    }

}

