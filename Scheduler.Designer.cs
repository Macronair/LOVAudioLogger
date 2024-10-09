namespace MarcosIcecastRecorder
{
    partial class frmScheduler
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
            this.listScheduler = new System.Windows.Forms.ListView();
            this.clDay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clProgram = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSave = new System.Windows.Forms.Button();
            this.lblSelectedIndex = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listScheduler
            // 
            this.listScheduler.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clDay,
            this.clProgram});
            this.listScheduler.FullRowSelect = true;
            this.listScheduler.GridLines = true;
            this.listScheduler.HideSelection = false;
            this.listScheduler.Location = new System.Drawing.Point(12, 12);
            this.listScheduler.MultiSelect = false;
            this.listScheduler.Name = "listScheduler";
            this.listScheduler.Size = new System.Drawing.Size(460, 520);
            this.listScheduler.TabIndex = 0;
            this.listScheduler.UseCompatibleStateImageBehavior = false;
            this.listScheduler.View = System.Windows.Forms.View.Details;
            this.listScheduler.SelectedIndexChanged += new System.EventHandler(this.listScheduler_SelectedIndexChanged);
            this.listScheduler.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listScheduler_MouseDoubleClick);
            // 
            // clDay
            // 
            this.clDay.Text = "Day";
            this.clDay.Width = 120;
            // 
            // clProgram
            // 
            this.clProgram.Text = "Program";
            this.clProgram.Width = 250;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(397, 538);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblSelectedIndex
            // 
            this.lblSelectedIndex.AutoSize = true;
            this.lblSelectedIndex.Location = new System.Drawing.Point(12, 543);
            this.lblSelectedIndex.Name = "lblSelectedIndex";
            this.lblSelectedIndex.Size = new System.Drawing.Size(75, 13);
            this.lblSelectedIndex.TabIndex = 2;
            this.lblSelectedIndex.Text = "Selected Item:";
            // 
            // frmScheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 568);
            this.Controls.Add(this.lblSelectedIndex);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.listScheduler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmScheduler";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Scheduler";
            this.Load += new System.EventHandler(this.frmScheduler_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listScheduler;
        private System.Windows.Forms.ColumnHeader clDay;
        private System.Windows.Forms.ColumnHeader clProgram;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblSelectedIndex;
    }
}