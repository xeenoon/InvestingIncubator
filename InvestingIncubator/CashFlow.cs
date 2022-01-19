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
    public partial class CashFlow : Form
    {
        public CashFlow(string sharename)
        {
            InitializeComponent();
            var tableLayoutPanel1 = this.tableLayoutPanel1;
            CreateCashFlowTable(sharename, tableLayoutPanel1);
        }
        List<string> sharenames = new List<string>();
        private void CreateCashFlowTable(string sharename, TableLayoutPanel tableLayoutPanel1)
        {
            sharenames.Add(sharename);
            Font f = new Font("Microsoft Tai Le", 12);
            Label name = new Label();
            tableLayoutPanel1.Controls.Add(name);
            name.Text = sharename;
            name.Font = f;
            tableLayoutPanel1.SetCellPosition(name, new TableLayoutPanelCellPosition(0, 0));

            Label total = new Label();
            tableLayoutPanel1.Controls.Add(total);
            total.Text = "Total";
            total.Font = f;
            tableLayoutPanel1.SetCellPosition(total, new TableLayoutPanelCellPosition(1, 0));

            Label pershare = new Label();
            tableLayoutPanel1.Controls.Add(pershare);
            pershare.Text = "Per share";
            pershare.Font = f;
            tableLayoutPanel1.SetCellPosition(pershare, new TableLayoutPanelCellPosition(2, 0));

            List<string> values = DataFromName(sharename);
            for (int i = 0; i < values.Count; ++i)
            {
                Label data = new Label();
                tableLayoutPanel1.Controls.Add(data);
                if (values[i] != "None")
                {
                    data.Text = '$' + AddLeaders((float.Parse(values[i]) / 1000f).ToString("N0"));
                }
                else
                {
                    data.Text = "$0";
                }
                data.Width = 400;
                data.Font = f;
                tableLayoutPanel1.SetCellPosition(data, new TableLayoutPanelCellPosition(1, i + 1));
            }
            float totalshares = GetShareAmount(sharename);

            for (int i = 0; i < values.Count; ++i)
            {
                Label data = new Label();
                tableLayoutPanel1.Controls.Add(data);
                try
                {
                    data.Text = '$' + Math.Round(float.Parse(values[i]) / totalshares, 2).ToString();
                }
                catch
                {
                    data.Text = "$0";
                }
                data.Width = 400;
                data.Font = f;
                data.Name = sharename + i.ToString();
                tableLayoutPanel1.SetCellPosition(data, new TableLayoutPanelCellPosition(2, i + 1));
            }
        }

        private List<string> DataFromName(string sharename)
        {
            List<string> result = new List<string>();

            List<string> file = File.ReadAllLines(@"C:\Users\chris\source\repos\InvestingIncubator\InvestingIncubator\bin\Debug\Income\" + sharename + ".json").ToList();

            string operatingCashFlow = TrimString(file[6].Split(':')[1].Substring(2), 2);
            result.Add(operatingCashFlow);

            string investingCashFlow = TrimString(file[16].Split(':')[1].Substring(2), 2);
            result.Add(investingCashFlow);

            string financingCashFlow = TrimString(file[17].Split(':')[1].Substring(2), 2);
            result.Add(financingCashFlow);


            string dividendPayout = TrimString(file[22].Split(':')[1].Substring(2), 2);
            result.Add(dividendPayout);

            string income = TrimString(file[32].Split(':')[1].Substring(2), 2);
            result.Add(income);

            return result;
        }
        public string TrimString(string str, int trimchars)
        {
            string result = "";
            for (int i = 0; i < str.Length - trimchars; ++i)
            {
                result += str[i];
            }
            return result;
        }
        private string AddLeaders(string v)
        {
            string result = "";
            for (int i = 0; i < v.Length; ++i)
            {
                if (v[i] == ',')
                {
                    for (int j = i; j < 3; ++j)
                    {
                        result += " ";
                    }
                    break;
                }
            }
            return result + v;
        }
        public float GetShareAmount(string sharename)
        {
            List<string> file = File.ReadAllLines(@"C:\Users\chris\source\repos\InvestingIncubator\InvestingIncubator\bin\Debug\Balance\" + sharename + ".json").ToList();
            return float.Parse(TrimString(file[41].Split(':')[1].Substring(2), 2));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Visible == false)
            {
                string[] files = Directory.GetFiles(@"C:\Users\chris\source\repos\InvestingIncubator\InvestingIncubator\bin\Debug\Income");
                foreach (var file in files)
                {
                    string data = file.Split('.')[0];
                    comboBox1.Items.Add(data.Split(new string[] { "\\Income\\" }, StringSplitOptions.None)[1]);
                }
                comboBox1.Visible = true;
            }
            else
            {
                CreateCashFlowTable((string)comboBox1.SelectedItem, tableLayoutPanel2);
                panel1.Visible = true;
                tableLayoutPanel2.Visible = true;
                button1.Visible = false;
                comboBox1.Visible = false;
                HighlightDifferencees(tableLayoutPanel1, tableLayoutPanel2);
            }
        }

        private void HighlightDifferencees(TableLayoutPanel tableLayoutPanel1, TableLayoutPanel tableLayoutPanel2)
        {
            string firstname  = sharenames[0];
            string secondname = sharenames[1];
            for (int i = 0; i < 5; ++i)
            {
                float firstnum = float.Parse(tableLayoutPanel1.Controls.Find(firstname + i, true).FirstOrDefault().Text.Substring(1));
                float secondnum = float.Parse(tableLayoutPanel2.Controls.Find(secondname + i, true).FirstOrDefault().Text.Substring(1));
                if (firstnum > secondnum)
                {
                    tableLayoutPanel1.Controls.Find(firstname + i, true).FirstOrDefault().ForeColor = Color.Green;
                    tableLayoutPanel2.Controls.Find(secondname + i, true).FirstOrDefault().ForeColor = Color.Red;
                }
                else
                {
                    tableLayoutPanel1.Controls.Find(firstname + i, true).FirstOrDefault().ForeColor = Color.Red;
                    tableLayoutPanel2.Controls.Find(secondname + i, true).FirstOrDefault().ForeColor = Color.Green;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
