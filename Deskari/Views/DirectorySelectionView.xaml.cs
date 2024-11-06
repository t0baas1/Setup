using System;
using System.Windows;
using System.Windows.Controls;

namespace Deskari.Views
{
    /// <summary>
    /// Interaction logic for DirectorySelectionView.xaml
    /// </summary>
    public partial class DirectorySelectionView : UserControl
    {

        public event EventHandler<string> ContinueClicked;

        public DirectorySelectionView()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DirectoryTextBox.Text = dialog.SelectedPath;
            }
        }


        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            ContinueClicked?.Invoke(this, DirectoryTextBox.Text);
        }

    }
}
