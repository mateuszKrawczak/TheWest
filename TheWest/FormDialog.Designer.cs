namespace TheWest
{
    partial class FormDialog
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
            this.labelAmountMoney = new System.Windows.Forms.Label();
            this.textBoxAmountMoney = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelAmountMoney
            // 
            this.labelAmountMoney.AutoSize = true;
            this.labelAmountMoney.Font = new System.Drawing.Font("Stencil", 12F);
            this.labelAmountMoney.Location = new System.Drawing.Point(71, 32);
            this.labelAmountMoney.Name = "labelAmountMoney";
            this.labelAmountMoney.Size = new System.Drawing.Size(243, 19);
            this.labelAmountMoney.TabIndex = 0;
            this.labelAmountMoney.Text = "Enter the amount of money";
            // 
            // textBoxAmountMoney
            // 
            this.textBoxAmountMoney.Location = new System.Drawing.Point(150, 74);
            this.textBoxAmountMoney.Name = "textBoxAmountMoney";
            this.textBoxAmountMoney.Size = new System.Drawing.Size(92, 20);
            this.textBoxAmountMoney.TabIndex = 1;
            // 
            // buttonOk
            // 
            this.buttonOk.Font = new System.Drawing.Font("Stencil", 10F);
            this.buttonOk.Location = new System.Drawing.Point(150, 115);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(92, 23);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // FormDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TheWest.Properties.Resources.western_background;
            this.ClientSize = new System.Drawing.Size(387, 178);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.textBoxAmountMoney);
            this.Controls.Add(this.labelAmountMoney);
            this.Name = "FormDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Amount of money";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAmountMoney;
        public System.Windows.Forms.TextBox textBoxAmountMoney;
        private System.Windows.Forms.Button buttonOk;
    }
}