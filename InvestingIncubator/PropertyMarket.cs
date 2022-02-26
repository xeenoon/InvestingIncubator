using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvestingIncubator
{
    public partial class PropertyMarket : Form
    {
        public PropertyMarket()
        {
            InitializeComponent();
        }

        private void PropertyMarket_Paint(object sender, PaintEventArgs e)
        {
            CheckBoundries(ref minOverallStars, 0, 5, minOverallStars_Text);
            CheckBoundries(ref maxOverallStars, 0, 5, maxOverallStars_Text);
            CheckBoundries(ref minRoomStars, 0, 5, minRoomStars_Text);
            CheckBoundries(ref maxRoomStars, 0, 5, maxRoomStars_Text);

            CheckBoundries(ref minAuction, 0, 10000000, minAuction_Text);
            CheckBoundries(ref maxAuction, 0, 10000000, maxAuction_Text);
            CheckBoundries(ref minBuyNow, 0, 10000000, minBuyNow_Text);
            CheckBoundries(ref maxBuyNow, 0, 10000000, maxBuyNow_Text);

            CheckBoundries(ref minLand,   0, 10000, minLandsize_Text);
            CheckBoundries(ref maxLand,   0, 10000, maxLandsize_Text);
            CheckBoundries(ref minUnused, 0, 10000, minUnusedLand_Text);
            CheckBoundries(ref maxUnused, 0, 10000, maxUnusedLand_Text);

            CheckBoundries(ref minBathrooms, 0, 9, minBathrooms_Text);
            CheckBoundries(ref maxBathrooms, 0, 9, maxBathrooms_Text);
            CheckBoundries(ref minBedrooms, 0, 9, minBedrooms_Text);
            CheckBoundries(ref maxBedrooms, 0, 9, maxBedrooms_Text);
            CheckBoundries(ref minDinings, 0, 9, minDinings_Text);
            CheckBoundries(ref maxDinings, 0, 9, maxDinings_Text);
            CheckBoundries(ref minLounges, 0, 9, minLounges_Text);
            CheckBoundries(ref maxLounges, 0, 9, maxLounges_Text);

            CheckBoundries(ref minAreaStars, 0, 9, minAreaStars_Text);
            CheckBoundries(ref maxAreaStars, 0, 9, maxAreaStars_Text);
            return;
            Random rnd = new Random();
            House house = House.Random();
            foreach (var rect in house.rooms)
            {
                int x = 100 + rect.area.X * 3;
                int y = 100 + rect.area.Y * 3;
                Rectangle place = new Rectangle(new Point(x, y), new Size(rect.area.Size.Width*3, rect.area.Size.Height*3));
                Color randomColor;
                if (rect.IsPublic()) 
                {
                    randomColor = Color.FromArgb(0, 0, 0);
                }
                else
                {
                    randomColor = Color.FromArgb(255, 0, 0);
                }
                e.Graphics.DrawString(rect.roomType.ToString(), new Font(FontFamily.GenericSansSerif, 10), new Pen(randomColor).Brush, x,y);
                e.Graphics.DrawRectangle(new Pen(randomColor, 2), place);
            }
        }

        private void CheckBoundries(ref int num, int low, int high, TextBox textbox)
        {
            num = num <= low ? low : num;
            num = num >= high ? high : num;
            textbox.Text = string.Format("{0:n0}", num);
        }

        public int minOverallStars;
        public int maxOverallStars;

        public int minRoomStars;
        public int maxRoomStars;
        private void StarsIncrement(object sender, EventArgs e)
        {
            switch (((Control)sender).Name)
            {
                case "starsdec1":
                    minOverallStars--;
                    break;
                case "starsdec2":
                    maxOverallStars--;
                    break;
                case "starsdec3":
                    minRoomStars--;
                    break;
                case "starsdec4":
                    maxRoomStars--;
                    break;

                case "starsinc1":
                    minOverallStars++;
                    break;
                case "starsinc2":
                    maxOverallStars++;
                    break;
                case "starsinc3":
                    minRoomStars++;
                    break;
                case "starsinc4":
                    maxRoomStars++;
                    break;
            }
            Invalidate();
        }
        private void StarsChanged(object sender, EventArgs e)
        {
            var textbox = (TextBox)sender;
            textbox.Text = RemoveChars(textbox.Text);
            if (textbox.Text != "0" && textbox.Text != "" && textbox.Text[0] == '0')
            {
                textbox.Text = textbox.Text.Substring(1);
            }
            if (textbox.Text != "0" && textbox.Text != "" && textbox.Text.Length == 2)
            {
                textbox.Text = textbox.Text.Substring(0, 1);
            }
            try
            {
                if (int.Parse(textbox.Text) >= 5)
                {
                    textbox.Text = "5";
                }
                else if (int.Parse(textbox.Text) <= 0)
                {
                    textbox.Text = "0";
                }
            }
            catch
            {
                textbox.Text = "0";
            }
            var num = int.Parse(RemoveChars(textbox.Text, ','));
            switch (((Control)sender).Name)
            {
                case "minOverallStars_Text":
                    minOverallStars = num;
                    break;
                case "maxOverallStars_Text":
                    maxOverallStars = num;
                    break;
                case "minRoomStars_Text":
                    minRoomStars = num;
                    break;
                case "maxRoomStars_Text":
                    maxRoomStars = num;
                    break;
            }
        }
        public string RemoveChars(string text)
        {
            string result = "";
            foreach (var c in text)
            {
                if (char.IsDigit(c) || c == ',')
                {
                    result += c;
                }
            }
            return result;
        }
        int minAuction;
        int maxAuction;

        int minBuyNow;
        int maxBuyNow;

        private void PriceIncrement(object sender, EventArgs e)
        {
            switch (((Control)sender).Name)
            {
                case "pricedec1":
                    minAuction-=100000;
                    break;
                case "pricedec2":
                    maxAuction -= 100000;
                    break;
                case "pricedec3":
                    minBuyNow -= 100000;
                    break;
                case "pricedec4":
                    maxBuyNow -= 100000;
                    break;

                case "priceinc1":
                    minAuction += 100000;
                    break;
                case "priceinc2":
                    maxAuction += 100000;
                    break;
                case "priceinc3":
                    minBuyNow += 100000;
                    break;
                case "priceinc4":
                    maxBuyNow += 100000;
                    break;
            }
            Invalidate();
        }
        private void PriceChanged(object sender, EventArgs e)
        {
            var textbox = (TextBox)sender;
            int caretPos = textbox.SelectionStart;
            textbox.Text = RemoveChars(textbox.Text);
            if (textbox.Text != "0" && textbox.Text != "" && textbox.Text[0] == '0')
            {
                textbox.Text = textbox.Text.Substring(1);
            }
            try
            {
                var text = RemoveChars(textbox.Text, ',');
                if (int.Parse(text) >= 10000000)
                {
                    text = "10000000";
                }
                else if (int.Parse(text) <= 0)
                {
                    text = "0";
                }
                textbox.Text = string.Format("{0:n0}", int.Parse(text));
            }
            catch
            {
                textbox.Text = "0";
            }
            textbox.SelectionStart = caretPos;
            var num = int.Parse(RemoveChars(textbox.Text, ','));
            switch (((Control)sender).Name)
            {
                case "minAuction_Text":
                    minAuction = num;
                    break;
                case "maxAuction_Text":
                    maxAuction = num;
                    break;
                case "minBuyNow_Text":
                    minBuyNow = num;
                    break;
                case "maxBuyNow_Text":
                    maxBuyNow = num;
                    break;
            }
        }

        int minLand;
        int maxLand;

        int minUnused;
        int maxUnused;
        private void SizeIncrement(object sender, EventArgs e)
        {
            switch (((Control)sender).Name)
            {
                case "sizedec1":
                    minLand -= 200;
                    break;
                case "sizedec2":
                    maxLand -= 200;
                    break;
                case "sizedec3":
                    minUnused -= 200;
                    break;
                case "sizedec4":
                    maxUnused -= 200;
                    break;

                case "sizeinc1":
                    minLand += 200;
                    break;
                case "sizeinc2":
                    maxLand += 200;
                    break;
                case "sizeinc3":
                    minUnused += 200;
                    break;
                case "sizeinc4":
                    maxUnused += 200;
                    break;
            }
            Invalidate();
        }
        private void LandSizeChanged(object sender, EventArgs e)
        {
            var textbox = (TextBox)sender;
            int caretPos = textbox.SelectionStart;
            textbox.Text = RemoveChars(textbox.Text);
            if (textbox.Text != "0" && textbox.Text != "" && textbox.Text[0] == '0')
            {
                textbox.Text = textbox.Text.Substring(1);
            }
            try
            {
                var text = RemoveChars(textbox.Text, ',');
                if (int.Parse(text) >= 10000)
                {
                    text = "10000";
                }
                else if (int.Parse(text) <= 0)
                {
                    text = "0";
                }
                textbox.Text = string.Format("{0:n0}", int.Parse(text));
            }
            catch
            {
                textbox.Text = "0";
            }
            textbox.SelectionStart = caretPos;
            var num = int.Parse(RemoveChars(textbox.Text, ','));
            switch (((Control)sender).Name)
            {
                case "minLandsize_Text":
                    minLand = num;
                    break;
                case "maxLandsize_Text":
                    maxLand = num;
                    break;
                case "minUnusedLand_Text":
                    minUnused = num;
                    break;
                case "maxUnusedLand_Text":
                    maxUnused = num;
                    break;
            }
        }

        int minBathrooms;
        int maxBathrooms;

        int minBedrooms;
        int maxBedrooms;

        int minDinings;
        int maxDinings;

        int minLounges;
        int maxLounges;

        private void RoomIncrement(object sender, EventArgs e)
        {
            switch (((Control)sender).Name)
            {
                case "roomsdec1":
                    minBathrooms -= 1;
                    break;
                case "roomsdec2":
                    maxBathrooms -= 1;
                    break;
                case "roomsdec3":
                    minBedrooms -= 1;
                    break;
                case "roomsdec4":
                    maxBedrooms -= 1;
                    break;
                case "roomsdec5":
                    minDinings -= 1;
                    break;
                case "roomsdec6":
                    maxDinings -= 1;
                    break;
                case "roomsdec7":
                    minLounges -= 1;
                    break;
                case "roomsdec8":
                    maxLounges -= 1;
                    break;


                case "roomsinc1":
                    minBathrooms += 1;
                    break;
                case "roomsinc2":
                    maxBathrooms += 1;
                    break;
                case "roomsinc3":
                    minBedrooms += 1;
                    break;
                case "roomsinc4":
                    maxBedrooms += 1;
                    break;
                case "roomsinc5":
                    minDinings += 1;
                    break;
                case "roomsinc6":
                    maxDinings += 1;
                    break;
                case "roomsinc7":
                    minLounges += 1;
                    break;
                case "roomsinc8":
                    maxLounges += 1;
                    break;
            }
            Invalidate();
        }
        private void RoomsChanged(object sender, EventArgs e)
        {
            var textbox = (TextBox)sender;
            int caretPos = textbox.SelectionStart;
            textbox.Text = RemoveChars(textbox.Text);
            if (textbox.Text != "0" && textbox.Text != "" && textbox.Text[0] == '0')
            {
                textbox.Text = textbox.Text.Substring(1);
            }
            if (textbox.Text != "0" && textbox.Text != "" && textbox.Text.Length == 2)
            {
                textbox.Text = textbox.Text.Substring(0,1);
            }
            try
            {
                var text = RemoveChars(textbox.Text, ',');
                if (int.Parse(text) >= 9)
                {
                    text = "9";
                }
                else if (int.Parse(text) <= 0)
                {
                    text = "0";
                }
                textbox.Text = string.Format("{0:n0}", int.Parse(text));
            }
            catch
            {
                textbox.Text = "0";
            }
            textbox.SelectionStart = caretPos;
            var num = int.Parse(RemoveChars(textbox.Text, ','));
            switch (((Control)sender).Name)
            {
                case "minBathrooms_Text":
                    minBathrooms = num;
                    break;
                case "maxBathrooms_Text":
                    maxBathrooms = num;
                    break;
                case "minBedrooms_Text":
                    minBedrooms = num;
                    break;
                case "maxBedrooms_Text":
                    maxBedrooms = num;
                    break;
                case "minDinings_Text":
                    minDinings = num;
                    break;
                case "maxDinings_Text":
                    maxDinings = num;
                    break;
                case "minLounges_Text":
                    minLounges = num;
                    break;
                case "maxLounges_Text":
                    maxLounges = num;
                    break;
            }
        }
        public int minAreaStars;
        public int maxAreaStars;
        private void AreaIncrement(object sender, EventArgs e)
        {
            switch (((Control)sender).Name)
            {
                case "areadec1":
                    minAreaStars--;
                    break;
                case "areadec2":
                    maxAreaStars--;
                    break;

                case "areainc1":
                    minAreaStars++;
                    break;
                case "areainc2":
                    maxAreaStars++;
                    break;
            }
            Invalidate();
        }
        private void AreaStarsChanged(object sender, EventArgs e)
        {
            var textbox = (TextBox)sender;
            textbox.Text = RemoveChars(textbox.Text);
            if (textbox.Text != "0" && textbox.Text != "" && textbox.Text[0] == '0')
            {
                textbox.Text = textbox.Text.Substring(1);
            }
            if (textbox.Text != "0" && textbox.Text != "" && textbox.Text.Length == 2)
            {
                textbox.Text = textbox.Text.Substring(0, 1);
            }
            try
            {
                if (int.Parse(textbox.Text) >= 5)
                {
                    textbox.Text = "5";
                }
                else if (int.Parse(textbox.Text) <= 0)
                {
                    textbox.Text = "0";
                }
            }
            catch
            {
                textbox.Text = "0";
            }
            var num = int.Parse(RemoveChars(textbox.Text, ','));
            switch (((Control)sender).Name)
            {
                case "minAreaStars_Text":
                    minAreaStars = num;
                    break;
                case "maxAreaStars_Text":
                    maxAreaStars = num;
                    break;
            }
        }
        public string RemoveChars(string s, char remove)
        {
            string result = "";
            foreach (var c in s)
            {
                if (c != remove)
                {
                    result += c;
                }
            }
            return result;
        }
    }
}
