using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DentiNovin.Controls
{
    public partial class MNMCurrencyTextBox : TextBox
    {

        public MNMCurrencyTextBox()
        {
            InitializeComponent();
        }

        public MNMCurrencyTextBox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        bool isDigit = true;
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            isDigit = true;
            if (!Char.IsDigit(e.KeyChar))
            {
                if (!(e.KeyChar == Convert.ToChar(Keys.Back)))
                    e.Handled = true;
                isDigit = false;
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (!isDigit)
                return;
            this.Text = amountMask(this.Text);
            this.SelectionStart = this.TextLength;
        }

        private Boolean checkForCurrectInput(string inputText)
        {
            decimal orginText = 0;
            if (!decimal.TryParse(inputText.Trim(), out orginText))
            {
                errorProvider1.SetError(this, "لطفآ مقدار عددی صحیح وارد کنید");
                return false;
            }
            return true;
        }

        private string amountMask(string amount)
        {
            if (amount == "")
                return string.Empty;
            string mystring = string.Empty;
            if (amount.Length > 3)
            {
                amount = amountDMask(amount);
                for (int i = amount.Length; i > 0; i = i - 3)
                {

                    if (i > 3)
                    {
                        mystring = "," + amount.Substring(i - 3, 3) + mystring;

                    }
                    else
                    {
                        mystring = amount.Substring(0, i) + mystring;
                    }
                }
                return mystring;
            }
            else
                return amount;

        }

        private string amountDMask(string amount)
        {
            return amount.Replace(",", "");
        }
    }
}
