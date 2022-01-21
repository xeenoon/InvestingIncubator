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
    public partial class JobItem : UserControl
    {
        // Declare an event
        [Category("Action")]
        [Description("Fires when dropdownmenu is clicked")]
        public event EventHandler DropDown;
        protected virtual void ClickTrigger()
        {
            // Raise the event
            DropDown?.Invoke(this, EventArgs.Empty);
        }
        public Job job;
        public JobItem(Job job)
        {
            InitializeComponent();
            this.job = job;
            Font f = new Font("Microsoft Tai Le", 12);
            label1.Text = job.ToString();
            name1.Text = job.jobTitle;
            label1.Size = new Size(label1.Width, (int)Math.Ceiling(CreateGraphics().MeasureString(job.ToString(), f, label1.Width).Height));
        }
        private void DropdownClick(object sender, EventArgs e)
        {
            ClickTrigger();
            if (panel1.Height > label1.Height) //Collapse
            {
                panel1.Height = 10;
                pictureBox1.Image = (Image)Resources.ResourceManager.GetObject("Expand");
            }
            else
            {
                panel1.Height = label1.Height + 25;
                pictureBox1.Image = (Image)Resources.ResourceManager.GetObject("Collapse");
            }
            Height = panel1.Height + 12;
        }
    }
    public class Job
    {
        public static Job RubbishCollector = new Job("Rubbish collector", "Pick up trash on the sidewalk", 500f);
        public static Job Waiter = new Job("Waiter", "Serve food and drinks at a resturant", 1000f);
        public static Job RocketSurgeon = new Job("Rocket surgeon", "Build rockets for some real rich dude", 50000f);

        public string jobTitle;
        public string jobDescription;
        public float payment;
        public List<Job> prerequisites = new List<Job>();

        public Job(string jobTitle, string jobDescription, float payment, List<Job> prerequisites)
        {
            this.jobTitle = jobTitle;
            this.jobDescription = jobDescription;
            this.payment = payment;
            this.prerequisites = prerequisites;
        }
        public Job(string jobTitle, string jobDescription, float payment)
        {
            this.jobTitle = jobTitle;
            this.jobDescription = jobDescription;
            this.payment = payment;
        }

        public override string ToString()
        {
            string prev = "";
            foreach (var item in prerequisites)
            {
                prev += item;
                prev += ',';
            }
            if (prev != "")
            {
                prev = prev.Substring(0, prev.Length - 1);
            }
            else
            {
                prev = "None";
            }
            return string.Format("Job title: {0}\nJob description: {1}\nPayment weekly: {2}\nPrerequisites: {3}", jobTitle, jobDescription, payment, prev);
        }
    }
}
