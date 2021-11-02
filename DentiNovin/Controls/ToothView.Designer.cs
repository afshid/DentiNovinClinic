namespace DentiNovin.Controls
{
    partial class ToothView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiPrimaryTooth = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPermanetTooth = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiChangeAllToPrimary = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangeAllToPermanent = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowTreatmentListOntyThis = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowTreatmentListAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 151);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPrimaryTooth,
            this.tsmiPermanetTooth,
            this.toolStripSeparator1,
            this.tsmiChangeAllToPrimary,
            this.tsmiChangeAllToPermanent,
            this.toolStripSeparator2,
            this.tsmiShowTreatmentListOntyThis,
            this.tsmiShowTreatmentListAll});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.ShowItemToolTips = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(229, 170);
            // 
            // tsmiPrimaryTooth
            // 
            this.tsmiPrimaryTooth.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmiPrimaryTooth.Name = "tsmiPrimaryTooth";
            this.tsmiPrimaryTooth.Size = new System.Drawing.Size(228, 22);
            this.tsmiPrimaryTooth.Text = "دندان موقت";
            this.tsmiPrimaryTooth.Click += new System.EventHandler(this.tsmiPrimaryTooth_Click);
            // 
            // tsmiPermanetTooth
            // 
            this.tsmiPermanetTooth.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmiPermanetTooth.Name = "tsmiPermanetTooth";
            this.tsmiPermanetTooth.Size = new System.Drawing.Size(228, 22);
            this.tsmiPermanetTooth.Text = "دندان دائمی";
            this.tsmiPermanetTooth.Click += new System.EventHandler(this.tsmiPermanetTooth_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(225, 6);
            // 
            // tsmiChangeAllToPrimary
            // 
            this.tsmiChangeAllToPrimary.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmiChangeAllToPrimary.Name = "tsmiChangeAllToPrimary";
            this.tsmiChangeAllToPrimary.Size = new System.Drawing.Size(228, 22);
            this.tsmiChangeAllToPrimary.Text = "تبدیل تمامی دندانها به اولیه ";
            this.tsmiChangeAllToPrimary.Click += new System.EventHandler(this.tsmiChangeAllToPrimary_Click);
            // 
            // tsmiChangeAllToPermanent
            // 
            this.tsmiChangeAllToPermanent.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmiChangeAllToPermanent.Name = "tsmiChangeAllToPermanent";
            this.tsmiChangeAllToPermanent.Size = new System.Drawing.Size(228, 22);
            this.tsmiChangeAllToPermanent.Text = "تبدیل تمامی دندانها به دندان دائمی";
            this.tsmiChangeAllToPermanent.Click += new System.EventHandler(this.tsmiChangeAllToPermanent_Click);
            // 
            // tsmiShowTreatmentListOntyThis
            // 
            this.tsmiShowTreatmentListOntyThis.Name = "tsmiShowTreatmentListOntyThis";
            this.tsmiShowTreatmentListOntyThis.Size = new System.Drawing.Size(228, 22);
            this.tsmiShowTreatmentListOntyThis.Text = "لیست درمانهای این دندان";
            this.tsmiShowTreatmentListOntyThis.Click += new System.EventHandler(this.tsmiShowTreatmentListOntyThis_Click);
            // 
            // tsmiShowTreatmentListAll
            // 
            this.tsmiShowTreatmentListAll.Name = "tsmiShowTreatmentListAll";
            this.tsmiShowTreatmentListAll.Size = new System.Drawing.Size(228, 22);
            this.tsmiShowTreatmentListAll.Text = "لیست درمانهای تمامی دندانها";
            this.tsmiShowTreatmentListAll.Click += new System.EventHandler(this.tsmiShowTreatmentListAll_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(225, 6);
            // 
            // ToothView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ToothView";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(52, 151);
            this.Load += new System.EventHandler(this.ToothView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrimaryTooth;
        private System.Windows.Forms.ToolStripMenuItem tsmiPermanetTooth;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangeAllToPrimary;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangeAllToPermanent;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowTreatmentListOntyThis;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowTreatmentListAll;
    }
}
