namespace KickBlastJudo_TrainingCostCal
{
    public partial class Form1 : Form
    {
        private readonly DatabaseManager _databaseManager;

        public Form1()
        {
            InitializeComponent();
            _databaseManager = new DatabaseManager();
        }

        private void AddAthleteBtn_Click(object sender, EventArgs e)
        {
            ClearAthleteForm();
            EnableAthleteFields();
            athleteSaveBtn.Show();
            clearFormBtn.Show();
            athleteEditBtn.Hide();
            calCostBtn.Hide();
            updateSaveBtn.Hide();
            cancelUpdtBtn.Show();
            athleteSaveBtn.Enabled = true;
            clearFormBtn.Enabled = true;
            cancelUpdtBtn.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            planCmbx.DataSource = Enum.GetValues(typeof(TrainingPlan));
            comCatCbx.DataSource = Enum.GetValues(typeof(WeightCategory));
            LoadAthletesIntoComboBox();
        }

        private void AthleteSaveBtn_Click(object sender, EventArgs e)
        {

            var athlete = new Athlete
            {
                AthleteName = athleteNameTbx.Text,
                TrainingPlan = (TrainingPlan)planCmbx.SelectedValue,
                CurrentWeightKg = weightBx.Value,
                CompetitionCategory = (WeightCategory)comCatCbx.SelectedItem,
                PrivateCoachingHours = Convert.ToInt32(prvtCoaHbx.Value),
                CompetitionEntered = competitionBx.Enabled == true ? Convert.ToInt32(competitionBx.Value) : 0
            };
            try
            {
                var result = _databaseManager.AddAthlete(athlete);
                MessageBox.Show("New Athlete Added Successfully");
                LoadAthletesIntoComboBox();               
                ClearAthleteForm();
                DisableAthleteFields();
            }
            catch (Exception)
            {
                MessageBox.Show("New Athlete Adding not Successfull. \nTry again.");
                throw;
            }
        }

        private void ClearFormBtn_Click(object sender, EventArgs e)
        {
            ClearAthleteForm();
        }

        private void PlanCmbx_SelectedIndexChanged(object sender, EventArgs e)
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
        private void AtheleteSelectCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (atheleteSelectCbx.SelectedItem is Athlete selectedAthlete)
            {

                athleteNameTbx.Text = selectedAthlete.AthleteName;
                planCmbx.SelectedItem = selectedAthlete.TrainingPlan;
                comCatCbx.SelectedItem = selectedAthlete.CompetitionCategory;
                weightBx.Value = selectedAthlete.CurrentWeightKg;
                competitionBx.Value = selectedAthlete.CompetitionEntered;
                competitionBx.Enabled = false;
                prvtCoaHbx.Value = selectedAthlete.PrivateCoachingHours;
                athleteEditBtn.Show();
                athleteSaveBtn.Hide();
                clearFormBtn.Hide();
                updateSaveBtn.Hide();
                calCostBtn.Show();
                cancelUpdtBtn.Hide();
                DisableAthleteFields();

            }
        }
        private void AthleteEditBtn_Click(object sender, EventArgs e)
        {
            EnableAthleteFields();
            competitionBx.Enabled = true;
            athleteEditBtn.Hide();
            calCostBtn.Hide();
            atheleteSelectCbx.Enabled = false;
            updateSaveBtn.Show();
            cancelUpdtBtn.Show();
            cancelUpdtBtn.Enabled = true;
        }

        private void CalCostBtn_Click(object sender, EventArgs e)
        {
            kbTabCtrl.SelectedTab = costCalTab;
            costAthleteSlctCbx.SelectedItem = atheleteSelectCbx.SelectedItem;
            var selectedAthlete = costAthleteSlctCbx.SelectedItem as Athlete;
            CalculateMonthlyStatement(selectedAthlete);
        }

