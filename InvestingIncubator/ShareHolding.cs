using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestingIncubator
{
    public class InvContext : DbContext
    {
        public InvContext() : base()
        {
            
        }

        public DbSet<Share> Shares { get; set; }
        public DbSet<ShareHolding> ShareHoldings { get; set; }
    }
    public class Share
    {
        public int ShareId { get; set; }
        public string Name { get; set; }
        public double LastSell { get; set; }
        public double LastBuy { get; set; }
//        public ICollection<ShareHolding> ShareHoldings { get; set; }
    }
    public class ShareHolding
    {
        public int ShareHoldingId { get; set; }
        public int ShareId { get; set; } = 1;
        public Share Share { get; set; }
        public uint Quantity { get; set; }
        public double CostAverage { get; set; }
    }
}
