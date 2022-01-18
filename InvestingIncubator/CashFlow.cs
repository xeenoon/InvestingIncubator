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

            Label operating = new Label();
            tableLayoutPanel1.Controls.Add(operating);
            operating.Text = "Operatingcashflow";
            operating.Font = f;
            tableLayoutPanel1.SetCellPosition(operating, new TableLayoutPanelCellPosition(0, 1));

            Label investing = new Label();
            tableLayoutPanel1.Controls.Add(investing);
            investing.Text = "Investing cash flow";
            investing.Font = f;
            tableLayoutPanel1.SetCellPosition(investing, new TableLayoutPanelCellPosition(0, 2));

            Label financing = new Label();
            tableLayoutPanel1.Controls.Add(financing);
            financing.Text = "Financing cash flow";
            financing.Font = f;
            tableLayoutPanel1.SetCellPosition(financing, new TableLayoutPanelCellPosition(0, 3));

            Label dividend = new Label();
            tableLayoutPanel1.Controls.Add(dividend);
            dividend.Text = "Dividend payout";
            dividend.Font = f;
            tableLayoutPanel1.SetCellPosition(dividend, new TableLayoutPanelCellPosition(0, 4));

            Label income = new Label();
            tableLayoutPanel1.Controls.Add(income);
            income.Text = "Income";
            income.Font = f;
            tableLayoutPanel1.SetCellPosition(income, new TableLayoutPanelCellPosition(0, 5));

            List<string> values = DataFromName(sharename);
            for (int i = 0; i < values.Count; ++i)
            {
                Label data = new Label();
                tableLayoutPanel1.Controls.Add(data);
                data.Text = '$' + values[i];
                data.Font = f;
                tableLayoutPanel1.SetCellPosition(data, new TableLayoutPanelCellPosition(1, i + 1));
            }
            float totalshares = GetShareAmount(sharename);

            for (int i = 0; i < values.Count; ++i)
            {
                Label data = new Label();
                tableLayoutPanel1.Controls.Add(data);
                data.Text = '$' + (float.Parse(values[i])/totalshares).ToString();
                data.Font = f;
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
        public float GetShareAmount(string sharename)
        {
            List<string> file = File.ReadAllLines(@"C:\Users\chris\source\repos\InvestingIncubator\InvestingIncubator\bin\Debug\Balance\" + sharename + ".json").ToList();
            return float.Parse(TrimString(file[40].Split(':')[1].Substring(2), 2));
        }
    }
}
