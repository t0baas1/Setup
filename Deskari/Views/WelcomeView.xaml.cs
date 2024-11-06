using System;
using System.Windows;
using System.Windows.Controls;


namespace Deskari.Views
{
    /// <summary>
    /// Interaction logic for WelcomeView.xaml
    /// </summary>
    public partial class WelcomeView : UserControl
    {
        public event EventHandler ContinueClicked;

        public WelcomeView()
        {
            InitializeComponent();
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            ContinueClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
