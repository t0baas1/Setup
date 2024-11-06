using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace Deskari.Views
{
    /// <summary>
    /// Interaction logic for ProgressView.xaml
    /// </summary>
    public partial class ProgressView : UserControl
    {
        public ProgressView(string sourceFolderPath, string destinationFolderPath)
        {
            InitializeComponent();
        }

        public void UpdateProgress(int percent)
        {
            FileCopyProgressBar.Value = percent;
        }
    }
}
