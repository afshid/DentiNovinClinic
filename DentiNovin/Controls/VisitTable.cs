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


namespace DentiNovin.Controls
{
    public class VisitTable : Control// BaseStyledControl
    {
        ContextMenuStrip aContextMenuStrip = new ContextMenuStrip();
        ToolTip toolTip1 = new ToolTip();

        #region Constants

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

        #endregion

        #region Private Fields

        //private Icon maleIcon = new Icon(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("DentiNovin.Resources.male_icon.gif")); 
        //private Icon maleIcon = new Icon("male_icon.ico");

        private Icon greenOccoupIcon = new Icon(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("DentiNovin.Resources.occupe-blue.ico"), new Size(16, 16));

        private ArrayList rects = new ArrayList(200);
        private bool rectsCreated;
        private bool showBorder = true;
        private StringFormat format;
        private Rectangle rcBody;
        private Rectangle rcHeader;
        private Rectangle rcFooter;
        private int iYear;
        private int iMonth;
        private int iDay;
        private PersianCalendar pc;
        private DateTimeCollection selectedDateRange;
        private bool isMultiSelect = false;
        private bool isNull;
        private DateTime selectedGregorianDate;
        public string selectedPersianDate;
        private ArrayList selectedRects = new ArrayList();
        private ArrayList selectedNodes = new ArrayList();
        private int iLastFocused = 1;
        private DateTime dtSelected;
        private ScrollOptionTypes scrollOption;
        private int lockUpdate;
        private Group _oGroup;
        private IContainer components;
        private DataSet _dSAppointment;
        private Boolean _registerable;
        private Int32 _daysNumber;
        #endregion


        #region EventHandlers

        public event EventHandler SelectedDateTimeChanged;
        public event EventHandler DayChanged;
        public event EventHandler MonthChanged;
        public event EventHandler YearChanged;
        public event VisitTableButtonClickedEventHandler RegisterClicked;
        public event VisitTableButtonClickedEventHandler UnRegisterClicked;
        public event VisitTableButtonClickedEventHandler ShowDossierClicked;
        public event EventHandler SelectedDateRangeChanged;
        public event CalendarButtonClickedEventHandler ButtonClicked;

        #endregion

        #region Properties

        [Browsable(false)]
        public Group oGroup
        {
            get { return _oGroup; }
            set { _oGroup = value; }
        }

        [Browsable(false)]
        public Int32 DaysNumber
        {
            get { return _daysNumber; }
            set { _daysNumber = value; }
        }

        [Browsable(false)]
        public DataSet DSAppointment
        {
            get { return _dSAppointment; }
            set { _dSAppointment = value; }
        }


        [Browsable(false)]
        public bool CanUpdate
        {
            get { return lockUpdate == 0; }
        }

        public void BeginUpdate()
        {
            lockUpdate++;
        }

        /// <summary>
        /// Removes a update lock from control.
        /// </summary>
        public void EndUpdate()
        {
            lockUpdate--;
        }

        public void Repaint()
        {
            if (CanUpdate)
                Invalidate();
        }

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
                    selectedDateRange.Clear();
                }

