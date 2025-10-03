using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KickBlastJudo_TrainingCostCal.Database
{
    public class Fee
    {
        public int FeeId { get; set; }
        public string FeeType { get; set; }
        public decimal Amount { get; set; }
    }
}
