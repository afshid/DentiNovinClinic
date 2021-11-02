namespace DentiNovin
{
    partial class AlertForm
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
            this.txtAlertMass1 = new System.Windows.Forms.TextBox();
            this.txtAlertMass2 = new System.Windows.Forms.TextBox();
            this.txtAlertMass3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ChkDontShow = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtAlertMass1
            // 
            this.txtAlertMass1.BackColor = System.Drawing.Color.White;
            this.txtAlertMass1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAlertMass1.Location = new System.Drawing.Point(1, 3);
            this.txtAlertMass1.Multiline = true;
            this.txtAlertMass1.Name = "txtAlertMass1";
            this.txtAlertMass1.ReadOnly = true;
            this.txtAlertMass1.Size = new System.Drawing.Size(409, 92);
            this.txtAlertMass1.TabIndex = 0;
            // 
            // txtAlertMass2
            // 
            this.txtAlertMass2.BackColor = System.Drawing.Color.White;
            this.txtAlertMass2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAlertMass2.Location = new System.Drawing.Point(1, 97);
            this.txtAlertMass2.Multiline = true;
            this.txtAlertMass2.Name = "txtAlertMass2";
            this.txtAlertMass2.ReadOnly = true;
            this.txtAlertMass2.Size = new System.Drawing.Size(409, 92);
            this.txtAlertMass2.TabIndex = 1;
            // 
            // txtAlertMass3
            // 
            this.txtAlertMass3.BackColor = System.Drawing.Color.White;
            this.txtAlertMass3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAlertMass3.Location = new System.Drawing.Point(1, 191);
            this.txtAlertMass3.Multiline = true;
            this.txtAlertMass3.Name = "txtAlertMass3";
            this.txtAlertMass3.ReadOnly = true;
            this.txtAlertMass3.Size = new System.Drawing.Size(409, 92);
            this.txtAlertMass3.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(324, 294);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "تایید";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChkDontShow
            // 
            this.ChkDontShow.AutoSize = true;
            this.ChkDontShow.Location = new System.Drawing.Point(12, 296);
            this.ChkDontShow.Name = "ChkDontShow";
            this.ChkDontShow.Size = new System.Drawing.Size(144, 17);
            this.ChkDontShow.TabIndex = 4;
            this.ChkDontShow.Text = "عدم نمایش برای این بیمار";
            this.ChkDontShow.UseVisualStyleBackColor = true;
            // 
            // AlertForm
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 326);
            this.Controls.Add(this.ChkDontShow);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtAlertMass3);
            this.Controls.Add(this.txtAlertMass2);
            this.Controls.Add(this.txtAlertMass1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlertForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "هشدار";
            this.Load += new System.EventHandler(this.AlertForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAlertMass1;
        private System.Windows.Forms.TextBox txtAlertMass2;
        private System.Windows.Forms.TextBox txtAlertMass3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox ChkDontShow;
    }
}