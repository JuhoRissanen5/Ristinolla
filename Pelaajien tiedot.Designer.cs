namespace Ristinolla
{
    partial class Pelaajientiedot
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
            this.dgvPelaajat = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPelaajat)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPelaajat
            // 
            this.dgvPelaajat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPelaajat.Location = new System.Drawing.Point(29, 0);
            this.dgvPelaajat.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPelaajat.Name = "dgvPelaajat";
            this.dgvPelaajat.ReadOnly = true;
            this.dgvPelaajat.RowHeadersWidth = 51;
            this.dgvPelaajat.Size = new System.Drawing.Size(1361, 615);
            this.dgvPelaajat.TabIndex = 0;
            // 
            // Pelaajientiedot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1728, 710);
            this.Controls.Add(this.dgvPelaajat);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Pelaajientiedot";
            this.Text = "Pelaajientiedot";
            this.Load += new System.EventHandler(this.Pelaajientiedot_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPelaajat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPelaajat;
    }
}