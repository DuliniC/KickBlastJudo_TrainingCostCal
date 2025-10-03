using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KickBlastJudo_TrainingCostCal.Database
{
    public class MonthlyCost
    {
        public int monthlyCostId { get; set; }
        public DateTime GeneratedDate { get; set; }
        public string AthleteName { get; set; }
        public decimal TrainingCost { get; set; }
        public decimal CompetitionCost { get; set; }
        public decimal PrivateCoachingCost { get; set; }
        public decimal TotalCost { get; set; }
    }
}
