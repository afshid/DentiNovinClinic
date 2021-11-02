using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FADatePicker.FAPopup;
using System.Windows.Forms;
using System.Drawing;

namespace FADatePicker
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

    public class SelectedDateTimeChangingEventArgs : EventArgs
    {
        private bool cancel;
        private string message;
        private DateTime oldValue;
        private DateTime newValue;

        public SelectedDateTimeChangingEventArgs(DateTime OldValue, DateTime NewValue)
        {
            oldValue = OldValue;
            newValue = NewValue;
            cancel = false;
            message = string.Empty;
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public DateTime NewValue
        {
            get { return newValue; }
            set { newValue = value; }
        }

        public DateTime OldValue
        {
            get { return oldValue; }
        }

        public bool Cancel
        {
            get { return cancel; }
            set { cancel = value; }
        }
    }

    public class ValueValidatingEventArgs : EventArgs
    {
        private bool hasError = false;
        private object value = null;

        public ValueValidatingEventArgs(object Value)
        {
            value = Value;
        }

        public bool HasError
        {
            get { return hasError; }
            set { hasError = value; }
        }

        public object Value
        {
            get { return value; }
        }
    }

    public class CalendarButtonClickedEventArgs : EventArgs
    {
        #region Fields

        private FAMonthViewButtons button;

        #endregion

        #region Ctor

        public CalendarButtonClickedEventArgs(FAMonthViewButtons button)
        {
            this.button = button;
        }

        #endregion

        #region Props

        public FAMonthViewButtons Button
        {
            get { return button; }
        }

        #endregion
    }

    public class CustomDrawDayEventArgs : EventArgs
    {
        private bool handled;
        private bool isToday;
        private Rectangle r;
        private Graphics g;
        private int dayNo;
        private int yearNo;
        private int monthNo;

        public CustomDrawDayEventArgs(Rectangle rectangle, Graphics graphics, int year, int month, int day, bool today)
        {
            dayNo = day;
            yearNo = year;
            monthNo = month;
            r = rectangle;
            g = graphics;
            isToday = today;
            handled = false;
        }

        public bool Handled
        {
            get { return handled; }
            set { handled = value; }
        }

        public Rectangle Rectangle
        {
            get { return r; }
        }

        public Graphics Graphics
        {
            get { return g; }
        }

        public int Day
        {
            get { return dayNo; }
        }

        public int Year
        {
            get { return yearNo; }
        }

        public int Month
        {
            get { return monthNo; }
        }

        public bool IsToday
        {
            get { return isToday; }
        }
    }

    /// <summary>
    /// Specifies change type of the collection.
    /// </summary>
    public class CollectionChangedEventArgs : EventArgs
    {
        private CollectionChangeType changeType = CollectionChangeType.Other;

        public CollectionChangedEventArgs(CollectionChangeType type)
        {
            changeType = type;
        }

        public CollectionChangeType ChangeType
        {
            get { return changeType; }
        }
    }

    internal delegate int Hook(int ncode, IntPtr wParam, IntPtr lParam);
    public delegate void ValueValidatingEventHandler(object sender, ValueValidatingEventArgs e);
    public delegate void BindPopupControlEventHandler(object sender, BindPopupControlEventArgs e);
    public delegate void SelectedDateTimeChangingEventHandler(object sender, SelectedDateTimeChangingEventArgs e);
    public delegate void CustomDrawDayEventHandler(object sender, CustomDrawDayEventArgs e);
    public delegate void CalendarButtonClickedEventHandler(object sender, CalendarButtonClickedEventArgs e);



}
