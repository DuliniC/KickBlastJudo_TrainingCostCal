using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KickBlastJudo_TrainingCostCal.Database
{
    public class TrainingPlan
    {
        public int PlanID { get; set; }
        public string PlanName { get; set; }
        public int SessionsPerWeek { get; set; }
        public decimal WeeklyFee { get; set; }
        public bool CanEnterCompetitions { get; set; }
    }
}
