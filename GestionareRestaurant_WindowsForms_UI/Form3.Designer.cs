namespace GestionareRestaurant_WindowsForms_UI
{
    partial class Form3
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
            this.lblIDComanda = new System.Windows.Forms.Label();
            this.txtIDComanda = new System.Windows.Forms.TextBox();
            this.buttonCautare = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblIDComanda
            // 
            this.lblIDComanda.AutoSize = true;
            this.lblIDComanda.Location = new System.Drawing.Point(34, 39);
            this.lblIDComanda.Name = "lblIDComanda";
            this.lblIDComanda.Size = new System.Drawing.Size(82, 16);
            this.lblIDComanda.TabIndex = 0;
            this.lblIDComanda.Text = "ID Comanda";
            // 
            // txtIDComanda
            // 
            this.txtIDComanda.Location = new System.Drawing.Point(157, 39);
            this.txtIDComanda.Name = "txtIDComanda";
            this.txtIDComanda.Size = new System.Drawing.Size(100, 22);
            this.txtIDComanda.TabIndex = 1;
            // 
            // buttonCautare
            // 
            this.buttonCautare.Location = new System.Drawing.Point(318, 37);
            this.buttonCautare.Name = "buttonCautare";
            this.buttonCautare.Size = new System.Drawing.Size(75, 23);
            this.buttonCautare.TabIndex = 2;
            this.buttonCautare.Text = "Cautare";
            this.buttonCautare.UseVisualStyleBackColor = true;
            this.buttonCautare.Click += new System.EventHandler(this.buttonCautare_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCautare);
            this.Controls.Add(this.txtIDComanda);
            this.Controls.Add(this.lblIDComanda);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIDComanda;
        private System.Windows.Forms.TextBox txtIDComanda;
        private System.Windows.Forms.Button buttonCautare;
    }
}