using Microsoft.Data.Analysis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Timer = System.Timers.Timer;


namespace InvestingIncubator
{
    public partial class Form2 : Form
    {
        string sharename = "";
        private static Timer loopTimer;

        public Form2(string sharename)
        {
            InitializeComponent();
            this.sharename = sharename;
            loopTimer = new Timer();
            chart1.Series["Series1"].IsVisibleInLegend = false;
            chart2.Series["Series1"].IsVisibleInLegend = false;
        }
        const float segmentsize = 320f/100f;
        private void WriteSliderData()
        {
            int lower = (int)Math.Round(sliderLine1.Location.X / segmentsize)-16;
            int upper = (int)Math.Round(sliderLine2.Location.X / segmentsize)-16;

            float lowervalue = activeShareValues[lower-1];
            float uppervalue = activeShareValues[upper-1];

            slider1Val.Text = lowervalue.ToString();
            slider2Val.Text = uppervalue.ToString();
            float percentage = ((((float)uppervalue) - (float)(lowervalue)) / ((float)uppervalue)) * 100f;
            percentagediff1.Text = percentage + "%";
            if (percentage >= 0)
            {
                percentagediff1.Text.Insert(0, "+");
                percentagediff1.ForeColor = Color.Green;
            }
            else
            {
                percentagediff1.Text.Insert(0, "-");
                percentagediff1.ForeColor = Color.Red;
            }





            if (activeShareValues2.Count == 100) 
            {
                float lowervalue2 = activeShareValues2[lower - 1];
                float uppervalue2 = activeShareValues2[upper - 1];

                slider3Val.Text = lowervalue2.ToString();
                slider4Val.Text = uppervalue2.ToString();
                float percentage2 = ((((float)uppervalue2) - (float)(lowervalue2)) / ((float)uppervalue2)) * 100f;
                percentageDiff2.Text = percentage2 + "%";
                if (percentage2 >= 0)
                {
                    percentageDiff2.Text.Insert(0, "+");
                    percentageDiff2.ForeColor = Color.Green;
                }
                else
                {
                    percentageDiff2.Text.Insert(0, "-");
                    percentageDiff2.ForeColor = Color.Red;
                }
            }
        }
        private void mouseDownEvent(object sender, MouseEventArgs e)
        {
            loopTimer.Enabled = true;
        }
        private void mouseUpEvent(object sender, MouseEventArgs e)
        {
            loopTimer.Enabled = false;
        }
        List<float> activeShareValues = new List<float>();
        List<float> activeShareValues2 = new List<float>();

        public void ShowGraph()
        {

            DataFrame df = DataFrame.LoadCsv(@"C:\Users\chris\source\repos\InvestingIncubator\InvestingIncubator\bin\Debug\Stocks\" + sharename + ".csv");
            var closevals = df.Columns[4];
            foreach (var item in closevals)
            {
                if (item is string)
                {
                    continue;
                }
                activeShareValues.Add((float)item);
            }
            chart1.ChartAreas[0].AxisY.Minimum = Math.Floor(activeShareValues.Min());
            for (int i = 0; i < activeShareValues.Count; ++i)
            {
                chart1.Series["Series1"].Points.AddXY(i+1, activeShareValues[i]);
            }
            WriteSliderData();
            sharename1.Text = sharename;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ShowGraph();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Visible == false)
            {
                string[] files = Directory.GetFiles(@"C:\Users\chris\source\repos\InvestingIncubator\InvestingIncubator\bin\Debug\Stocks");
                foreach (var file in files)
                {
                    string data = file.Split('.')[0];
                    comboBox1.Items.Add(data.Split(new string[] { "\\Stocks\\" }, StringSplitOptions.None)[1]);
                }
                comboBox1.Visible = true;
            }
            else
            {
                DataFrame df = DataFrame.LoadCsv(@"C:\Users\chris\source\repos\InvestingIncubator\InvestingIncubator\bin\Debug\Stocks\" + comboBox1.SelectedItem.ToString() + ".csv");
                var closevals = df.Columns[4];
                foreach (var item in closevals)
                {
                    if (item is string)
                    {
                        continue;
                    }
                    activeShareValues2.Add((float)item);
                }
                chart2.ChartAreas[0].AxisY.Minimum = Math.Floor(activeShareValues2.Min());
                for (int i = 0; i < activeShareValues2.Count; ++i)
                {
                    chart2.Series["Series1"].Points.AddXY(i + 1, activeShareValues2[i]);
                }
                chart2.Visible = true;
                comboBox1.Visible = false;

                sliderLine3.Visible = true;
                sliderLine4.Visible = true;
                sliderLine3.BringToFront();
                sliderLine4.BringToFront();
                RecalculateSliderPositions();
                WriteSliderData();
                sharename2.Text = comboBox1.SelectedItem.ToString();
                label1.Visible = true;
                label2.Visible = true;
            }
        }

        private void RecalculateSliderPositions()
        {
           sliderLine3.Location = new Point(sliderLine1.Location.X+ 471, sliderLine1.Location.Y);
           sliderLine4.Location = new Point(sliderLine2.Location.X+ 471, sliderLine2.Location.Y);
        }
        public static int slidersPlaced = 0;

        private void chart1_MouseUp(object sender, MouseEventArgs e)
        {
            Slider.Reset(((Chart)sender).CreateGraphics());
        }
        bool _capturingMoves1 = false;
        bool _capturingMoves2 = false;
        private void sliderHandle2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _capturingMoves2 = true;
            }
        }

