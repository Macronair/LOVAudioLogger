namespace MarcosIcecastRecorder
{
    partial class Settings
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtSourceURL = new System.Windows.Forms.TextBox();
            this.radSourcePhysical = new System.Windows.Forms.RadioButton();
            this.cmbSourcePhysical = new System.Windows.Forms.ComboBox();
            this.radSourceURL = new System.Windows.Forms.RadioButton();
            this.txtLoggerFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLoggerLocation = new System.Windows.Forms.TextBox();
            this.btnChooseLoggerLocation = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnProgramScheduler = new System.Windows.Forms.Button();
            this.radFSbyDayProgram = new System.Windows.Forms.RadioButton();
            this.radFSbyProgramDay = new System.Windows.Forms.RadioButton();
            this.radFSbyProgram = new System.Windows.Forms.RadioButton();
            this.radFSbyDay = new System.Windows.Forms.RadioButton();
            this.radFSNone = new System.Windows.Forms.RadioButton();
            this.chkSyncWithFullHour = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.btnSaveRestart = new System.Windows.Forms.Button();
            this.fldLoggerLocation = new System.Windows.Forms.FolderBrowserDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.nmrRecordingDuration = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.chkUseTempFolder = new System.Windows.Forms.CheckBox();
            this.btnShowSavedRecordings = new System.Windows.Forms.Button();
            this.nmrDaysToKeep = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrRecordingDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrDaysToKeep)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(376, 435);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 36);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(21, 435);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 36);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtSourceURL
            // 
            this.txtSourceURL.Location = new System.Drawing.Point(108, 75);
            this.txtSourceURL.Name = "txtSourceURL";
            this.txtSourceURL.Size = new System.Drawing.Size(334, 20);
            this.txtSourceURL.TabIndex = 2;
            // 
            // radSourcePhysical
            // 
            this.radSourcePhysical.AutoSize = true;
            this.radSourcePhysical.Location = new System.Drawing.Point(16, 49);
            this.radSourcePhysical.Name = "radSourcePhysical";
            this.radSourcePhysical.Size = new System.Drawing.Size(64, 17);
            this.radSourcePhysical.TabIndex = 3;
            this.radSourcePhysical.Text = "Physical";
            this.radSourcePhysical.UseVisualStyleBackColor = true;
            this.radSourcePhysical.CheckedChanged += new System.EventHandler(this.radSourcePhysical_CheckedChanged);
            // 
            // cmbSourcePhysical
            // 
            this.cmbSourcePhysical.Enabled = false;
            this.cmbSourcePhysical.FormattingEnabled = true;
            this.cmbSourcePhysical.Location = new System.Drawing.Point(107, 48);
            this.cmbSourcePhysical.Name = "cmbSourcePhysical";
            this.cmbSourcePhysical.Size = new System.Drawing.Size(335, 21);
            this.cmbSourcePhysical.TabIndex = 4;
            // 
            // radSourceURL
            // 
            this.radSourceURL.AutoSize = true;
            this.radSourceURL.Checked = true;
            this.radSourceURL.Location = new System.Drawing.Point(16, 76);
            this.radSourceURL.Name = "radSourceURL";
            this.radSourceURL.Size = new System.Drawing.Size(47, 17);
            this.radSourceURL.TabIndex = 5;
            this.radSourceURL.TabStop = true;
            this.radSourceURL.Text = "URL";
            this.radSourceURL.UseVisualStyleBackColor = true;
            this.radSourceURL.CheckedChanged += new System.EventHandler(this.radSourceURL_CheckedChanged);
            // 
            // txtLoggerFileName
            // 
            this.txtLoggerFileName.Location = new System.Drawing.Point(107, 159);
            this.txtLoggerFileName.Name = "txtLoggerFileName";
            this.txtLoggerFileName.Size = new System.Drawing.Size(254, 20);
            this.txtLoggerFileName.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Filename:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(359, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = ".mp3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Logger location:";
            // 
            // txtLoggerLocation
            // 
            this.txtLoggerLocation.Location = new System.Drawing.Point(107, 133);
            this.txtLoggerLocation.Name = "txtLoggerLocation";
            this.txtLoggerLocation.Size = new System.Drawing.Size(254, 20);
            this.txtLoggerLocation.TabIndex = 10;
            // 
            // btnChooseLoggerLocation
            // 
            this.btnChooseLoggerLocation.Location = new System.Drawing.Point(367, 131);
            this.btnChooseLoggerLocation.Name = "btnChooseLoggerLocation";
            this.btnChooseLoggerLocation.Size = new System.Drawing.Size(102, 23);
            this.btnChooseLoggerLocation.TabIndex = 11;
            this.btnChooseLoggerLocation.Text = "Choose folder";
            this.btnChooseLoggerLocation.UseVisualStyleBackColor = true;
            this.btnChooseLoggerLocation.Click += new System.EventHandler(this.btnChooseLoggerLocation_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnProgramScheduler);
            this.groupBox1.Controls.Add(this.radFSbyDayProgram);
            this.groupBox1.Controls.Add(this.radFSbyProgramDay);
            this.groupBox1.Controls.Add(this.radFSbyProgram);
            this.groupBox1.Controls.Add(this.radFSbyDay);
            this.groupBox1.Controls.Add(this.radFSNone);
            this.groupBox1.Location = new System.Drawing.Point(16, 253);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 138);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File structuring";
            // 
            // btnProgramScheduler
            // 
            this.btnProgramScheduler.Location = new System.Drawing.Point(333, 13);
            this.btnProgramScheduler.Name = "btnProgramScheduler";
            this.btnProgramScheduler.Size = new System.Drawing.Size(114, 23);
            this.btnProgramScheduler.TabIndex = 5;
            this.btnProgramScheduler.Text = "Program scheduler";
            this.btnProgramScheduler.UseVisualStyleBackColor = true;
            this.btnProgramScheduler.Click += new System.EventHandler(this.btnProgramScheduler_Click);
            // 
            // radFSbyDayProgram
            // 
            this.radFSbyDayProgram.AutoSize = true;
            this.radFSbyDayProgram.Location = new System.Drawing.Point(6, 111);
            this.radFSbyDayProgram.Name = "radFSbyDayProgram";
            this.radFSbyDayProgram.Size = new System.Drawing.Size(380, 17);
            this.radFSbyDayProgram.TabIndex = 4;
            this.radFSbyDayProgram.TabStop = true;
            this.radFSbyDayProgram.Text = "By day + program (create folder for each day + subfolders for each program)";
            this.radFSbyDayProgram.UseVisualStyleBackColor = true;
            this.radFSbyDayProgram.CheckedChanged += new System.EventHandler(this.RecordingMode_CheckedChanged);
            // 
            // radFSbyProgramDay
            // 
            this.radFSbyProgramDay.AutoSize = true;
            this.radFSbyProgramDay.Location = new System.Drawing.Point(6, 88);
            this.radFSbyProgramDay.Name = "radFSbyProgramDay";
            this.radFSbyProgramDay.Size = new System.Drawing.Size(380, 17);
            this.radFSbyProgramDay.TabIndex = 3;
            this.radFSbyProgramDay.TabStop = true;
            this.radFSbyProgramDay.Text = "By program + day (create folder for each program + subfolders for each day)";
            this.radFSbyProgramDay.UseVisualStyleBackColor = true;
            this.radFSbyProgramDay.CheckedChanged += new System.EventHandler(this.RecordingMode_CheckedChanged);
            // 
            // radFSbyProgram
            // 
            this.radFSbyProgram.AutoSize = true;
            this.radFSbyProgram.Location = new System.Drawing.Point(6, 65);
            this.radFSbyProgram.Name = "radFSbyProgram";
            this.radFSbyProgram.Size = new System.Drawing.Size(229, 17);
            this.radFSbyProgram.TabIndex = 2;
            this.radFSbyProgram.TabStop = true;
            this.radFSbyProgram.Text = "By program (create folder for each program)";
            this.radFSbyProgram.UseVisualStyleBackColor = true;
            this.radFSbyProgram.CheckedChanged += new System.EventHandler(this.RecordingMode_CheckedChanged);
            // 
            // radFSbyDay
            // 
            this.radFSbyDay.AutoSize = true;
            this.radFSbyDay.Location = new System.Drawing.Point(6, 42);
            this.radFSbyDay.Name = "radFSbyDay";
            this.radFSbyDay.Size = new System.Drawing.Size(187, 17);
            this.radFSbyDay.TabIndex = 1;
            this.radFSbyDay.TabStop = true;
            this.radFSbyDay.Text = "By day (create folder for each day)";
            this.radFSbyDay.UseVisualStyleBackColor = true;
            this.radFSbyDay.CheckedChanged += new System.EventHandler(this.RecordingMode_CheckedChanged);
            // 
            // radFSNone
            // 
            this.radFSNone.AutoSize = true;
            this.radFSNone.Location = new System.Drawing.Point(6, 19);
            this.radFSNone.Name = "radFSNone";
            this.radFSNone.Size = new System.Drawing.Size(145, 17);
            this.radFSNone.TabIndex = 0;
            this.radFSNone.TabStop = true;
            this.radFSNone.Text = "None (no folder structure)";
            this.radFSNone.UseVisualStyleBackColor = true;
            this.radFSNone.CheckedChanged += new System.EventHandler(this.RecordingMode_CheckedChanged);
            // 
            // chkSyncWithFullHour
            // 
            this.chkSyncWithFullHour.AutoSize = true;
            this.chkSyncWithFullHour.Location = new System.Drawing.Point(107, 110);
            this.chkSyncWithFullHour.Name = "chkSyncWithFullHour";
            this.chkSyncWithFullHour.Size = new System.Drawing.Size(112, 17);
            this.chkSyncWithFullHour.TabIndex = 13;
            this.chkSyncWithFullHour.Text = "Sync with full hour";
            this.chkSyncWithFullHour.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Title:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(108, 12);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(216, 20);
            this.txtTitle.TabIndex = 15;
            // 
            // btnSaveRestart
            // 
            this.btnSaveRestart.Location = new System.Drawing.Point(277, 435);
            this.btnSaveRestart.Name = "btnSaveRestart";
            this.btnSaveRestart.Size = new System.Drawing.Size(93, 36);
            this.btnSaveRestart.TabIndex = 16;
            this.btnSaveRestart.Text = "Save and Restart logger";
            this.btnSaveRestart.UseVisualStyleBackColor = true;
            this.btnSaveRestart.Click += new System.EventHandler(this.btnSaveRestart_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(105, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Max. recording duration:";
            // 
            // nmrRecordingDuration
            // 
            this.nmrRecordingDuration.Location = new System.Drawing.Point(232, 183);
            this.nmrRecordingDuration.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nmrRecordingDuration.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmrRecordingDuration.Name = "nmrRecordingDuration";
            this.nmrRecordingDuration.Size = new System.Drawing.Size(72, 20);
            this.nmrRecordingDuration.TabIndex = 18;
            this.nmrRecordingDuration.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(305, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "sec";
            // 
            // chkUseTempFolder
            // 
            this.chkUseTempFolder.AutoSize = true;
            this.chkUseTempFolder.Location = new System.Drawing.Point(359, 186);
            this.chkUseTempFolder.Name = "chkUseTempFolder";
            this.chkUseTempFolder.Size = new System.Drawing.Size(104, 17);
            this.chkUseTempFolder.TabIndex = 20;
            this.chkUseTempFolder.Text = "Use Temp folder";
            this.chkUseTempFolder.UseVisualStyleBackColor = true;
            // 
            // btnShowSavedRecordings
            // 
            this.btnShowSavedRecordings.Location = new System.Drawing.Point(16, 396);
            this.btnShowSavedRecordings.Name = "btnShowSavedRecordings";
            this.btnShowSavedRecordings.Size = new System.Drawing.Size(192, 23);
            this.btnShowSavedRecordings.TabIndex = 21;
            this.btnShowSavedRecordings.Text = "Show saved recordings";
            this.btnShowSavedRecordings.UseVisualStyleBackColor = true;
            this.btnShowSavedRecordings.Click += new System.EventHandler(this.btnShowSavedRecordings_Click);
            // 
            // nmrDaysToKeep
            // 
            this.nmrDaysToKeep.Location = new System.Drawing.Point(232, 227);
            this.nmrDaysToKeep.Maximum = new decimal(new int[] {
            1095,
            0,
            0,
            0});
            this.nmrDaysToKeep.Name = "nmrDaysToKeep";
            this.nmrDaysToKeep.Size = new System.Drawing.Size(72, 20);
            this.nmrDaysToKeep.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(69, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Total days to keep recordings:";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 483);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nmrDaysToKeep);
            this.Controls.Add(this.btnShowSavedRecordings);
            this.Controls.Add(this.chkUseTempFolder);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nmrRecordingDuration);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSaveRestart);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkSyncWithFullHour);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnChooseLoggerLocation);
            this.Controls.Add(this.txtLoggerLocation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLoggerFileName);
            this.Controls.Add(this.radSourceURL);
            this.Controls.Add(this.cmbSourcePhysical);
            this.Controls.Add(this.radSourcePhysical);
            this.Controls.Add(this.txtSourceURL);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Name = "Settings";
            this.ShowIcon = false;
            this.Text = "Recorder settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrRecordingDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrDaysToKeep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtSourceURL;
        private System.Windows.Forms.RadioButton radSourcePhysical;
        private System.Windows.Forms.ComboBox cmbSourcePhysical;
        private System.Windows.Forms.RadioButton radSourceURL;
        private System.Windows.Forms.TextBox txtLoggerFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLoggerLocation;
        private System.Windows.Forms.Button btnChooseLoggerLocation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnProgramScheduler;
        private System.Windows.Forms.RadioButton radFSbyDayProgram;
        private System.Windows.Forms.RadioButton radFSbyProgramDay;
        private System.Windows.Forms.RadioButton radFSbyProgram;
        private System.Windows.Forms.RadioButton radFSbyDay;
        private System.Windows.Forms.RadioButton radFSNone;
        private System.Windows.Forms.CheckBox chkSyncWithFullHour;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Button btnSaveRestart;
        private System.Windows.Forms.FolderBrowserDialog fldLoggerLocation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nmrRecordingDuration;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkUseTempFolder;
        private System.Windows.Forms.Button btnShowSavedRecordings;
        private System.Windows.Forms.NumericUpDown nmrDaysToKeep;
        private System.Windows.Forms.Label label7;
    }
}