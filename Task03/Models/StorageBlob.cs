using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Task04.Utils;

namespace Task04.Models
{
    public class StorageBlob
    {
        public int IDFile { get; set; }
        public int IDDirectory { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public DateTime DateCreated { get; set; }
        public byte[] Data { get; set; }

        public BitmapImage Image
        {
            get
            {
                return ImageUtils.ByteArrayToBitmapImage(Data);
            }
        }

        public BlobDirectory? Directory { get; set; }

        public override string ToString() => $"{Directory.Name ?? ""}/{FileName}";

    }
}
