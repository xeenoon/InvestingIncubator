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
    public partial class TransactionHistory : Form
    {
        public TransactionHistory()
        {
            InitializeComponent();
            Font f = new Font("Microsoft Tai Le", 12);
            Font b = new Font("Microsoft Tai Le", 14, FontStyle.Bold);

            Label title = new Label
            {
                Text = "Transaction history",
                Font = b
            };
            title.Width = 7000;
            tableLayoutPanel1.Controls.Add(title);
            tableLayoutPanel1.SetCellPosition(title, new TableLayoutPanelCellPosition(0,0));
            string[] file = File.ReadAllLines("transactionhistory.txt");
            for (int i = 0; i < file.Length; i++)
            {
                string line = file[i];
                if (tableLayoutPanel1.RowCount == i) 
                {
                    tableLayoutPanel1.RowCount++;
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
                }

                Label label = new Label();
                label.Text = line;
                label.Font = f;
                label.Width = 7000;
                tableLayoutPanel1.Controls.Add(label);
                tableLayoutPanel1.SetCellPosition(label, new TableLayoutPanelCellPosition(0, i+1));
            }
        }
    }
}
