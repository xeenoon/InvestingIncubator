using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Data.Analysis;

namespace InvestingIncubator
{
    public partial class Form1 : Form
    {
        InvContext context;
        bool loaded = false;

        public List<string> sharenames = new List<string>() {"AAPL", "AMZN", "DIS", "FB", "GOOG", "MSFT", "TSLA", "UBER"};
        public Form1()
        {
            context = new InvContext();
            InitializeComponent();
            SaveCsvFromURL("TSLA");

            //this.Resize += new EventHandler(Form1_Resize);
            X = this.Width;
            Y = this.Height;
            CreateTable();
            ShowStockData();

            setTag(this);
            setTag(tableLayoutPanel1);
            setTag(tableLayoutPanel2);
            setTag(panel1);

            loaded = true;
            ResizeAndPositionControls();

            context.Shares.Load();

            //            context.Shares.Add(new Share() { ShareId = 1, Name = "APPL", LastBuy = 123.34, LastSell = 126.89 });
            //            context.Shares.Add(new Share() { ShareId = 1, Name = "GOOG", LastBuy = 123.34, LastSell = 126.89 });
            //            context.SaveChanges();

            //            sharesGridView.DataSource = context.Shares.Local.ToBindingList();
            //            sharesGridView.UserDeletedRow += SharesGridView_UserDeletedRow;
            //            sharesGridView.UserDeletingRow += SharesGridView_UserDeletingRow;
            //            sharesGridView.UserAddedRow += SharesGridView_UserAddedRow;
            //            sharesGridView.CellValueChanged += SharesGridView_CellValueChanged;
        }

        private void SharesGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateSharesGrid();
        }

        private void UpdateSharesGrid()
        {
            context.SaveChanges();
            context.Shares.Load();
            //sharesGridView.Refresh();
        }

        private void SharesGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        { 
            UpdateSharesGrid();
        }

        private void SharesGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var del = MessageBox.Show($"Deleting Share {((Share)e.Row.DataBoundItem).Name}", "Deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (del == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void SharesGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            UpdateSharesGrid();
        }

        string _apikey = "R5Y2C5YF1MDYK3YX";
        public string SaveCsvFromURL(string symbol)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://" + $@"www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={symbol}&apikey={_apikey}&datatype=csv");
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            File.WriteAllText(@"C:\Users\chris\source\repos\InvestingIncubator\InvestingIncubator\bin\Debug\Stocks\"+symbol+".csv", results);
            sr.Close();
            return results;
        }

        float X, Y;

        private void Form1_Resize(object sender, EventArgs e)
        {
            ResizeAndPositionControls();
        }

        private void ResizeAndPositionControls()
        {
            if (loaded == true)
            {
                float newX = this.Width / X;
                float newY = this.Height / Y;
                setControls(newX, newY, this);
                setControls(newX, newY, tableLayoutPanel1);
                setControls(newX, newY, tableLayoutPanel2);
                setControls(newX, newY, panel1);
            }
        }


