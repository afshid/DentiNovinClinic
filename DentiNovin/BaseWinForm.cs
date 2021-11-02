using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DentiNovin.Common;

namespace DentiNovin
{
    public abstract partial class BaseWinForm : BaseForm
    {
       
        public BaseWinForm()
        {
            aPageMode = PageMode.Mode_new;
            InitializeComponent();
        }
        
        public abstract  void SetObject();

        public abstract  void SaveInfo();

        public   abstract void SaveObject();

        public  abstract  void EditObject();

        public abstract void FillGrid();

        public abstract void InitialForm(bool SetValue);

        public abstract void GetObjectList();
      
    }
}
