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
            House house = House.Random();
        }
    }
}
