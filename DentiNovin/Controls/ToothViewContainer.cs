using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using DentiNovin.Controls.Popup;
using System.Windows.Forms;
using System.Drawing;

namespace DentiNovin.Controls
{
    [ToolboxItem(false)]
    public class ToothViewContainer : PopupContainer, IPopupControl
    {
        #region Fields

        private ToothView tv;
        private Control owner;
        private HookPopup hook;
        private IPopupServiceControl serviceObject;
        private static IPopupServiceControl popupServiceControl = new HookPopupController();

        #endregion

        #region Props

        /// <summary>
        /// Owner control of this Popup control.
        /// </summary>
        [Browsable(false)]
        public Control OwnerControl
        {
            get { return owner; }
            set { owner = value; }
        }

        /// <summary>
        /// Service object which handles popup behaviors.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IPopupServiceControl ServiceObject
        {
            get { return serviceObject; }
            set
            {
                if (value == null) return;
                serviceObject = value;
            }
        }

        /// <summary>
        /// Actual control that is being displayed.
        /// </summary>
        [Browsable(false)]
        public ToothView ToothViewControl
        {
            get { return tv; }
        }

        /// <summary>
        /// Editor which shows the popup control.
        /// </summary>
        public override Control OwnerEdit
        {
            get { return owner; }
        }


        #endregion

                #region Ctor

        /// <summary>
        /// Creates a new instance of FAMonthViewContainer class.
        /// </summary>
        public ToothViewContainer()
            : this(null)
        {
        }

        /// <summary>
        /// Creates a new instance of FAMonthViewContainer which hosts a <see cref="FAMonthView"/> control in popup mode.
        /// </summary>
        /// <param name="ownerControl"></param>
        public ToothViewContainer(Control ownerControl)
        {
            hook = new HookPopup(this);
            tv = new ToothView(true);
            tv.Dock = DockStyle.Fill;
            Size = new Size(tv.Size.Width - 2, tv.Size.Height - 2);
            Controls.Add(tv);
            tv.IsPopupMode = true;
            serviceObject = popupServiceControl;
            RealBounds = new Rectangle(tv.Bounds.X, tv.Bounds.Y, tv.Bounds.Width, tv.Bounds.Height);
            Parent = owner;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            ControlBox = false;
            owner = ownerControl;
            SetStyle(ControlStyles.Opaque, true);
            ShadowSize = 3;
            RightToLeft = ownerControl.RightToLeft;
        }

        /// <summary>
        /// Disposes the control.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            hook.Dispose();
            base.Dispose(disposing);
        }

        #endregion

        
        
        
        
        #region IPopupControl Members

        public System.Windows.Forms.Control PopupWindow
        {
            get { return tv; }
        }

        public void ClosePopup()
        {
            Visible = false;
            Form form = OwnerEdit.FindForm();
            if (form != null && ActiveForm == form)
                form.Activate();
        }

        public void ShowPopup()
        {
            Rectangle r = OwnerEdit.RectangleToScreen(OwnerEdit.ClientRectangle);
            Point showLocation;
            Point topLocation;
            if (OwnerEdit.RightToLeft == RightToLeft.Yes)
            {
                topLocation = new Point(r.Left, r.Bottom);
            }
            else
            {
                topLocation = new Point(r.Right - Width, r.Bottom);
            }

            Point bottomLocation = new Point(topLocation.X, topLocation.Y);
            showLocation = ControlUtils.CalcLocation(bottomLocation, topLocation, Size);

            ClientSize = Size;
            Location = showLocation;
            Visible = true;
        }

        public bool AllowMouseClick(System.Windows.Forms.Control control, System.Drawing.Point mousePosition)
        {
            return false;
        }
        internal HookPopup PopupHook
        {
            get { return hook; }
        }
        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ToothViewContainer
            // 
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Name = "ToothViewContainer";
            this.ResumeLayout(false);

        }
    }
}
