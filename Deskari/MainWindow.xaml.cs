using System;
using System.Windows;
using Deskari.Views;
using Deskari.Model;
using System.Threading.Tasks;

namespace Deskari
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowWelcomeView();
        }

        private void ShowWelcomeView()
        {
            var welcomeView = new WelcomeView();
            welcomeView.ContinueClicked += (s, e) => ShowDirectorySelectionView();
            MainGrid.Children.Clear();
            MainGrid.Children.Add(welcomeView);
        }

        private void ShowDirectorySelectionView()
        {
            var directorySelectionView = new DirectorySelectionView();
            directorySelectionView.ContinueClicked += (s, path) =>
            {
                string sourceFolderPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tiedostot");
                ShowConfirmationView(path, sourceFolderPath);
            };
            MainGrid.Children.Clear();
            MainGrid.Children.Add(directorySelectionView);
        }

        private void ShowConfirmationView(string destinationPath, string sourceFolderPath)
        {

            var confirmationView = new ConfirmationView();
            confirmationView.ContinueClicked += (s, e) =>
            {
                ShowProgressView(sourceFolderPath, destinationPath);
            };
            confirmationView.BackClicked += (s, e) =>
            {
                ShowDirectorySelectionView();
            };

            MainGrid.Children.Clear();
            MainGrid.Children.Add(confirmationView);
        }

        private void ShowProgressView(string sourceFolderPath, string destinationFolderPath)
        {
            var progressView = new ProgressView(sourceFolderPath, destinationFolderPath);
            MainGrid.Children.Clear();
            MainGrid.Children.Add(progressView);

            var fileCopyModel = new FileCopyModel();

            var progress = new Progress<int>(percent =>
            {
                progressView.UpdateProgress(percent);
            });

            fileCopyModel.CopyCompleted += (s, e) =>
            {
                Dispatcher.Invoke(() =>
                {
                    var copyCompleteView = new CopyCompleteView();
                    MainGrid.Children.Clear();
                    MainGrid.Children.Add(copyCompleteView);
                });
            };

            Task.Run(() =>
            {
                fileCopyModel.CopyFiles(sourceFolderPath, destinationFolderPath, progress);
            });
        }
    }
}
