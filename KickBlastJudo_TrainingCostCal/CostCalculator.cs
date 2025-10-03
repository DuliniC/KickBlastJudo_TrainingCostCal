using KickBlastJudo_TrainingCostCal.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KickBlastJudo_TrainingCostCal
{
    public class CostCalculator
    {
        private readonly Athlete _athlete;
        private Dictionary<string, decimal> _feeLookup;

        public CostCalculator(Athlete athlete, Dictionary<string, decimal> feeLookup)
        {
            _athlete = athlete;
            _feeLookup = feeLookup;
        }

        public MonthlyCost FindMonthlyCost()
        {
            var monthlyCost = new MonthlyCost()
            {
                AthleteName = _athlete.AthleteName,
                TrainingCost = GetTrainingCost(),
                CompetitionCost = GetCompetitionCost(),
                PrivateCoachingCost = GetPrivateTutionCost(),
                TotalCost = GetTotalCost()
            };
            
            return monthlyCost;
        } 
        public decimal GetTrainingCost()
        {
            if(_athlete.TrainingPlan != null)
            {
                return _athlete.TrainingPlan.WeeklyFee * _athlete.TrainingPlan.SessionsPerWeek * 4;
            }
            return 0.00m;
        }

        public decimal GetCompetitionCost()
        {
            
            return _athlete.CompetitionEntered * _feeLookup["CompetitionFee"];
        }

        public decimal GetPrivateTutionCost()
        {
            return _athlete.PrivateCoachingHours * _feeLookup["PrivateCoatchingFee"];
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
