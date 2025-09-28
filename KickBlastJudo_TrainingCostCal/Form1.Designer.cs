namespace KickBlastJudo_TrainingCostCal
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            kbTabCtrl = new TabControl();
            athleteTab = new TabPage();
            atheleteSelectCbx = new ComboBox();
            label16 = new Label();
            addAthleteBtn = new Button();
            groupBox1 = new GroupBox();
            updateSaveBtn = new Button();
            calCostBtn = new Button();
            comEligibleLbl = new Label();
            athleteEditBtn = new Button();
            prvtCoaHbx = new NumericUpDown();
            competitionBx = new NumericUpDown();
            comCatCbx = new ComboBox();
            weightBx = new NumericUpDown();
            planCmbx = new ComboBox();
            athleteNameTbx = new TextBox();
            clearFormBtn = new Button();
            athleteSaveBtn = new Button();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            costCalTab = new TabPage();
            costAthleteSlctCbx = new ComboBox();
            label2 = new Label();
            groupBox2 = new GroupBox();
            weightAnalysisLbl = new Label();
            label15 = new Label();
            totalCostLbl = new Label();
            label13 = new Label();
            groupBox3 = new GroupBox();
            privateCoatchLbl = new Label();
            competitionCostLbl = new Label();
            trainingCostLbl = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            kbTabCtrl.SuspendLayout();
            athleteTab.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)prvtCoaHbx).BeginInit();
            ((System.ComponentModel.ISupportInitialize)competitionBx).BeginInit();
            ((System.ComponentModel.ISupportInitialize)weightBx).BeginInit();
            costCalTab.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sans Serif Collection", 19.7999973F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 31);
            label1.Name = "label1";
            label1.Size = new Size(274, 112);
            label1.TabIndex = 1;
            label1.Text = "KickBlast Judo";
            // 
            // kbTabCtrl
            // 
            kbTabCtrl.Controls.Add(athleteTab);
            kbTabCtrl.Controls.Add(costCalTab);
            kbTabCtrl.Location = new Point(12, 140);
            kbTabCtrl.Name = "kbTabCtrl";
            kbTabCtrl.SelectedIndex = 0;
            kbTabCtrl.Size = new Size(858, 711);
            kbTabCtrl.TabIndex = 7;
            // 
            // athleteTab
            // 
            athleteTab.Controls.Add(atheleteSelectCbx);
            athleteTab.Controls.Add(label16);
            athleteTab.Controls.Add(addAthleteBtn);
            athleteTab.Controls.Add(groupBox1);
            athleteTab.Location = new Point(4, 40);
            athleteTab.Name = "athleteTab";
            athleteTab.Padding = new Padding(3);
            athleteTab.Size = new Size(850, 667);
            athleteTab.TabIndex = 0;
            athleteTab.Text = "Athlete";
            athleteTab.UseVisualStyleBackColor = true;
            // 
            // atheleteSelectCbx
            // 
            atheleteSelectCbx.FormattingEnabled = true;
            atheleteSelectCbx.Location = new Point(202, 40);
            atheleteSelectCbx.Name = "atheleteSelectCbx";
            atheleteSelectCbx.Size = new Size(342, 39);
            atheleteSelectCbx.TabIndex = 10;
            atheleteSelectCbx.SelectedIndexChanged += AtheleteSelectCbx_SelectedIndexChanged;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(30, 40);
            label16.Name = "label16";
            label16.Size = new Size(166, 31);
            label16.TabIndex = 9;
            label16.Text = "Select Athlete :";
            // 
            // addAthleteBtn
            // 
            addAthleteBtn.BackColor = SystemColors.GradientActiveCaption;
            addAthleteBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addAthleteBtn.Location = new Point(593, 39);
            addAthleteBtn.Name = "addAthleteBtn";
            addAthleteBtn.Size = new Size(229, 44);
            addAthleteBtn.TabIndex = 8;
            addAthleteBtn.Text = "Add New Athlete";
            addAthleteBtn.UseVisualStyleBackColor = false;
            addAthleteBtn.Click += AddAthleteBtn_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(updateSaveBtn);
            groupBox1.Controls.Add(calCostBtn);
            groupBox1.Controls.Add(comEligibleLbl);
            groupBox1.Controls.Add(athleteEditBtn);
            groupBox1.Controls.Add(prvtCoaHbx);
            groupBox1.Controls.Add(competitionBx);
            groupBox1.Controls.Add(comCatCbx);
            groupBox1.Controls.Add(weightBx);
            groupBox1.Controls.Add(planCmbx);
            groupBox1.Controls.Add(athleteNameTbx);
            groupBox1.Controls.Add(clearFormBtn);
            groupBox1.Controls.Add(athleteSaveBtn);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(30, 103);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(810, 548);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Athlete Information";
            // 
            // updateSaveBtn
            // 
            updateSaveBtn.BackColor = Color.LightSkyBlue;
            updateSaveBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            updateSaveBtn.Location = new Point(32, 455);
            updateSaveBtn.Name = "updateSaveBtn";
            updateSaveBtn.Size = new Size(146, 48);
            updateSaveBtn.TabIndex = 20;
            updateSaveBtn.Text = "Save";
            updateSaveBtn.UseVisualStyleBackColor = false;
            updateSaveBtn.Visible = false;
            // 
            // calCostBtn
            // 
            calCostBtn.BackColor = Color.Aquamarine;
            calCostBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            calCostBtn.Location = new Point(184, 454);
            calCostBtn.Name = "calCostBtn";
            calCostBtn.RightToLeft = RightToLeft.Yes;
            calCostBtn.Size = new Size(152, 49);
            calCostBtn.TabIndex = 19;
            calCostBtn.Text = "Calculate Cost";
            calCostBtn.UseVisualStyleBackColor = false;
            calCostBtn.Visible = false;
            calCostBtn.Click += CalCostBtn_Click;
            // 
            // comEligibleLbl
            // 
            comEligibleLbl.AutoSize = true;
            comEligibleLbl.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            comEligibleLbl.ForeColor = Color.RoyalBlue;
            comEligibleLbl.Location = new Point(455, 291);
            comEligibleLbl.Name = "comEligibleLbl";
            comEligibleLbl.Size = new Size(285, 28);
            comEligibleLbl.TabIndex = 18;
            comEligibleLbl.Text = "For Elite and Intermidiate only";
            // 
            // athleteEditBtn
            // 
            athleteEditBtn.BackColor = Color.DarkTurquoise;
            athleteEditBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            athleteEditBtn.Location = new Point(31, 455);
            athleteEditBtn.Name = "athleteEditBtn";
            athleteEditBtn.Size = new Size(146, 48);
            athleteEditBtn.TabIndex = 17;
            athleteEditBtn.Text = "Edit";
            athleteEditBtn.UseVisualStyleBackColor = false;
            athleteEditBtn.Visible = false;
            athleteEditBtn.Click += AthleteEditBtn_Click;
            // 
            // prvtCoaHbx
            // 
            prvtCoaHbx.Enabled = false;
            prvtCoaHbx.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            prvtCoaHbx.Location = new Point(373, 345);
            prvtCoaHbx.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            prvtCoaHbx.Name = "prvtCoaHbx";
            prvtCoaHbx.Size = new Size(75, 34);
            prvtCoaHbx.TabIndex = 16;
            // 
            // competitionBx
            // 
            competitionBx.Enabled = false;
            competitionBx.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            competitionBx.Location = new Point(373, 288);
            competitionBx.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            competitionBx.Name = "competitionBx";
            competitionBx.Size = new Size(76, 34);
            competitionBx.TabIndex = 15;
            // 
            // comCatCbx
            // 
            comCatCbx.Enabled = false;
            comCatCbx.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comCatCbx.FormattingEnabled = true;
            comCatCbx.Location = new Point(373, 231);
            comCatCbx.Name = "comCatCbx";
            comCatCbx.Size = new Size(295, 36);
            comCatCbx.TabIndex = 14;
            // 
            // weightBx
            // 
            weightBx.DecimalPlaces = 3;
            weightBx.Enabled = false;
            weightBx.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            weightBx.Location = new Point(373, 176);
            weightBx.Maximum = new decimal(new int[] { 150, 0, 0, 0 });
            weightBx.Name = "weightBx";
            weightBx.Size = new Size(102, 34);
            weightBx.TabIndex = 13;
            weightBx.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // planCmbx
            // 
            planCmbx.Enabled = false;
            planCmbx.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            planCmbx.FormattingEnabled = true;
            planCmbx.Location = new Point(373, 113);
            planCmbx.Name = "planCmbx";
            planCmbx.Size = new Size(419, 36);
            planCmbx.TabIndex = 12;
            planCmbx.SelectedIndexChanged += PlanCmbx_SelectedIndexChanged;
            // 
            // athleteNameTbx
            // 
            athleteNameTbx.Enabled = false;
            athleteNameTbx.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            athleteNameTbx.Location = new Point(373, 59);
            athleteNameTbx.Name = "athleteNameTbx";
            athleteNameTbx.Size = new Size(419, 34);
            athleteNameTbx.TabIndex = 11;
            // 
            // clearFormBtn
            // 
            clearFormBtn.BackColor = Color.LightCyan;
            clearFormBtn.Enabled = false;
            clearFormBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clearFormBtn.Location = new Point(184, 455);
            clearFormBtn.Name = "clearFormBtn";
            clearFormBtn.Size = new Size(146, 48);
            clearFormBtn.TabIndex = 7;
            clearFormBtn.Text = "Clear Form";
            clearFormBtn.UseVisualStyleBackColor = false;
            clearFormBtn.Click += ClearFormBtn_Click;
            // 
            // athleteSaveBtn
            // 
            athleteSaveBtn.BackColor = Color.LightSkyBlue;
            athleteSaveBtn.Enabled = false;
            athleteSaveBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            athleteSaveBtn.Location = new Point(32, 455);
            athleteSaveBtn.Name = "athleteSaveBtn";
            athleteSaveBtn.Size = new Size(146, 48);
            athleteSaveBtn.TabIndex = 6;
            athleteSaveBtn.Text = "Submit";
            athleteSaveBtn.UseVisualStyleBackColor = false;
            athleteSaveBtn.Click += AthleteSaveBtn_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(31, 351);
            label8.Name = "label8";
            label8.Size = new Size(230, 28);
            label8.TabIndex = 5;
            label8.Text = "Private Coaching Hours : ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(31, 294);
            label7.Name = "label7";
            label7.Size = new Size(275, 28);
            label7.TabIndex = 4;
            label7.Text = "No. of Competitions Entered : ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(31, 236);
            label6.Name = "label6";
            label6.Size = new Size(289, 28);
            label6.TabIndex = 3;
            label6.Text = "Competition Weight Category : ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(31, 178);
            label5.Name = "label5";
            label5.Size = new Size(205, 28);
            label5.TabIndex = 2;
            label5.Text = "Current Weight  (Kg) : ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(31, 121);
            label4.Name = "label4";
            label4.Size = new Size(132, 28);
            label4.TabIndex = 1;
            label4.Text = "Training Plan :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(31, 65);
            label3.Name = "label3";
            label3.Size = new Size(146, 28);
            label3.TabIndex = 0;
            label3.Text = "Athlete Name : ";
            // 
            // costCalTab
            // 
            costCalTab.Controls.Add(costAthleteSlctCbx);
            costCalTab.Controls.Add(label2);
            costCalTab.Controls.Add(groupBox2);
            costCalTab.Location = new Point(4, 40);
            costCalTab.Name = "costCalTab";
            costCalTab.Padding = new Padding(3);
            costCalTab.Size = new Size(850, 667);
            costCalTab.TabIndex = 1;
            costCalTab.Text = "Cost Calculator";
            costCalTab.UseVisualStyleBackColor = true;
            // 
            // costAthleteSlctCbx
            // 
            costAthleteSlctCbx.FormattingEnabled = true;
            costAthleteSlctCbx.Location = new Point(205, 25);
            costAthleteSlctCbx.Name = "costAthleteSlctCbx";
            costAthleteSlctCbx.Size = new Size(557, 39);
            costAthleteSlctCbx.TabIndex = 8;
            costAthleteSlctCbx.SelectedIndexChanged += CostAthleteSlctCbx_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 28);
            label2.Name = "label2";
            label2.Size = new Size(166, 31);
            label2.TabIndex = 7;
            label2.Text = "Select Athlete :";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(weightAnalysisLbl);
            groupBox2.Controls.Add(label15);
            groupBox2.Controls.Add(totalCostLbl);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Controls.Add(label9);
            groupBox2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(33, 89);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(729, 538);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Monthly Statement";
            // 
            // weightAnalysisLbl
            // 
            weightAnalysisLbl.AutoSize = true;
            weightAnalysisLbl.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            weightAnalysisLbl.Location = new Point(210, 394);
            weightAnalysisLbl.Name = "weightAnalysisLbl";
            weightAnalysisLbl.Size = new Size(0, 28);
            weightAnalysisLbl.TabIndex = 5;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.Location = new Point(18, 394);
            label15.Name = "label15";
            label15.Size = new Size(159, 28);
            label15.TabIndex = 4;
            label15.Text = "Weight Analysis: ";
            // 
            // totalCostLbl
            // 
            totalCostLbl.AutoSize = true;
            totalCostLbl.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            totalCostLbl.Location = new Point(210, 324);
            totalCostLbl.Name = "totalCostLbl";
            totalCostLbl.Size = new Size(47, 28);
            totalCostLbl.TabIndex = 3;
            totalCostLbl.Text = "Rs. ";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(18, 324);
            label13.Name = "label13";
            label13.Size = new Size(186, 28);
            label13.TabIndex = 2;
            label13.Text = "Total Monthly Cost: ";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(privateCoatchLbl);
            groupBox3.Controls.Add(competitionCostLbl);
            groupBox3.Controls.Add(trainingCostLbl);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(label10);
            groupBox3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(18, 83);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(692, 217);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            // 
            // privateCoatchLbl
            // 
            privateCoatchLbl.AutoSize = true;
            privateCoatchLbl.Location = new Point(248, 135);
            privateCoatchLbl.Name = "privateCoatchLbl";
            privateCoatchLbl.Size = new Size(49, 28);
            privateCoatchLbl.TabIndex = 5;
            privateCoatchLbl.Text = "0.00";
            // 
            // competitionCostLbl
            // 
            competitionCostLbl.AutoSize = true;
            competitionCostLbl.Location = new Point(248, 89);
            competitionCostLbl.Name = "competitionCostLbl";
            competitionCostLbl.Size = new Size(49, 28);
            competitionCostLbl.TabIndex = 4;
            competitionCostLbl.Text = "0.00";
            // 
            // trainingCostLbl
            // 
            trainingCostLbl.AutoSize = true;
            trainingCostLbl.Location = new Point(248, 46);
            trainingCostLbl.Name = "trainingCostLbl";
            trainingCostLbl.Size = new Size(0, 28);
            trainingCostLbl.TabIndex = 3;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(23, 135);
            label12.Name = "label12";
            label12.Size = new Size(207, 28);
            label12.TabIndex = 2;
            label12.Text = "Private Coaching   : Rs.";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(23, 89);
            label11.Name = "label11";
            label11.Size = new Size(208, 28);
            label11.TabIndex = 1;
            label11.Text = "Competitions         : Rs.";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(23, 46);
            label10.Name = "label10";
            label10.Size = new Size(209, 28);
            label10.TabIndex = 0;
            label10.Text = "Training                   : Rs.";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(18, 52);
            label9.Name = "label9";
            label9.Size = new Size(142, 28);
            label9.TabIndex = 0;
            label9.Text = "Itemised Costs:";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(876, 852);
            Controls.Add(kbTabCtrl);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5);
            Name = "Form1";
            Text = "KickBlast Judo - Training Cost Calculator";
            Load += Form1_Load;
            kbTabCtrl.ResumeLayout(false);
            athleteTab.ResumeLayout(false);
            athleteTab.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)prvtCoaHbx).EndInit();
            ((System.ComponentModel.ISupportInitialize)competitionBx).EndInit();
            ((System.ComponentModel.ISupportInitialize)weightBx).EndInit();
            costCalTab.ResumeLayout(false);
            costCalTab.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TabControl kbTabCtrl;
        private TabPage athleteTab;
        private TabPage costCalTab;
        private ComboBox atheleteSelectCbx;
        private Label label16;
        private Button addAthleteBtn;
        private GroupBox groupBox1;
        private Button clearFormBtn;
        private Button athleteSaveBtn;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private ComboBox costAthleteSlctCbx;
        private Label label2;
        private GroupBox groupBox2;
        private Label label15;
        private Label totalCostLbl;
        private Label label13;
        private GroupBox groupBox3;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private NumericUpDown weightBx;
        private ComboBox planCmbx;
        private TextBox athleteNameTbx;
        private NumericUpDown prvtCoaHbx;
        private NumericUpDown competitionBx;
        private ComboBox comCatCbx;
        private ContextMenuStrip contextMenuStrip1;
        private Button athleteEditBtn;
        private Label competitionCostLbl;
        private Label trainingCostLbl;
        private Label privateCoatchLbl;
        private Label weightAnalysisLbl;
        private Label comEligibleLbl;
        private Button calCostBtn;
        private Button updateSaveBtn;
    }
}
