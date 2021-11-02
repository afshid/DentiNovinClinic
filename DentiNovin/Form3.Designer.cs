using DentiClinic.Controls;
namespace DentiClinic
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
            this.toothView1 = new DentiClinic.Controls.ToothView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // toothView1
            // 
            this.toothView1.CompletedColor = System.Drawing.Color.Empty;
            this.toothView1.ConditionsColor = System.Drawing.Color.Empty;
            this.toothView1.CurrentColor = System.Drawing.Color.Red;
            this.toothView1.CurrentTooth = null;
            this.toothView1.CurrentToothTreatment = null;
            this.toothView1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.toothView1.Location = new System.Drawing.Point(0, 0);
            this.toothView1.Margin = new System.Windows.Forms.Padding(0);
            this.toothView1.Name = "toothView1";
            this.toothView1.PlannedColor = System.Drawing.Color.Empty;
            this.toothView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toothView1.Size = new System.Drawing.Size(52, 151);
            this.toothView1.TabIndex = 0;
            this.toothView1.TActionMode = DentiClinic.Common.ActionMode.None;
            this.toothView1.ToothAlternativeImage = null;
            this.toothView1.ToothImage = global::DentiClinic.Properties.Resources.T_38;
            this.toothView1.ToothTreatmentList = null;
            this.toothView1.Click += new System.EventHandler(this.toothView1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(203, 106);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(203, 143);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 2;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 262);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.toothView1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ToothView toothView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}