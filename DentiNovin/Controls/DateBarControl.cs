using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DentiNovin.BaseClasses;
using System.Windows.Forms.VisualStyles;
using DentiNovin.Common.DateConvert;
using System.Collections;
using System.Drawing.Text;

namespace DentiNovin.Controls
{
    public partial class DateBarControl : UserControl
    {
        private const int DEF_HEADER_SIZE = 30;
        private const int DEF_ARROW_SIZE = 4;

        private Rectangle rcHeader;
        private PersianCalendar pc;
        private DateTimeCollection selectedDateRange;
        public string selectedPersianDate;
        private int iYear;
        private int iMonth;
        private int iDay;
        private bool rectsCreated;

        public int IYear
        {
            get
            { return iYear; }
            set
            { iYear = value; }
        }

        public int IMonth
        {
            get
            { return iMonth; }
            set
            { iMonth = value; }
        }
        public int IDay
        {
            get
            { return iDay; }
            set
            { iDay = value; }
        }
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
                IDay = pc.GetDayOfMonth(selectedGregorianDate);
                OnDayChanged(EventArgs.Empty);

                IMonth = pc.GetMonth(selectedGregorianDate);
                OnMonthChanged(EventArgs.Empty);

                IYear = pc.GetYear(selectedGregorianDate);
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



        private ArrayList rects = new ArrayList(200);

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
        private StringFormat format;

        public event EventHandler DayChanged;
        public event EventHandler MonthChanged;
        public event EventHandler YearChanged;
        public event EventHandler SelectedDateTimeChanged;

        public DateBarControl()
        {
            InitializeComponent();
            format = new StringFormat();
            pc = new PersianCalendar();
            selectedDateRange = new DateTimeCollection();

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //SelectedDateTime = DateTime.Now;
            OnDrawHeader(new PaintEventArgs(e.Graphics, rcHeader));
        }

        private void OnDrawHeader(PaintEventArgs pevent)
        {


            Graphics g = pevent.Graphics;
            Rectangle rc = new Rectangle(0, 0, Width, Height);

            // Draw header background
            rcHeader = new Rectangle(rc.X + 1, rc.Y + 1, rc.Width - 2, DEF_HEADER_SIZE);
            DrawButton(g, rcHeader, string.Empty, Font, null, ItemState.Open, false, true);

            //Rectangle rc = pevent.ClipRectangle;
            Rectangle rcOut = Rectangle.Inflate(rc, -6, -1);

            PaintEventArgs ev = new PaintEventArgs(pevent.Graphics, rcOut);

            OnDrawMonthHeader(ev);
            OnDrawYearHeader(ev);
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

        private void AddActiveRect(Rectangle rc, TRectangleAction action)
        {
            if (rectsCreated == false)
            {
                rects.Add(new ActRect(rc, action));
            }
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

        protected internal virtual void OnDayChanged(EventArgs e)
        {
            if (DayChanged != null)
                DayChanged(this, e);
        }

        protected internal virtual void OnSelectedDateTimeChanged(EventArgs e)
        {
            if (SelectedDateTimeChanged != null)
                SelectedDateTimeChanged(this, e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            OnInternalMouseClick(e.Location);

            base.OnMouseClick(e);

        }

        internal void OnInternalMouseClick(Point location)
        {
            Focus();

            ActRect rect = FindActiveRectByPoint(location);

            if (rect != null && rect.Action != TRectangleAction.WeekDay)
            {
                ResetActiveRectanglesState();
                ResetFocusedRectangleState();
                OnRectangleClick(rect);
            }
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

            }

            Invalidate();
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
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }
    }
}
