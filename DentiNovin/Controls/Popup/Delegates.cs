using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DentiNovin.Controls.Popup
{
    public class BindPopupControlEventArgs : EventArgs
    {
        #region Class members

        private Control parent;
        private IPopupControl popupControl;

        #endregion

        #region Props

        public IPopupControl BindedControl
        {
            get { return popupControl; }
            set { popupControl = value; }
        }

        public Control OwnerControl
        {
            get { return parent; }
        }

        #endregion

        #region Ctor

        private BindPopupControlEventArgs()
        {
        }

        public BindPopupControlEventArgs(Control owner)
        {
            parent = owner;
        }

        #endregion
    }
    internal delegate int Hook(int ncode, IntPtr wParam, IntPtr lParam);
    public delegate void BindPopupControlEventHandler(object sender, BindPopupControlEventArgs e);

}