        private void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
            }
        }
        public void ShowStockData()
        {

            Font f = new Font("Microsoft Tai Le", 12);

            Font title = new Font("Microsoft Tai Le", 12, FontStyle.Bold);


            Label sharenameLabel = new Label();
            tableLayoutPanel2.Controls.Add(sharenameLabel);
            sharenameLabel.Text = "Share name";
            sharenameLabel.Font = title;
            tableLayoutPanel2.SetCellPosition(sharenameLabel, new TableLayoutPanelCellPosition(0, 0));

            Label shareopenlabel = new Label();
            tableLayoutPanel2.Controls.Add(shareopenlabel);
            shareopenlabel.Text = "Open";
            shareopenlabel.Font = title;
            tableLayoutPanel2.SetCellPosition(shareopenlabel, new TableLayoutPanelCellPosition(1, 0));

            Label sharecloselabel = new Label();
            tableLayoutPanel2.Controls.Add(sharecloselabel);
            sharecloselabel.Text = "Close";
            sharecloselabel.Font = title;
            tableLayoutPanel2.SetCellPosition(sharecloselabel, new TableLayoutPanelCellPosition(2, 0));

            string[] files = Directory.GetFiles(@"C:\Users\chris\source\repos\InvestingIncubator\InvestingIncubator\bin\Debug\Stocks");
            for (int i = 0; i < files.Length; ++i) 
            {
                DataFrame df = DataFrame.LoadCsv(files[i]);
                var row = df.Rows[1].ToList();

                Label name = new Label();
                tableLayoutPanel2.Controls.Add(name);
                string sharename = files[i].Split('\\').Last().Split('.').First();
                name.Text = sharename;
                name.Font = f;
                name.Name = "Name"+(i+1);
                name.DoubleClick += new System.EventHandler(this.ShowGraph);
                tableLayoutPanel2.SetCellPosition(name, new TableLayoutPanelCellPosition(0, i+1));

                Label openPrice = new Label();
                tableLayoutPanel2.Controls.Add(openPrice);
                openPrice.Text = row[1].ToString();
                openPrice.Font = f;
                openPrice.Name = "Open"+(i+1);
                openPrice.DoubleClick += new System.EventHandler(this.ShowGraph);
                tableLayoutPanel2.SetCellPosition(openPrice, new TableLayoutPanelCellPosition(1, i+1));

                Label closePrice = new Label();
                tableLayoutPanel2.Controls.Add(closePrice);
                closePrice.Text = row[4].ToString();
                closePrice.Font = f;
                closePrice.Name = "Close"+(i+1);
                closePrice.DoubleClick += new System.EventHandler(this.ShowGraph);
                tableLayoutPanel2.SetCellPosition(closePrice, new TableLayoutPanelCellPosition(2, i+1));
            }
        }

        private void ShowGraph(object sender, EventArgs e)
        {
            string name = ((Label)sender).Name;
            string num = "";
            foreach (var c in name)
            {
                if (char.IsNumber(c))
                {
                    num += c;
                }
            }
            string[] files = Directory.GetFiles(@"C:\Users\chris\source\repos\InvestingIncubator\InvestingIncubator\bin\Debug\Stocks");
            string sharename = files[int.Parse(num) - 1].Split('\\').Last().Split('.').First();
            Hide();
            Form2 form2 = new Form2(sharename);
            form2.ShowDialog(this);
        }

        void HideData()
        {
            foreach (var control in Controls)
            {
                if (((Control)control).Name != "panel1")
                {
                    ((Control)control).Visible = false;
                }
            }
        }
        void ShowData()
        {
            foreach (var control in Controls)
            {
                if (((Control)control).Name != "panel1")
                {
                    ((Control)control).Visible = true;
                }
            }
        }

        float cash = 0f;
        void ClearTable()
        {
            tableLayoutPanel1.Controls.Clear();
        }
        public void CreateTable()
        {
            Font f = new Font("Microsoft Tai Le", 12);

            Font title = new Font("Microsoft Tai Le", 12, FontStyle.Bold);

            Label sharenameLabel = new Label();
            tableLayoutPanel1.Controls.Add(sharenameLabel);
            sharenameLabel.Text = "Share name";
            sharenameLabel.Font = title;
            tableLayoutPanel1.SetCellPosition(sharenameLabel, new TableLayoutPanelCellPosition(0, 0));

            Label shareamountLabel = new Label();
            tableLayoutPanel1.Controls.Add(shareamountLabel);
            shareamountLabel.Text = "Amount";
            shareamountLabel.Font = title;
            tableLayoutPanel1.SetCellPosition(shareamountLabel, new TableLayoutPanelCellPosition(1, 0));

            Label sharevalueLabel = new Label();
            tableLayoutPanel1.Controls.Add(sharevalueLabel);
            sharevalueLabel.Text = "Value";
            sharevalueLabel.Font = title;
            tableLayoutPanel1.SetCellPosition(sharevalueLabel, new TableLayoutPanelCellPosition(2, 0));

            var file = File.ReadAllLines("sharedata.txt");
            cash = float.Parse(file[0]);
            label3.Text = "$" + file[0];
            for (int i = 1; i < file.Length; ++i)
            {
                var texts = file[i].Split(',');
                string name = texts[0];
                string amount = texts[1];
                string value = (GetSharePrice(name)*int.Parse(amount)).ToString();


                Label sharename = new Label();
                tableLayoutPanel1.Controls.Add(sharename);
                sharename.Text = name;
                sharename.Font = f;
                sharename.DoubleClick += new System.EventHandler(this.SellShare);
                sharename.Name = string.Format("{0}:name:{1}", name, i);
                tableLayoutPanel1.SetCellPosition(sharename, new TableLayoutPanelCellPosition(0, i + 1));

                Label shareamount = new Label();
                tableLayoutPanel1.Controls.Add(shareamount);
                shareamount.Text = amount;
                shareamount.Font = f;
                shareamount.DoubleClick += new System.EventHandler(this.SellShare);
                shareamount.Name = string.Format("{0}:amount:{1}", name, i);
                tableLayoutPanel1.SetCellPosition(shareamount, new TableLayoutPanelCellPosition(1, i + 1));

                Label sharevalue = new Label();
                tableLayoutPanel1.Controls.Add(sharevalue);
                sharevalue.Text = value;
                sharevalue.Font = f;
                sharevalue.DoubleClick += new System.EventHandler(this.SellShare);
                sharevalue.Name = string.Format("{0}:value:{1}", name, i);
                tableLayoutPanel1.SetCellPosition(sharevalue, new TableLayoutPanelCellPosition(2, i + 1));
            }
            setTag(tableLayoutPanel1);

            ResizeAndPositionControls();
        }

        private float GetSharePrice(string name)
        {
            string file = Directory.GetFiles(@"C:\Users\chris\source\repos\InvestingIncubator\InvestingIncubator\bin\Debug\Stocks", name+".csv").FirstOrDefault();
            DataFrame df = DataFrame.LoadCsv(file);
            var row = df.Rows[1].ToList();
            return (float)row[4];
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
          //  tableLayoutPanel1.
        }

        private void Buy_Click(object sender, EventArgs e)
        {
            int buttonNo = int.Parse(((Button)sender).Name.ToString().Substring(3));
            var text = this.Controls.OfType<TextBox>().FirstOrDefault(c => c.Name == "textBox" + buttonNo.ToString());
            text.Visible = true;
            var back = this.Controls.OfType<PictureBox>().FirstOrDefault(c => c.Name == "Back" + buttonNo.ToString());
            back.Visible = true;
            var tick = this.Controls.OfType<PictureBox>().FirstOrDefault(c => c.Name == "Tick" + buttonNo.ToString());
            tick.Visible = true;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            int backNo = int.Parse(((PictureBox)sender).Name.ToString().Substring(4));
            var text = this.Controls.OfType<TextBox>().FirstOrDefault(c => c.Name == "textBox" + backNo.ToString());
            text.Visible = false;
            var back = this.Controls.OfType<PictureBox>().FirstOrDefault(c => c.Name == "Back" + backNo.ToString());
            back.Visible = false;
            var tick = this.Controls.OfType<PictureBox>().FirstOrDefault(c => c.Name == "Tick" + backNo.ToString());
            tick.Visible = false;
        }

        private void TickClick(object sender, EventArgs e)
        {
            int tickNo = int.Parse(((PictureBox)sender).Name.ToString().Substring(4));
            var text = this.Controls.OfType<TextBox>().FirstOrDefault(c => c.Name == "textBox" + tickNo.ToString());
            text.Visible = false;
            var back = this.Controls.OfType<PictureBox>().FirstOrDefault(c => c.Name == "Back" + tickNo.ToString());
            back.Visible = false;
            var tick = this.Controls.OfType<PictureBox>().FirstOrDefault(c => c.Name == "Tick" + tickNo.ToString());
            tick.Visible = false;

            List<string> file = File.ReadAllLines("sharedata.txt").ToList();
            var value = float.Parse(text.Text) * float.Parse(((Label)tableLayoutPanel2.Controls.Find("Close" + tickNo, true).FirstOrDefault()).Text);
            if (cash >= value) 
            {
                string name = ((Label)tableLayoutPanel2.Controls.Find("Name" + tickNo, true).FirstOrDefault()).Text;
                string sharedata = string.Format("{0},{1}", name, text.Text);
                file.Add(sharedata);
                text.Text = "10000";
                cash -= value;
                file.RemoveAt(0);
                file.Insert(0, cash.ToString());
                File.WriteAllLines("sharedata.txt", file.ToArray());
                label3.Text = "$" + cash;
                ClearTable();
                CreateTable();
            }
            else
            {
                MessageBox.Show("You do not have enough funds to buy these shares");
            }
        }


        private void SellShare(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to sell these shares?", "Sell", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            string label = ((Label)sender).Name;
            string sharename = label.Split(':')[0];
            Control amountLabel = tableLayoutPanel1.Controls.Find(string.Format("{0}:{1}:{2}",sharename, "amount", label.Split(':')[2]), true).FirstOrDefault();
            int amount = int.Parse(amountLabel.Text);
            Control valueLabel = tableLayoutPanel1.Controls.Find(string.Format("{0}:{1}:{2}", sharename, "value", label.Split(':')[2]), true).FirstOrDefault();
            float value = float.Parse(valueLabel.Text);

            List<string> lines = File.ReadAllLines("sharedata.txt").ToList();
            lines.Remove(string.Format("{0},{1}", sharename,amount.ToString()));
            lines.RemoveAt(0);
            cash += value;
            lines.Insert(0, (cash).ToString());
            File.WriteAllLines("sharedata.txt", lines.ToArray());
            label3.Text = "$" + cash.ToString();
            ClearTable();
            CreateTable();
        }
        

        private void setControls(float newX, float newY, Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                string[] mytag = con.Tag.ToString().Split(new char[] { ':' });
                float a = Convert.ToSingle(mytag[0]) * newX;
                con.Width = (int)(a);

                a = Convert.ToSingle(mytag[1]) * newY;
                con.Height = (int)(a);

                a = Convert.ToSingle(mytag[2]) * newX;
                con.Left = (int)(a);

                a = Convert.ToSingle(mytag[3]) * newY;
                con.Top = (int)(a);

                float currentSize = Convert.ToSingle(mytag[4]) * newY;
                con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
            }
        }
    }
}
