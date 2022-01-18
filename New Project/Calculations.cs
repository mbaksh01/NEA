using System;
using System.Collections.Generic;
using System.Drawing;
using GlobalWarmingModel.Servies;

namespace GlobalWarmingModel
{
    public class Calculations
    {
        private readonly IFileReader _fileReader; 

        public Calculations(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public Color GetEmissionColour(string nation, int year, Color color)
        {
            Color[] colors = new Color[] { Color.Crimson, Color.Red, Color.Orange, Color.Yellow, Color.GreenYellow, Color.Green };
            List<int> values =  _fileReader.GetNationalCO2(nation);

            try
            {
                if (values[values.IndexOf(year) + 1] > values[values.IndexOf(year) - 1])
                {
                    for (int i = 0; i < colors.Length; i++) // loop through the list to find the colour that was perviously used
                    {
                        if (colors[i] == color)             // when that color is found then then change it to the previous index
                        {
                            return colors[i - 1];
                        }
                    }
                }
                else if (values[values.IndexOf(year) + 1] < values[values.IndexOf(year) - 1])
                {
                    for (int i = 0; i < colors.Length; i++)
                    {
                        if (colors[i] == color)
                        {
                            return colors[i + 1];
                        }
                    }
                }
            }
            catch
            {
                return color;
            }

            return color;
        }

        public Color GetAverageSeaLevelRise(int year)
        {
            int r = 0, g = 0, b = 0;

            _fileReader.GetSeaLevel(year, 'm');

            return Color.FromArgb(r, g, b);
        }

        public double GetStandardDeviation(List<double> StDev, List<int> Numeric, List<double> Mean)
        {
            List<double> Sigma = new List<double> { };      // list for each sigma from each set
            List<long> SigmaSquared = new List<long> { };   
            double SigmaSquaredTotal = 0;
            int NumericTotal = 0;                           // number of values used
            double SigmaTotal = 0;
            double StandardDeviation;

            for (int i = 0; i < Mean.Count; i++)
            {
                Sigma.Add(Mean[i] * Numeric[i]);            // addign sigmas to the sigma list
                SigmaSquared.Add((long)((Math.Pow(StDev[i], 2) + Math.Pow(Mean[i], 2)) * Numeric[i]));  // rearanging stdev eq to get sigma squared and adding it to the list
            }

            foreach (double d in SigmaSquared)
            {
                SigmaSquaredTotal += d;         // adding up all sigmas into a single numer (value higher than 32bit signed int)
            }

            foreach (int i in Numeric)
            {
                NumericTotal += i;
            }

            foreach (double d in Sigma)
            {
                SigmaTotal += d;
            }

            try
            {
                StandardDeviation = Math.Sqrt(SigmaSquaredTotal / NumericTotal - SigmaTotal / NumericTotal);    // stdev formula
            }
            catch
            {
                return -1;
            }
            
            return StandardDeviation;
        }
    }
}
