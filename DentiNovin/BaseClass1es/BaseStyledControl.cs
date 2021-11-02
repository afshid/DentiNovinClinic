using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace DentiNovin.BaseClasses
{
    [ToolboxItem(false)]
   public class BaseStyledControl:Control
    {
        private int lockUpdate;


        [Browsable(false)]
        public bool CanUpdate
        {
            get { return lockUpdate == 0; }
        }


        public void Repaint()
        {
            if (CanUpdate)
                Invalidate();
        }
    }
}
