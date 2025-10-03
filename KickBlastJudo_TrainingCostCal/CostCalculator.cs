using KickBlastJudo_TrainingCostCal.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KickBlastJudo_TrainingCostCal
{
    public class CostCalculator
    {
        const decimal competitionFee = 250.00m; //per competition
        const decimal privateTutionFee = 150.00m; // per hour

        private readonly Athlete _athlete;

        public CostCalculator(Athlete athlete)
        {
            _athlete = athlete;
        }
        public decimal GetTrainingCost()
        {
            if(_athlete.TrainingPlan == null)
            {
                return _athlete.TrainingPlan.WeeklyFee * _athlete.TrainingPlan.SessionsPerWeek;
            }
            return 0.00m;
        }

        public decimal GetCompetitionCost()
        {
            return _athlete.CompetitionEntered * competitionFee;
        }

        public decimal GetPrivateTutionCost()
        {
            return _athlete.PrivateCoachingHours * privateTutionFee;
        }

        public decimal GetTotalCost()
        {
            var trainingCost = GetTrainingCost();
            var competitionCost = GetCompetitionCost();
            var privateTutionCost = GetPrivateTutionCost();

            return trainingCost + competitionCost + privateTutionCost;
        }   
    }
}
