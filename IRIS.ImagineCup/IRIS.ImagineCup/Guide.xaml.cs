using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace IRIS.ImagineCup
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Guide : Page
    {
        int i;

        public Guide()
        {
            this.InitializeComponent();
            i = 1;
            brahem.Source = ImageFromRelativePath(this, "Assets/Images/1.png");

        }

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            i++;
            if (i == 12) { i = 11; }

            if (i == 2)
            {
                brahem.Source = ImageFromRelativePath(this, "Assets/Images/2.png");
            } else
            if (i == 3)
            {
                brahem.Source = ImageFromRelativePath(this, "Assets/Images/3.png");
            }
            else
            if (i == 4)
            {
                brahem.Source = ImageFromRelativePath(this, "Assets/Images/4.png");
            }
            else
            if (i == 5)
            {
                brahem.Source = ImageFromRelativePath(this, "Assets/Images/5.png");
            }
            else
            if (i == 6)
            {
                brahem.Source = ImageFromRelativePath(this, "Assets/Images/6.png");
            }
            else
            if (i == 7)
            {
                brahem.Source = ImageFromRelativePath(this, "Assets/Images/7.png");
            }
            else
            if (i == 8)
            {
                brahem.Source = ImageFromRelativePath(this, "Assets/Images/8.png");
            }
            else
            if (i == 9)
            {
                brahem.Source = ImageFromRelativePath(this, "Assets/Images/9.png");
            }
            else
            if (i == 10)
            {
                brahem.Source = ImageFromRelativePath(this, "Assets/Images/10.png");
            }
            else
            if (i == 11)
            {
                brahem.Source = ImageFromRelativePath(this, "Assets/Images/11.png");
            }
            // else if () { }
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            i--;

            if (i == 0) { i = 1; }
            if (i == 1)
            { 
                brahem.Source = ImageFromRelativePath(this, "Assets/Images/1.png");

            } else 
            if (i == 2)
            {
                brahem.Source = ImageFromRelativePath(this, "Assets/Images/2.png");
            }
            else
           if (i == 3)
            {
                brahem.Source = ImageFromRelativePath(this, "Assets/Images/3.png");
            }
            else
           if (i == 4)
            {
                brahem.Source = ImageFromRelativePath(this, "Assets/Images/4.png");
            }
            else
           if (i == 5)
            {
                brahem.Source = ImageFromRelativePath(this, "Assets/Images/5.png");
            }
            else
           if (i == 6)
            {
                brahem.Source = ImageFromRelativePath(this, "Assets/Images/6.png");
            }
            else
           if (i == 7)
            {
                brahem.Source = ImageFromRelativePath(this, "Assets/Images/7.png");
            }
            else
           if (i == 8)
            {
                brahem.Source = ImageFromRelativePath(this, "Assets/Images/8.png");
            }
            else
           if (i == 9)
            {
                brahem.Source = ImageFromRelativePath(this, "Assets/Images/9.png");
            }
            else
           if (i == 10)
            {
                brahem.Source = ImageFromRelativePath(this, "Assets/Images/10.png");
            }
            else
           if (i == 11)
            {
                brahem.Source = ImageFromRelativePath(this, "Assets/Images/11.png");
            }


        }

        private void AppBarButton_Click_2(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), null);
        }

        public static BitmapImage ImageFromRelativePath(FrameworkElement parent, string path)
        {
            var uri = new Uri(parent.BaseUri, path);
            BitmapImage bmp = new BitmapImage();
            bmp.UriSource = uri;
            return bmp;
        }
    }
}
