using System;
using System.Windows;
using System.Windows.Controls;


namespace Deskari.Views
{
    /// <summary>
    /// Interaction logic for ConfirmationView.xaml
    /// </summary>
    public partial class ConfirmationView : UserControl
    {

        public event EventHandler ContinueClicked;
        public event EventHandler BackClicked;

        public ConfirmationView()
        {
            InitializeComponent();
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            ContinueClicked?.Invoke(this, EventArgs.Empty);
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            BackClicked?.Invoke(this, EventArgs.Empty);
        }

    }
}
