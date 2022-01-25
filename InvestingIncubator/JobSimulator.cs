using InvestingIncubator.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            CreateJob(Job.JobType.RocketSurgeon);
            CreateJob(Job.JobType.CarSalesman);
            CreateJob(Job.JobType.Cook);
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
            UpdateDescription();
        }

        public void UpdateDescription()
        {
            List<string> file = File.ReadAllLines("jobdata.txt").ToList();
            List<Job.JobType> jobtypes = new List<Job.JobType>();
            foreach (var line in file)
            {
                jobtypes.Add(Job.Parse(line));
            }
            label2.Text = Job.Jobs[jobtypes[0]].ToString();
            jobtypes.RemoveAt(0);
            label2.Text = label2.Text.Substring(0, label2.Text.PositionOf("Prerequisite") + 1);
            label2.Text += "\nPrevious jobs: \n";
            foreach (var job in jobtypes)
            {
                label2.Text += "    -";
                label2.Text += Job.Jobs[job].jobTitle;
                label2.Text += '\n';
            }
        }

        public void CreateJob(Job.JobType jobType)
        {
            var jobItem = new JobItem(Job.Jobs[jobType]);
            flowLayoutPanel1.Controls.Add(jobItem);
            jobItem.Location = new Point(3, 3);
            jobItem.Name = "jobItem1";
            jobItem.Size = new Size(200, 22);
            jobItem.TabIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
