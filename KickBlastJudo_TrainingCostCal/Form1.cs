namespace KickBlastJudo_TrainingCostCal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addAthleteBtn_Click(object sender, EventArgs e)
        {
            athleteNameTbx.Enabled = true;
            planCmbx.Enabled = true;
            weightCatCbx.Enabled = true;
            weightBx.Enabled = true;
            competitionBx.Enabled = true;
            prvtCoaHbx.Enabled = true;
            athleteSaveBtn.Enabled = true;
            clearFormBtn.Enabled = true;
        }
    }
}
