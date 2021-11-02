using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using DentiNovin.Common;

using DentiNovin.Common.DateConvert;
using DentiNovin.BaseClasses;
using System.Drawing.Text;
using System.Collections;
using System.Drawing.Design;
using System.Windows.Forms.VisualStyles;
using System.Data;
using System.Threading;


namespace DentiNovin.Controls
{
    public class NewVisitTable : Control// BaseStyledControl
    {

        ContextMenuStrip aContextMenuStrip = new ContextMenuStrip();
        ToolTip toolTip1 = new ToolTip();

        private const int DEF_HEADER_SIZE = 21;
        private const int DEF_ARROW_SIZE = 3;
        private const int DEF_FOOTER_SIZE = 27;
        private const int DEF_BUTTON_WIDTH = 60;
        private const int DEF_BUTTON_HEIGHT = 23;
        private const int DEF_WEEK_DAY_HEIGHT = 20;
        private const int DEF_ROWS_MARGIN = 3;

        private const int DEF_COLUMNS_COUNT = 7;
        private const int DEF_ROWS_COUNT = 7;
        private const int DEF_TODAY_TAB_INDEX = 100;
        private const int DEF_NONE_TAB_INDEX = 101;
        private const int DEF_DYCOLUMNS_WIDTH = 70;

        private PersianCalendar pc;
        private DateTimeCollection selectedDateRange;
        public string selectedPersianDate;
        private int iYear;
        private int iMonth;
        private int iDay;
        private int numDays;
        private DataRow dr;

        private VisitNode selectedNodes;

        private DateTime selectedGregorianDate;
        [Description("Currently selected DateTime instance from calendar.")]
        [RefreshProperties(RefreshProperties.All)]
        [Bindable(true)]
        [Localizable(true)]
        public DateTime SelectedDateTime
        {
            get
            {
                return selectedGregorianDate;
            }
            set
            {
                if (value.Equals(DateTime.MinValue))
                    IsNull = true;
                else
                    IsNull = false;

                if (selectedGregorianDate == value)
                    return;

                selectedGregorianDate = value;
                selectedPersianDate = PersianDateConverter.ToPersianDate(value).ToString("d", null);
                iDay = pc.GetDayOfMonth(selectedGregorianDate);
                OnDayChanged(EventArgs.Empty);

                iMonth = pc.GetMonth(selectedGregorianDate);
                OnMonthChanged(EventArgs.Empty);

                iYear = pc.GetYear(selectedGregorianDate);
                OnYearChanged(EventArgs.Empty);

                Invalidate();

                OnSelectedDateTimeChanged(EventArgs.Empty);
            }
        }
        private bool isNull;
        [DefaultValue(true)]
        [RefreshProperties(RefreshProperties.All)]
        public bool IsNull
        {
            get { return isNull; }
            set
            {
                if (isNull == value)
                    return;

                isNull = value;
                if (isNull)
                {
                    //also clear the selection
                    // selectedDateRange.Clear();
                }

                Invalidate();
            }
        }

        private Group _oGroup;
        [Browsable(false)]
        public Group oGroup
        {
            get { return _oGroup; }
            set { _oGroup = value; }
        }

        private DataSet _dSAppointment;
        [Browsable(false)]
        public DataSet DSAppointment
        {
            get { return _dSAppointment; }
            set { _dSAppointment = value; }
        }

        private Int32 _daysNumber;
        [Browsable(false)]
        public Int32 DaysNumber
        {
            get { return _daysNumber; }
            set { _daysNumber = value; }
        }

        [Browsable(false)]
        public string CurrentMonthName
        {
            get
            {
                return PersianDate.PersianMonthNames.Default[iMonth];
            }
        }

        private string[] _weekDayName;//=new string[]{};
        private string[] _weekDayDate;// = new string[] { };

       public DataSet ds = new DataSet();
        DataGridView dgv = new DataGridView();
        DataTable dt = new DataTable();
        public event EventHandler SelectedDateTimeChanged;
        public event EventHandler DayChanged;
        public event EventHandler MonthChanged;
        public event EventHandler YearChanged;
        public event VisitNodeEventHandler RegisterClicked;
        public event VisitNodeEventHandler UnRegisterClicked;
        public event VisitNodeEventHandler ShowDossierClicked;

