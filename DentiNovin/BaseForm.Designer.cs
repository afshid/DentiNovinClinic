namespace DentiNovin
{
    partial class BaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BaseForm";
            this.Text = "BaseForm";
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.ResizeBegin += new System.EventHandler(this.BaseForm_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.BaseForm_ResizeEnd);
            //this.Paint += new System.Windows.Forms.PaintEventHandler(this.BaseForm_Paint);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.BaseForm_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BaseForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BaseForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BaseForm_MouseUp);
            this.Resize += new System.EventHandler(this.BaseForm_Resize);
            this.ResumeLayout(false);

        }

        #endregion


    }
}