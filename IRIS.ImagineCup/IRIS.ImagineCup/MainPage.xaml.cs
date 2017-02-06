using IRIS.ImagineCup.Entities;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace IRIS.ImagineCup
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void scanNav_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ScanPage), null);

        }

        private void diagnosticNav_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Diagnosis), null);
        }

        private void galleryNav_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Gallery), null);

        }

        private void guideNav_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Guide), null);
        }
    }
}
