using System;
using System.Collections.Generic;
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
using CarPart.WPF.Commands;
using CarPart.WPF.ViewModels;

namespace CarPart.WPF.Views
{
    /// <summary>
    /// Логика взаимодействия для AuthView.xaml
    /// </summary>
    public partial class AuthView : UserControl
    {
        public static readonly DependencyProperty LoginCommandProperty=
            DependencyProperty.Register("LoginCommand", typeof(ICommand), typeof(AuthView), new PropertyMetadata(null));

        public ICommand LoginCommand
        {
            get => (ICommand) GetValue(LoginCommandProperty);
            set => SetValue(LoginCommandProperty, value);
        }

        public AuthView()
        {
            InitializeComponent();
        }

        

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Task.Yield();
            if (LoginCommand != null)
            {
                string psw = pswBx.Password;
                LoginCommand.Execute(psw);
            }
        }
    }
}
