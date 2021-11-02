using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DentiNovin.Common;
using System.Drawing.Imaging;
using System.IO;
using DentiNovin.BusinessLogic;
using DentiNovin.BaseClasses;

namespace DentiNovin
{
    public partial class XRayImageForm : BaseForm
    {
        private PatientTreatmentBLL _fPatientTreatmentBLL;
        public PatientTreatmentBLL FPatientTreatmentBLL
        {
            get
            {
                if (_fPatientTreatmentBLL == null)
                    _fPatientTreatmentBLL = new PatientTreatmentBLL();
                return _fPatientTreatmentBLL;
            }
            set
            {
                _fPatientTreatmentBLL = value;
            }
        }

        private XRayImage _oXRayImage;
        public XRayImage OXRayImage
        {
            get
            {
                //if (_oXRayImage == null)
                //    _oXRayImage = new XRayImage();
                return _oXRayImage;
            }
            set { _oXRayImage = value; }
        }

        public bool  ShowMode { get; set; }

        public event EventHandler ImageSaved;

        public XRayImageForm()
        {
            InitializeComponent();
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "IMAGE Files|*.jpg;*.jpeg;*.bmp";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Bitmap aBitmap = new Bitmap(dlg.FileName);
                pictureBox1.Image = aBitmap;
                OXRayImage.Image = pictureBox1.Image;

                //FPatientTreatmentBLL.oXRayImage = this.OXRayImage;
                //FPatientTreatmentBLL.InsertXRayImage();
                //ImageChange = true;
                btnSave.Enabled = true;
            }
        }

        private void XRayImageForm_Load(object sender, EventArgs e)
        {
            this.fdpImageDate.SelectedDateTime = DateTime.Now;
            btnSave.Enabled = false;
            if (ShowMode)
            {
                btnADD.Enabled = false;
                fdpImageDate.Text = OXRayImage.DateOfRegister;
                pictureBox1.Image = OXRayImage.Image;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.OXRayImage.DateOfRegister = fdpImageDate.Text;
            this.OXRayImage.Imagebyte = Utilises.ConvertImageToByteArray(this.OXRayImage.Image, ImageFormat.Jpeg);
            FPatientTreatmentBLL.oXRayImage = this.OXRayImage;
            try
            {
            FPatientTreatmentBLL.InsertXRayImage();
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1083");
                MessageBox.Show("بروز خطا در ذخیره سازی عکس دندان بیمار", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //btnSave.Enabled = false;
            //btnADD.Enabled = false;
            OnImageSaved();
            MessageBox.Show("عکس دندان با موفقیت ذخیره شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();

        }

        private void OnImageSaved()
        {
            if (ImageSaved != null)
                ImageSaved(null, null);
        }
    }
}
