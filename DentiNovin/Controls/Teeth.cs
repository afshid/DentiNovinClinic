using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DentiClinic.Common;
using FADatePicker.Utilies;
using DentiClinic.BaseClasses;
using System.Runtime.Serialization;
using DentiClinic.Controls.Popup;

namespace DentiClinic.Controls
{
    public partial class Teeth : UserControl
    {
        internal ToothViewContainer tvc;
        protected event EventHandler PopupShowing;
        protected event BindPopupControlEventHandler BindPopupControl;
        private IPopupControl bindedControl;
        protected IPopupControl BindedControl
        {
            get { return bindedControl; }
        }
        private List<cTooth> _lSelectedTeeth;
        public List<cTooth> LSelectedTeeth
        {
            get
            {
                if (!MultiSelect)
                {
                    if (_lSelectedTeeth.Count > 1)
                        _lSelectedTeeth.RemoveRange(0, _lSelectedTeeth.Count - 1);
                }
                return _lSelectedTeeth;
            }
            set
            {
                _lSelectedTeeth = value;
            }//
        }

        private Color _pColor;

        private ToothMode _mode;
        public ToothMode Mode
        {
            get { return _mode; }
            set {
                _mode = value;
                OnToothModeChanged();
            }
        }

        private ToothSelectMode _selectMode;
        public ToothSelectMode SelectMode
        {
            get { return _selectMode; }
            set { _selectMode = value; }
        }

        private Boolean _multiSelect = false;
        public Boolean MultiSelect
        {
            get { return _multiSelect; }
            set
            {
                _multiSelect = value;
            }
        }

        private Boolean _previewMode = false;
        public Boolean PreviewMode
        {
            get { return _previewMode; }
            set
            {
                _previewMode = value;
            }
        }

        private void OnToothModeChanged()
        {
            if (Mode == ToothMode.Child)
            {
                btn01.Enabled = false;
                btn02.Enabled = false;
                btn03.Enabled = false;
                btn16.Enabled = false;
                btn15.Enabled = false;
                btn14.Enabled = false;
                btn17.Enabled = false;
                btn18.Enabled = false;
                btn19.Enabled = false;
                btn30.Enabled = false;
                btn31.Enabled = false;
                btn32.Enabled = false;
            }
            else
            {
                btn01.Enabled = true;
                btn02.Enabled = true;
                btn03.Enabled = true;
                btn16.Enabled = true;
                btn15.Enabled = true;
                btn14.Enabled = true;
                btn17.Enabled = true;
                btn18.Enabled = true;
                btn19.Enabled = true;
                btn30.Enabled = true;
                btn31.Enabled = true;
                btn32.Enabled = true;
            }
        }


        public event TeethButtonSelectedEventHandler SelectedTeethChanged;

        public void OnSelectedTeethChanged(List<cTooth> e)
        {
            if (SelectedTeethChanged != null)
                SelectedTeethChanged(this, e);
        }

        public event ToothButtonSelectedEventHandler LastSelectedToothChanged;

        public void OnLastSelectedToothChanged(cTooth e)
        {
            if (LastSelectedToothChanged != null)
                LastSelectedToothChanged(this, e);
        }

        public Teeth()
        {
            tvc = new ToothViewContainer(this);
            _lSelectedTeeth = new List<cTooth>();
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            ToothButton sButton = (ToothButton)sender;
           
            cTooth acTooth = new cTooth(sButton.ToothNumber, sButton.ToothDirection);
            if (!PreviewMode)
            {
                sButton.BackColor = _pColor;
                ReOrganizeSelectedTeeth(acTooth);
            }
            else
            {
                //SetSelectedTeeth();
                //sButton.BackColor = Color.Red;
            }

            OnSelectedTeethChanged(LSelectedTeeth);
            OnLastSelectedToothChanged(acTooth);
            //ToothViewForm aToothViewForm = new ToothViewForm();
            //aToothViewForm.TopMost = true;

            //aToothViewForm.ShowDialog();
            //panel1.Visible = true;
           // panel1.Location = this.Location;
            ShowToothView();
        }

