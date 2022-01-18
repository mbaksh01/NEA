using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GlobalWarmingModel
{
    public partial class Form1 : Form
    {
        Pen pen = new Pen(Color.Red, 2);
        bool yearchanged;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Demo();

            //OptionsComboBox.SelectedIndex = 0;      // setting default selection in the combo boxes
            //SelectionComboBox.SelectedIndex = 1;

            TimelineBar.LargeChange = 1;            // reducing the scroll bar sider to its minimum size
            TimelineBar.Maximum = 2020;             // setting max for timeline

            Size = new Size(1217, 640);             // setting a start up size
            MinimumSize = new Size(1217, 640);      // locking form to this size
            MaximumSize = new Size(1217, 640);

            #region Loading Initial Images

            GlobeImageBox.BackgroundImage = Image.FromFile(@"Images\World Map.jpg");

            TempGraph.ImageLocation = @"Images\Global Temp.png";    //scales image to size of picture box
            TempGraph.SizeMode = PictureBoxSizeMode.StretchImage;

            CO2Graph.ImageLocation = @"Images\CO2.png";
            CO2Graph.SizeMode = PictureBoxSizeMode.StretchImage;

            SeaLevelRiseGraph.ImageLocation = @"Images\Sea Level.png";
            SeaLevelRiseGraph.SizeMode = PictureBoxSizeMode.StretchImage;

            ColourScaleBox.ImageLocation = @"Images\Colour Scale.jpg";
            ColourScaleBox.SizeMode = PictureBoxSizeMode.StretchImage;

            #endregion

            //Points:
            //UK - 320,97
            //America - 110,140
            //Africa - 372,265
            //Europe - 373,119
            //Asia - 500,144
            //China - 547,173
            //Austrailia - 623,353
        }

        private void Timeline_Bar_Scroll(object sender, ScrollEventArgs e)
        {
            yearchanged = true;
            TimelineBarToolTip.SetToolTip(TimelineBar, Convert.ToString(TimelineBar.Value));    // tooltip for year output during scrolling
            
            if (SelectionComboBox.SelectedIndex == 1)
            {
                switch (OptionsComboBox.SelectedIndex)
                {
                    case 0:
                        // large sea level circle over the entire map to show increase
                        // dose it funtion exactly the same as the graph, therefore is it needed?
                        // maybe find sea level rise per country and do that
                        break;
                }
            }
            else
            {
                switch (OptionsComboBox.SelectedIndex)
                {
                    case 0:
                        SeaLevelGraph();
                        break;
                    case 1:
                        CO2LevelGraph();
                        break;
                    case 2:
                        TemperatureGraph();
                        break;
                    case 3:
                        IceSheetsGraph();
                        break;
                    case 4:
                        ArcticSeaIceGraph();
                        break;
                }
            }
        }

        private void Options_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (OptionsComboBox.SelectedIndex)
            {
                case 0:
                    SeaLevelGraph();
                    FileReader.GetSeaLevel(TimelineBar.Value, 'm');     // delete if not used
                    TopLabel.Text = "Fast\nIncrease\nRate";
                    BottomLabel.Text = "Slow\nIncrease\nRate";
                    BottomLabel.Location = new Point(819, 89);          // setting location for the lable
                    TimelineBar.Minimum = 1993;                         // resetting minimum based on file minimum year
                    TimelineBar.Value = 1993;
                    break;
                case 1:
                    CO2LevelGraph();
                    FileReader.GetGlobalCO2(TimelineBar.Value, 'm');
                    TopLabel.Text = "High\nEmissions";
                    BottomLabel.Text = "Low\nEmissions";
                    BottomLabel.Location = new Point(819, 102);
                    TimelineBar.Minimum = 1958;
                    TimelineBar.Value = 1958;
                    break;
                case 2:
                    TemperatureGraph();
                    FileReader.GetGlobalTemp(TimelineBar.Value);
                    TopLabel.Text = "High\nTemperature";
                    BottomLabel.Text = "Low\nTemperature";
                    BottomLabel.Location = new Point(819, 102);
                    TimelineBar.Minimum = 1950;
                    TimelineBar.Value = 1950;
                    break;
                case 3:
                    IceSheetsGraph();
                    FileReader.GetIceSheets(TimelineBar.Value);
                    TopLabel.Text = "Fast\nMelt\nRate";
                    BottomLabel.Text = "Slow\nMelt\nRate";
                    BottomLabel.Location = new Point(819, 89);
                    TimelineBar.Minimum = 2002;
                    TimelineBar.Value = 2002;
                    break;
                case 4:
                    ArcticSeaIceGraph();
                    FileReader.GetArcticSeaIce(TimelineBar.Value);
                    TopLabel.Text = "High\nMelt\nRate";
                    BottomLabel.Text = "Low\nMelt\nRate";
                    BottomLabel.Location = new Point(819, 89);
                    TimelineBar.Minimum = 1979;
                    TimelineBar.Value = 1979;
                    break;
            }
        }

        private void Selection_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (SelectionComboBox.SelectedIndex)
            {
                case 0:
                    GlobeImageBox.Visible = false;    // make the map not visible when the graph option is selected
                    MainGraph.Visible = true;
                    switch (OptionsComboBox.SelectedIndex)     // delete switch if not in use
                    {
                        case 0:
                            SeaLevelGraph();
                            break;
                        case 1:
                            CO2LevelGraph();
                            break;
                        case 2:
                            TemperatureGraph();
                            break;
                        case 3:
                            IceSheetsGraph();
                            break;
                        case 4:
                            ArcticSeaIceGraph();
                            break;
                    }
                    break;
                case 1:
                    MainGraph.Visible = false;
                    GlobeImageBox.Visible = true;
                    GlobeImageBox.ImageLocation = @"Images\World Map.jpg";
                    GlobeImageBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    break;
            }
        }

        private void infolabel_Click(object sender, EventArgs e) // label to test things
        {
            infolabel.Text = Convert.ToString(GlobeImageBox.Width);
            infolabel2.Text = Convert.ToString(GlobeImageBox.Height);
            infolabel3.Text = Convert.ToString(FileReader.GetSeaLevelStandardDeviation(TimelineBar.Value));
        }

        #region Graph Data Points
        public void SeaLevelGraph()
        {
            if (TimelineBar.Value >= 1993 && TimelineBar.Value < 2002)
            {
                MainGraph.Series = new SeriesCollection
                {
                    new LineSeries
                    { 
                        Values = new ChartValues<ObservablePoint>
                        {
                            new ObservablePoint(1993, FileReader.GetSeaLevel(1993, 'm')),   // plot point one the graph
                            new ObservablePoint(1994, FileReader.GetSeaLevel(1994, 'm')),
                            new ObservablePoint(1995, FileReader.GetSeaLevel(1995, 'm')),
                            new ObservablePoint(1996, FileReader.GetSeaLevel(1996, 'm')),
                            new ObservablePoint(1997, FileReader.GetSeaLevel(1997, 'm')),
                            new ObservablePoint(1998, FileReader.GetSeaLevel(1998, 'm')),
                            new ObservablePoint(1999, FileReader.GetSeaLevel(1999, 'm')),
                            new ObservablePoint(2000, FileReader.GetSeaLevel(2000, 'm')),
                            new ObservablePoint(2001, FileReader.GetSeaLevel(2001, 'm'))
                        }
                    }
                };
            }
            else if (TimelineBar.Value >= 2002 && TimelineBar.Value < 2011)
            {
                MainGraph.Series = new SeriesCollection
                {
                    new LineSeries
                    {

                        Values = new ChartValues<ObservablePoint>
                        {
                            new ObservablePoint(2002, FileReader.GetSeaLevel(2002, 'm')),
                            new ObservablePoint(2003, FileReader.GetSeaLevel(2003, 'm')),
                            new ObservablePoint(2004, FileReader.GetSeaLevel(2004, 'm')),
                            new ObservablePoint(2005, FileReader.GetSeaLevel(2005, 'm')),
                            new ObservablePoint(2006, FileReader.GetSeaLevel(2006, 'm')),
                            new ObservablePoint(2007, FileReader.GetSeaLevel(2007, 'm')),
                            new ObservablePoint(2008, FileReader.GetSeaLevel(2008, 'm')),
                            new ObservablePoint(2009, FileReader.GetSeaLevel(2009, 'm')),
                            new ObservablePoint(2010, FileReader.GetSeaLevel(2010, 'm'))
                        }
                    }
                };
            }
            else if (TimelineBar.Value >= 2011 && TimelineBar.Value < 2021)
            {
                MainGraph.Series = new SeriesCollection
                {
                    new LineSeries
                    {

                        Values = new ChartValues<ObservablePoint>
                        {
                            new ObservablePoint(2011, FileReader.GetSeaLevel(2011, 'm')),   // plot point one the graph
                            new ObservablePoint(2012, FileReader.GetSeaLevel(2012, 'm')),
                            new ObservablePoint(2013, FileReader.GetSeaLevel(2013, 'm')),
                            new ObservablePoint(2014, FileReader.GetSeaLevel(2014, 'm')),
                            new ObservablePoint(2015, FileReader.GetSeaLevel(2015, 'm')),
                            new ObservablePoint(2016, FileReader.GetSeaLevel(2016, 'm')),
                            new ObservablePoint(2017, FileReader.GetSeaLevel(2017, 'm')),
                            new ObservablePoint(2018, FileReader.GetSeaLevel(2018, 'm')),
                            new ObservablePoint(2019, FileReader.GetSeaLevel(2019, 'm')),
                            new ObservablePoint(2020, FileReader.GetSeaLevel(2020, 'm'))
                        }
                    }
                };  
            }
            
        }
        public void CO2LevelGraph()
        {
            if (TimelineBar.Value >= 1958 && TimelineBar.Value < 1969)
            {
                MainGraph.Series = new SeriesCollection
                {
                    new LineSeries
                    {

                        Values = new ChartValues<ObservablePoint>
                        {
                            new ObservablePoint(1958, FileReader.GetGlobalCO2(1958, 'm')),
                            new ObservablePoint(1959, FileReader.GetGlobalCO2(1959, 'm')),
                            new ObservablePoint(1960, FileReader.GetGlobalCO2(1960, 'm')),
                            new ObservablePoint(1961, FileReader.GetGlobalCO2(1961, 'm')),
                            new ObservablePoint(1962, FileReader.GetGlobalCO2(1962, 'm')),
                            new ObservablePoint(1963, FileReader.GetGlobalCO2(1963, 'm')),
                            new ObservablePoint(1964, FileReader.GetGlobalCO2(1964, 'm')),
                            new ObservablePoint(1965, FileReader.GetGlobalCO2(1965, 'm')),
                            new ObservablePoint(1966, FileReader.GetGlobalCO2(1966, 'm')),
                            new ObservablePoint(1967, FileReader.GetGlobalCO2(1967, 'm')),
                            new ObservablePoint(1968, FileReader.GetGlobalCO2(1968, 'm'))

                        }
                    }
                };
            }
            else if (TimelineBar.Value >= 1969 && TimelineBar.Value < 1979)
            {
                MainGraph.Series = new SeriesCollection
                {
                    new LineSeries
                    {

                        Values = new ChartValues<ObservablePoint>
                        {
                            new ObservablePoint(1969, FileReader.GetGlobalCO2(1969, 'm')),
                            new ObservablePoint(1970, FileReader.GetGlobalCO2(1970, 'm')),
                            new ObservablePoint(1971, FileReader.GetGlobalCO2(1971, 'm')),
                            new ObservablePoint(1972, FileReader.GetGlobalCO2(1972, 'm')),
                            new ObservablePoint(1973, FileReader.GetGlobalCO2(1973, 'm')),
                            new ObservablePoint(1974, FileReader.GetGlobalCO2(1974, 'm')),
                            new ObservablePoint(1975, FileReader.GetGlobalCO2(1975, 'm')),
                            new ObservablePoint(1976, FileReader.GetGlobalCO2(1976, 'm')),
                            new ObservablePoint(1977, FileReader.GetGlobalCO2(1977, 'm')),
                            new ObservablePoint(1978, FileReader.GetGlobalCO2(1978, 'm'))
                            
                        }
                    }
                };
            }
            else if (TimelineBar.Value >= 1979 && TimelineBar.Value < 1989)
            {
                MainGraph.Series = new SeriesCollection
                {
                    new LineSeries
                    {

                        Values = new ChartValues<ObservablePoint>
                        {
                            new ObservablePoint(1979, FileReader.GetGlobalCO2(1979, 'm')),
                            new ObservablePoint(1980, FileReader.GetGlobalCO2(1980, 'm')),
                            new ObservablePoint(1981, FileReader.GetGlobalCO2(1981, 'm')),
                            new ObservablePoint(1982, FileReader.GetGlobalCO2(1982, 'm')),
                            new ObservablePoint(1983, FileReader.GetGlobalCO2(1983, 'm')),
                            new ObservablePoint(1984, FileReader.GetGlobalCO2(1984, 'm')),
                            new ObservablePoint(1985, FileReader.GetGlobalCO2(1985, 'm')),
                            new ObservablePoint(1986, FileReader.GetGlobalCO2(1986, 'm')),
                            new ObservablePoint(1987, FileReader.GetGlobalCO2(1987, 'm')),
                            new ObservablePoint(1988, FileReader.GetGlobalCO2(1988, 'm'))
                        }
                    }
                };
            }
            else if (TimelineBar.Value >= 1989 && TimelineBar.Value < 1999)
            {
                MainGraph.Series = new SeriesCollection
                {
                    new LineSeries
                    {

                        Values = new ChartValues<ObservablePoint>
                        {
                            new ObservablePoint(1989, FileReader.GetGlobalCO2(1989, 'm')),
                            new ObservablePoint(1990, FileReader.GetGlobalCO2(1990, 'm')),
                            new ObservablePoint(1991, FileReader.GetGlobalCO2(1991, 'm')),
                            new ObservablePoint(1992, FileReader.GetGlobalCO2(1992, 'm')),
                            new ObservablePoint(1993, FileReader.GetGlobalCO2(1993, 'm')),
                            new ObservablePoint(1994, FileReader.GetGlobalCO2(1994, 'm')),
                            new ObservablePoint(1995, FileReader.GetGlobalCO2(1995, 'm')),
                            new ObservablePoint(1996, FileReader.GetGlobalCO2(1996, 'm')),
                            new ObservablePoint(1997, FileReader.GetGlobalCO2(1997, 'm')),
                            new ObservablePoint(1998, FileReader.GetGlobalCO2(1998, 'm'))
                        }
                    }
                };
            }
            else if (TimelineBar.Value >= 1999 && TimelineBar.Value < 2010)
            {
                MainGraph.Series = new SeriesCollection
                {
                    new LineSeries
                    {

                        Values = new ChartValues<ObservablePoint>
                        {
                            new ObservablePoint(1999, FileReader.GetGlobalCO2(1999, 'm')),
                            new ObservablePoint(2000, FileReader.GetGlobalCO2(2000, 'm')),
                            new ObservablePoint(2001, FileReader.GetGlobalCO2(2001, 'm')),
                            new ObservablePoint(2002, FileReader.GetGlobalCO2(2002, 'm')),
                            new ObservablePoint(2003, FileReader.GetGlobalCO2(2003, 'm')),
                            new ObservablePoint(2004, FileReader.GetGlobalCO2(2004, 'm')),
                            new ObservablePoint(2005, FileReader.GetGlobalCO2(2005, 'm')),
                            new ObservablePoint(2006, FileReader.GetGlobalCO2(2006, 'm')),
                            new ObservablePoint(2007, FileReader.GetGlobalCO2(2007, 'm')),
                            new ObservablePoint(2008, FileReader.GetGlobalCO2(2008, 'm')),
                            new ObservablePoint(2009, FileReader.GetGlobalCO2(2009, 'm'))
                        }
                    }
                };
            }
            else if (TimelineBar.Value >= 2010 && TimelineBar.Value < 2021)
            {
                MainGraph.Series = new SeriesCollection
                {
                    new LineSeries
                    {

                        Values = new ChartValues<ObservablePoint>
                        {
                            new ObservablePoint(2010, FileReader.GetGlobalCO2(2010, 'm')),
                            new ObservablePoint(2011, FileReader.GetGlobalCO2(2011, 'm')),
                            new ObservablePoint(2012, FileReader.GetGlobalCO2(2012, 'm')),
                            new ObservablePoint(2013, FileReader.GetGlobalCO2(2013, 'm')),
                            new ObservablePoint(2014, FileReader.GetGlobalCO2(2014, 'm')),
                            new ObservablePoint(2015, FileReader.GetGlobalCO2(2015, 'm')),
                            new ObservablePoint(2016, FileReader.GetGlobalCO2(2016, 'm')),
                            new ObservablePoint(2017, FileReader.GetGlobalCO2(2017, 'm')),
                            new ObservablePoint(2018, FileReader.GetGlobalCO2(2018, 'm')),
                            new ObservablePoint(2019, FileReader.GetGlobalCO2(2019, 'm')),
                            new ObservablePoint(2020, FileReader.GetGlobalCO2(2020, 'm'))
                        }
                    }
                };
            }
        }
        public void TemperatureGraph()
        {
            if (TimelineBar.Value >= 1950 && TimelineBar.Value < 1959)
            {
                MainGraph.Series = new SeriesCollection
                {
                    new LineSeries
                    {

                        Values = new ChartValues<ObservablePoint>
                        {
                            new ObservablePoint(1950, FileReader.GetGlobalTemp(1950)),
                            new ObservablePoint(1951, FileReader.GetGlobalTemp(1951)),
                            new ObservablePoint(1952, FileReader.GetGlobalTemp(1952)),
                            new ObservablePoint(1953, FileReader.GetGlobalTemp(1953)),
                            new ObservablePoint(1954, FileReader.GetGlobalTemp(1954)),
                            new ObservablePoint(1955, FileReader.GetGlobalTemp(1955)),
                            new ObservablePoint(1956, FileReader.GetGlobalTemp(1956)),
                            new ObservablePoint(1957, FileReader.GetGlobalTemp(1957)),
                            new ObservablePoint(1958, FileReader.GetGlobalTemp(1958))
                        }
                    }
                };
            }
            else if (TimelineBar.Value >= 1959 && TimelineBar.Value < 1969)
            {
                MainGraph.Series = new SeriesCollection
                {
                    new LineSeries
                    {

                        Values = new ChartValues<ObservablePoint>
                        {
                            new ObservablePoint(1959, FileReader.GetGlobalTemp(1959)),
                            new ObservablePoint(1960, FileReader.GetGlobalTemp(1960)),
                            new ObservablePoint(1961, FileReader.GetGlobalTemp(1961)),
                            new ObservablePoint(1962, FileReader.GetGlobalTemp(1962)),
                            new ObservablePoint(1963, FileReader.GetGlobalTemp(1963)),
                            new ObservablePoint(1964, FileReader.GetGlobalTemp(1964)),
                            new ObservablePoint(1965, FileReader.GetGlobalTemp(1965)),
                            new ObservablePoint(1966, FileReader.GetGlobalTemp(1966)),
                            new ObservablePoint(1967, FileReader.GetGlobalTemp(1967)),
                            new ObservablePoint(1968, FileReader.GetGlobalTemp(1968))
                        }
                    }
                };
            }
            else if (TimelineBar.Value >= 1969 && TimelineBar.Value < 1979)
            {
                MainGraph.Series = new SeriesCollection
                {
                    new LineSeries
                    {

                        Values = new ChartValues<ObservablePoint>
                        {
                            new ObservablePoint(1969, FileReader.GetGlobalTemp(1969)),
                            new ObservablePoint(1970, FileReader.GetGlobalTemp(1970)),
                            new ObservablePoint(1971, FileReader.GetGlobalTemp(1971)),
                            new ObservablePoint(1972, FileReader.GetGlobalTemp(1972)),
                            new ObservablePoint(1973, FileReader.GetGlobalTemp(1973)),
                            new ObservablePoint(1974, FileReader.GetGlobalTemp(1974)),
                            new ObservablePoint(1975, FileReader.GetGlobalTemp(1975)),
                            new ObservablePoint(1976, FileReader.GetGlobalTemp(1976)),
                            new ObservablePoint(1977, FileReader.GetGlobalTemp(1977)),
                            new ObservablePoint(1978, FileReader.GetGlobalTemp(1978))
                        }
                    }
                };
            }
            else if (TimelineBar.Value >= 1979 && TimelineBar.Value < 1989)
            {
                MainGraph.Series = new SeriesCollection
                {
                    new LineSeries
                    {

                        Values = new ChartValues<ObservablePoint>
                        {
                            new ObservablePoint(1979, FileReader.GetGlobalTemp(1979)),
                            new ObservablePoint(1980, FileReader.GetGlobalTemp(1980)),
                            new ObservablePoint(1981, FileReader.GetGlobalTemp(1981)),
                            new ObservablePoint(1982, FileReader.GetGlobalTemp(1982)),
                            new ObservablePoint(1983, FileReader.GetGlobalTemp(1983)),
                            new ObservablePoint(1984, FileReader.GetGlobalTemp(1984)),
                            new ObservablePoint(1985, FileReader.GetGlobalTemp(1985)),
                            new ObservablePoint(1986, FileReader.GetGlobalTemp(1986)),
                            new ObservablePoint(1987, FileReader.GetGlobalTemp(1987)),
                            new ObservablePoint(1988, FileReader.GetGlobalTemp(1988))
                        }
                    }
                };
            }
            else if (TimelineBar.Value >= 1989 && TimelineBar.Value < 2002)
            {
                MainGraph.Series = new SeriesCollection
                {
                    new LineSeries
                    {

                        Values = new ChartValues<ObservablePoint>
                        {
                            new ObservablePoint(1989, FileReader.GetGlobalTemp(1989)),
                            new ObservablePoint(1990, FileReader.GetGlobalTemp(1990)),
                            new ObservablePoint(1991, FileReader.GetGlobalTemp(1991)),
                            new ObservablePoint(1992, FileReader.GetGlobalTemp(1992)),
                            new ObservablePoint(1993, FileReader.GetGlobalTemp(1993)),
                            new ObservablePoint(1994, FileReader.GetGlobalTemp(1994)),
                            new ObservablePoint(1995, FileReader.GetGlobalTemp(1995)),
                            new ObservablePoint(1996, FileReader.GetGlobalTemp(1996)),
                            new ObservablePoint(1997, FileReader.GetGlobalTemp(1997)),
                            new ObservablePoint(1998, FileReader.GetGlobalTemp(1998))
                        }
                    }
                };
            }
            else if (TimelineBar.Value >= 1999 && TimelineBar.Value < 2010)
            {
                MainGraph.Series = new SeriesCollection
                {
                    new LineSeries
                    {

                        Values = new ChartValues<ObservablePoint>
                        {
                            new ObservablePoint(1999, FileReader.GetGlobalTemp(1999)),
                            new ObservablePoint(2000, FileReader.GetGlobalTemp(2000)),
                            new ObservablePoint(2001, FileReader.GetGlobalTemp(2001)),
                            new ObservablePoint(2002, FileReader.GetGlobalTemp(2002)),
                            new ObservablePoint(2003, FileReader.GetGlobalTemp(2003)),
                            new ObservablePoint(2004, FileReader.GetGlobalTemp(2004)),
                            new ObservablePoint(2005, FileReader.GetGlobalTemp(2005)),
                            new ObservablePoint(2006, FileReader.GetGlobalTemp(2006)),
                            new ObservablePoint(2007, FileReader.GetGlobalTemp(2007)),
                            new ObservablePoint(2008, FileReader.GetGlobalTemp(2008)),
                            new ObservablePoint(2009, FileReader.GetGlobalTemp(2009))
                        }
                    }
                };
            }
            else if (TimelineBar.Value >= 2010 && TimelineBar.Value < 2021)
            {
                MainGraph.Series = new SeriesCollection
                {
                    new LineSeries
                    {

                        Values = new ChartValues<ObservablePoint>
                        {
                            new ObservablePoint(2010, FileReader.GetGlobalTemp(2010)),
                            new ObservablePoint(2011, FileReader.GetGlobalTemp(2011)),
                            new ObservablePoint(2012, FileReader.GetGlobalTemp(2012)),
                            new ObservablePoint(2013, FileReader.GetGlobalTemp(2013)),
                            new ObservablePoint(2014, FileReader.GetGlobalTemp(2014)),
                            new ObservablePoint(2015, FileReader.GetGlobalTemp(2015)),
                            new ObservablePoint(2016, FileReader.GetGlobalTemp(2016)),
                            new ObservablePoint(2017, FileReader.GetGlobalTemp(2017)),
                            new ObservablePoint(2018, FileReader.GetGlobalTemp(2018)),
                            new ObservablePoint(2019, FileReader.GetGlobalTemp(2019)),
                            new ObservablePoint(2020, FileReader.GetGlobalTemp(2020))
                        }
                    }
                };
            }
        }
        public void IceSheetsGraph()
        {
            if (TimelineBar.Value >= 2002 && TimelineBar.Value < 2012)
            {
                MainGraph.Series = new SeriesCollection
                {
                    new LineSeries
                    {

                        Values = new ChartValues<ObservablePoint>
                        {
                            new ObservablePoint(2002, FileReader.GetIceSheets(2002)),
                            new ObservablePoint(2003, FileReader.GetIceSheets(2003)),
                            new ObservablePoint(2004, FileReader.GetIceSheets(2004)),
                            new ObservablePoint(2005, FileReader.GetIceSheets(2005)),
                            new ObservablePoint(2006, FileReader.GetIceSheets(2006)),
                            new ObservablePoint(2007, FileReader.GetIceSheets(2007)),
                            new ObservablePoint(2008, FileReader.GetIceSheets(2008)),
                            new ObservablePoint(2009, FileReader.GetIceSheets(2009)),
                            new ObservablePoint(2010, FileReader.GetIceSheets(2010)),
                            new ObservablePoint(2011, FileReader.GetIceSheets(2011))
                        }
                    }
                };
            }
            else if (TimelineBar.Value >= 2012 && TimelineBar.Value < 2021)
            {
                MainGraph.Series = new SeriesCollection
                {
                    new LineSeries
                    {

                        Values = new ChartValues<ObservablePoint>
                        {

                            new ObservablePoint(2012, FileReader.GetIceSheets(2012)),
                            new ObservablePoint(2013, FileReader.GetIceSheets(2013)),
                            new ObservablePoint(2014, FileReader.GetIceSheets(2014)),
                            new ObservablePoint(2015, FileReader.GetIceSheets(2015)),
                            new ObservablePoint(2016, FileReader.GetIceSheets(2016)),
                            new ObservablePoint(2017, FileReader.GetIceSheets(2017)),
                            new ObservablePoint(2018, FileReader.GetIceSheets(2018)),
                            new ObservablePoint(2019, FileReader.GetIceSheets(2019)),
                            new ObservablePoint(2020, FileReader.GetIceSheets(2020))
                        }
                    }
                };
            }
        }
        public void ArcticSeaIceGraph()
        {
            if (TimelineBar.Value >= 1979 && TimelineBar.Value < 1989)
            {
                MainGraph.Series = new SeriesCollection
                {
                    new LineSeries
                    {

                        Values = new ChartValues<ObservablePoint>
                        {
                            new ObservablePoint(1979, FileReader.GetArcticSeaIce(1979)),
                            new ObservablePoint(1980, FileReader.GetArcticSeaIce(1980)),
                            new ObservablePoint(1981, FileReader.GetArcticSeaIce(1981)),
                            new ObservablePoint(1982, FileReader.GetArcticSeaIce(1982)),
                            new ObservablePoint(1983, FileReader.GetArcticSeaIce(1983)),
                            new ObservablePoint(1984, FileReader.GetArcticSeaIce(1984)),
                            new ObservablePoint(1985, FileReader.GetArcticSeaIce(1985)),
                            new ObservablePoint(1986, FileReader.GetArcticSeaIce(1986)),
                            new ObservablePoint(1987, FileReader.GetArcticSeaIce(1987)),
                            new ObservablePoint(1988, FileReader.GetArcticSeaIce(1988))
                        }
                    }
                };
            }
            else if (TimelineBar.Value >= 1989 && TimelineBar.Value < 1999)
            {
                MainGraph.Series = new SeriesCollection
                {
                    new LineSeries
                    {

                        Values = new ChartValues<ObservablePoint>
                        {
                            new ObservablePoint(1989, FileReader.GetArcticSeaIce(1989)),
                            new ObservablePoint(1990, FileReader.GetArcticSeaIce(1990)),
                            new ObservablePoint(1991, FileReader.GetArcticSeaIce(1991)),
                            new ObservablePoint(1992, FileReader.GetArcticSeaIce(1992)),
                            new ObservablePoint(1993, FileReader.GetArcticSeaIce(1993)),
                            new ObservablePoint(1994, FileReader.GetArcticSeaIce(1994)),
                            new ObservablePoint(1995, FileReader.GetArcticSeaIce(1995)),
                            new ObservablePoint(1996, FileReader.GetArcticSeaIce(1996)),
                            new ObservablePoint(1997, FileReader.GetArcticSeaIce(1997)),
                            new ObservablePoint(1998, FileReader.GetArcticSeaIce(1998))
                        }
                    }
                };
            }
            else if (TimelineBar.Value >= 1999 && TimelineBar.Value < 2010)
            {
                MainGraph.Series = new SeriesCollection
                {
                    new LineSeries
                    {

                        Values = new ChartValues<ObservablePoint>
                        {
                            new ObservablePoint(1999, FileReader.GetArcticSeaIce(1999)),
                            new ObservablePoint(2000, FileReader.GetArcticSeaIce(2000)),
                            new ObservablePoint(2001, FileReader.GetArcticSeaIce(2001)),
                            new ObservablePoint(2002, FileReader.GetArcticSeaIce(2002)),
                            new ObservablePoint(2003, FileReader.GetArcticSeaIce(2003)),
                            new ObservablePoint(2004, FileReader.GetArcticSeaIce(2004)),
                            new ObservablePoint(2005, FileReader.GetArcticSeaIce(2005)),
                            new ObservablePoint(2006, FileReader.GetArcticSeaIce(2006)),
                            new ObservablePoint(2007, FileReader.GetArcticSeaIce(2007)),
                            new ObservablePoint(2008, FileReader.GetArcticSeaIce(2008)),
                            new ObservablePoint(2009, FileReader.GetArcticSeaIce(2009))
                        }
                    }
                };
            }
            else if (TimelineBar.Value >= 2010 && TimelineBar.Value < 2021)
            {
                MainGraph.Series = new SeriesCollection
                {
                    new LineSeries
                    {

                        Values = new ChartValues<ObservablePoint>
                        {
                            new ObservablePoint(2010, FileReader.GetArcticSeaIce(2010)),
                            new ObservablePoint(2011, FileReader.GetArcticSeaIce(2011)),
                            new ObservablePoint(2012, FileReader.GetArcticSeaIce(2012)),
                            new ObservablePoint(2013, FileReader.GetArcticSeaIce(2013)),
                            new ObservablePoint(2014, FileReader.GetArcticSeaIce(2014)),
                            new ObservablePoint(2015, FileReader.GetArcticSeaIce(2015)),
                            new ObservablePoint(2016, FileReader.GetArcticSeaIce(2016)),
                            new ObservablePoint(2017, FileReader.GetArcticSeaIce(2017)),
                            new ObservablePoint(2018, FileReader.GetArcticSeaIce(2018)),
                            new ObservablePoint(2019, FileReader.GetArcticSeaIce(2019)),
                            new ObservablePoint(2020, FileReader.GetArcticSeaIce(2020))
                        }
                    }
                };
            }
        }
        #endregion

        private void MainGraph_DataClick(object sender, ChartPoint chartPoint)
        {
            switch (OptionsComboBox.SelectedIndex)
            {
                case 0:
                    YearLabelAns.Text = Convert.ToString(chartPoint.X);

                    AltimeterLabelText.Visible = true;      // make all relevant labels visible
                    AltimeterLabelAns.Visible = true;
                    AltimeterLabelAns.Text = Convert.ToString(FileReader.GetSeaLevel((int)chartPoint.X, 'a'));  // change the text to the corresponding information of the point clicked

                    NumericLabelText.Visible = true;
                    NumericLabelAns.Visible = true;
                    NumericLabelAns.Text = Convert.ToString(FileReader.GetSeaLevel((int)chartPoint.X, 'n'));

                    MeanLabelText.Visible = true;
                    MeanLabelAns.Visible = true;
                    MeanLabelText.Location = new Point(801, 359);
                    MeanLabelAns.Location = new Point(801, 373);
                    MeanLabelAns.Text = Convert.ToString(FileReader.GetSeaLevel((int)chartPoint.X, 'm'));

                    StDevLabelText.Visible = true;
                    StDevLabelAns.Visible = true;
                    StDevLabelText.Location = new Point(801, 392);
                    StDevLabelAns.Location = new Point(801, 406);
                    StDevLabelAns.Text = Convert.ToString(FileReader.GetSeaLevel((int)chartPoint.X, 's'));
                    break;
                case 1:
                    YearLabelAns.Text = Convert.ToString(chartPoint.X);

                    AltimeterLabelText.Visible = false;
                    AltimeterLabelAns.Visible = false;

                    NumericLabelText.Visible = false;
                    NumericLabelAns.Visible = false;

                    MeanLabelText.Visible = true;
                    MeanLabelAns.Visible = true;
                    MeanLabelText.Location = new Point(AltimeterLabelText.Location.X, AltimeterLabelText.Location.Y);
                    MeanLabelAns.Location = new Point(AltimeterLabelAns.Location.X, AltimeterLabelAns.Location.Y);
                    MeanLabelAns.Text = Convert.ToString(FileReader.GetGlobalCO2((int)chartPoint.X, 'm'));

                    StDevLabelText.Visible = true;
                    StDevLabelAns.Visible = true;
                    StDevLabelText.Location = new Point(NumericLabelText.Location.X, NumericLabelText.Location.Y);
                    StDevLabelAns.Location = new Point(NumericLabelAns.Location.X, NumericLabelAns.Location.Y);
                    StDevLabelAns.Text = Convert.ToString(FileReader.GetGlobalCO2((int)chartPoint.X, 's'));
                    break;
                case 2:
                    YearLabelAns.Text = Convert.ToString(chartPoint.X);

                    AltimeterLabelText.Visible = false;
                    AltimeterLabelAns.Visible = false;

                    NumericLabelText.Visible = false;
                    NumericLabelAns.Visible = false;

                    MeanLabelText.Visible = true;
                    MeanLabelAns.Visible = true;
                    MeanLabelText.Location = new Point(AltimeterLabelText.Location.X, AltimeterLabelText.Location.Y);
                    MeanLabelAns.Location = new Point(AltimeterLabelAns.Location.X, AltimeterLabelAns.Location.Y);
                    MeanLabelAns.Text = Convert.ToString(FileReader.GetGlobalTemp((int)chartPoint.X));

                    StDevLabelText.Visible = false;
                    StDevLabelAns.Visible = false;
                    break;
                case 3:
                    YearLabelAns.Text = Convert.ToString(chartPoint.X);

                    AltimeterLabelText.Visible = false;
                    AltimeterLabelText.Visible = false;

                    NumericLabelText.Visible = false;
                    NumericLabelAns.Visible = false;

                    MeanLabelText.Visible = true;
                    MeanLabelAns.Visible = true;
                    MeanLabelText.Location = new Point(AltimeterLabelText.Location.X, AltimeterLabelText.Location.Y);
                    MeanLabelAns.Location = new Point(AltimeterLabelAns.Location.X, AltimeterLabelAns.Location.Y);
                    MeanLabelAns.Text = Convert.ToString(FileReader.GetGlobalTemp((int)chartPoint.X));

                    StDevLabelText.Visible = false;
                    StDevLabelAns.Visible = false;
                    break;
                case 4:
                    YearLabelAns.Text = Convert.ToString(chartPoint.X);

                    AltimeterLabelText.Visible = false;
                    AltimeterLabelAns.Visible = false;

                    NumericLabelText.Visible = false;
                    NumericLabelAns.Visible = false;

                    MeanLabelText.Visible = true;
                    MeanLabelAns.Visible = true;
                    MeanLabelText.Location = new Point(AltimeterLabelText.Location.X, AltimeterLabelText.Location.Y);
                    MeanLabelAns.Location = new Point(AltimeterLabelAns.Location.X, AltimeterLabelAns.Location.Y);
                    MeanLabelAns.Text = Convert.ToString(FileReader.GetArcticSeaIce((int)chartPoint.X));

                    StDevLabelText.Visible = false;
                    StDevLabelAns.Visible = false;
                    break;
            }
        }

        private void Timeline_Bar_MouseHover(object sender, EventArgs e)
        {
            TimelineBarToolTip.SetToolTip(TimelineBar, Convert.ToString(TimelineBar.Value));    // display current year as a tooltip
        }

        private void GlobeImageBox_Click(object sender, EventArgs e)
        {
            infolabel.Text = Convert.ToString(Cursor.Position);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)   // coordinate locator
        {
            if (e.KeyCode == Keys.A)
            {
                PointLabel.Location = new Point(PointLabel.Location.X - 1, PointLabel.Location.Y);
                infolabel3.Text = Convert.ToString(PointLabel.Location);
            }
            else if (e.KeyCode == Keys.D)
            {
                PointLabel.Location = new Point(PointLabel.Location.X + 1, PointLabel.Location.Y);
                infolabel3.Text = Convert.ToString(PointLabel.Location);
            }
            else if (e.KeyCode == Keys.W)
            {
                PointLabel.Location = new Point(PointLabel.Location.X, PointLabel.Location.Y - 1);
                infolabel3.Text = Convert.ToString(PointLabel.Location);
            }
            else if (e.KeyCode == Keys.S)
            {
                PointLabel.Location = new Point(PointLabel.Location.X, PointLabel.Location.Y + 1);
                infolabel3.Text = Convert.ToString(PointLabel.Location);
            }
        }

        private void Draw_Circles()
        {
            if (yearchanged)
            {
                string[] countrynames = new string[] { "China", "United States" , "India" , "Russian Federation" , "Japan" , "Germany" , "Islamic Republic of Iran" ,
                    "South Korea" ,"Saudi Arabia" , "Indonesia" , "Canada" , "Mexico" , "South Africa", "Brazil" , "Turkey" , "Australia" , "United Kingdom" , "Poland" ,
                    "France" , "Italy" };

                Bitmap btm = new Bitmap(GlobeImageBox.Size.Width, GlobeImageBox.Size.Height);   // creating a blank bitmap to draw on
                Graphics g = Graphics.FromImage(btm);       // assigning graphics to the bitmap

                foreach (string s in countrynames)
                {
                    pen.Color = Calculations.GetEmissionColour(s, TimelineBar.Value, pen.Color);    // changing colour based on coiuntry emmisions
                    g.DrawEllipse(pen, FileReader.GetXCoordinate(s) - FileReader.GetDiameter(s) / 2, FileReader.GetYCoordinate(s) -  FileReader.GetDiameter(s) / 2, FileReader.GetDiameter(s), FileReader.GetDiameter(s));
                }

                GlobeImageBox.Image = btm;      // making the bitmap the main image
                yearchanged = false;
            }
        }

        private void DrawBtn_Click(object sender, EventArgs e)
        {
            if (OptionsComboBox.SelectedIndex == 1)
            {
                Draw_Circles();
            }
        }

        private void Demo()
        {
            //infolabel.Visible = false;
            //infolabel2.Visible = false;
            //infolabel3.Visible = false;
            //PointLabel.Visible = false;
        }
    }
}
