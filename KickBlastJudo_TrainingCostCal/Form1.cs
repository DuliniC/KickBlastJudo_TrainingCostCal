using KickBlastJudo_TrainingCostCal.Database;

namespace KickBlastJudo_TrainingCostCal
{
    public partial class Form1 : Form
    {
        private readonly DatabaseManager _databaseManager;
        private bool _isDataLoaded = false;
        private List<WeightCategory> _weightCategories;
        private List<Fee> _fees;

        public Form1()
        {
            InitializeComponent();
            _databaseManager = new DatabaseManager();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataFromDatabase();
            LoadAthletesIntoComboBox();
            _isDataLoaded = true;
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

        private void AthleteSaveBtn_Click(object sender, EventArgs e)
        {
            if (ValidateAthleteInputs())
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
                    MessageBox.Show("New Athlete Added Successfully", "Success", MessageBoxButtons.OK);
                    LoadAthletesIntoComboBox();
                    ClearAthleteForm();
                    DisableAthleteFields();
                }
                catch (Exception)
                {
                    MessageBox.Show("New Athlete Adding not Successfull. \nTry again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
        }

        private void ClearFormBtn_Click(object sender, EventArgs e)
        {
            ClearAthleteForm();
        }

        private void PlanCmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Competition box Only Enable with Elite and Intemediate plans.
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
            if (!_isDataLoaded)
            {
                return;
            }

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
            if (!_isDataLoaded)
            {
                return;
            }

            if (costAthleteSlctCbx.SelectedItem is Athlete selectedAthlete)
            {
                CalculateMonthlyStatement(selectedAthlete);
            }

        }

        private void CancelUpdtBtn_Click(object sender, EventArgs e)
        {
            updateSaveBtn.Hide();
            athleteEditBtn.Hide();
            clearFormBtn.Hide();
            athleteSaveBtn.Hide();
            cancelUpdtBtn.Hide();
            atheleteSelectCbx.Enabled = true;
            DisableAthleteFields();
        }

        private void UpdateSaveBtn_Click(object sender, EventArgs e)
        {
            if (atheleteSelectCbx.SelectedItem is Athlete selectedAthlete)
            {
                if (ValidateAthleteInputs())
                {
                    try
                    {
                        selectedAthlete.AthleteName = athleteNameTbx.Text;
                        selectedAthlete.TrainingPlan = (TrainingPlan)planCmbx.SelectedValue;
                        selectedAthlete.CurrentWeightKg = weightBx.Value;
                        selectedAthlete.CompetitionCategory = (WeightCategory)comCatCbx.SelectedItem;
                        selectedAthlete.PrivateCoachingHours = Convert.ToInt32(prvtCoaHbx.Value);
                        selectedAthlete.CompetitionEntered = competitionBx.Enabled ? Convert.ToInt32(competitionBx.Value) : 0;

                        int rowsAffected = _databaseManager.EditAthlete(selectedAthlete);

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Athlete updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to update athlete.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred. Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            LoadAthletesIntoComboBox();
            DisableAthleteFields();
            ClearAthleteForm();
            ClearCostCalValues();
            atheleteSelectCbx.Enabled = true;
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

        private void ClearCostCalValues()
        {
            trainingCostLbl.Text = "Fee for Plan * Sessions per Week * Weeks per month";
            competitionCostLbl.Text = "Competitions Entered * Competition Fee";
            privateCoachLbl.Text = "Private Coaching Hours * Private Coaching Fee";
            totalCostLbl.Text = "0.00";
            weightAnalysisLbl.Text = string.Empty;
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

        private void LoadDataFromDatabase()
        {
            var trainingPlans = _databaseManager.GetTrainingPlans();


            planCmbx.DataSource = trainingPlans;
            planCmbx.DisplayMember = "DisplayText";
            planCmbx.ValueMember = "PlanID";

            _weightCategories = _databaseManager.GetWeightCategories();

            comCatCbx.DataSource = _weightCategories;
            comCatCbx.DisplayMember = "DisplayText";
            comCatCbx.ValueMember = "CategoryID";

            _fees = _databaseManager.GetFees();

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

                atheleteSelectCbx.SelectedIndex = -1;
                atheleteSelectCbx.Text = "-- Select Athlete --";
                var listForCalTab = new List<Athlete>(athletes);

                costAthleteSlctCbx.DataSource = listForCalTab;
                costAthleteSlctCbx.DisplayMember = "AthleteName";
                costAthleteSlctCbx.ValueMember = "AthleteID";

                costAthleteSlctCbx.SelectedIndex = -1;
                costAthleteSlctCbx.Text = "-- Select Athlete --";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load athletes", "Error", MessageBoxButtons.OK);
            }
        }
        private void CalculateMonthlyStatement(Athlete selectedAthlete)
        {
            var feeLookup = _fees.ToDictionary(f => f.FeeType, f => f.Amount);

            var costCal = new CostCalculator(selectedAthlete, feeLookup);

            var monthlyCost = costCal.FindMonthlyCost();

            trainingCostLbl.Text = $"{selectedAthlete.TrainingPlan.WeeklyFee} * " +
                $"{selectedAthlete.TrainingPlan.SessionsPerWeek} * 4 = {monthlyCost.TrainingCost}";
            competitionCostLbl.Text = $"{selectedAthlete.CompetitionEntered} * {feeLookup["CompetitionFee"]} " +
                $"= {monthlyCost.CompetitionCost}";
            privateCoachLbl.Text = $"{selectedAthlete.PrivateCoachingHours} * {feeLookup["PrivateCoatchingFee"]} " +
                $"= {monthlyCost.PrivateCoachingCost}";
            totalCostLbl.Text = monthlyCost.TotalCost.ToString();

            weightAnalysisLbl.Text = GetWeightAnalysis(selectedAthlete.CompetitionCategory,
                                                            selectedAthlete.CurrentWeightKg);
            _databaseManager.SaveMonthlyCost(monthlyCost);

        }

        private string GetWeightAnalysis(WeightCategory weightCategory, decimal currentWeight)
        {
            decimal lowerLimit = 0;
            var orderIndex = weightCategory.DisplayOrder;

            if (orderIndex > 1)
            {
                var prevoiusCatUpperLimit = _weightCategories.Where(c => c.DisplayOrder == orderIndex - 1).FirstOrDefault();
                lowerLimit = prevoiusCatUpperLimit.UpperWeightLimit.Value;

                if (currentWeight < lowerLimit)
                {
                    return "Underweight";
                }
                else if (weightCategory.UpperWeightLimit.HasValue && currentWeight > weightCategory.UpperWeightLimit.Value)
                {
                    return "Overweight";
                }
            }
            return "Correct Category";
        }

        // Validations
        private bool ValidateAthleteInputs()
        {
            var validationErrors = new List<string>();

            if (string.IsNullOrWhiteSpace(athleteNameTbx.Text))
            {
                validationErrors.Add(" - Athlete Name cannot be empty.");
            }

            if (weightBx.Value <= 0)
            {
                validationErrors.Add(" - Current Weight must be greater than zero.");
            }

            if (prvtCoaHbx.Value > 5)
            {
                validationErrors.Add(" - Maximum private coaching hours is 5.");
            }

            if (prvtCoaHbx.Value < 0)
            {
                validationErrors.Add(" - Private coaching hours cannot be negative.");
            }

            if (planCmbx.SelectedIndex == 0 && competitionBx.Value > 0)
            {
                validationErrors.Add(" - Only Elite and Intermediate plans can enter into competitions");
            }

            if (competitionBx.Enabled && competitionBx.Value < 0)
            {
                validationErrors.Add(" - Competitions Entered cannot be a negative number.");
            }

            if (validationErrors.Any())
            {
                string errorMessage = string.Join(Environment.NewLine, validationErrors);

                MessageBox.Show(errorMessage, "Validation Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

    }

}