        public NewVisitTable()
        {
            format = new StringFormat();
            pc = new PersianCalendar();
            selectedDateRange = new DateTimeCollection();
            SelectedDateTime = DateTime.Now;
            //AddContexMenu();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
           // this.Controls.Add(SetDataGridView());
            OnDrawHeader(new PaintEventArgs(e.Graphics, rcHeader));

        }



        private void OnDrawHeader(PaintEventArgs pevent)
        {
           

            Graphics g = pevent.Graphics;
            Rectangle rc = new Rectangle(0, 0, Width, Height);

            // Draw header background
            rcHeader = new Rectangle(rc.X + 1, rc.Y + 1, rc.Width - 2, DEF_HEADER_SIZE);
            DrawButton(g, rcHeader, string.Empty, Font, null, ItemState.Normal, false, true);

            //Rectangle rc = pevent.ClipRectangle;
            Rectangle rcOut = Rectangle.Inflate(rc, -6, -1);

            PaintEventArgs ev = new PaintEventArgs(pevent.Graphics, rcHeader);

            OnDrawMonthHeader(ev);
            //ondrawyearheader(ev);
        }
        [Browsable(false)]
        internal StringFormat OneLineNoTrimming
        {
            get
            {
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                format.Trimming = StringTrimming.None;
                format.FormatFlags = StringFormatFlags.LineLimit;
                format.HotkeyPrefix = HotkeyPrefix.Show;

                return format;
            }
        }
        private StringFormat format;
        private void OnDrawMonthHeader(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            Rectangle rc = pevent.ClipRectangle;

            string strMonth = CurrentMonthName;
            string strLongestMonth = PersianDate.PersianMonthNames.Default.Ordibehesht;

            // Draw left arrow and add it as Active Rectangle
            Rectangle rect = DrawArrow(g, rc, true, false, DEF_ARROW_SIZE);
            AddActiveRect(rect, TRectangleAction.MonthDown);

            SizeF sz = g.MeasureString(strLongestMonth, Font);
            Rectangle rcText = new Rectangle(rect.Right + 4, rc.Y, (int)sz.Width + 20, rc.Height);
            g.DrawString(strMonth, Font, SystemBrushes.WindowText, rcText, OneLineNoTrimming);

            // draw  right arrow and add it like Active Rectangle
            rect = DrawArrow(g, new Rectangle(rcText.Right + 4, rc.Y, 100, rc.Height), false, false, DEF_ARROW_SIZE);
            AddActiveRect(rect, TRectangleAction.MonthUp);
        }


        public Rectangle DrawArrow(Graphics g, Rectangle rc, bool isLeft, bool isDisabled, int arrowSize)
        {
            int xLeft, xRight, yTop, yMidd, yBott;

            xLeft = rc.Left + 1;
            xRight = xLeft + arrowSize;
            yMidd = rc.Top + (rc.Height / 2);
            yTop = yMidd - arrowSize;
            yBott = yMidd + arrowSize;

            Point[] array;

            if (isLeft)
            {
                array = new Point[]
					{
						new Point(new Size(xLeft, yMidd)),
						new Point(new Size(xRight, yTop)),
						new Point(new Size(xRight, yBott))
					};
            }
            else
            {
                array = new Point[]
					{
						new Point(new Size(xLeft, yTop)),
						new Point(new Size(xLeft, yBott)),
						new Point(new Size(xRight, yMidd))
					};
            }

            g.DrawPolygon((isDisabled ? SystemPens.GrayText : SystemPens.WindowText), array);
            g.FillPolygon((isDisabled ? SystemBrushes.GrayText : SystemBrushes.WindowText), array);

            return new Rectangle(xLeft - 2, yTop - 2, arrowSize + 14, arrowSize * 2 + 14);
        }
        private bool rectsCreated;
        private ArrayList rects = new ArrayList(200);
        private void AddActiveRect(Rectangle rc, TRectangleAction action)
        {
            if (rectsCreated == false)
            {
                rects.Add(new ActRect(rc, action));
            }
        }


