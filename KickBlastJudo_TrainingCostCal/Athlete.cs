using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KickBlastJudo_TrainingCostCal
{
    public class Athlete
    {
        public int AthleteID { get; init; }
        public string AthleteName { get; set; }
        public TrainingPlan TrainingPlan { get; set; }
        public decimal CurrentWeightKg { get; set; }
        public WeightCategory CompetitionCategory { get; set; }
        public int CompetitionEntered { get; set; }
        public int PrivateCoachingHours { get; set; }

        public bool IsValidForCompetition()
        {
            return TrainingPlan == TrainingPlan.Intermidiate || TrainingPlan == TrainingPlan.Elite;
        }
    }

    public enum TrainingPlan
    {
        Begginer,
        Intermidiate,
        Elite
    }

    public enum WeightCategory
    {
        Heavyweight,
        Light_Heavyweight,
        Middleweight,
        Light_Middleweight,
        Lightweight,
        Flyweight
    }
}
