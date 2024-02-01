using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Task04.Dal;
using Task04.Models;
using Task04.Utils;

namespace Task04.ViewModels
{
    public class StorageBlobsViewModel
    {
        private string[] allowedExts = new[]
        {
            "jpeg", "jpg", "tiff", "png", "svg", "gif"
        };
        public ObservableCollection<StorageBlob> Blobs { get; set; }
        public ObservableCollection<BlobDirectory> Dirs { get; set; }

        public BlobDirectory? SelectedDirectory { get; set; } = null;

        public StorageBlobsViewModel() {
            Blobs = new ObservableCollection<StorageBlob>();
            Dirs = new ObservableCollection<BlobDirectory>();

            RefreshList();
        }

        public void RefreshList()
        {
            Dirs.Clear();
            Blobs.Clear();

            Dirs.AddRange(Repository.GetDirectories());
            Blobs.AddRange(Repository.GetPictures().ToList().FindAll(p => p.Directory?.Name.Equals(SelectedDirectory?.Name) ?? true));
        }

        public async Task AsyncUpload(string absolutePath)
        {
            var filename = absolutePath[(absolutePath.LastIndexOf(Path.DirectorySeparatorChar) + 1)..];
            var ext = Path.GetExtension(absolutePath).TrimStart('.').ToLower();

            if (!allowedExts.Contains(ext))
                throw new ArgumentException("File provided is not an image");

            byte[] bytes = await File.ReadAllBytesAsync(absolutePath);

            var blob = new StorageBlob()
            {
                FileName = filename,
                ContentType = MimeTypes.GetMimeType(ext),
                Data = bytes,
                DateCreated = DateTime.Now,
            };
            Repository.CreatePicture(ext, blob);

            RefreshList();
        }

        public void DeletePicture(StorageBlob storageBlob)
        {
            Repository.DeletePicture(storageBlob);
            RefreshList();
        }
    }
}
