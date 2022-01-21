using InvestingIncubator.Properties;
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
    public partial class JobSimulator : Form
    {
        public JobSimulator()
        {
            InitializeComponent();
        }
        
        private void DropdownClick(object sender, EventArgs e)
        {
            int index = FindInt(((Control)sender).Name);


            var panel = Controls.Find("panel" + index, true).FirstOrDefault();
            var textbox = Controls.Find("label" + index, true).FirstOrDefault();
            var dropdown = (PictureBox)sender;

            if (panel.Height > textbox.Height) //Collapse
            {
                panel.Height = 10;
                dropdown.Image = (Image)Resources.ResourceManager.GetObject("Expand");
                foreach (var c in Controls)
                {
                    var control = (Control)c;
                    if (FindInt(control.Name) > index) //number is larger
                    {
                        control.Location = new Point(control.Location.X, control.Location.Y - textbox.Height - 25);
                    }
                }
            }
            else
            {
                panel.Height = textbox.Height + 25;
                dropdown.Image = (Image)Resources.ResourceManager.GetObject("Collapse");
                foreach (var c in Controls)
                {
                    var control = (Control)c;
                    if (FindInt(control.Name) > index) //number is larger
                    {
                        control.Location = new Point(control.Location.X, control.Location.Y + textbox.Height + 25);
                    }
                }
            }
        }
        public int FindInt(string name)
        {
            string result = "";
            foreach (var c in name)
            {
                if (char.IsNumber(c))
                {
                    result += c;
                }
            }
            try
            {
                return int.Parse(result);
            }
            catch
            {
                return 0;
            }
        }

        private void JobSimulator_Load(object sender, EventArgs e)
        {

        }
        int timesdone = 0;
        float finalheight;
        bool first;
        private void flowLayoutPanel1_ClientSizeChanged(object sender, EventArgs e)
        {
        //    if(flowLayoutPanel1.HorizontalScroll.Visible)
        //    {
                //              int bob = 3;
                //             foreach (var item in flowLayoutPanel1.Controls)
                //            {
                //               bob += ((Control)item).Height * 2;
                //          }
                int bob = 3;
                foreach (var item in flowLayoutPanel1.Controls)
                {
                    Control ctrl = ((Control)item);
                    if (ctrl.Left > 500)
                    {
                        int fred = ctrl.Top + ctrl.Height;
                        if (fred > bob)
                        {
                            bob = fred;
                        }
                    }
                }
            if (bob > 3)
            {
                flowLayoutPanel1.Height += bob;
                timesdone++;
                label1.Text = timesdone.ToString();
            }
        //    }
            if (timesdone == 111)
            {

            }
        }
    }
}