        const int minSlider = 44;
        const int maxSlider = 364;
        const int minSliderSpace = 1;
        const int sliderHandleWidth = 8;
        
        private void sliderHandle2_MouseMove(object sender, MouseEventArgs e)
        {
            var xVal = PointToClient(System.Windows.Forms.Cursor.Position).X;
            if (_capturingMoves2 && xVal > minSlider && xVal < maxSlider && xVal > sliderHandle1.Left + minSliderSpace + sliderHandleWidth)
            {
                sliderHandle2.Left = xVal;
                sliderLine2.Left = sliderHandle2.Left;
                RecalculateSliderPositions();
                WriteSliderData();
            }
        }

        private void sliderHandle2_MouseUp(object sender, MouseEventArgs e)
        {
            _capturingMoves2 = false;
        }

        private void sliderHandle1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _capturingMoves1 = true;
            }
        }

        private void sliderHandle1_MouseMove(object sender, MouseEventArgs e)
        {
            var xVal = PointToClient(System.Windows.Forms.Cursor.Position).X;
            if (_capturingMoves1 && xVal > minSlider && xVal < maxSlider && xVal < sliderHandle2.Left - minSliderSpace - sliderHandleWidth)
            {
                sliderHandle1.Left = xVal;
                sliderLine1.Left = sliderHandle1.Left + sliderHandleWidth;
                RecalculateSliderPositions();
                WriteSliderData();
            }
        }

        private void sliderHandle1_MouseUp(object sender, MouseEventArgs e)
        {
            _capturingMoves1 = false;
        }

    }
    public class Slider
    {
        public static List<Slider> sliders = new List<Slider>();


        public List<PointF> bounds; //The area in which the selected slider can be moved
        public Brush topbrush;  //The colour of the slider
        public Brush bodybrush; //The colour of the sliderbody
        public int centre;
        Chart chart;
        float segmentsize = 225f/100f;

        public int XLocation
        {
            get
            {
                return (int)Math.Round((centre-50) / segmentsize);
            }
        }

        public Slider(List<PointF> bounds, Graphics currGraphics, Brush topbrush, Brush bodybrush, int centre, Chart chart)
        {
            sliders.Add(this);

            this.chart = chart;
            this.bounds = bounds;
            this.topbrush = topbrush;
            this.bodybrush = bodybrush;
            this.centre = centre;
            currGraphics.FillRectangle(bodybrush, centre, 19, 2, 243);
            currGraphics.FillPolygon(topbrush, bounds.ToArray());
        }
        public bool mouseWasDown = false;
        public void Redraw(Graphics g, int newCentre)
        {
            chart.Invalidate();
            int oldcentre = centre;
            centre = newCentre;
            for (int i = 0; i < bounds.Count; ++i)
            {
                var newx = bounds[i].X + (newCentre - oldcentre);
                bounds[i] = new PointF(newx, bounds[i].Y);
            }
            foreach (var slider in sliders)
            {
                slider.Redraw(g);
            }
        }
        public void Redraw(Graphics g)
        {
            g.FillRectangle(bodybrush, centre, 19, 2, 243);
            g.FillPolygon(topbrush, bounds.ToArray());
        }
        public static void Redraw(Graphics newGraphics, Point mousepos)
        {
            foreach (var slider in sliders)
            {
                if (slider.bounds.Select(p=>p.X).Min() <= mousepos.X && slider.bounds.Select(p => p.Y).Min() <= mousepos.Y &&
                    slider.bounds.Select(p => p.X).Max() >= mousepos.X && slider.bounds.Select(p => p.Y).Max() >= mousepos.Y &&
                    slider.mouseWasDown == false)
                {
                    slider.mouseWasDown = true;
                }
                else if(slider.mouseWasDown == true && sliders.Where(s=>s.mouseWasDown == true).Count()==1)
                {
                    slider.Redraw(newGraphics, mousepos.X);
                }
            }
        }
        public static void Reset(Graphics g)
        {
            foreach (var slider in sliders)
            {
                slider.mouseWasDown = false;
                slider.Redraw(g);
            }
        }
    }
}
