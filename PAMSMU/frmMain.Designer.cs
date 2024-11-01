namespace PAMSMU
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOpeningMilitaryRecord = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbFullName = new System.Windows.Forms.TextBox();
            this.tbStatisticalNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbFullName = new System.Windows.Forms.RadioButton();
            this.rbStatisticalNumber = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lilTeam = new System.Windows.Forms.LinkLabel();
            this.btnShowMilitaryRecord = new System.Windows.Forms.Button();
            this.btnEntitlements = new System.Windows.Forms.Button();
            this.lblNumberOfPeople = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpeningMilitaryRecord
            // 
            this.btnOpeningMilitaryRecord.BackColor = System.Drawing.Color.Ivory;
            this.btnOpeningMilitaryRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpeningMilitaryRecord.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpeningMilitaryRecord.Location = new System.Drawing.Point(36, 444);
            this.btnOpeningMilitaryRecord.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpeningMilitaryRecord.Name = "btnOpeningMilitaryRecord";
            this.btnOpeningMilitaryRecord.Size = new System.Drawing.Size(279, 28);
            this.btnOpeningMilitaryRecord.TabIndex = 3;
            this.btnOpeningMilitaryRecord.Text = "فتح قيد جديد";
            this.btnOpeningMilitaryRecord.UseVisualStyleBackColor = false;
            this.btnOpeningMilitaryRecord.Click += new System.EventHandler(this.btnOpeningMilitaryRecord_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Honeydew;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Location = new System.Drawing.Point(36, 272);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(279, 28);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "بحث";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbFullName
            // 
            this.tbFullName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFullName.Location = new System.Drawing.Point(11, 217);
            this.tbFullName.Margin = new System.Windows.Forms.Padding(4);
            this.tbFullName.Name = "tbFullName";
            this.tbFullName.Size = new System.Drawing.Size(189, 27);
            this.tbFullName.TabIndex = 2;
            this.tbFullName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFullName_KeyPress);
            // 
            // tbStatisticalNumber
            // 
            this.tbStatisticalNumber.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStatisticalNumber.Location = new System.Drawing.Point(11, 171);
            this.tbStatisticalNumber.Margin = new System.Windows.Forms.Padding(4);
            this.tbStatisticalNumber.Name = "tbStatisticalNumber";
            this.tbStatisticalNumber.Size = new System.Drawing.Size(189, 27);
            this.tbStatisticalNumber.TabIndex = 3;
            this.tbStatisticalNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbStatisticalNumber_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 217);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = ":الاسم";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.lilTeam);
            this.panel2.Controls.Add(this.btnShowMilitaryRecord);
            this.panel2.Controls.Add(this.btnEntitlements);
            this.panel2.Controls.Add(this.lblNumberOfPeople);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnOpeningMilitaryRecord);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.tbFullName);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.tbStatisticalNumber);
            this.panel2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(496, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(348, 556);
            this.panel2.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Ivory;
            this.panel3.Controls.Add(this.rbFullName);
            this.panel3.Controls.Add(this.rbStatisticalNumber);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(11, 73);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(315, 91);
            this.panel3.TabIndex = 12;
            // 
            // rbFullName
            // 
            this.rbFullName.AutoSize = true;
            this.rbFullName.Location = new System.Drawing.Point(25, 48);
            this.rbFullName.Name = "rbFullName";
            this.rbFullName.Size = new System.Drawing.Size(80, 25);
            this.rbFullName.TabIndex = 19;
            this.rbFullName.Text = "الأسم";
            this.rbFullName.UseVisualStyleBackColor = true;
            this.rbFullName.CheckedChanged += new System.EventHandler(this.rbFullName_CheckedChanged);
            // 
            // rbStatisticalNumber
            // 
            this.rbStatisticalNumber.AutoSize = true;
            this.rbStatisticalNumber.Checked = true;
            this.rbStatisticalNumber.Location = new System.Drawing.Point(129, 48);
            this.rbStatisticalNumber.Name = "rbStatisticalNumber";
            this.rbStatisticalNumber.Size = new System.Drawing.Size(156, 25);
            this.rbStatisticalNumber.TabIndex = 18;
            this.rbStatisticalNumber.TabStop = true;
            this.rbStatisticalNumber.Text = "الرقم الاحصائي";
            this.rbStatisticalNumber.UseVisualStyleBackColor = true;
            this.rbStatisticalNumber.CheckedChanged += new System.EventHandler(this.rbStatisticalNumber_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 21);
            this.label2.TabIndex = 15;
            this.label2.Text = ":البحث من خلال";
            // 
            // lilTeam
            // 
            this.lilTeam.AutoSize = true;
            this.lilTeam.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lilTeam.LinkColor = System.Drawing.Color.Brown;
            this.lilTeam.Location = new System.Drawing.Point(217, 521);
            this.lilTeam.Name = "lilTeam";
            this.lilTeam.Size = new System.Drawing.Size(97, 24);
            this.lilTeam.TabIndex = 11;
            this.lilTeam.TabStop = true;
            this.lilTeam.Text = "المطورين";
            this.lilTeam.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Team_LinkClicked);
            // 
            // btnShowMilitaryRecord
            // 
            this.btnShowMilitaryRecord.BackColor = System.Drawing.Color.Turquoise;
            this.btnShowMilitaryRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowMilitaryRecord.Enabled = false;
            this.btnShowMilitaryRecord.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowMilitaryRecord.Location = new System.Drawing.Point(11, 321);
            this.btnShowMilitaryRecord.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowMilitaryRecord.Name = "btnShowMilitaryRecord";
            this.btnShowMilitaryRecord.Size = new System.Drawing.Size(159, 28);
            this.btnShowMilitaryRecord.TabIndex = 10;
            this.btnShowMilitaryRecord.Text = "عرض المعلومات";
            this.btnShowMilitaryRecord.UseVisualStyleBackColor = false;
            this.btnShowMilitaryRecord.Click += new System.EventHandler(this.btnShowMilitaryRecord_Click);
            // 
            // btnEntitlements
            // 
            this.btnEntitlements.BackColor = System.Drawing.Color.Turquoise;
            this.btnEntitlements.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEntitlements.Enabled = false;
            this.btnEntitlements.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEntitlements.Location = new System.Drawing.Point(177, 321);
            this.btnEntitlements.Margin = new System.Windows.Forms.Padding(4);
            this.btnEntitlements.Name = "btnEntitlements";
            this.btnEntitlements.Size = new System.Drawing.Size(159, 28);
            this.btnEntitlements.TabIndex = 9;
            this.btnEntitlements.Text = "الاستحقاقات";
            this.btnEntitlements.UseVisualStyleBackColor = false;
            this.btnEntitlements.Click += new System.EventHandler(this.tbShowEntitlements_Click);
            // 
            // lblNumberOfPeople
            // 
            this.lblNumberOfPeople.AutoSize = true;
            this.lblNumberOfPeople.Location = new System.Drawing.Point(122, 39);
            this.lblNumberOfPeople.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumberOfPeople.Name = "lblNumberOfPeople";
            this.lblNumberOfPeople.Size = new System.Drawing.Size(78, 21);
            this.lblNumberOfPeople.TabIndex = 8;
            this.lblNumberOfPeople.Text = "العدد##";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = ":العدد الكلي";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(199, 175);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = ":الرقم الاحصائي";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::PAMSMU.Properties.Resources.Coat_of_arms_of_Iraq_svg;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Location = new System.Drawing.Point(3, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(491, 556);
            this.panel1.TabIndex = 7;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.PaleVioletRed;
            this.btnLogout.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLogout.FlatAppearance.BorderSize = 2;
            this.btnLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnLogout.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(9, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(152, 44);
            this.btnLogout.TabIndex = 13;
            this.btnLogout.Text = "تسجيل خروج";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CancelButton = this.btnLogout;
            this.ClientSize = new System.Drawing.Size(840, 554);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PAMSMU";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnOpeningMilitaryRecord;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbFullName;
        private System.Windows.Forms.TextBox tbStatisticalNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNumberOfPeople;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnShowMilitaryRecord;
        private System.Windows.Forms.Button btnEntitlements;
        private System.Windows.Forms.LinkLabel lilTeam;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbFullName;
        private System.Windows.Forms.RadioButton rbStatisticalNumber;
        private System.Windows.Forms.Button btnLogout;
    }
}