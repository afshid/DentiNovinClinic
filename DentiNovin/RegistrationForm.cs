using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DentiNovin.Common.SerialMaker;

namespace DentiNovin
{
    public partial class RegistrationForm : BaseForm
    {
        private SerialMaker aSerialMaker;

        public RegistrationForm(SerialMaker sMaker)
        {
            InitializeComponent();
            slbSystemID.Text = sMaker.SystemID;
            this.aSerialMaker = sMaker;
            slbSerial.Select();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (slbSerial.Text.Trim() == string.Empty)
            {
                this.Close();
                return;
            }
            if (this.aSerialMaker.RegisterSoftware(slbSerial.Text) == DentiNovin.Common.SerialMaker.SerialMaker.RunTypes.Full)
            {
                MessageBox.Show(".ثبت نرم افزار با موفقیت انجام شد", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("شماره سریال وارد شده صحیح نمی باشد", "خطا",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }

    }
}
