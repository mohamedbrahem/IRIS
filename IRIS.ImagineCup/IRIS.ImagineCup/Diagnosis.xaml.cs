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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace IRIS.ImagineCup
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Diagnosis : Page
    {
        Double[,] dataTempOne = new Double[60,80];
        Double[,] dataTempTwo = new Double[60,80];

        int a, b, c, d ;


        public Diagnosis()
        {
            this.InitializeComponent();
            firstImage.Source = Gallery.ScanOne.image;
            secondImage.Source = Gallery.ScanTwo.image;
            dataTempOne = Gallery.ScanOne.dataTemp;
            dataTempTwo = Gallery.ScanTwo.dataTemp;
        }

        private void scrollViewerFirst_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            double X, Y;
            X = Double.Parse(e.GetCurrentPoint(firstImage).Position.X.ToString());
            Y = Double.Parse(e.GetCurrentPoint(firstImage).Position.Y.ToString());
            Thickness marginX = firstCrossHair.Margin;
            marginX.Left = X;
            marginX.Top = Y;
            firstCrossHair.Margin = marginX;
            int x = (int)Math.Round(X);
            int y = (int)Math.Round(Y);
            double px = (double)x / 180;
            double py = (double)y / 240;
            double x1 = Math.Floor(60 * py);
            double y1 = Math.Floor(80 * px);
            firstTxtBlock.Text = dataTempOne[Convert.ToInt32(x1), Convert.ToInt32(y1)].ToString() + " °C";

            a = Convert.ToInt32(x1);
            b = Convert.ToInt32(y1);

            if (dataTempOne[a, b] - dataTempTwo[c, d] >= 2) {
                messageTxt.Text = "Possible anomaly detected";
            }
            else if (dataTempOne[a, b] - dataTempTwo[c, d] <= -2) {
                messageTxt.Text = "Possible anomaly detected";
            }
            else {
                messageTxt.Text = "Normal situation";

            }
            
        }

       private void scrollViewerSecond_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            double X, Y;
            X = Double.Parse(e.GetCurrentPoint(secondImage).Position.X.ToString());
            Y = Double.Parse(e.GetCurrentPoint(secondImage).Position.Y.ToString());
            Thickness marginY = secondCrossHair.Margin;
            marginY.Left = X;
            marginY.Top = Y;
            secondCrossHair.Margin = marginY;
            int x = (int)Math.Round(X);
            int y = (int)Math.Round(Y);
            double px = (double)x / 180;
            double py = (double) y / 240;
            double x1 = Math.Floor(60 * py);
            double y1 = Math.Floor(80 * px);

            secondTxtBlock.Text = dataTempTwo[Convert.ToInt32(x1), Convert.ToInt32(y1)].ToString() + " °C";

            c = Convert.ToInt32(x1);
            d = Convert.ToInt32(y1);
            
            if (dataTempOne[a, b] - dataTempTwo[c, d] >= 2)
            {
                messageTxt.Text = "Possible anomaly detected";
            }
            else if (dataTempOne[a, b] - dataTempTwo[c, d] <= -2)
            {
                messageTxt.Text = "Possible anomaly detected";
            }
            else {
                messageTxt.Text = "Normal situation";

            }
             
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), null);
        }
    }
}