using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KickBlastJudo_TrainingCostCal.Database
{
    public class Athlete
    {
        public int AthleteID { get; init; }
        public string AthleteName { get; set; }
        public int TrainingPlan { get; set; }
        public decimal CurrentWeightKg { get; set; }
        public int CompetitionCategory { get; set; }
        public int CompetitionEntered { get; set; }
        public int PrivateCoachingHours { get; set; }

    }

}
