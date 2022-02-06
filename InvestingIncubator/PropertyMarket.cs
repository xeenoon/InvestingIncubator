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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
