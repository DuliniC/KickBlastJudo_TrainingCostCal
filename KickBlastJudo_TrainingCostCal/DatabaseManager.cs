using KickBlastJudo_TrainingCostCal.Database;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KickBlastJudo_TrainingCostCal
{
    public class DatabaseManager
    {
        private readonly string connectionString;
        public DatabaseManager()
        {
            connectionString = ConfigurationManager.ConnectionStrings["KickBlastJudo"].ConnectionString;
        }

        public List<Athlete> GetAllAthletes()
        {
            var athletes = new List<Athlete>();
            const string sql = "SELECT AthleteID, AthleteName, TrainingPlan, CurrentWeightKg, CompetitionCategory, CompetitionEntered, PrivateCoachingHours FROM Athletes;";
            var plans = GetTrainingPlans();
            var weightCategories = GetWeightCategories();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int planId = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                                var plan = plans.FirstOrDefault(p => p.PlanID == planId);

                                int weightCategoryId = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                                var weightCategory = weightCategories.FirstOrDefault(w => w.CategoryID == weightCategoryId);

                                var athlete = new Athlete
                                {
                                    AthleteID = reader.GetInt32(reader.GetOrdinal("AthleteID")),
                                    AthleteName = reader.GetString(reader.GetOrdinal("AthleteName")),
                                    TrainingPlan = plan,
                                    CurrentWeightKg = reader.GetDecimal(reader.GetOrdinal("CurrentWeightKg")),
                                    CompetitionCategory = weightCategory,
                                    CompetitionEntered = reader.GetInt32(reader.GetOrdinal("CompetitionEntered")),
                                    PrivateCoachingHours = reader.GetInt32(reader.GetOrdinal("PrivateCoachingHours"))
                                };
                                athletes.Add(athlete);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                throw;
            }

            return athletes;
        }

        public int AddAthlete(Athlete athlete)
        {
            const string sql = @"
            INSERT INTO Athletes (AthleteName, TrainingPlan, CurrentWeightKg, CompetitionCategory, CompetitionEntered, PrivateCoachingHours)
            OUTPUT INSERTED.AthleteID
            VALUES (@AthleteName, @TrainingPlan, @CurrentWeightKg, @CompetitionCategory, @CompetitionEntered, @PrivateCoachingHours);
        ";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@AthleteName", athlete.AthleteName);
                        command.Parameters.AddWithValue("@TrainingPlan", athlete.TrainingPlan.PlanID);
                        command.Parameters.AddWithValue("@CurrentWeightKg", athlete.CurrentWeightKg);
                        command.Parameters.AddWithValue("@CompetitionCategory", athlete.CompetitionCategory.CategoryID);
                        command.Parameters.AddWithValue("@CompetitionEntered", athlete.CompetitionEntered);
                        command.Parameters.AddWithValue("@PrivateCoachingHours", athlete.PrivateCoachingHours);

                        // Execute the query and get the new ID.
                        int newId = (int)command.ExecuteScalar();
                        return newId;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                throw;
            }
        }
        public int EditAthlete(Athlete athleteToUpdate)
        {
            if (athleteToUpdate == null || athleteToUpdate.AthleteID <= 0)
            {
                throw new ArgumentException("A valid athlete with a valid ID must be provided for update.");
            }

            const string sql = @"
            UPDATE Athletes 
            SET 
                AthleteName = @AthleteName, 
                TrainingPlan = @TrainingPlan, 
                CurrentWeightKg = @CurrentWeightKg, 
                CompetitionCategory = @CompetitionCategory, 
                CompetitionEntered = @CompetitionEntered, 
                PrivateCoachingHours = @PrivateCoachingHours
            WHERE 
                AthleteID = @AthleteID";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@AthleteName", athleteToUpdate.AthleteName);
                    command.Parameters.AddWithValue("@TrainingPlan", athleteToUpdate.TrainingPlan.PlanID);
                    command.Parameters.AddWithValue("@CurrentWeightKg", athleteToUpdate.CurrentWeightKg);
                    command.Parameters.AddWithValue("@CompetitionCategory", athleteToUpdate.CompetitionCategory.CategoryID);
                    command.Parameters.AddWithValue("@CompetitionEntered", athleteToUpdate.CompetitionEntered);
                    command.Parameters.AddWithValue("@PrivateCoachingHours", athleteToUpdate.PrivateCoachingHours);
                    command.Parameters.AddWithValue("@AthleteID", athleteToUpdate.AthleteID); // Used in the WHERE clause

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while editing the athlete: " + ex.Message);
                return 0;
            }
        }

        public List<TrainingPlan> GetTrainingPlans()
        {
            var plans = new List<TrainingPlan>();
            string sql = "SELECT PlanID, PlanName, SessionsPerWeek, WeeklyFee, CanEnterCompetitions FROM TrainingPlans";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var plan = new TrainingPlan
                        {
                            PlanID = reader.GetInt32(0),
                            PlanName = reader.GetString(1),
                            SessionsPerWeek = reader.GetInt32(2),
                            WeeklyFee = reader.GetDecimal(3),
                            CanEnterCompetitions = reader.GetBoolean(4)
                        };
                        plans.Add(plan);
                    }
                }
                return plans;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<WeightCategory> GetWeightCategories()
        {
            var categories = new List<WeightCategory>();
            string sql = "SELECT CategoryID, CategoryName, UpperWeightLimit, Description, DisplayOrder FROM WeightCategories";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    categories.Add(new WeightCategory
                    {
                        CategoryID = reader.GetInt32(0),
                        CategoryName = reader.GetString(1),
                        UpperWeightLimit = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                        Description = reader.GetString(3),
                        DisplayOrder = reader.GetInt32(4)
                    });
                }
            }
            return categories;
        }

        public List<Fee> GetFees()
        {
            var fees = new List<Fee>();
            string sql = "SELECT FeeId, FeeType, Amount FROM Fees";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    fees.Add(new Fee
                    {
                        FeeId = reader.GetInt32(0),
                        FeeType = reader.GetString(1),
                        Amount = reader.GetDecimal(2)
                    });
                }
            }
            return fees;
        }

        public void SaveMonthlyCost(MonthlyCost cost)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO MonthlyCosts 
                           (GeneratedDate, AthleteName, TrainingCost, CompetitionCost, PrivateCoachingCost, TotalCost) 
                           VALUES (@GeneratedDate, @AthleteName, @TrainingCost, @CompetitionCost, @PrivateCoachingCost, @TotalCost)";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@GeneratedDate", DateTime.Now);  // set now
                cmd.Parameters.AddWithValue("@AthleteName", cost.AthleteName);
                cmd.Parameters.AddWithValue("@TrainingCost", cost.TrainingCost);
                cmd.Parameters.AddWithValue("@CompetitionCost", cost.CompetitionCost);
                cmd.Parameters.AddWithValue("@PrivateCoachingCost", cost.PrivateCoachingCost);
                cmd.Parameters.AddWithValue("@TotalCost", cost.TotalCost);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
