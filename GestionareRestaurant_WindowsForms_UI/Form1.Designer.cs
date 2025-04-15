namespace GestionareRestaurant_WindowsForms_UI
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonAdauga = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonCautare = new System.Windows.Forms.Button();
            this.lblIDComanda = new System.Windows.Forms.Label();
            this.lblGarnituri = new System.Windows.Forms.Label();
            this.lblFelPrincipal = new System.Windows.Forms.Label();
            this.lblStareComanda = new System.Windows.Forms.Label();
            this.lblPretTotal = new System.Windows.Forms.Label();
            this.lblNrMasa = new System.Windows.Forms.Label();
            this.lblDesert = new System.Windows.Forms.Label();
            this.lblBautura = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonAdauga
            // 
            this.buttonAdauga.Location = new System.Drawing.Point(12, 77);
            this.buttonAdauga.Name = "buttonAdauga";
            this.buttonAdauga.Size = new System.Drawing.Size(75, 23);
            this.buttonAdauga.TabIndex = 0;
            this.buttonAdauga.Text = "Adauga";
            this.buttonAdauga.UseVisualStyleBackColor = true;
            this.buttonAdauga.Click += new System.EventHandler(this.buttonAdauga_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(12, 124);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 1;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonCautare
            // 
            this.buttonCautare.Location = new System.Drawing.Point(12, 167);
            this.buttonCautare.Name = "buttonCautare";
            this.buttonCautare.Size = new System.Drawing.Size(75, 23);
            this.buttonCautare.TabIndex = 2;
            this.buttonCautare.Text = "Cautare";
            this.buttonCautare.UseVisualStyleBackColor = true;
            this.buttonCautare.Click += new System.EventHandler(this.buttonCautare_Click);
            // 
            // lblIDComanda
            // 
            this.lblIDComanda.AutoSize = true;
            this.lblIDComanda.Location = new System.Drawing.Point(148, 38);
            this.lblIDComanda.Name = "lblIDComanda";
            this.lblIDComanda.Size = new System.Drawing.Size(82, 16);
            this.lblIDComanda.TabIndex = 3;
            this.lblIDComanda.Text = "ID Comanda";
            // 
            // lblGarnituri
            // 
            this.lblGarnituri.AutoSize = true;
            this.lblGarnituri.Location = new System.Drawing.Point(1099, 38);
            this.lblGarnituri.Name = "lblGarnituri";
            this.lblGarnituri.Size = new System.Drawing.Size(56, 16);
            this.lblGarnituri.TabIndex = 4;
            this.lblGarnituri.Text = "Garnituri";
            // 
            // lblFelPrincipal
            // 
            this.lblFelPrincipal.AutoSize = true;
            this.lblFelPrincipal.Location = new System.Drawing.Point(908, 38);
            this.lblFelPrincipal.Name = "lblFelPrincipal";
            this.lblFelPrincipal.Size = new System.Drawing.Size(75, 16);
            this.lblFelPrincipal.TabIndex = 5;
            this.lblFelPrincipal.Text = "FelPrincipa";
            // 
            // lblStareComanda
            // 
            this.lblStareComanda.AutoSize = true;
            this.lblStareComanda.Location = new System.Drawing.Point(730, 38);
            this.lblStareComanda.Name = "lblStareComanda";
            this.lblStareComanda.Size = new System.Drawing.Size(98, 16);
            this.lblStareComanda.TabIndex = 6;
            this.lblStareComanda.Text = "StareComanda";
            // 
            // lblPretTotal
            // 
            this.lblPretTotal.AutoSize = true;
            this.lblPretTotal.Location = new System.Drawing.Point(531, 38);
            this.lblPretTotal.Name = "lblPretTotal";
            this.lblPretTotal.Size = new System.Drawing.Size(62, 16);
            this.lblPretTotal.TabIndex = 7;
            this.lblPretTotal.Text = "PretTotal";
            // 
            // lblNrMasa
            // 
            this.lblNrMasa.AutoSize = true;
            this.lblNrMasa.Location = new System.Drawing.Point(365, 38);
            this.lblNrMasa.Name = "lblNrMasa";
            this.lblNrMasa.Size = new System.Drawing.Size(55, 16);
            this.lblNrMasa.TabIndex = 8;
            this.lblNrMasa.Text = "NrMasa";
            // 
            // lblDesert
            // 
            this.lblDesert.AutoSize = true;
            this.lblDesert.Location = new System.Drawing.Point(1468, 38);
            this.lblDesert.Name = "lblDesert";
            this.lblDesert.Size = new System.Drawing.Size(47, 16);
            this.lblDesert.TabIndex = 9;
            this.lblDesert.Text = "Desert";
            // 
            // lblBautura
            // 
            this.lblBautura.AutoSize = true;
            this.lblBautura.Location = new System.Drawing.Point(1283, 38);
            this.lblBautura.Name = "lblBautura";
            this.lblBautura.Size = new System.Drawing.Size(53, 16);
            this.lblBautura.TabIndex = 10;
            this.lblBautura.Text = "Bautura";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1709, 450);
            this.Controls.Add(this.lblBautura);
            this.Controls.Add(this.lblDesert);
            this.Controls.Add(this.lblNrMasa);
            this.Controls.Add(this.lblPretTotal);
            this.Controls.Add(this.lblStareComanda);
            this.Controls.Add(this.lblFelPrincipal);
            this.Controls.Add(this.lblGarnituri);
            this.Controls.Add(this.lblIDComanda);
            this.Controls.Add(this.buttonCautare);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonAdauga);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAdauga;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonCautare;
        private System.Windows.Forms.Label lblIDComanda;
        private System.Windows.Forms.Label lblGarnituri;
        private System.Windows.Forms.Label lblFelPrincipal;
        private System.Windows.Forms.Label lblStareComanda;
        private System.Windows.Forms.Label lblPretTotal;
        private System.Windows.Forms.Label lblNrMasa;
        private System.Windows.Forms.Label lblDesert;
        private System.Windows.Forms.Label lblBautura;
    }
}

