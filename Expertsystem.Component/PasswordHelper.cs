using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Expertsystem.Component
{
    public class PasswordBoxHelper
    {
        public static readonly DependencyProperty PasswordProperty =
          DependencyProperty.RegisterAttached("Password", typeof(string), typeof(PasswordBoxHelper), 
              new PropertyMetadata(string.Empty, OnPasswordPropertyChanged));
        public static readonly DependencyProperty AttachProperty =
          DependencyProperty.RegisterAttached("Attach", typeof(bool), typeof(PasswordBoxHelper), 
              new PropertyMetadata(false, onAttachChanged));

        public static readonly DependencyProperty IsUpdatingProperty =
          DependencyProperty.RegisterAttached("IsUpdating", typeof(bool), typeof(PasswordBoxHelper));

        public static void SetAttach(DependencyObject dp ,bool value)
        {
            dp.SetValue(AttachProperty, value);
        }

        public static void GetAttach(DependencyObject dp)
        {
            dp.GetValue(AttachProperty);
        }

        public static string GetPassword(DependencyObject dp)
        {
            return (string)dp.GetValue(PasswordProperty);
        }

        public static void SetPassword(DependencyObject dp,string value)
        {
            dp.SetValue(PasswordProperty, value);
        }

        public static void SetIsUpdating(DependencyObject dp,bool value)
        {
            dp.SetValue(IsUpdatingProperty,value);
        }

        public static bool GetIsUpdating(DependencyObject dp)
        {
           return  (bool)dp.GetValue(IsUpdatingProperty);
        }
        private static void OnPasswordPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            passwordBox.PasswordChanged -= PasswordChanged;

            if (!(bool)GetIsUpdating(passwordBox))
            { 
               passwordBox.Password=(string)e.NewValue;
            }

            passwordBox.PasswordChanged += PasswordChanged;
        }

        public static void onAttachChanged(DependencyObject sender,DependencyPropertyChangedEventArgs e)
        { 
             PasswordBox passwordBox=sender as PasswordBox;
            if (passwordBox == null)
                return;
            if ((bool)e.OldValue)
            {
                passwordBox.PasswordChanged -= PasswordChanged;
            }
            if ((bool)e.NewValue)
            {
                passwordBox.PasswordChanged += PasswordChanged;
            }
        }
        
        private static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox=sender as PasswordBox;
            SetIsUpdating(passwordBox,true);
            SetPassword(passwordBox,passwordBox.Password);
            SetIsUpdating(passwordBox,false);
        }

    }
}
