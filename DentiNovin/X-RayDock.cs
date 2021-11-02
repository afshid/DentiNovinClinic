using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Runtime.InteropServices;
using DentiNovin.BusinessLogic;
using System.IO;
using DentiNovin.Common;
using DentiNovin.BaseClasses;

namespace DentiNovin
{
    public partial class X_RayDock : DockContent
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
                if (_oXRayImage == null)
                    _oXRayImage = new XRayImage();
                return _oXRayImage;
            }
            set { _oXRayImage = value; }
        }

        DataSet aDataSet;

        public int PatientID { get; set; }

        [DllImport("User32")]
        private static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr  wParam,IntPtr lParam);

        public int MakeLong(short lowPart, short highPart)
        {
            return (int)(((ushort)lowPart) | (uint)(highPart << 16));
        }

        public void ListView1_SetSpacing(ListView listview, short cx, short cy)
        {
            const int LVM_FIRST = 0x1000;
            const int LVM_SETICONSPACING = LVM_FIRST + 53;
            SendMessage(listview.Handle, LVM_SETICONSPACING, IntPtr.Zero, (IntPtr)MakeLong(cx, cy));
        }

        public X_RayDock()
        {
            InitializeComponent();
        }

        private void X_RayDock_Load(object sender, EventArgs e)
        {
            ListView1_SetSpacing(this.listView1, 128 + 12, 128 + 12);
            listView1.Columns.Add("Images", -2, HorizontalAlignment.Center);
            if (this.PatientID == 0)
            {
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                btnRefresh.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = true;
                btnRefresh.Enabled = true;
            }
        }

        public void GetXRayImages(int patientID)
        {
            btnAdd.Enabled = true;
            btnRefresh.Enabled = true;
            try
            {
            aDataSet = FPatientTreatmentBLL.GetXRayList(patientID);

            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1081");
                MessageBox.Show("بروز خطا در بارگزاری عکس دندان بیمار", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (aDataSet == null || aDataSet.Tables.Count == 0)
                return;
            Image aImage;
            iList.Images.Clear();
            listView1.Items.Clear();
            for (int i = 0; i < aDataSet.Tables[0].Rows.Count; i++)
            {
                aImage = Utilises.byteArrayToImage((byte[])aDataSet.Tables[0].Rows[i][2]);
                iList.Images.Add(aDataSet.Tables[0].Rows[i][0].ToString(),aImage);
                listView1.Items.Add(aDataSet.Tables[0].Rows[i][3].ToString(), i);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            XRayImageForm aXRayImageForm = new XRayImageForm();
            this.OXRayImage.PatientID = this.PatientID;
            ListViewItem aListViewItem = ((ListView)sender).SelectedItems[0];
            this.OXRayImage.Image = iList.Images[aListViewItem.Index];
            aXRayImageForm.OXRayImage = this.OXRayImage;
            aXRayImageForm.ShowMode = true;
            aXRayImageForm.MdiParent = this.MdiParent;
            aXRayImageForm.ShowDialog();
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
          // string tt= iList.Images.Keys[e.Item.ImageIndex];
            if (listView1.CheckedItems.Count != 0)
                btnDelete.Enabled = true;
            else
                btnDelete.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            XRayImageForm aXRayImageForm = new XRayImageForm();
            aXRayImageForm.ImageSaved += new EventHandler(aXRayImageForm_ImageSaved);
            this.OXRayImage.PatientID =this.PatientID;
            aXRayImageForm.OXRayImage = this.OXRayImage;
            aXRayImageForm.ShowDialog();
        }

        void aXRayImageForm_ImageSaved(object sender, EventArgs e)
        {
            GetXRayImages(this.PatientID);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string _selectedItemsList=string.Empty;
            for (int i = 0; i < listView1.CheckedItems.Count; i++)
            {
                if (_selectedItemsList != string.Empty)
                    _selectedItemsList = _selectedItemsList + ",";
                _selectedItemsList = _selectedItemsList + iList.Images.Keys[listView1.CheckedItems[i].Index];
            }
            if (MessageBox.Show("تصاویر انتخاب شده حذف خواهند شد آیا مطمئن هستید؟", "", MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.No)
                return;
            try
            {
            FPatientTreatmentBLL.DeleteXRayImages(_selectedItemsList);
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1082");
                MessageBox.Show("بروز خطا در حذف عکس دندان بیمار", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            GetXRayImages(this.PatientID);
            btnDelete.Enabled = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetXRayImages(this.PatientID);
        }

        private void btnRefresh_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip((Control)sender, "بارگزاری مجدد");
        }

        private void btnDelete_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip((Control)sender, "حذف");
        }

        private void btnAdd_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip((Control)sender, "جدید");
        }
    }
}
