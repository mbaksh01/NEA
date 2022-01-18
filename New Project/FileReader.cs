using System.Collections.Generic;
using System.IO;

namespace GlobalWarmingModel
{
    class FileReader
    {
        public static double GetSeaLevel(int year, char type)
        {
            StreamReader reader = new StreamReader(@"Sea Level Data.txt");

            for (int i = 0; i < 16; i++) // skip lines which contain text
            {
                reader.ReadLine();
            }

            for (int x = 0; x < 1014; x++)
            {
                string[] splitstrings = reader.ReadLine().Split(' ');   // read the line and put it into a string array.
                string[] mystrings = new string[12];
                int pos = 0;

                for (int i = 0; i < splitstrings.Length; i++)           // remove all spaces from the array
                {
                    if (splitstrings[i] != "")
                    {
                        mystrings[pos] = splitstrings[i];
                        pos++;
                    }
                }
                
                if ((int)double.Parse(mystrings[2]) == year)    // compair the value to see if its the year im looking for
                {
                    if (type == 'a')        // a - altimeter
                    {
                        return double.Parse(mystrings[0]);      // return if it is a match
                    }
                    else if (type == 'n')   //n - numeric
                    {
                        return double.Parse(mystrings[3]);
                    }
                    else if (type == 'm')   // m - mean
                    {
                        return double.Parse(mystrings[5]);      
                    }
                    else if (type == 's')   // s - stdev
                    {
                        return double.Parse(mystrings[6]);
                    }
                }
            }

            reader.Close();
            return -1;          // if nothings found return -1 
        }

        public static double GetSeaLevelStandardDeviation(int year)
        {
            List<double> StDev = new List<double> { };
            List<int> Numeric = new List<int> { };
            List<double> Mean = new List<double> { };

            StreamReader reader = new StreamReader(@"Sea Level Data.txt");

            for (int i = 0; i < 16; i++)
            {
                reader.ReadLine();
            }

            for (int x = 0; x < 1014; x++)
            {
                string[] splitstrings = reader.ReadLine().Split(' ');   
                string[] mystrings = new string[12];
                int pos = 0;

                for (int i = 0; i < splitstrings.Length; i++)           
                {
                    if (splitstrings[i] != "")
                    {
                        mystrings[pos] = splitstrings[i];
                        pos++;
                    }
                }

                if ((int)double.Parse(mystrings[2]) == year)    
                {
                    StDev.Add(double.Parse(mystrings[6]));      // collects all stdevs into a single list to be manipulated
                    Numeric.Add(int.Parse(mystrings[3]));       // collects all numerics into a single list to be manipulated
                    Mean.Add(double.Parse(mystrings[5]));       // collects all means into a single list to be manipulated
                }
            }

            reader.Close();
            return Calculations.GetStandardDeviation(StDev, Numeric, Mean);
        }
        
        public static double GetGlobalCO2(int year, char type)
        {
            StreamReader reader = new StreamReader(@"CO2 Level Data.txt");
            for (int i = 0; i < 53; i++)
            {
                reader.ReadLine();
            }

            for (int x = 0; x < 752; x++)
            {
                string[] splitstrings = reader.ReadLine().Split(' ');
                string[] mystrings = new string[8];
                int pos = 0;

                for (int i = 0; i < splitstrings.Length; i++)
                {
                    if (splitstrings[i] != "")
                    {
                        mystrings[pos] = splitstrings[i];
                        pos++;
                    }
                }

                if ((int)double.Parse(mystrings[2]) == year)
                {
                    if (type == 'm')
                    {
                        return double.Parse(mystrings[3]);
                    }
                    else if (type == 's')
                    {
                        return double.Parse(mystrings[6]);
                    }
                }
            }

            reader.Close();
            return -1;
        }

