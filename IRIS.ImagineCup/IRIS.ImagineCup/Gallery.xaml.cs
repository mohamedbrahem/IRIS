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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace IRIS.ImagineCup
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Gallery : Page
    {
        private static List<Scan> scans = new List<Scan>();
        private List<Scan> liste = new List<Scan>();
        private static Scan scanTwo = new Scan();
        private static Scan scanOne = new Scan();
        int count = 1;

        public Gallery()
        {
            this.InitializeComponent();
            ScanList.ItemsSource = Scans;
            CheckButton.Visibility = Visibility.Collapsed;
            numberTxtBlock.Text = scans.Count().ToString();
        }


        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), null);
        }


        private void ScanList_ItemClick(object sender, ItemClickEventArgs e)
        {

            if (count == 1)
            {
                numberTxtBlock.Text = count.ToString();
                messageTxtBlock.Text = "Please select one more scan";
                Scan scan1 = (Scan)e.ClickedItem;
                scanOne = scan1;
                count = 2;
                CheckButton.Visibility = Visibility.Collapsed;
            }
            else {
                numberTxtBlock.Text = count.ToString();
                messageTxtBlock.Text ="";

                Scan scan2 = (Scan)e.ClickedItem;
                scanTwo = scan2;
                count = 1;
                CheckButton.IsEnabled = true;
                CheckButton.Visibility = Visibility.Visible;

            }

        }
        internal static Scan ScanOne
        {
            get
            {
                return scanOne;
            }

            set
            {
                scanOne = value;
            }
        }

        internal static Scan ScanTwo
        {
            get
            {
                return ScanTwo1;
            }

            set
            {
                ScanTwo1 = value;
            }
        }

        internal static Scan ScanTwo1
        {
            get
            {
                return scanTwo;
            }

            set
            {
                scanTwo = value;
            }
        }

        internal static List<Scan> Scans
        {
            get
            {
                return scans;
            }

            set
            {
                scans = value;
            }
        }

        internal List<Scan> Liste
        {
            get
            {
                return liste;
            }

            set
            {
                liste = value;
            }
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), null);
        }
    }
}