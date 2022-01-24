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
            Font f = new Font("Microsoft Tai Le", 10);
            label1.Text = job.ToString();
            name1.Text = job.jobTitle;
            label1.Size = new Size(label1.Width, (int)Math.Ceiling(CreateGraphics().MeasureString(job.ToString(), f, label1.Width).Height + 10));
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
        public string jobTitle;
        public string jobDescription;
        public float payment;

        public List<JobType> prerequisites = new List<JobType>();
        public static List<Job> jobs = new List<Job>();

        public static Dictionary<JobType, Job> Jobs = new Dictionary<JobType, Job>();

        public enum JobType
        {
            RubbishCollector,
            Waiter,
            RocketSurgeon,
            FactoryWorker,
            FactorySupervisor,
            FactoryManager,
            CarSalesman,
            Cook,
            HeadChef,
            JuniorProgrammer,
            Programmer,
            SeniorProgrammer,
            ProgrammingManager,
            Accountant,
            TaxAccountant,
            SeniorTaxAccountant,
            TaxInvestigator,
            SeniorTaxInvestigator,
            AccountingManager,
            Plumber,
            InternDoctor,
            Resident,
            Attending,
            Surgeon,
            HeartSurgeon,
            PediatricSurgeon,
            BrainSurgeon,
            CasualGamer,
            TryHardGamer,
            ProGamer,
            VideoGameMaker,
            VideoGameDesigner,
            VideoGameCompanyManager,
            Pharmicist,
            PharmacyOwner,
            JuniorPharmasuticalResearcher,
            PharmasuticalResearcher,
            JuniorEngineer,
            Engineer,
            SeniorEngineer,
            EngineeringManager,
            Scientest,
            CorporateScientest,
            AIResearcher,
            SelfDriveCarDesigner,
            AIRocketeer,
            BurgerFlipper,
            SandwichMaker,
            SandwichDesigner,
            FastFoodChainOwner,
            FastFoodFranchise,
            Receptionist,
            ComputerSalesman,
            Policeman,
            FederalAgent,
            IntelligenceAnalyst,
            Spy,
            Superspy,
            Lawyer,
            JuniorLawyer,
            LawPartner,
            Judge,
        }

        public static void PopulateJobs()
        {
            Jobs.Add(JobType.RubbishCollector, new Job("Rubbish collector", "Pick up trash on the sidewalk", 500f));
            Jobs.Add(JobType.Waiter, new Job("Waiter", "Serve food and drinks at a resturant", 1000f));
            Jobs.Add(JobType.RocketSurgeon, new Job("Rocket surgeon", "Build rockets for some real rich dude", 25000f, JobType.AIRocketeer, JobType.Surgeon));
            Jobs.Add(JobType.FactoryWorker, new Job("Factory worker", "Fix those spinning machines... while they are running!", 750f));
            Jobs.Add(JobType.FactorySupervisor, new Job("Factory supervisor", "Work as a supervisor in a factory. Cover up all accidents", 1000f, JobType.FactoryWorker));
            Jobs.Add(JobType.FactoryManager, new Job("Factory manager", "Own the factory, the factories profits are your profits", 1500f, JobType.FactorySupervisor));
            Jobs.Add(JobType.CarSalesman, new Job("Car salesman", "Sleazy 2nd hand car salesman, sell the **** cars that no one wants using questionable advertising", 1250f));
            Jobs.Add(JobType.Cook, new Job("Cook", "Cook food in a resturant to be served to customers", 1250f, JobType.Waiter));
            Jobs.Add(JobType.HeadChef, new Job("Head chef", "Act as the head chef for a resturant, tell other chefs what to do and where to do it", 2000f, JobType.Cook));
            Jobs.Add(JobType.JuniorProgrammer, new Job("Junior programmer", "Write buggy code that crashes every 10 seconds", 1000f));
            Jobs.Add(JobType.Programmer, new Job("Programmer", "Write corporate software to be sold for $$$$", 2000f, JobType.JuniorProgrammer));
            Jobs.Add(JobType.SeniorProgrammer, new Job("Senior programmer", "Lead a team of programmers to write top class software", 3500f, JobType.Programmer));
            Jobs.Add(JobType.ProgrammingManager, new Job("Programming manager", "Manage a whole department of programmers", 5000f, JobType.SeniorProgrammer));
            Jobs.Add(JobType.Accountant, new Job("Accountant", "File small company reports with spelling mistakes", 750f));
            Jobs.Add(JobType.TaxAccountant, new Job("Tax accountant", "A corporate accountant specialized in ripping off the tax office", 1500f, JobType.Accountant));
            Jobs.Add(JobType.SeniorTaxAccountant, new Job("Senior tax accountant", "Manage a team of contract tax accountants", 3000f, JobType.TaxAccountant));
            Jobs.Add(JobType.TaxInvestigator, new Job("Tax investigator", "Work for the tax office and hunt down scheming tax accountants", 1250f, JobType.Accountant));
            Jobs.Add(JobType.SeniorTaxInvestigator, new Job("Senior tax investigator", "Run a department of tax agents", 2500f, JobType.TaxInvestigator));
            Jobs.Add(JobType.AccountingManager, new Job("Accounting manager", "Run a contract accounting company", 5000f, JobType.SeniorTaxAccountant, JobType.SeniorTaxInvestigator));
            Jobs.Add(JobType.Plumber, new Job("Plumber", "De-clog toilets", 500f));
            Jobs.Add(JobType.InternDoctor, new Job("Intern doctor", "Intern as a doctor at a hospital", -500f));
            Jobs.Add(JobType.Resident, new Job("Resident doctor", "Become a resident at a hospital", 1000f, JobType.InternDoctor));
            Jobs.Add(JobType.Attending, new Job("Attending doctor", "Be a senior attending at a hospital", 3500f, JobType.Resident));
            Jobs.Add(JobType.Surgeon, new Job("Surgeon", "Become a junior surgeon", 2000f, JobType.Attending, JobType.Cook));
            Jobs.Add(JobType.HeartSurgeon, new Job("Heart surgeon", "Repair peoples hearts if they get stabbed or just have too much cholesterol", 5000f, JobType.Surgeon));
            Jobs.Add(JobType.PediatricSurgeon, new Job("Pediatric surgeon", "Do surgery on kids", 4000f, JobType.Attending));
            Jobs.Add(JobType.BrainSurgeon, new Job("Brain surgery", "Do surgery on peoples brains to fix them up if they go CUCKOO", 10000f, JobType.HeartSurgeon));
            Jobs.Add(JobType.CasualGamer, new Job("Casual gamer", "Casually play games, post a few videos with no views", -500f));
            Jobs.Add(JobType.TryHardGamer, new Job("Try hard gamer", "Play games full time and compete in tournaments", 750f));
            Jobs.Add(JobType.ProGamer, new Job("Pro gamer", "Play extreme pro video games, earn revenue from tournaments and streaming", 7500f));
            Jobs.Add(JobType.VideoGameMaker, new Job("Video game maker", "Make videogames for public consumption", 3000f, JobType.Programmer, JobType.CasualGamer));
            Jobs.Add(JobType.VideoGameDesigner, new Job("Video game designer", "Design videogames that you want to design", 2500f, JobType.VideoGameMaker));
            Jobs.Add(JobType.VideoGameCompanyManager, new Job("Video game manager", "Run a videogame company!", 10000f, JobType.VideoGameDesigner, JobType.Accountant));
            Jobs.Add(JobType.Pharmicist, new Job("Pharmicist", "Vendor at a pharmasutical agency", 1000f, JobType.Scientest));
            Jobs.Add(JobType.PharmacyOwner, new Job("Pharmacy owner", "Own a pharmacy, the pharmacys profits are yours", 2500f, JobType.Pharmicist));
            Jobs.Add(JobType.JuniorPharmasuticalResearcher, new Job("Junior pharmasutical researcher", "Help produce life saving medicines", 3000f, JobType.PharmacyOwner));
            Jobs.Add(JobType.PharmasuticalResearcher, new Job("Pharmasutical researcher", "Build rockets for some real rich dude", 50000f, JobType.JuniorPharmasuticalResearcher));
            Jobs.Add(JobType.JuniorEngineer, new Job("Junior engineer", "Work as a junior engineer designing infrastructure", 1000f));
            Jobs.Add(JobType.Engineer, new Job("Engineer", "Design infrastructure", 2000f, JobType.JuniorEngineer));
            Jobs.Add(JobType.SeniorEngineer, new Job("Senior engineer", "Run a group of engineers designing building and other structures", 3000f, JobType.Engineer));
            Jobs.Add(JobType.EngineeringManager, new Job("Engineering manager", "Manage a department of engineering", 5000f, JobType.SeniorEngineer));
            Jobs.Add(JobType.Scientest, new Job("Scientest", "Work as a junior researcher at a university", 500f));
            Jobs.Add(JobType.CorporateScientest, new Job("Corporate scientest", "Do research projects for commercial entities", 2000f, JobType.Scientest));
            Jobs.Add(JobType.AIResearcher, new Job("AI researcher", "Work on AI algorithims for a car company", 4000f, JobType.SeniorProgrammer));
            Jobs.Add(JobType.SelfDriveCarDesigner, new Job("Self drive car designer", "Design cutting edge self drive cars using advanced AI algorithims", 8000f, JobType.AIResearcher));
            Jobs.Add(JobType.AIRocketeer, new Job("AI Rocketeer", "Design the self landing systems on rockets", 10000f, JobType.SelfDriveCarDesigner, JobType.SeniorEngineer));
            Jobs.Add(JobType.BurgerFlipper, new Job("Burger flipper", "Flip burgers at a fast food resturant", 500f));
            Jobs.Add(JobType.SandwichMaker, new Job("Sandwich maker", "Assemble sandwiches at a fast food resturant", 500f));
            Jobs.Add(JobType.SandwichDesigner, new Job("Sandwich designer", "Design sandwiches for a fast food chain", 2000f, JobType.BurgerFlipper, JobType.SandwichMaker));
            Jobs.Add(JobType.FastFoodChainOwner, new Job("Fast food chain owner", "Manage a fast food chain resturant", 3000f, JobType.SandwichDesigner, JobType.Accountant));
            Jobs.Add(JobType.FastFoodFranchise, new Job("Fast food owner", "Own a fast food franchise", 10000f, JobType.FastFoodChainOwner, JobType.CarSalesman));
            Jobs.Add(JobType.Receptionist, new Job("Receptionist", "Act as a receptionist at a major company", 500f));
            Jobs.Add(JobType.ComputerSalesman, new Job("Computer salesman", "Sell \"refurbished\" old computers", 750f));
            Jobs.Add(JobType.Policeman, new Job("Police", "Work as a traffic cop giving out speeding tichets", 1000f));
            Jobs.Add(JobType.FederalAgent, new Job("Federal agent", "Work as a federal agent hunting down serious criminals", 1500f, JobType.Policeman));
            Jobs.Add(JobType.IntelligenceAnalyst, new Job("Intelligence analyst", "Work as an analyst for the ASIS", 2000f, JobType.FederalAgent));
            Jobs.Add(JobType.Spy, new Job("Spy", "Work field operations for the ASIS", 3000f, JobType.IntelligenceAnalyst));
            Jobs.Add(JobType.Superspy, new Job("Superspy", "Do high risk superspy operations", 7500f, JobType.Spy));
            Jobs.Add(JobType.Lawyer, new Job("Lawyer", "Ambulance chaser junior lawyer, start frivolous long lawsuits", 2000f, JobType.Accountant, JobType.CarSalesman));
            Jobs.Add(JobType.JuniorLawyer, new Job("Junior lawyer", "Join a law firm, fighting frivolous lawsuits from ambulance chasers", 3500f, JobType.Lawyer));
            Jobs.Add(JobType.LawPartner, new Job("Law partner", "Be a partner in a law firm", 5000f, JobType.JuniorLawyer));
            Jobs.Add(JobType.Judge, new Job("Judge", "Be a judge in court, prosecuting Junior Lawyers", 10000f, JobType.LawPartner));
        }

        public Job(string jobTitle, string jobDescription, float payment, params JobType[] prerequisites)
        {
            this.jobTitle = jobTitle;
            this.jobDescription = jobDescription;
            this.payment = payment;
            foreach (var prerequisite in prerequisites)
            {
                this.prerequisites.Add(prerequisite);
            }
            jobs.Add(this);
        }

        public override string ToString()
        {
            string prev = "";
            foreach (var item in prerequisites)
            {
                prev += Jobs[item].jobTitle;
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