        private void CostAthleteSlctCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (costAthleteSlctCbx.SelectedItem is Athlete selectedAthlete)
            {
                CalculateMonthlyStatement(selectedAthlete);
            }

        }

        private void cancelUpdtBtn_Click(object sender, EventArgs e)
        {
            updateSaveBtn.Hide();
            athleteEditBtn.Hide();
            clearFormBtn.Hide();
            athleteSaveBtn.Hide();
            cancelUpdtBtn.Hide();
            atheleteSelectCbx.Enabled = true;
            DisableAthleteFields();
        }

        //Supporting Methods
        private void ClearAthleteForm()
        {
            athleteNameTbx.Clear();
            planCmbx.SelectedIndex = 0;
            comCatCbx.SelectedIndex = 0;
            weightBx.Value = weightBx.Minimum;
            competitionBx.Value = 0;
            prvtCoaHbx.Value = 0;
        }

        private void EnableAthleteFields()
        {
            athleteNameTbx.Enabled = true;
            planCmbx.Enabled = true;
            comCatCbx.Enabled = true;
            weightBx.Enabled = true;
            prvtCoaHbx.Enabled = true;
        }

        private void DisableAthleteFields()
        {
            athleteNameTbx.Enabled = false;
            planCmbx.Enabled = false;
            comCatCbx.Enabled = false;
            weightBx.Enabled = false;
            prvtCoaHbx.Enabled = false;
            competitionBx.Enabled = false;
        }
        private void LoadAthletesIntoComboBox()
        {
            try
            {
                List<Athlete> athletes = _databaseManager.GetAllAthletes();

                var listForAthleteTab = new List<Athlete>(athletes);

                atheleteSelectCbx.DataSource = listForAthleteTab;
                atheleteSelectCbx.DisplayMember = "AthleteName";
                atheleteSelectCbx.ValueMember = "AthleteID";

                var listForCalTab = new List<Athlete>(athletes);

                costAthleteSlctCbx.DataSource = listForCalTab;
                costAthleteSlctCbx.DisplayMember = "AthleteName";
                costAthleteSlctCbx.ValueMember = "AthleteID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load athletes");
            }
        }

        private void CalculateMonthlyStatement(Athlete selectedAthlete)
        {
            var costCal = new CostCalculator(selectedAthlete);

            trainingCostLbl.Text = costCal.GetTrainingCost().ToString();
            competitionCostLbl.Text = costCal.GetCompetitionCost().ToString();
            privateCoatchLbl.Text = costCal.GetPrivateTutionCost().ToString();
            totalCostLbl.Text = costCal.GetTotalCost().ToString();

            weightAnalysisLbl.Text = GetWeightAnalysis(selectedAthlete.CompetitionCategory,
                                                            selectedAthlete.CurrentWeightKg);
        }

        private string GetWeightAnalysis(WeightCategory weightCategory, decimal weight)
        {
            var upperLimit = 200m;
            var lowerLimit = 0m;
            switch (weightCategory)
            {
                case WeightCategory.Heavyweight:
                    lowerLimit = 100.1m;
                    break;
                case WeightCategory.Light_Heavyweight:
                    upperLimit = 100m;
                    lowerLimit = 90.1m;
                    break;
                case WeightCategory.Middleweight:
                    upperLimit = 90m;
                    lowerLimit = 81.1m;
                    break;
                case WeightCategory.Light_Middleweight:
                    upperLimit = 81m;
                    lowerLimit = 73.1m;
                    break;
                case WeightCategory.Lightweight:
                    upperLimit = 73m;
                    lowerLimit = 60.1m;
                    break;
                case WeightCategory.Flyweight:
                    upperLimit = 60m;
                    break;
                default:
                    break;
            }

            if (weight > upperLimit)
            {
                return "Above Category Weight";
            }
            else if (weight < lowerLimit)
            {
                return "Below Category Weight";
            }
            else
            {
                return "At Correct Weight";
            }
        }

    }

}
