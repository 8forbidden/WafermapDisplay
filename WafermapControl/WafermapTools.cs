using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fratte.at.WafermapDisplay
{
    class WafermapTools
    {
        public static int[,] scaleArray(int[,]data, int scale){
            // Create the scaled array
            int[,] newdata = new int[(int)Math.Ceiling((double)data.GetLength(0) / (double)scale), (int)Math.Ceiling((double)data.GetLength(1) / (double)scale)];
            // Fill the array
            int temp = newdata.GetLength(0);
            int temp1 = newdata.GetLength(1);
            for (int x = 0; x < temp; x++)
            {
                for (int y = 0; y < temp1; y++)
                {
                    // Slice array
                    newdata[x, y] = getMaxArray(data,x,y,scale);
                }
            }
                return newdata;
        }

        private static int getMaxArray(int[,] data, int xFrom, int yFrom, int size){
            int temp = data.GetLength(0);
            int temp1 = data.GetLength(1);
            int max = 0;

            if (xFrom + size < temp)
                temp = xFrom + size;
            if (yFrom + size < temp1)
                temp1 = yFrom + size;

            for (int x = xFrom; x < temp; x++)
            {
                for (int y = yFrom; y < temp1; y++)
                {
                    if (data[x, y] > max)
                    {
                        max = data[x, y];
                    }
                }
            }
            return max;
        }

        public double getYield(int[,] data, int[] goodBins, int[] ignoreBins)
        {
            double y = -1.00;
            int total = 0;
            int good = 0;
            foreach (int bin in data)
            {
                if (!ignoreBins.Contains(bin))
                {
                    total += 1;
                    if (goodBins.Contains(bin))
                    {
                        good += 1;
                    }
                }
            }
            y = (double)good / (double)total; 
            return y;
        }
    }

    
    
}
