using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace FADatePicker.FAPopup
{
    [ToolboxItem(false)]
    public class FAPopupContainer : FATopFormBase
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style = unchecked((int)0x80000000);
                cp.ClassStyle |= 0x0800;
                return cp;
            }
        }
    }
}
