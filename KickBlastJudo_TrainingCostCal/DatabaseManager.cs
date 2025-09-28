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
                                var athlete = new Athlete
                                {
                                    AthleteID = reader.GetInt32(reader.GetOrdinal("AthleteID")),
                                    AthleteName = reader.GetString(reader.GetOrdinal("AthleteName")),
                                    TrainingPlan = (TrainingPlan)Enum.Parse(typeof(TrainingPlan), reader.GetString(reader.GetOrdinal("TrainingPlan"))),
                                    CurrentWeightKg = reader.GetDecimal(reader.GetOrdinal("CurrentWeightKg")),
                                    CompetitionCategory = (WeightCategory)Enum.Parse(typeof(WeightCategory), reader.GetString(reader.GetOrdinal("CompetitionCategory"))),
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
                        command.Parameters.AddWithValue("@TrainingPlan", athlete.TrainingPlan.ToString());
                        command.Parameters.AddWithValue("@CurrentWeightKg", athlete.CurrentWeightKg);
                        command.Parameters.AddWithValue("@CompetitionCategory", athlete.CompetitionCategory.ToString());
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
                    command.Parameters.AddWithValue("@TrainingPlan", (int)athleteToUpdate.TrainingPlan);
                    command.Parameters.AddWithValue("@CurrentWeightKg", athleteToUpdate.CurrentWeightKg);
                    command.Parameters.AddWithValue("@CompetitionCategory", (int)athleteToUpdate.CompetitionCategory);
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

    }
}
