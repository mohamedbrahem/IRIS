using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace IRIS.ImagineCup.Entities
{
    class Scan 
    {
        public BitmapImage image { get; set; }
        public Double[,] dataTemp { get; set; }

        public Scan() { }
        public Scan(BitmapImage image, Double[,] dataTemp)
        {
            this.image = image;
            this.dataTemp = dataTemp;
        }

        public double getMaxTemp()
        {
            double max = 0;

            for (int i = 0; i < 60; i++)
            {
                for (int j = 0; j < 80; j++)
                {
                    if (dataTemp[i, j] > max)
                        max = dataTemp[i, j];
                }
            }

            return max;
        }

        public double getMinTemp()
        {
            double min = 1000;

            for (int i = 0; i < 60; i++)
            {
                for (int j = 0; j < 80; j++)
                {
                    if (dataTemp[i, j] < min)
                        min = dataTemp[i, j];
                }
            }

            return min;
        }

    }
}
