namespace DentiClinic
{
    partial class Form2
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
            this.reservationControl1 = new DentiClinic.Controls.ReservationControl();
            this.SuspendLayout();
            // 
            // reservationControl1
            // 
            this.reservationControl1.DaysNumber = 0;
            this.reservationControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reservationControl1.DSTimesWeek = null;
            this.reservationControl1.Location = new System.Drawing.Point(0, 0);
            this.reservationControl1.Name = "reservationControl1";
            this.reservationControl1.oGroup = null;
            this.reservationControl1.Size = new System.Drawing.Size(1022, 611);
            this.reservationControl1.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1022, 611);
            this.Controls.Add(this.reservationControl1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ReservationControl reservationControl1;


    }
}