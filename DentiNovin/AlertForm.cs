using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DentiNovin.Common;
using DentiNovin.BusinessLogic;
using DentiNovin.BaseClasses;

namespace DentiNovin
{
    public partial class AlertForm : BaseForm
    {
        private Patient _oPatient;
        public Patient oPatient
        {
            get { return _oPatient; }
            set { _oPatient = value; }
        }

        private PatientBLL _fPatientBLL;
        public PatientBLL FPatientBLL
        {
            get
            {
                if (_fPatientBLL == null)
                    _fPatientBLL = new PatientBLL();
                return _fPatientBLL;
            }
            set
            {
                _fPatientBLL = value;
            }
        }


        public AlertForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            if (ChkDontShow.Checked)
                FPatientBLL.DisableAlertForm(oPatient.PatientID);
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1002");
                MessageBox.Show("بروز خطا در ثبت اطلاعات", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }

        private void AlertForm_Load(object sender, EventArgs e)
        {
            txtAlertMass3.Text = oPatient.Description;
            txtAlertMass2.Text = oPatient.DrugDesc + "/" + oPatient.SurgeryDesc + "/" + oPatient.PregnancyDesc;
            txtAlertMass1.Text = CreateMaladyString(oPatient.Malady);

        }

        private string CreateMaladyString(int _malady)
        {
            string _maladyStr = string.Empty;
            if (_malady != 0)
            {
                if (_malady % 10 == 8)
                    _maladyStr = _maladyStr + " - " + "آلرژی یا حساسیت";
                if (_malady % 100 >= 70)
                    _maladyStr = _maladyStr + " - " + "هپاتیت (زردی)";
                if (_malady % 1000 >= 600)
                    _maladyStr = _maladyStr + " - " + "بیماری تنفسی (آسم)";
                if (_malady % 10000 >= 5000)
                    _maladyStr = _maladyStr + " - " + "بیماری کلیوی";
                if (_malady % 100000 >= 40000)
                    _maladyStr = _maladyStr + " - " + "هموفیلی";
                if (_malady % 1000000 >= 300000)
                    _maladyStr = _maladyStr + " - " + "بیماری دیابت (مرض قند)";
                if (_malady % 10000000 >= 2000000)
                    _maladyStr = _maladyStr + " - " + "بیماری عصبی (تشنج)";
                if (_malady >= 10000000)
                    _maladyStr = _maladyStr + " - " + "بیماری قلبی";
            }
            return _maladyStr;

        }

    }
}