        public void DrawButton(Graphics g, Rectangle rectangle, string text, Font font, StringFormat fmt, ItemState state, bool hasBorder, bool enabled)
        {
            VisualStyleRenderer renderer = null;

            if (!enabled)
            {
                renderer = new VisualStyleRenderer(VisualStyleElement.Button.PushButton.Disabled);
            }
            else
            {
                switch (state)
                {
                    case ItemState.Open:
                        renderer = new VisualStyleRenderer(VisualStyleElement.Button.PushButton.Default);
                        break;

                    case ItemState.Normal:
                        renderer = new VisualStyleRenderer(VisualStyleElement.Button.PushButton.Normal);
                        break;

                    case ItemState.HotTrack:
                        renderer = new VisualStyleRenderer(VisualStyleElement.Button.PushButton.Hot);
                        break;

                    case ItemState.Pressed:
                        renderer = new VisualStyleRenderer(VisualStyleElement.Button.PushButton.Pressed);
                        break;
                }
            }

            renderer.DrawBackground(g, rectangle);

            if (!string.IsNullOrEmpty(text))
            {
                if (enabled)
                {
                    using (SolidBrush br = new SolidBrush(SystemColors.ControlText))
                        g.DrawString(text, font, br, rectangle, fmt);
                }
                else
                {
                    using (SolidBrush br = new SolidBrush(SystemColors.GrayText))
                        g.DrawString(text, font, br, rectangle, fmt);
                }
            }
        }
        
        private DataGridView SetDataGridView()
        {
            //DataGridView dgv = new DataGridView();
            dgv.AutoGenerateColumns = false;
            dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.Dock = DockStyle.Fill;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(dgv_CellFormatting);
            //dgv.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(dgv_CellContentDoubleClick);
            dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(dgv_CellContentDoubleClick);
            dgv.RowHeadersDefaultCellStyle.Font = new Font("Tahoma", 8);
            dgv.RowHeadersWidth = 150;
            //dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            DataGridViewColumn dgvc;// = new DataGridViewColumn();

            

            numDays = pc.GetDaysInMonth(iYear, iMonth);
            DateTime dtStartOfMonth = new DateTime(iYear, iMonth, 1, 0, 0, 0, pc);
            int firstDay = GetFirstDayOfWeek(dtStartOfMonth);
            int k;
            _weekDayName = new string[numDays];
            _weekDayDate = new string[numDays];
            for (int i = 0; i < numDays; i++)
            {
                k = (i + firstDay) % 7;
                string strDayWeek = GetWeekDayName(k);
                string strDayDate = Utilities.toDouble(iMonth) + "/" + Utilities.toDouble(i + 1);
                _weekDayName[i] = strDayWeek;
                _weekDayDate[i] = strDayDate;
                if (!DaysNumber.ToString().Contains((k + 1).ToString()))
                { }
            }

            int iRowHeight = (Height - DEF_WEEK_DAY_HEIGHT) / numDays;
            int XRowHeight = (Height - DEF_WEEK_DAY_HEIGHT) / numDays;

            if ((oGroup != null) && (oGroup.RowEffected != false))
            {
                int COLUMNS_COUNT = 0;

                if (oGroup.EndTime < oGroup.StartTime)
                    COLUMNS_COUNT = System.Convert.ToInt32(24 - (oGroup.StartTime - oGroup.EndTime).TotalMinutes / oGroup.PeriodLength) + 1;
                else
                    COLUMNS_COUNT = System.Convert.ToInt32((oGroup.EndTime - oGroup.StartTime).TotalMinutes / oGroup.PeriodLength) + 1;
                dgv.Columns.Clear();
                dt.Columns.Clear();
                for (int i = 0; i < COLUMNS_COUNT-1; i++)
                {
                    TimeSpan tsNodeStime = oGroup.StartTime.Add(new TimeSpan(0, oGroup.PeriodLength * i, 0));
                    string strNodeStime = tsNodeStime.ToString();
                    if (tsNodeStime.Days > 0)
                        strNodeStime = tsNodeStime.Subtract(TimeSpan.FromDays(1)).ToString();
                    dgvc = new DataGridViewTextBoxColumn();
                    dgvc.ContextMenuStrip = aContextMenuStrip;
                    dgvc.HeaderText = strNodeStime;
                    dgvc.Name = "Column" + i;
                    dgvc.DataPropertyName = "Column" + i;
                    dgvc.ReadOnly = true;
                    dgv.Columns.Add(dgvc);
                    dt.Columns.Add(new DataColumn("Column" + i, typeof(VisitNode)));
                }

                DvgDataBinding();
            }


            return dgv;
        }


