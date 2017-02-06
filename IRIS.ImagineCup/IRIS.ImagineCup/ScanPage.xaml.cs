using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.Storage;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace IRIS.ImagineCup.Entities
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ScanPage : Page
    {
        String      stream = "7";
        String        stop = "http://192.168.1.4:8080/LeptonModule/software/raspberrypi_video/stopstream.php";
        String picturePath = "http://192.168.1.4:8080/LeptonModule/software/raspberrypi_video/picture.jpg";
        String        site = "http://192.168.1.4:8080/LeptonModule/software/raspberrypi_capture/file.txt";
        Scan scan;
        List<Scan> scans;
        int number = 0;
        int gaia = 0;

        public ScanPage()
        {
            this.InitializeComponent();
            streamerWebView.Navigate(new Uri(stream, UriKind.Absolute));
            scans = new List<Scan>();
        }


        private async Task<Scan> gettScan() {
            scan = new Scan();
            //scan.dataTemp = new Double[60, 80];
            //scan.image = new BitmapImage();
            scan.image = await loadImage();
            scan.dataTemp = await loadData();
            return scan;
        }

        private async void snapPictureButton_Click(object sender, RoutedEventArgs e)
        {
            if (gaia == 1)
            {
                MessageTxt.Text = "Please take another scan";
            }
            else {
                Gallery.Scans.Add(await gettScan());
                myProgressRing.IsActive = true;
                snapPictureButton.Visibility = Visibility.Collapsed;
                HomeButton.Visibility = Visibility.Collapsed;
                MessageTxt.Visibility = Visibility.Visible;
                await Task.Delay(3000);
                number++;
                numberTxtBlock.Text = number.ToString();
                myProgressRing.IsActive = false;
                snapPictureButton.Visibility = Visibility.Visible;
                HomeButton.Visibility = Visibility.Visible;
                MessageTxt.Visibility = Visibility.Collapsed;
                gaia = 0;

            }
           }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), null);
        }

        public async Task<Double[,]> loadData()
        {
            Double[,] dataTemp = new Double[60, 80];
            var clienx = new HttpClient();
            HttpResponseMessage response = await clienx.GetAsync(new Uri(site));
            string data = await response.Content.ReadAsStringAsync();
            int count = 0;
            string[] s = data.Split('+');

            for (int i = 0; i < 60; i++)
            {
                for (int j = 0; j < 80; j++)
                {
                    dataTemp[i, j] = Double.Parse(s[count++]);
                    if (dataTemp[i, j] < 20) { gaia = 1; } 
                }
            }



            return dataTemp;
        }

        public async Task<BitmapImage> loadImage()
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(new Uri(stop));
            // string data = await response.Content.ReadAsStringAsync();
            // Uri myUri = new Uri(picturePath, UriKind.Absolute); BitmapImage bmi = new BitmapImage(new Uri(picturePath,UriKind.RelativeOrAbsolute));


            BitmapImage bmi = new BitmapImage(new Uri(picturePath, UriKind.RelativeOrAbsolute));

            bmi.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            var url1 = new Uri("http://192.168.1.4:8080/LeptonModule/software/raspberrypi_video/picture.jpg");      // URL of image
            var urlT = new Uri("http://192.168.1.4:8080/LeptonModule/software/raspberrypi_video/picture.jpg");    // URL of thumbnail from google pic search


            var thumbnail = RandomAccessStreamReference.CreateFromUri(urlT);

            var remoteFile = await StorageFile.CreateStreamedFileFromUriAsync("aziz.jpg", url1, thumbnail);
            var storedFile = await remoteFile.CopyAsync(KnownFolders.SavedPictures, "aziz.jpg", NameCollisionOption.GenerateUniqueName);

            using (IRandomAccessStream fileStream = await storedFile.OpenAsync(Windows.Storage.FileAccessMode.Read))
            {
                BitmapImage image = new BitmapImage();
                image.SetSource(fileStream);
                galleryImage.Source = image;
                return image;
            }

            // bmi.UriSource = myUri;
            //galleryImage.Source =  bmi;

        }

    }
}

