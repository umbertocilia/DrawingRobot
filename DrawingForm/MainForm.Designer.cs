namespace DrawingForm
{
    partial class MainForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblY = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.lblAlfa = new System.Windows.Forms.Label();
            this.lblBeta = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelDataBlocks = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pbSend = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPoints = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSegments = new System.Windows.Forms.Label();
            this.pbClear = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClear)).BeginInit();
            this.SuspendLayout();
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblY.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblY.Location = new System.Drawing.Point(78, 8);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(35, 18);
            this.lblY.TabIndex = 0;
            this.lblY.Text = "lblY";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblX.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblX.Location = new System.Drawing.Point(10, 8);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(36, 18);
            this.lblX.TabIndex = 1;
            this.lblX.Text = "lblX";
            // 
            // lblAlfa
            // 
            this.lblAlfa.AutoSize = true;
            this.lblAlfa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlfa.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblAlfa.Location = new System.Drawing.Point(303, 8);
            this.lblAlfa.Name = "lblAlfa";
            this.lblAlfa.Size = new System.Drawing.Size(52, 18);
            this.lblAlfa.TabIndex = 3;
            this.lblAlfa.Text = "label1";
            // 
            // lblBeta
            // 
            this.lblBeta.AutoSize = true;
            this.lblBeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeta.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblBeta.Location = new System.Drawing.Point(209, 8);
            this.lblBeta.Name = "lblBeta";
            this.lblBeta.Size = new System.Drawing.Size(52, 18);
            this.lblBeta.TabIndex = 2;
            this.lblBeta.Text = "label2";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(-3, -3);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(449, 677);
            this.panel1.TabIndex = 7;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(66)))), ((int)(((byte)(99)))));
            this.panel2.Controls.Add(this.lblX);
            this.panel2.Controls.Add(this.lblY);
            this.panel2.Controls.Add(this.lblBeta);
            this.panel2.Controls.Add(this.lblAlfa);
            this.panel2.Location = new System.Drawing.Point(462, 625);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(382, 34);
            this.panel2.TabIndex = 9;
            // 
            // panelDataBlocks
            // 
            this.panelDataBlocks.Location = new System.Drawing.Point(462, 337);
            this.panelDataBlocks.Name = "panelDataBlocks";
            this.panelDataBlocks.Size = new System.Drawing.Size(1, 1);
            this.panelDataBlocks.TabIndex = 10;
            this.panelDataBlocks.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDataBloks_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::DrawingForm.Properties.Resources.arrow__1_;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(524, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 40);
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // pbSend
            // 
            this.pbSend.BackgroundImage = global::DrawingForm.Properties.Resources.send1;
            this.pbSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbSend.Location = new System.Drawing.Point(468, 12);
            this.pbSend.Name = "pbSend";
            this.pbSend.Size = new System.Drawing.Size(40, 40);
            this.pbSend.TabIndex = 11;
            this.pbSend.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(828, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPoints);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.groupBox1.Location = new System.Drawing.Point(462, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(74, 60);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Points";
            // 
            // lblPoints
            // 
            this.lblPoints.AutoSize = true;
            this.lblPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoints.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblPoints.Location = new System.Drawing.Point(5, 21);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(60, 25);
            this.lblPoints.TabIndex = 4;
            this.lblPoints.Text = "HDU";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblSegments);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.groupBox2.Location = new System.Drawing.Point(543, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(74, 60);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Segments";
            // 
            // lblSegments
            // 
            this.lblSegments.AutoSize = true;
            this.lblSegments.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSegments.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblSegments.Location = new System.Drawing.Point(6, 21);
            this.lblSegments.Name = "lblSegments";
            this.lblSegments.Size = new System.Drawing.Size(44, 25);
            this.lblSegments.TabIndex = 5;
            this.lblSegments.Text = "DU";
            // 
            // pbClear
            // 
            this.pbClear.BackgroundImage = global::DrawingForm.Properties.Resources.cancel;
            this.pbClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbClear.Location = new System.Drawing.Point(580, 12);
            this.pbClear.Name = "pbClear";
            this.pbClear.Size = new System.Drawing.Size(40, 40);
            this.pbClear.TabIndex = 15;
            this.pbClear.TabStop = false;
            this.pbClear.Click += new System.EventHandler(this.pbClear_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(856, 671);
            this.Controls.Add(this.pbClear);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pbSend);
            this.Controls.Add(this.panelDataBlocks);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDataBloks_Paint);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClear)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblAlfa;
        private System.Windows.Forms.Label lblBeta;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelDataBlocks;
        private System.Windows.Forms.PictureBox pbSend;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblSegments;
        private System.Windows.Forms.PictureBox pbClear;
    }
}

