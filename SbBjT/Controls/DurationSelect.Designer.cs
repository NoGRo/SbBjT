namespace SbBjT.Controls
{
    partial class DurationSelect
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nrValue = new System.Windows.Forms.NumericUpDown();
            this.nrMin = new System.Windows.Forms.NumericUpDown();
            this.nrMax = new System.Windows.Forms.NumericUpDown();
            this.chkRandom = new System.Windows.Forms.CheckBox();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.gbTitle = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.nrValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrMax)).BeginInit();
            this.gbTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // nrValue
            // 
            this.nrValue.Location = new System.Drawing.Point(67, 19);
            this.nrValue.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nrValue.Name = "nrValue";
            this.nrValue.Size = new System.Drawing.Size(46, 20);
            this.nrValue.TabIndex = 0;
            // 
            // nrMin
            // 
            this.nrMin.Location = new System.Drawing.Point(67, 44);
            this.nrMin.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nrMin.Name = "nrMin";
            this.nrMin.Size = new System.Drawing.Size(46, 20);
            this.nrMin.TabIndex = 0;
            // 
            // nrMax
            // 
            this.nrMax.Location = new System.Drawing.Point(155, 44);
            this.nrMax.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nrMax.Name = "nrMax";
            this.nrMax.Size = new System.Drawing.Size(46, 20);
            this.nrMax.TabIndex = 0;
            // 
            // chkRandom
            // 
            this.chkRandom.AutoSize = true;
            this.chkRandom.Location = new System.Drawing.Point(122, 20);
            this.chkRandom.Name = "chkRandom";
            this.chkRandom.Size = new System.Drawing.Size(79, 17);
            this.chkRandom.TabIndex = 1;
            this.chkRandom.Text = "Randomize";
            this.chkRandom.UseVisualStyleBackColor = true;
            this.chkRandom.CheckedChanged += new System.EventHandler(this.chkRandom_CheckedChanged);
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(119, 46);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(30, 13);
            this.lblMax.TabIndex = 2;
            this.lblMax.Text = "Max:";
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(34, 46);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(27, 13);
            this.lblMin.TabIndex = 2;
            this.lblMin.Text = "Min:";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(24, 21);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(37, 13);
            this.lblValue.TabIndex = 2;
            this.lblValue.Text = "Value:";
            // 
            // gbTitle
            // 
            this.gbTitle.Controls.Add(this.lblMin);
            this.gbTitle.Controls.Add(this.lblMax);
            this.gbTitle.Controls.Add(this.chkRandom);
            this.gbTitle.Controls.Add(this.nrMax);
            this.gbTitle.Controls.Add(this.nrMin);
            this.gbTitle.Controls.Add(this.nrValue);
            this.gbTitle.Controls.Add(this.lblValue);
            this.gbTitle.Location = new System.Drawing.Point(0, 3);
            this.gbTitle.Name = "gbTitle";
            this.gbTitle.Size = new System.Drawing.Size(206, 72);
            this.gbTitle.TabIndex = 3;
            this.gbTitle.TabStop = false;
            this.gbTitle.Text = "groupBox1";
            this.gbTitle.Enter += new System.EventHandler(this.gbTitle_Enter);
            // 
            // DurationSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbTitle);
            this.Name = "DurationSelect";
            this.Size = new System.Drawing.Size(206, 75);
            ((System.ComponentModel.ISupportInitialize)(this.nrValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrMax)).EndInit();
            this.gbTitle.ResumeLayout(false);
            this.gbTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nrValue;
        private System.Windows.Forms.NumericUpDown nrMin;
        private System.Windows.Forms.NumericUpDown nrMax;
        private System.Windows.Forms.CheckBox chkRandom;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.GroupBox gbTitle;
    }
}