        public void DvgDataBinding()
        {
            dt.Rows.Clear();
            ds.Tables.Clear();

            for (int i = 0; i < numDays; i++)
            {
                dr = dt.NewRow();
                dt.Rows.Add(dr);
            }
            ds.Tables.Add(dt);
            int DayIndex;
            int TimeIndex;
            for (int i = 0; i < DSAppointment.Tables[0].Rows.Count; i++)
            {
                DayIndex = System.Convert.ToInt16(DSAppointment.Tables[0].Rows[i][7])-1;
                TimeIndex = System.Convert.ToInt16(DSAppointment.Tables[0].Rows[i][9]);
                //VisitNode oVisitNode = new VisitNode((int)DSAppointment.Tables[0].Rows[i][2], DSAppointment.Tables[0].Rows[i][12].ToString() + " - " + DSAppointment.Tables[0].Rows[i][13].ToString(), (int)DSAppointment.Tables[0].Rows[i][0], System.Convert.ToInt16(DSAppointment.Tables[0].Rows[i][7]), TimeIndex);
                VisitNode oVisitNode = new VisitNode((int)DSAppointment.Tables[0].Rows[i][2], DSAppointment.Tables[0].Rows[i][12].ToString() + " - " + DSAppointment.Tables[0].Rows[i][13].ToString(), (Int64)DSAppointment.Tables[0].Rows[i][0], System.Convert.ToInt16(DSAppointment.Tables[0].Rows[i][7]), TimeIndex, DSAppointment.Tables[0].Rows[i][4].ToString(), Convert.ToDateTime(DSAppointment.Tables[0].Rows[i][8]).TimeOfDay);

                ds.Tables[0].Rows[DayIndex][TimeIndex] = oVisitNode;
            }
            dgv.DataSource = ds.Tables[0];
        }


        private int GetFirstDayOfWeek(DateTime date)
        {
            PersianDate pd = date;
            return (int)pd.DayOfWeek;
        }

        protected internal virtual void OnYearChanged(EventArgs e)
        {
            if (YearChanged != null)
                YearChanged(this, e);
        }

        protected internal virtual void OnMonthChanged(EventArgs e)
        {
            if (MonthChanged != null)
                MonthChanged(this, e);
        }

        protected internal virtual void OnSelectedDateTimeChanged(EventArgs e)
        {
            if (SelectedDateTimeChanged != null)
                SelectedDateTimeChanged(this, e);
        }

        protected internal virtual void OnDayChanged(EventArgs e)
        {
            if (DayChanged != null)
                DayChanged(this, e);
        }

