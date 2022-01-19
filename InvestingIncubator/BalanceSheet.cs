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
    public partial class BalanceSheet : Form
    {
        public BalanceSheet(string sharename)
        {
            InitializeComponent();
            label23.Text = sharename;
            Font f = new Font("Microsoft Tai Le", 12);
            var items = DataFromName(sharename);
            for (int i = 0; i < 14; ++i)
            {
                Label data = new Label();
                tableLayoutPanel1.Controls.Add(data);
                if (items[i] != "None" && items[i] != "")
                {
                    data.Text = '$' + AddLeaders((float.Parse(items[i])/1000f).ToString("N0"));
                }
                else if (items[i] != "")
                {
                    data.Text = "$0";
                }
                data.Font = f;
                data.Width = 400;
                tableLayoutPanel1.SetCellPosition(data, new TableLayoutPanelCellPosition(1, i));
            }
            for (int i = 14; i < 26; ++i)
            {
                Label data = new Label();
                tableLayoutPanel1.Controls.Add(data);
                if (items[i] != "None" && items[i] != "")
                {
                    data.Text = '$' + AddLeaders((float.Parse(items[i]) / 1000f).ToString("N0"));
                }
                else if (items[i] != "")
                {
                    data.Text = "$0";
                }
                data.Width = 400;
                data.Font = f;
                tableLayoutPanel1.SetCellPosition(data, new TableLayoutPanelCellPosition(4, i-14));
            }
        }

        private string AddLeaders(string v)
        {
            string result = "";
            for (int i = 0; i <v.Length; ++i)
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
            return result+v;
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
        private List<string> DataFromName(string sharename)
        {
            List<string> result = new List<string>();

            List<string> file = File.ReadAllLines(@"C:\Users\chris\source\repos\InvestingIncubator\InvestingIncubator\bin\Debug\Balance\" + sharename + ".json").ToList();
            
            
            
            AddJSONItem(ref result, file, 6);
            result.Add("");
            AddJSONItem(ref result, file, 7);
            AddJSONItem(ref result, file, 8);
            AddJSONItem(ref result, file, 20);
            AddJSONItem(ref result, file, 10);
            AddJSONItem(ref result, file, 11);
            AddJSONItem(ref result, file, 21);
            result.Add("");
            AddJSONItem(ref result, file, 12);
            AddJSONItem(ref result, file, 13);
            AddJSONItem(ref result, file, 15);
            AddJSONItem(ref result, file, 19);
            AddJSONItem(ref result, file, 22);
            AddJSONItem(ref result, file, 23);
            result.Add("");
            AddJSONItem(ref result, file, 24);
            AddJSONItem(ref result, file, 25);
            result.Add("DEFFERRED");
            AddJSONItem(ref result, file, 28);
            AddJSONItem(ref result, file, 32);
            AddJSONItem(ref result, file, 35);
            result[18] = (Parse(result[16]) - Parse(result[17]) - Parse(result[19]) - Parse(result[20]) - Parse(result[21])).ToString(); //Calculated by hand because API value is incorrect
            result.Add("");
            AddJSONItem(ref result, file, 29);
            AddJSONItem(ref result, file, 33);
            AddJSONItem(ref result, file, 36);

            return result;
        }

        private float Parse(string v)
        {
            float.TryParse(v, out float result);
            return result;
        }

        private void AddJSONItem(ref List<string> result, List<string> file, int lineno)
        {
            result.Add(TrimString(file[lineno].Split(':')[1].Substring(2), 2));
        }
    }
}
