using Microsoft.Win32;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Task04.Models;
using Task04.ViewModels;

namespace Task04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StorageBlobsViewModel model;
        public MainWindow()
        {
            InitializeComponent();
            this.model = new StorageBlobsViewModel();
            lbFiles.ItemsSource = model.Blobs;
            cbDirs.ItemsSource = model.Dirs;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lbFiles.SelectedItem != null)
            {
                model.DeletePicture(lbFiles.SelectedItem as StorageBlob);
            }
        }

        private async void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                await model.AsyncUpload(dialog.FileName);
            }
        }

        private void lbFiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbFiles.SelectedItem != null)
            {
                var blob = lbFiles.SelectedItem as StorageBlob;
                tbFileName.Text = blob.FileName;
                tbDirectory.Text = blob.Directory.Name;
                tbContentType.Text = blob.ContentType;
                tbDateCreated.Text = blob.DateCreated.ToString();
                tbContentSize.Text = blob.Data.Length.ToString();

                MemoryStream stream = new MemoryStream(blob.Data);
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = stream;
                bitmap.EndInit();

                image.Source = bitmap;
            }
        }

        private void cbDirs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbDirs.SelectedItem != null)
            {
                model.SelectedDirectory = cbDirs.SelectedItem as BlobDirectory;
                model.RefreshList();
            }
        }
    }
}