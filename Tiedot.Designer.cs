namespace Ristinolla
{
    partial class Tiedot
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
            this.components = new System.ComponentModel.Container();
            this.cb1 = new System.Windows.Forms.ComboBox();
            this.btnTallenna = new System.Windows.Forms.Button();
            this.lblTiedot = new System.Windows.Forms.Label();
            this.lblSyntymavuosi = new System.Windows.Forms.Label();
            this.lblSukunimi = new System.Windows.Forms.Label();
            this.lblEtunimi = new System.Windows.Forms.Label();
            this.tbSyntymavuosi = new System.Windows.Forms.TextBox();
            this.tbSukunimi = new System.Windows.Forms.TextBox();
            this.tbEtunimi = new System.Windows.Forms.TextBox();
            this.btnTietokone = new System.Windows.Forms.Button();
            this.btnToinenpelaaja = new System.Windows.Forms.Button();
            this.btnPoistu = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // cb1
            // 
            this.cb1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb1.FormattingEnabled = true;
            this.cb1.Location = new System.Drawing.Point(231, 86);
            this.cb1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb1.Name = "cb1";
            this.cb1.Size = new System.Drawing.Size(195, 24);
            this.cb1.TabIndex = 34;
            this.cb1.Leave += new System.EventHandler(this.cb1_Leave);
            // 
            // btnTallenna
            // 
            this.btnTallenna.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTallenna.Location = new System.Drawing.Point(293, 346);
            this.btnTallenna.Margin = new System.Windows.Forms.Padding(4);
            this.btnTallenna.Name = "btnTallenna";
            this.btnTallenna.Size = new System.Drawing.Size(133, 33);
            this.btnTallenna.TabIndex = 33;
            this.btnTallenna.Text = "Tallenna";
            this.btnTallenna.UseVisualStyleBackColor = true;
            this.btnTallenna.Click += new System.EventHandler(this.btnTallenna_Click);
            // 
            // lblTiedot
            // 
            this.lblTiedot.AutoSize = true;
            this.lblTiedot.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiedot.Location = new System.Drawing.Point(71, 22);
            this.lblTiedot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTiedot.Name = "lblTiedot";
            this.lblTiedot.Size = new System.Drawing.Size(323, 29);
            this.lblTiedot.TabIndex = 32;
            this.lblTiedot.Text = "Anna tiedot tai valitse pelaaja";
            // 
            // lblSyntymavuosi
            // 
            this.lblSyntymavuosi.AutoSize = true;
            this.lblSyntymavuosi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSyntymavuosi.Location = new System.Drawing.Point(63, 250);
            this.lblSyntymavuosi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSyntymavuosi.Name = "lblSyntymavuosi";
            this.lblSyntymavuosi.Size = new System.Drawing.Size(112, 20);
            this.lblSyntymavuosi.TabIndex = 31;
            this.lblSyntymavuosi.Text = "Syntymävuosi";
            // 
            // lblSukunimi
            // 
            this.lblSukunimi.AutoSize = true;
            this.lblSukunimi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSukunimi.Location = new System.Drawing.Point(99, 193);
            this.lblSukunimi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSukunimi.Name = "lblSukunimi";
            this.lblSukunimi.Size = new System.Drawing.Size(77, 20);
            this.lblSukunimi.TabIndex = 30;
            this.lblSukunimi.Text = "Sukunimi";
            // 
            // lblEtunimi
            // 
            this.lblEtunimi.AutoSize = true;
            this.lblEtunimi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEtunimi.Location = new System.Drawing.Point(113, 146);
            this.lblEtunimi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEtunimi.Name = "lblEtunimi";
            this.lblEtunimi.Size = new System.Drawing.Size(65, 20);
            this.lblEtunimi.TabIndex = 29;
            this.lblEtunimi.Text = "Etunimi";
            // 
            // tbSyntymavuosi
            // 
            this.tbSyntymavuosi.Location = new System.Drawing.Point(293, 254);
            this.tbSyntymavuosi.Margin = new System.Windows.Forms.Padding(4);
            this.tbSyntymavuosi.MaxLength = 4;
            this.tbSyntymavuosi.Name = "tbSyntymavuosi";
            this.tbSyntymavuosi.Size = new System.Drawing.Size(132, 22);
            this.tbSyntymavuosi.TabIndex = 28;
            this.tbSyntymavuosi.Text = "1";
            this.tbSyntymavuosi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSyntymavuosi_KeyPress);
            this.tbSyntymavuosi.Validating += new System.ComponentModel.CancelEventHandler(this.tbSyntymavuosi_Validating);
            // 
            // tbSukunimi
            // 
            this.tbSukunimi.Location = new System.Drawing.Point(293, 203);
            this.tbSukunimi.Margin = new System.Windows.Forms.Padding(4);
            this.tbSukunimi.MaxLength = 15;
            this.tbSukunimi.Name = "tbSukunimi";
            this.tbSukunimi.Size = new System.Drawing.Size(132, 22);
            this.tbSukunimi.TabIndex = 27;
            this.tbSukunimi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSukunimi_KeyPress);
            // 
            // tbEtunimi
            // 
            this.tbEtunimi.Location = new System.Drawing.Point(293, 146);
            this.tbEtunimi.Margin = new System.Windows.Forms.Padding(4);
            this.tbEtunimi.MaxLength = 15;
            this.tbEtunimi.Name = "tbEtunimi";
            this.tbEtunimi.Size = new System.Drawing.Size(132, 22);
            this.tbEtunimi.TabIndex = 26;
            this.tbEtunimi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbEtunimi_KeyPress);
            // 
            // btnTietokone
            // 
            this.btnTietokone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTietokone.Location = new System.Drawing.Point(527, 86);
            this.btnTietokone.Margin = new System.Windows.Forms.Padding(4);
            this.btnTietokone.Name = "btnTietokone";
            this.btnTietokone.Size = new System.Drawing.Size(133, 102);
            this.btnTietokone.TabIndex = 35;
            this.btnTietokone.Text = "Tietokonetta vastaan";
            this.btnTietokone.UseVisualStyleBackColor = true;
            this.btnTietokone.Visible = false;
            this.btnTietokone.Click += new System.EventHandler(this.btnTietokone_Click);
            // 
            // btnToinenpelaaja
            // 
            this.btnToinenpelaaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToinenpelaaja.Location = new System.Drawing.Point(527, 224);
            this.btnToinenpelaaja.Margin = new System.Windows.Forms.Padding(4);
            this.btnToinenpelaaja.Name = "btnToinenpelaaja";
            this.btnToinenpelaaja.Size = new System.Drawing.Size(133, 108);
            this.btnToinenpelaaja.TabIndex = 36;
            this.btnToinenpelaaja.Text = "Toista pelaajaa vastaan";
            this.btnToinenpelaaja.UseVisualStyleBackColor = true;
            this.btnToinenpelaaja.Visible = false;
            this.btnToinenpelaaja.Click += new System.EventHandler(this.btnToinenpelaaja_Click);
            // 
            // btnPoistu
            // 
            this.btnPoistu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPoistu.Location = new System.Drawing.Point(527, 346);
            this.btnPoistu.Margin = new System.Windows.Forms.Padding(4);
            this.btnPoistu.Name = "btnPoistu";
            this.btnPoistu.Size = new System.Drawing.Size(133, 33);
            this.btnPoistu.TabIndex = 37;
            this.btnPoistu.Text = "Poistu";
            this.btnPoistu.UseVisualStyleBackColor = true;
            this.btnPoistu.Click += new System.EventHandler(this.btnPoistu_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // Tiedot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 549);
            this.Controls.Add(this.btnPoistu);
            this.Controls.Add(this.btnToinenpelaaja);
            this.Controls.Add(this.btnTietokone);
            this.Controls.Add(this.cb1);
            this.Controls.Add(this.btnTallenna);
            this.Controls.Add(this.lblTiedot);
            this.Controls.Add(this.lblSyntymavuosi);
            this.Controls.Add(this.lblSukunimi);
            this.Controls.Add(this.lblEtunimi);
            this.Controls.Add(this.tbSyntymavuosi);
            this.Controls.Add(this.tbSukunimi);
            this.Controls.Add(this.tbEtunimi);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Tiedot";
            this.Text = "Tiedot ristinollaan";
            this.Load += new System.EventHandler(this.Tiedot_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb1;
        private System.Windows.Forms.Button btnTallenna;
        private System.Windows.Forms.Label lblTiedot;
        private System.Windows.Forms.Label lblSyntymavuosi;
        private System.Windows.Forms.Label lblSukunimi;
        private System.Windows.Forms.Label lblEtunimi;
        private System.Windows.Forms.TextBox tbSyntymavuosi;
        private System.Windows.Forms.TextBox tbSukunimi;
        private System.Windows.Forms.TextBox tbEtunimi;
        private System.Windows.Forms.Button btnTietokone;
        private System.Windows.Forms.Button btnToinenpelaaja;
        private System.Windows.Forms.Button btnPoistu;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
    }
}