        protected void OnBindingPopupControl(BindPopupControlEventArgs e)
        {
            e.BindedControl = tvc;
            if (BindPopupControl != null)
                BindPopupControl(this, e);

            bindedControl = e.BindedControl;
        }
        protected void OnPopupShowing(EventArgs e)
        {
            if (PopupShowing != null)
                PopupShowing(this, EventArgs.Empty);
        }

        public void ShowToothView()
        {
            if (BindedControl == null)
            {
                BindPopupControlEventArgs args = new BindPopupControlEventArgs(this);
                OnBindingPopupControl(args);
            }

            if (BindedControl != null)
            {
                OnPopupShowing(EventArgs.Empty);
                BindedControl.ShowPopup();
            }
        }
        public void HideToothView()
        {
            if (BindedControl == null)
                return;

            BindedControl.ClosePopup();
        }
        private void ReOrganizeSelectedTeeth(cTooth tooth)
        {
            if (LSelectedTeeth.Contains(tooth))
            {
                LSelectedTeeth.Remove(tooth);
            }
            else
            {
                if (!MultiSelect)
                {
                    LSelectedTeeth.Clear();
                }
                LSelectedTeeth.Add(tooth);
            }
            SetSelectedTeeth();
        }

        private void SetSelectedTeeth()
        {
            if (!MultiSelect)
            {
                foreach (Control aControl in this.Controls)
                {
                    if (aControl is ToothButton)
                        ((ToothButton)aControl).BackColor = SystemColors.ButtonHighlight;
                }

            }
            for (int i = 0; i < LSelectedTeeth.Count; i++)
            {
                foreach (Control aControl in this.Controls)
                {
                    if (aControl is ToothButton)
                    {
                        if (((ToothButton)aControl).ToothNumber == LSelectedTeeth[i].ToothNumber && ((ToothButton)aControl).ToothDirection == LSelectedTeeth[i].ToothDirection)
                            ((ToothButton)aControl).BackColor = Color.SteelBlue;
                    }
                }
            }
        }

        private void btn_MouseHover(object sender, EventArgs e)
        {
            ToothButton sButton = (ToothButton)sender;
            string strToothNumber = sButton.ToothNumber.ToString();
            if(Mode==ToothMode.Child)
                switch (sButton.ToothNumber)
                {
                    case 1:
                        strToothNumber = "A";
                        break;
                    case 2:
                        strToothNumber = "B";
                        break;
                    case 3:
                        strToothNumber = "C";
                        break;
                    case 4:
                        strToothNumber = "D";
                        break;
                    case 5:
                        strToothNumber = "E";
                        break;
                    default:
                        break;
                }
            toolTip1.SetToolTip(sButton, strToothNumber + " | " + sButton.strDirection);

        }

        public void ResetControl(Boolean setEmpty)
        {
            if (setEmpty)
            {
                LSelectedTeeth.Clear();
            }
            SetSelectedTeeth();
        }

        public cTooth CreateTooth(int number, int direction)
        {
            if (direction > 4 && direction<100)
                direction = direction - 4;
            return new cTooth(number, direction);

        }
    }
    [Serializable]
    public class cTooth : IEquatable<cTooth>, ISerializable
    {
        public int ToothNumber { get; set; }

        public int ToothDirection { get; set; }

        public cTooth(int ToothNumber, int ToothDirection)
        {
            this.ToothNumber = ToothNumber; this.ToothDirection = ToothDirection;
        }

        #region IEquatable<cTooth> Members

        public bool Equals(cTooth other)
        {
            return (other != null && other.ToothNumber == this.ToothNumber && other.ToothDirection == this.ToothDirection);
        }

        #endregion

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

}