        public static List<int> GetNationalCO2(string nation)
        {
            StreamReader reader = new StreamReader(@"National CO2 Emissions.txt");
            List<int> values = new List<int> { };
            bool found = false;     // act as a break to stop loop

            for (int i = 0; i < 5; i++)
            {
                reader.ReadLine();
            }

            for (int x = 0; x < 17671; x++)
            {
                string[] splitstrings = reader.ReadLine().Split('\t');
                string[] mystrings = new string[10];
                int pos = 0;
                
                for (int i = 0; i < splitstrings.Length; i++)
                {
                    if (splitstrings[i] != "")
                    {
                        mystrings[pos] = splitstrings[i];
                        pos++;
                    }
                }

                if (mystrings[0] == nation)
                {
                    found = true;
                    values.Add(int.Parse(mystrings[1]));
                    values.Add(int.Parse(mystrings[2]));
                }
                else if (found)
                {
                    return values;
                }
            }

            reader.Close();
            return values;
        }

        public static double GetGlobalTemp(int year)
        {
            StreamReader reader = new StreamReader(@"Global Temperature Data.txt");

            for (int i = 0; i < 4; i++)
            {
                reader.ReadLine();
            }

            for (int x = 0; x < 140; x++)
            {
                string[] splitstrings = reader.ReadLine().Split(' ');
                string[] mystrings = new string[3];
                int pos = 0;

                for (int i = 0; i < splitstrings.Length; i++)
                {
                    if (splitstrings[i] != "")
                    {
                        mystrings[pos] = splitstrings[i];
                        pos++;
                    }
                }

                if ((int)double.Parse(mystrings[0]) == year)
                {
                    return double.Parse(mystrings[1]);
                }
            }

            reader.Close();
            return -1;
        }

        public static double GetIceSheets(int year)
        {
            StreamReader reader = new StreamReader(@"Ice Sheets.txt");
            for (int i = 0; i < 7; i++)
            {
                reader.ReadLine();
            }

            for (int x = 0; x < 189; x++)
            {
                string[] splitstrings = reader.ReadLine().Split(' ');
                string[] mystrings = new string[3];
                int pos = 0;

                for (int i = 0; i < splitstrings.Length; i++)
                {
                    if (splitstrings[i] != "")
                    {
                        mystrings[pos] = splitstrings[i];
                        pos++;
                    }
                }

                if ((int)double.Parse(mystrings[0]) == year)
                {
                    return double.Parse(mystrings[1]);
                }
            }

            reader.Close();
            return -1;
        }

        public static double GetArcticSeaIce(int year)
        {
            StreamReader reader = new StreamReader(@"Arctic Sea Ice Minimum.csv");

            reader.ReadLine();
            
            for (int x = 0; x < 42; x++)
            {
                string[] splitstrings = reader.ReadLine().Split(' ', ',');
                string[] mystrings = new string[6];
                int pos = 0;

                for (int i = 0; i < splitstrings.Length; i++)
                {
                    if (splitstrings[i] != "")
                    {
                        mystrings[pos] = splitstrings[i];
                        pos++;
                    }
                }

                if ((int)double.Parse(mystrings[0]) == year)
                {
                    return double.Parse(mystrings[4]);
                }
            }

            reader.Close();
            return -1;
        }

        public static int GetXCoordinate(string countryname)
        {
            StreamReader reader = new StreamReader(@"Coordinates.txt");

            for (int x = 0; x < 20; x++)
            {
                string[] splitstrings = reader.ReadLine().Split(','); 

                if (splitstrings[0] == countryname)    
                {
                    return int.Parse(splitstrings[1]);
                }
            }

            reader.Close();
            return -1; 
        }
            
        public static int GetYCoordinate(string countryname)
        {
            StreamReader reader = new StreamReader(@"Coordinates.txt");

            for (int x = 0; x < 20; x++)
            {
                string[] splitstrings = reader.ReadLine().Split(',');

                if (splitstrings[0] == countryname)
                {
                    return int.Parse(splitstrings[2]);
                }
            }

            reader.Close();
            return -1;
        }

        public static int GetDiameter(string countryname)
        {
            StreamReader reader = new StreamReader(@"Coordinates.txt");

            for (int x = 0; x < 20; x++)
            {
                string[] splitstrings = reader.ReadLine().Split(',');

                if (splitstrings[0] == countryname)
                {
                    return int.Parse(splitstrings[3]);
                }
            }

            reader.Close();
            return -1;
        }
    }
}
