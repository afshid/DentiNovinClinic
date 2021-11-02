using System.Windows.Forms;
using DentiClinic.Controls;
namespace DentiClinic
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private ToothView toothView1;
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
            this.label1 = new System.Windows.Forms.Label();
            this.visitTable1 = new DentiClinic.Controls.NewVisitTable();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(478, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "1";

            
            
            this.toothView1 = new DentiClinic.Controls.ToothView();

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
            // 
            // visitTable1
            // 
            this.visitTable1.DaysNumber = 0;
            this.visitTable1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visitTable1.DSTimesWeek = null;
            this.visitTable1.IsNull = false;
            this.visitTable1.Location = new System.Drawing.Point(0, 0);
            this.visitTable1.Name = "visitTable1";
            this.visitTable1.oGroup = null;
            this.visitTable1.SelectedDateTime = new System.DateTime(2012, 2, 17, 18, 7, 2, 130);
            this.visitTable1.Size = new System.Drawing.Size(921, 603);
            this.visitTable1.TabIndex = 2;
            this.visitTable1.Text = "newVisitTable1";
            this.visitTable1.RegisterClicked += new DentiClinic.BaseClasses.VisitNodeEventHandler(this.visitTable1_RegisterClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 603);
            this.Controls.Add(this.visitTable1);
            this.Controls.Add(this.toothView1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DentiClinic.Controls.ToothChart toothChart1;
        private System.Windows.Forms.Label label1;
        private Controls.NewVisitTable visitTable1;
    }
}