        //public void bind()
        //{
        //    dgv.DataSource = ds.Tables[1];
        //}
        int axx;
        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.ColumnIndex == 0)
                dgv.Rows[e.RowIndex].HeaderCell.Value = _weekDayName[e.RowIndex] + " - " + _weekDayDate[e.RowIndex];
        }

        private void dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (((System.Data.DataRowView)(dgv.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[e.ColumnIndex] == System.DBNull.Value)
            {
                //selectedNodes = new VisitNode(0, "", 0, e.RowIndex, e.ColumnIndex);
                selectedNodes = new VisitNode(0, "", 0, e.RowIndex, e.ColumnIndex - 1, this.selectedPersianDate.Substring(0, 4) + "/" + this.selectedPersianDate.Substring(5, 2) + "/" + Utilities.toDouble(e.RowIndex + 1), new TimeSpan());

                OnRegisterClicked(selectedNodes);
            }

            else
                OnUnRegisterClicked((VisitNode)((System.Data.DataRowView)(dgv.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[e.ColumnIndex]);
            //VisitNode avn=  (VisitNode)((System.Data.DataRowView)(dgv.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[e.ColumnIndex];
        }

        public string GetWeekDayName(int day)
        {
            return PersianDate.PersianWeekDayNames.Default[day];
        }

        private void AddContexMenu()
        {
            aContextMenuStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            aContextMenuStrip.Left += aContextMenuStrip.Width;
            aContextMenuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            aContextMenuStrip.ShowImageMargin = false;

            ToolStripMenuItem toolStripItem1 = new ToolStripMenuItem();
            toolStripItem1.Text = "ثبت نوبت";
            //toolStripItem1.Click += new EventHandler(toolStripItem1_Click);

            ToolStripMenuItem toolStripItem2 = new ToolStripMenuItem();
            toolStripItem2.Text = "حذف نوبت";
            //toolStripItem2.Click += new EventHandler(toolStripItem2_Click);

            ToolStripMenuItem toolStripItem3 = new ToolStripMenuItem();
            toolStripItem3.Text = "مشاهده پرونده";
           // toolStripItem3.Click += new EventHandler(toolStripItem3_Click);

            aContextMenuStrip.Items.Add(toolStripItem1);
            aContextMenuStrip.Items.Add(toolStripItem2);
            aContextMenuStrip.Items.Add(toolStripItem3);
            //this.dgv.ContextMenuStrip = aContextMenuStrip;
        }

        //private void toolStripItem1_Click(object sender, EventArgs args)
        //{
        //    OnRegisterClicked(selectedNodes);
        //}

        //private void toolStripItem2_Click(object sender, EventArgs args)
        //{
        //    OnUnRegisterClicked(selectedNodes);
        //}

        //private void toolStripItem3_Click(object sender, EventArgs args)
        //{
        //   OnShowDossierClicked(selectedNodes);
        //}

        protected internal virtual void OnRegisterClicked(VisitNode e)
        {
            if (RegisterClicked != null)
                RegisterClicked(this, e);
            selectedNodes.PatientFullName = "dddd-fffff";
           // dgv.EditMode = DataGridViewEditMode.EditProgrammatically;
           // dgv.BeginEdit(false);
           // ((System.Data.DataRowView)(dgv.Rows[selectedNodes.DayNumber - 1].DataBoundItem)).Row.ItemArray[selectedNodes.TimeIndex] = this.selectedNodes;
           // dgv.CommitEdit(DataGridViewDataErrorContexts.LeaveControl);
           // dgv.Refresh();
            this.DvgDataBinding();
        }

        protected internal virtual void OnUnRegisterClicked(VisitNode e)
        {
            if (UnRegisterClicked != null)
                UnRegisterClicked(this, e);
        }
        protected internal virtual void OnShowDossierClicked(VisitNode e)
        {
            if (ShowDossierClicked != null)
                ShowDossierClicked(this, e);
        }







        private Rectangle rcHeader;
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    }

    //public class VisitNode : BaseClass
    //{
    //    public int PatientID { get; set; }

    //    public string  PatientFullName { get; set; }

    //    public Int64 AppointmentID { get; set; }

    //   // public int GroupID { get; set; }

    //    public int DayNumber { get; set; }

    //    public int TimeIndex { get; set; }

    //    public VisitNode(int patientID, string patientFullName, Int64 appointmentID, int dayNumber, int timeIndex)
    //    {
    //        this.PatientID = patientID;
    //        this.PatientFullName = patientFullName;
    //        this.AppointmentID = appointmentID;
    //        this.DayNumber = dayNumber;
    //        this.TimeIndex = timeIndex;

    //    }
    //    public override string ToString()
    //    {
    //        return this.PatientFullName;
    //    }

    //}

}