                Invalidate();
            }
        }

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

                rectsCreated = false;
                Invalidate();

                OnSelectedDateTimeChanged(EventArgs.Empty);
            }
        }

        [DefaultValue(false)]
        [Description("Gets or Sets the control in MultiSelect mode.")]
        public bool IsMultiSelect
        {
            get
            {
                return isMultiSelect;
            }
            set
            {
                if (isMultiSelect == value)
                    return;

                isMultiSelect = value;
                Repaint();
            }
        }
        ///// <summary>
        ///// Selected values collection, if the control is in MultiSelect mode.
        ///// </summary>
        //[Editor(typeof(DateTimeCollectionEditor), typeof(UITypeEditor))]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        //[TypeConverter(typeof(DateTimeConverter))]
        //[Description("Selected values collection, if the control is in MultiSelect mode.")]
        //public DateTimeCollection SelectedDateRange
        //{
        //    get
        //    {
        //        if (IsMultiSelect)
        //        {
        //            return selectedDateRange;
        //        }
        //        else
        //        {
        //            DateTimeCollection singleSelection = new DateTimeCollection();
        //            if (!IsNull)
        //                singleSelection.Add(SelectedDateTime);

        //            return singleSelection;
        //        }
        //    }
        //}

        [DefaultValue(true)]
        [Description("Gets or Sets to show a border around the control.")]
        public bool ShowBorder
        {
            get { return showBorder; }
            set
            {
                if (showBorder == value)
                    return;

                showBorder = value;
                Invalidate();
            }
        }


        /// <summary>
        /// Gets the Day value.
        /// </summary>
        [Browsable(false)]
        public int Day
        {
            get { return iDay; }
        }

        /// <summary>
        /// Gets the Month value.
        /// </summary>
        [Browsable(false)]
        public int Month
        {
            get { return iMonth; }
        }

        /// <summary>
        /// Gets the Year value.
        /// </summary>
        [Browsable(false)]
        public int Year
        {
            get { return iYear; }
        }

        [Browsable(false)]
        public string CurrentMonthName
        {
            get
            {
                return PersianDate.PersianMonthNames.Default[iMonth];
            }
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

        [Browsable(false)]
        public Boolean Registerable
        {
            get { return _registerable; }
            set { _registerable = value; }
        }

        #endregion

        public VisitTable()
        {
            toolTip1.IsBalloon = true;
            //toolTip1.ShowAlways = true;
            pc = new PersianCalendar();
            selectedDateRange = new DateTimeCollection();
            // selectedDateRange.CollectionChanged += OnSelectionCollectionChanged;

            base.Size = new Size(600, 600);
            base.Font = new Font("Tahoma", 8.25F);
            SelectedDateTime = DateTime.Now;
            dtSelected = SelectedDateTime;
            format = new StringFormat();
            scrollOption = ScrollOptionTypes.Month;
            isNull = true;
            AddContexMenu();
        }

        private ActRect FindActiveRectByPoint(Point pnt)
        {
            foreach (ActRect rc in rects)
            {
                if (rc.Rect.Contains(pnt))
                    return rc;
            }

            return null;
        }
        private void ResetActiveRectanglesState()
        {
            foreach (ActRect rc in rects)
            {
                if ((rc.State & TRectangleStatus.Active) > 0)
                {
                    rc.State = (TRectangleStatus)((int)rc.State & ~(int)TRectangleStatus.Active);
                }
            }
        }
        private void ResetFocusedRectangleState()
        {
            foreach (ActRect rc in rects)
            {
                if ((rc.State & TRectangleStatus.Focused) > 0)
                {
                    rc.State = (TRectangleStatus)((int)rc.State & ~(int)TRectangleStatus.Focused);
                }
            }
        }
        public void ToPrevMonth()
        {
            try
            {
                SelectedDateTime = pc.AddMonths(SelectedDateTime, -1);
                OnRecalculateRequired();
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }
        public void ToNextMonth()
        {
            try
            {
                SelectedDateTime = pc.AddMonths(SelectedDateTime, 1);
                OnRecalculateRequired();
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }
        public void ToPrevYear()
        {
            try
            {
                SelectedDateTime = pc.AddYears(SelectedDateTime, -1);
                OnRecalculateRequired();
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }
        public void ToNextYear()
        {
            try
            {
                SelectedDateTime = pc.AddYears(SelectedDateTime, 1);
                OnRecalculateRequired();
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }
        public void SetTodayDay()
        {
            //SelectedDateRange.Clear();
            SelectedDateTime = DateTime.Now;
            IsNull = false;
            //SelectedDateRange.Add(SelectedDateTime);
        }
        public void SetNoneDay()
        {
            IsNull = true;
            //SelectedDateRange.Clear();
            OnSelectedDateTimeChanged(EventArgs.Empty);
        }



        private void OnRectangleClick(ActRect rc)
        {
            switch (rc.Action)
            {
                case TRectangleAction.MonthDown:
                    ToPrevMonth();
                    break;
                case TRectangleAction.MonthUp:
                    ToNextMonth();
                    break;
                case TRectangleAction.YearDown:
                    ToPrevYear();
                    break;
                case TRectangleAction.YearUp:
                    ToNextYear();
                    break;
                case TRectangleAction.TodayBtn:
                    iLastFocused = DEF_TODAY_TAB_INDEX;
                    SetTodayDay();
                    OnButtonClicked(new CalendarButtonClickedEventArgs(FAMonthViewButtons.Today));
                    break;
                case TRectangleAction.NoneBtn:
                    iLastFocused = DEF_NONE_TAB_INDEX;
                    SetNoneDay();
                    OnButtonClicked(new CalendarButtonClickedEventArgs(FAMonthViewButtons.None));
                    break;
                case TRectangleAction.Node:
                    if (iDay == 0) return;
                    //Node SelectedNode = (Node)rc.Tag;

                    if (!selectedNodes.Contains(rc.Tag))
                        selectedNodes.Add(rc.Tag);
                    //if (IsMultiSelect)
                    //{
                    if (!selectedRects.Contains(rc.Rect))
                        selectedRects.Add(rc.Rect);
                    //}

                    OnButtonClicked(new CalendarButtonClickedEventArgs(FAMonthViewButtons.Node));
                    break;
            }

            Invalidate();
        }

        internal void OnInternalMouseClick(Point location)
        {
            Focus();

            ActRect rect = FindActiveRectByPoint(location);

            if (rect != null && rect.Action != TRectangleAction.WeekDay)
            {
                ResetActiveRectanglesState();
                ResetFocusedRectangleState();

                if (rect.Action == TRectangleAction.Node)
                {
                    if (((Node)rect.Tag).oPatient == null)
                    {
                        this.aContextMenuStrip.Items[1].Enabled = false;
                        this.aContextMenuStrip.Items[0].Enabled = true;
                        this.aContextMenuStrip.Items[2].Enabled = false;
                    }
                    else
                    {
                        this.aContextMenuStrip.Items[0].Enabled = false;
                        this.aContextMenuStrip.Items[1].Enabled = true;
                        this.aContextMenuStrip.Items[2].Enabled = true;
                    }
                    if (!Registerable)
                        this.aContextMenuStrip.Items[0].Enabled = false;
                    this.aContextMenuStrip.Show(MousePosition.X, MousePosition.Y);
                }


                // if selection begin
                if ((ModifierKeys & (Keys.Control | Keys.Shift)) == 0)
                {
                    selectedRects.Clear();
                    selectedNodes.Clear();
                    selectedDateRange.Clear();
                    ResetSelectedRectangleState();
                    OnRectangleClick(rect);
                }
                else
                {
                    if (!selectedNodes.Contains(rect.Tag))
                        selectedNodes.Add(rect.Tag);
                    if (!selectedRects.Contains(rect.Rect))
                        selectedRects.Add(rect.Rect);
                    aContextMenuStrip.Items[2].Enabled = false;
                    OnSelectionClick(rect);
                }
            }
        }

        internal void OnInternalMouseHover(Point location)
        {
            ActRect rect = FindActiveRectByPoint(location);

            if (rect != null && rect.Action != TRectangleAction.WeekDay)
            {
                if (rect.Action == TRectangleAction.Node)
                {
                    if (((Node)rect.Tag).oPatient != null)
                        toolTip1.SetToolTip(this, ((Node)rect.Tag).oPatient.LastName + " - " + ((Node)rect.Tag).oPatient.FirstName + " : " + ((Node)rect.Tag).oPatient.FileNumber);
                    //else
                    //toolTip1.Hide(this);
                }

            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            //if (rectsCreated == false)
            rects.Clear();
            Rectangle rc = new Rectangle(0, 0, Width, Height);
            OnDrawHeader(new PaintEventArgs(e.Graphics, rcHeader));
            //OnDrawFooter(new PaintEventArgs(pe.Graphics, rcFooter));

            if (rectsCreated == false)
            {
                rcBody = new Rectangle(rc.X, rcHeader.Bottom, rc.Width, rcFooter.Top - rcHeader.Bottom);
                rcBody = Rectangle.Inflate(rcBody, -4, -1);
            }

            OnDrawBody(new PaintEventArgs(e.Graphics, rcBody));
            //rectsCreated = true;
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if (!CanUpdate)
                return;

            try
            {
                BeginUpdate();

                Graphics g = pevent.Graphics;
                Rectangle rc = new Rectangle(0, 0, Width, Height);

                DrawFilledBackground(g, rc, false, 90f);

                // Draw header background
                rcHeader = new Rectangle(rc.X + 1, rc.Y + 1, rc.Width - 2, DEF_HEADER_SIZE);
                DrawButton(g, rcHeader, string.Empty, Font, null, ItemState.Normal, false, true);

                // Construct footer rect
                int yBott = rc.Bottom - DEF_FOOTER_SIZE - 1;
                rcFooter = new Rectangle(rc.X + 6, yBott, rc.Width - 12, DEF_FOOTER_SIZE);
            }
            finally
            {
                EndUpdate();
            }
        }

        private void OnDrawBody(PaintEventArgs pevent)
        {
            //rects.Clear();
            Graphics g = pevent.Graphics;
            Rectangle rc = pevent.ClipRectangle;
            int numDays = pc.GetDaysInMonth(iYear, iMonth);
            DateTime dtStartOfMonth = new DateTime(iYear, iMonth, 1, 0, 0, 0, pc);
            int firstDay = GetFirstDayOfWeek(dtStartOfMonth);
            //int iColWidth = rc.Width / DEF_COLUMNS_COUNT;

            //Width of Horizontal Head
            int nColWidth;

            //Width of Vertical Head
            int dColWidth = DEF_DYCOLUMNS_WIDTH;

            int iRowHeight = (rc.Height - DEF_WEEK_DAY_HEIGHT) / numDays;
            int XRowHeight = (rc.Height - DEF_WEEK_DAY_HEIGHT) / numDays;
            #region Top Separator
            DrawSeparator(g, new Point(rc.X + dColWidth * 3 / 2 + 2, rc.Y + 3),
                                  new Point(rc.X + dColWidth * 3 / 2 + 2, rc.Y + rc.Height - 3));

            #endregion

            #region Header Times

            Rectangle rcHeadH;
            Rectangle rcNodeBase;
            if ((oGroup != null) && (oGroup.RowEffected != false))
            {
                int COLUMNS_COUNT = 0;

                if (oGroup.EndTime < oGroup.StartTime)
                    COLUMNS_COUNT = System.Convert.ToInt32(24 - (oGroup.StartTime - oGroup.EndTime).TotalMinutes / oGroup.PeriodLength) + 1;
                else
                    COLUMNS_COUNT = System.Convert.ToInt32((oGroup.EndTime - oGroup.StartTime).TotalMinutes / oGroup.PeriodLength) + 1;


                nColWidth = (((rc.Width - (dColWidth * 3 / 2)) - COLUMNS_COUNT) / COLUMNS_COUNT);
                rcHeadH = new Rectangle(rc.X, rc.Y, nColWidth, iRowHeight);
                rcNodeBase = new Rectangle(rc.X + (dColWidth * 3 / 2) + 6, rc.Y + rcHeadH.Y, nColWidth, XRowHeight);
                for (int i = 0; i < COLUMNS_COUNT; i++)
                {
                    rcHeadH.X = rc.X + (dColWidth * 3 / 2) + (i * nColWidth) + 6 + i;
                    TimeSpan tsNodeStime = oGroup.StartTime.Add(new TimeSpan(0, oGroup.PeriodLength * i, 0));
                    string strNodeStime = tsNodeStime.ToString();
                    if (tsNodeStime.Days > 0)
                        strNodeStime = tsNodeStime.Subtract(TimeSpan.FromDays(1)).ToString();

                    g.DrawString(strNodeStime, Font, SystemBrushes.WindowText, rcHeadH, OneLineNoTrimming);
                    OnDrawBorder(new PaintEventArgs(g, rcHeadH));
                }

                Month aMounth = new Month(numDays, oGroup, rcNodeBase);
                int DaysNum;
                int NodeNum;

                for (int i = 0; i < DSAppointment.Tables[0].Rows.Count; i++)
                {

                    DaysNum = System.Convert.ToInt16(DSAppointment.Tables[0].Rows[i][7]) - 1;
                    NodeNum = System.Convert.ToInt16(DSAppointment.Tables[0].Rows[i][9]);
                    Patient oPatient = new Patient();
                    oPatient.LastName = DSAppointment.Tables[0].Rows[i][12].ToString();
                    oPatient.FirstName = DSAppointment.Tables[0].Rows[i][13].ToString();
                    oPatient.FileNumber = (int)DSAppointment.Tables[0].Rows[i][14];
                    aMounth.Days[DaysNum][NodeNum].rIndex = System.Convert.ToInt16(DSAppointment.Tables[0].Rows[i][0]);
                    aMounth.Days[DaysNum][NodeNum].oPatient = oPatient;
                }
                // aMounth.DrowMonth(g, OneLineNoTrimming,Font);
                string strPatientName = "";
                for (int i = 0; i < aMounth.Days.Count; i++)
                {
                    for (int j = 0; j < aMounth.Days[i].NodeCount; j++)
                    {
                        if (aMounth.Days[i][j].oPatient != null)
                        {
                            strPatientName = aMounth.Days[i][j].oPatient.LastName;
                            using (SolidBrush brush = new SolidBrush(Color.SteelBlue))
                            {
                                g.FillRectangle(SystemBrushes.Highlight, aMounth.Days[i][j].rcNode);
                            }
                        }
                        else
                            strPatientName = "";


                        if (selectedRects.Contains(aMounth.Days[i][j].rcNode))
                        {
                            using (SolidBrush brush = new SolidBrush(Color.Red))
                            {
                                g.FillRectangle(brush, aMounth.Days[i][j].rcNode);
                            }
                        }
                        Application.DoEvents();

                        //g.DrawIcon(maleIcon,aMounth.Days[i][j].rcNode);
                        OnDrawBorder(new PaintEventArgs(g, aMounth.Days[i][j].rcNode));//SystemBrushes.WindowText
                        g.DrawString(strPatientName, Font, SystemBrushes.HighlightText, aMounth.Days[i][j].rcNode, OneLineNoTrimming);
                        AddActiveRect(aMounth.Days[i][j].rcNode, TRectangleAction.Node, aMounth.Days[i][j]);
                    }
                }
            }

            #endregion

            #region Weekday Name

            Brush backbrush = Brushes.Gray;
            //Rectangle rcHead = new Rectangle(rc.X, rc.Y, iColWidth, DEF_WEEK_DAY_HEIGHT -3);
            Rectangle rcHeadV = new Rectangle(rc.X, rc.Y, dColWidth, iRowHeight);
            Rectangle rcDate = new Rectangle(rc.X + dColWidth, rc.Y, dColWidth / 2, iRowHeight);
            int k = 0;
            // 


            for (int i = 0; i < numDays; i++)
            {
                ////rcHead.X = rc.Width - (i * iColWidth);
                rcHeadV.Y = rc.Y + ((i + 1) * iRowHeight) + i;
                rcDate.Y = rc.Y + ((i + 1) * iRowHeight) + i;
                k = (i + firstDay) % 7;
                string strDayWeek = GetWeekDayName(k);//+ iMonth.ToString() + "/" + (i + 1).ToString();
                string strDayDate = Utilities.toDouble(iMonth) + "/" + Utilities.toDouble(i + 1);
                if (!DaysNumber.ToString().Contains((k + 1).ToString()))
                {
                    g.DrawIcon(greenOccoupIcon, rcHeadV.X, rcHeadV.Y + (rcHeadV.Height - greenOccoupIcon.Height) / 2);
                    //using (SolidBrush brush = new SolidBrush(Color.Blue))
                    //{
                    //    g.FillRectangle(brush, rcHeadV);
                    //    g.FillRectangle(brush, rcDate);
                    //}
                }
                //if (k == 6)
                //{
                //    using (SolidBrush brush = new SolidBrush(Color.Gray))
                //    {
                //        g.FillRectangle(brush, rcHeadV);
                //        g.FillRectangle(brush, rcDate);
                //    }
                //}
                g.DrawString(strDayWeek, Font, SystemBrushes.WindowText, rcHeadV, OneLineNoTrimming);
                OnDrawBorder(new PaintEventArgs(g, rcHeadV));
                g.DrawString(strDayDate, Font, SystemBrushes.WindowText, rcDate, OneLineNoTrimming);
                OnDrawBorder(new PaintEventArgs(g, rcDate));
                //g.FillRectangle(backbrush, rcHead);
            }

            #endregion
        }

        private void OnDrawBorder(PaintEventArgs e)
        {
            if (ShowBorder)
            {
                Rectangle border = new Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
                DrawBorder(e.Graphics, border, false);
            }
        }

        private void OnDrawHeader(PaintEventArgs pevent)
        {
            Rectangle rc = pevent.ClipRectangle;
            Rectangle rcOut = Rectangle.Inflate(rc, -6, -1);

            PaintEventArgs ev = new PaintEventArgs(pevent.Graphics, rcOut);

            OnDrawMonthHeader(ev);
            OnDrawYearHeader(ev);
        }

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

        private void OnDrawYearHeader(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            Rectangle rc = pevent.ClipRectangle;

            //string strYear = toFarsi.Convert(iYear.ToString(), DefaultCulture);
            string strYear = iYear.ToString();

            Rectangle rect = DrawArrow(g, new Rectangle(rc.Right - 4 - DEF_ARROW_SIZE - 2, rc.Y, DEF_ARROW_SIZE * 2, rc.Height), false, false, DEF_ARROW_SIZE);
            AddActiveRect(rect, TRectangleAction.YearUp);

            SizeF sz = g.MeasureString(strYear, Font);
            Rectangle rcText = new Rectangle(rect.Left - 4 - (int)sz.Width - 8, rc.Y, (int)sz.Width + 8, rc.Height);
            g.DrawString(strYear, Font, SystemBrushes.WindowText, rcText, OneLineNoTrimming);

            rect = DrawArrow(g, new Rectangle(rcText.Left - 4 - DEF_ARROW_SIZE - 2, rc.Y, DEF_ARROW_SIZE * 2, rc.Height), true, false, DEF_ARROW_SIZE);
            AddActiveRect(rect, TRectangleAction.YearDown);
        }

        private void OnSelectionClick(ActRect rc)
        {
            if (rc.Action != TRectangleAction.Node)
            {
                rc.State = (TRectangleStatus)((int)rc.State & ~(int)TRectangleStatus.Selected);
                selectedRects.Remove(rc.Rect);
            }


            //if (rc.Action == TRectangleAction.Node)
            //{
            //    if (rc.IsSelected == false)
            //    {
            //        rc.State |= TRectangleStatus.Selected;

            //        SelectedDateTime = new DateTime(iYear, iMonth, ((Node)rc.Tag).dIndex, 0, 0, 0, pc);
            //        //if (!isNull && !SelectedDateRange.Contains(SelectedDateTime))
            //        //{
            //        //    SelectedDateRange.Add(SelectedDateTime);

            //        //    if (!selectedRects.Contains(rc.Tag))
            //        //        selectedRects.Add(rc.Tag);
            //        //}
            //        //if (!isNull)
            //        //{
            //        //    if (!selectedRects.Contains(rc.Rect))
            //        //        selectedRects.Add(rc.Rect);
            //        //}
            //    }
            //    else
            //    {
            //        rc.State = (TRectangleStatus)((int)rc.State & ~(int)TRectangleStatus.Selected);
            //        selectedRects.Remove(rc.Rect);
            //    }

            //    iLastFocused = (int)rc.Tag;
            //    isNull = false;
            //}

            Invalidate();
        }

        //private void OnSelectionCollectionChanged(object sender, CollectionChangedEventArgs e)
        //{
        //    ResetSelectedRectangleState();
        //    selectedRects.Clear();

        //    if (SelectedDateRange.Count > 0)
        //    {
        //        SelectedDateTime = SelectedDateRange[0];
        //    }
        //    else
        //    {
        //        isNull = true;
        //    }

        //    OnRecalculateRequired();
        //    Invalidate();
        //    OnSelectedDateRangeChanged(EventArgs.Empty);
        //}

        public string GetWeekDayName(int day)
        {
            return PersianDate.PersianWeekDayNames.Default[day];
        }

        private int GetFirstDayOfWeek(DateTime date)
        {
            PersianDate pd = date;
            return (int)pd.DayOfWeek;
        }

        private void ResetSelectedRectangleState()
        {
            foreach (ActRect rc in rects)
            {
                if ((rc.State & TRectangleStatus.Selected) > 0)
                {
                    rc.State = (TRectangleStatus)((int)rc.State & ~(int)TRectangleStatus.Selected);
                }
            }
        }

        private void AddActiveRect(Rectangle rc, TRectangleAction action, object tag)
        {
            if (rectsCreated == false)
            {
                rects.Add(new ActRect(rc, action, tag));
            }
        }

        private void AddActiveRect(Rectangle rc, TRectangleAction action)
        {
            if (rectsCreated == false)
            {
                rects.Add(new ActRect(rc, action));
            }
        }

        private void ResetAllRectangleStates()
        {
            foreach (ActRect rc in rects)
            {
                rc.State = TRectangleStatus.Normal;
            }
        }

        internal void OnRecalculateRequired()
        {
            ResetAllRectangleStates();

            bool bRecreate = true;
            if (rectsCreated && bRecreate)
                rectsCreated = false;

            ActRect rect = FindActiveRectByTag(iDay);
            if (iLastFocused < DEF_TODAY_TAB_INDEX)
                iLastFocused = iDay;

            if (rect != null)
                rect.State |= TRectangleStatus.FocusSelect;
        }

        private ActRect FindActiveRectByTag(object tag)
        {
            foreach (ActRect rect in rects)
            {
                if (rect.Tag != null && rect.Tag.Equals(tag))
                    return rect;
            }

            return null;
        }

        protected internal virtual void OnButtonClicked(CalendarButtonClickedEventArgs e)
        {
            if (ButtonClicked != null)
                ButtonClicked(this, e);
        }

        protected internal virtual void OnRegisterClicked(ArrayList e)
        {
            if (RegisterClicked != null)
                RegisterClicked(this, e);
        }

        protected internal virtual void OnUnRegisterClicked(ArrayList e)
        {
            if (UnRegisterClicked != null)
                UnRegisterClicked(this, e);
        }

        protected internal virtual void OnShowDossierClicked(ArrayList e)
        {
            if (ShowDossierClicked != null)
                ShowDossierClicked(this, e);
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

        protected override void OnMouseClick(MouseEventArgs e)
        {
            OnInternalMouseClick(e.Location);

            switch (e.Button)
            {
                case MouseButtons.Left:
                    //OnInternalMouseClick(e.Location);
                    //this.aContextMenuStrip.Show(e.X, e.Y);

                    break;
                case MouseButtons.Middle:
                    break;
                case MouseButtons.None:
                    break;
                case MouseButtons.Right:
                    //this.ContextMenuStrip = null;
                    this.aContextMenuStrip.Close();
                    break;
                case MouseButtons.XButton1:
                    break;
                case MouseButtons.XButton2:
                    break;
                default:
                    break;

            }

            base.OnMouseClick(e);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            //base.OnMouseDoubleClick(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            OnInternalMouseHover(e.Location);
        }

        protected internal virtual void OnSelectedDateRangeChanged(EventArgs e)
        {
            if (SelectedDateRangeChanged != null)
                SelectedDateRangeChanged(this, e);
        }

        private void AddContexMenu()
        {
            aContextMenuStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            aContextMenuStrip.Left += aContextMenuStrip.Width;
            aContextMenuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            aContextMenuStrip.ShowImageMargin = false;

            ToolStripMenuItem toolStripItem1 = new ToolStripMenuItem();
            toolStripItem1.Text = "ثبت نوبت";
            toolStripItem1.Click += new EventHandler(toolStripItem1_Click);

            ToolStripMenuItem toolStripItem2 = new ToolStripMenuItem();
            toolStripItem2.Text = "حذف نوبت";
            toolStripItem2.Click += new EventHandler(toolStripItem2_Click);

            ToolStripMenuItem toolStripItem3 = new ToolStripMenuItem();
            toolStripItem3.Text = "مشاهده پرونده";
            toolStripItem3.Click += new EventHandler(toolStripItem3_Click);

            aContextMenuStrip.Items.Add(toolStripItem1);
            aContextMenuStrip.Items.Add(toolStripItem2);
            aContextMenuStrip.Items.Add(toolStripItem3);
            this.ContextMenuStrip = aContextMenuStrip;
        }

        private void toolStripItem1_Click(object sender, EventArgs args)
        {
            OnRegisterClicked(selectedNodes);

        }

        private void toolStripItem2_Click(object sender, EventArgs args)
        {
            OnUnRegisterClicked(selectedNodes);
        }

        private void toolStripItem3_Click(object sender, EventArgs args)
        {
            OnShowDossierClicked(selectedNodes);
        }

        //***********************************************

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

        public void DrawSeparator(Graphics g, Point ptFrom, Point ptTo)
        {
            // Find point halfway across for separator lines
            Pen p = new Pen(SystemColors.ControlDark);

            // Draw two lines to give 3D effect and indent by 2 pixels
            g.DrawLine(p, ptFrom, ptTo);

            p.Dispose();
        }

        public void DrawBorder(Graphics g, Rectangle rectangle, bool enabled)
        {
            if (rectangle.Width > 0 && rectangle.Height > 0)
            {
                //Color c = enabled ? SystemColors.ActiveBorder : SystemColors.InactiveBorder;
                Color c = enabled ? SystemColors.ActiveBorder : SystemColors.ControlDarkDark;

                using (Pen p = new Pen(c))
                {
                    g.DrawRectangle(p, rectangle);
                }
            }
        }

        public void DrawFilledBackground(Graphics g, Rectangle rectangle, bool isGradient, float angle)
        {
            using (Brush brush = new SolidBrush(SystemColors.Window))
            {
                g.FillRectangle(brush, rectangle);
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

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // VisitTable
            // 
            this.ResumeLayout(false);

        }

        //*********************************************************************88
    }



    internal class ActRect
    {
        #region Fields

        private Rectangle m_rect;
        private TRectangleStatus m_state;
        private bool m_bInvalidate = true;
        private TRectangleAction m_act;
        private object m_tag;

        #endregion

        #region Class Properties

        public Rectangle Rect
        {
            get { return m_rect; }
            set { m_rect = value; }
        }

        public TRectangleStatus State
        {
            get { return m_state; }
            set
            {
                m_state = TRectangleStatus.Normal;
            }
        }

        public bool InvalidateOnChange
        {
            get { return m_bInvalidate; }
            set { m_bInvalidate = value; }
        }

        public TRectangleAction Action
        {
            get { return m_act; }
            set { m_act = value; }
        }

        public object Tag
        {
            get { return m_tag; }
            set { m_tag = value; }
        }

        public bool IsFocused
        {
            get { return (m_state & TRectangleStatus.Focused) == TRectangleStatus.Focused; }
        }

        public bool IsSelected
        {
            get { return (m_state & TRectangleStatus.Selected) == TRectangleStatus.Selected; }
        }

        public bool IsActive
        {
            get { return (m_state & TRectangleStatus.Active) == TRectangleStatus.Active; }
        }

        #endregion

        #region Ctor

        public ActRect(Rectangle rc, TRectangleStatus state, TRectangleAction act, bool invalidate)
        {
            m_rect = rc;
            m_state = state;
            m_bInvalidate = invalidate;
            m_act = act;
        }

        public ActRect(Rectangle rc, TRectangleStatus state, TRectangleAction act)
            : this(rc, state, act, true)
        {
        }

        public ActRect(Rectangle rc, TRectangleAction act, object tag)
        {
            m_rect = rc;
            m_state = TRectangleStatus.Normal;
            m_act = act;
            m_tag = tag;
        }

        public ActRect(Rectangle rc, TRectangleAction act)
            : this(rc, TRectangleStatus.Normal, act, true)
        {
        }

        public ActRect(Rectangle rc, TRectangleStatus state)
            : this(rc, state, TRectangleAction.None, true)
        {
        }

        public ActRect(Rectangle rc)
            : this(rc, TRectangleStatus.Normal, TRectangleAction.None, true)
        {
        }

        public ActRect()
            : this(Rectangle.Empty, TRectangleStatus.Normal, TRectangleAction.None, true)
        {
        }

        #endregion
    }

}
