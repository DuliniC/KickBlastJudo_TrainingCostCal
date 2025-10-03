using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KickBlastJudo_TrainingCostCal.Database
{
    public class WeightCategory
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public decimal? UpperWeightLimit { get; set; }
        public string Description { get; set; }
        public int DisplayOrder {  get; set; }

        public string DisplayText
        {
            get
            {
                return $"{CategoryName} - {Description}";
            }
        }
    }
}
