namespace SbBjT.Controls
{
    partial class AreaDetector
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
            this.pnlWebCam = new System.Windows.Forms.Panel();
            this.cmbDickPart = new System.Windows.Forms.ComboBox();
            this.btnPick = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlWebCam
            // 
            this.pnlWebCam.Location = new System.Drawing.Point(0, 30);
            this.pnlWebCam.Name = "pnlWebCam";
            this.pnlWebCam.Size = new System.Drawing.Size(640, 480);
            this.pnlWebCam.TabIndex = 0;
            this.pnlWebCam.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlWebCam_Paint);
            this.pnlWebCam.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlWebCam_MouseDown);
            this.pnlWebCam.MouseLeave += new System.EventHandler(this.pnlWebCam_MouseLeave);
            this.pnlWebCam.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlWebCam_MouseMove);
            this.pnlWebCam.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlWebCam_MouseUp);
            // 
            // cmbDickPart
            // 
            this.cmbDickPart.FormattingEnabled = true;
            this.cmbDickPart.Location = new System.Drawing.Point(0, 3);
            this.cmbDickPart.Name = "cmbDickPart";
            this.cmbDickPart.Size = new System.Drawing.Size(121, 21);
            this.cmbDickPart.TabIndex = 2;
            this.cmbDickPart.SelectedIndexChanged += new System.EventHandler(this.cmbDickPart_SelectedIndexChanged);
            // 
            // btnPick
            // 
            this.btnPick.Location = new System.Drawing.Point(126, 3);
            this.btnPick.Name = "btnPick";
            this.btnPick.Size = new System.Drawing.Size(71, 21);
            this.btnPick.TabIndex = 3;
            this.btnPick.Text = "Pick Color";
            this.btnPick.UseVisualStyleBackColor = true;
            this.btnPick.Click += new System.EventHandler(this.btnPick_Click);
            // 
            // AreaDetector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPick);
            this.Controls.Add(this.cmbDickPart);
            this.Controls.Add(this.pnlWebCam);
            this.Name = "AreaDetector";
            this.Size = new System.Drawing.Size(654, 530);
            this.Load += new System.EventHandler(this.AreaDetector_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlWebCam;
        private System.Windows.Forms.ComboBox cmbDickPart;
        private System.Windows.Forms.Button btnPick;
    }
}
