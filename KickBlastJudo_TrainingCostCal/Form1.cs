using System.Text.Json;

namespace KickBlastJudo_TrainingCostCal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AddAthleteBtn_Click(object sender, EventArgs e)
        {
            athleteNameTbx.Enabled = true;
            planCmbx.Enabled = true;
            weightCatCbx.Enabled = true;
            weightBx.Enabled = true;
            //competitionBx.Enabled = true;
            prvtCoaHbx.Enabled = true;
            athleteSaveBtn.Enabled = true;
            clearFormBtn.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            planCmbx.DataSource = Enum.GetValues(typeof(TrainingPlan));
            weightCatCbx.DataSource = Enum.GetValues(typeof(WeightCategory));
        }

        private void AthleteSaveBtn_Click(object sender, EventArgs e)
        {
            var athlete = new Athlete
            {
                AthleteID = 1,
                AthleteName = athleteNameTbx.Text,
                TrainingPlan = (TrainingPlan)planCmbx.SelectedValue,
                CurrentWeightKg = weightBx.Value,
                CompetitionCategory = (WeightCategory)weightCatCbx.SelectedItem,
                PrivateCoachingHours = Convert.ToInt32(prvtCoaHbx.Value)
            };
            //SaveAthlete(athlete);
        }

        private void clearFormBtn_Click(object sender, EventArgs e)
        {
            athleteNameTbx.Clear();
            planCmbx.SelectedIndex = 0;
            weightCatCbx.SelectedIndex = 0;
            weightBx.Value = weightBx.Minimum;
            competitionBx.Value = 0;
            prvtCoaHbx.Value = 0;
        }

        private void planCmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (planCmbx.SelectedIndex != 0) 
            {
                competitionBx.Enabled = true;
            }
            else
            {
                competitionBx.Enabled = false;
            }
        }

        //string filePath = Path.Combine(Application.StartupPath, "athlete.json");
        //private void SaveAthlete(Athlete athlete)
        //{
        //    string json = JsonSerializer.Serialize(athlete ,new JsonSerializerOptions { WriteIndented = true });

        //    File.AppendAllText(filePath, json + Environment.NewLine);
        //}

    }

}
