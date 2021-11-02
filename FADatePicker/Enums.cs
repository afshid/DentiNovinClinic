using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FADatePicker
{

    /// <summary>
    /// Decides which property to change when user scrolls mouse wheel over the <see cref="FAMonthView"/> control.
    /// </summary>
    public enum ScrollOptionTypes
    {
        /// <summary>
        /// Scroll days in the FAMonthView control.
        /// </summary>
        Day,

        /// <summary>
        /// Scroll months in the FAMonthView control.
        /// </summary>
        Month,

        /// <summary>
        /// Scroll years in the FAMonthView control.
        /// </summary>
        Year
    }

    /// <summary>
    /// Status of each ActRect instances in FAMonthView controls.
    /// </summary>
    [Flags]
    internal enum TRectangleStatus
    {
        Normal = 0x0000,
        Active = 0x0001,
        Selected = 0x0002,
        Focused = 0x0004,
        Pressed = 0x0008,
        ActiveSelect = Active | Selected,
        FocusSelect = Focused | Selected,
        All = Active | Selected | Focused
    } ;

    public enum CollectionChangeType
    {
        Add,
        Remove,
        Clear,
        Other
    }

    /// <summary>
    /// Action Type of the ActRect class.
    /// </summary>
    internal enum TRectangleAction
    {
        None,
        MonthDown,
        MonthUp,
        YearDown,
        YearUp,
        TodayBtn,
        NoneBtn,
        MonthDay,
        WeekDay
    } ;

    /// <summary>
    /// FAMonthView buttons which will raise the button click event.
    /// </summary>
    public enum FAMonthViewButtons
    {
        /// <summary>
        /// None button of FAMonthView control
        /// </summary>
        None,

        /// <summary>
        /// Today button of FAMonthView control
        /// </summary>
        Today,

        /// <summary>
        /// Any normal day of FAMonthView control
        /// </summary>
        MonthDay,
    }

    public enum TextAlignment
    {
        /// <summary>
        /// Alignment based on system default settings.
        /// </summary>
        Default,

        /// <summary>
        /// Center alignment.
        /// </summary>
        Center,

        /// <summary>
        /// Near alignment, based on RTL settings.
        /// </summary>
        Near,

        /// <summary>
        /// Far alignment, based on RTL settings.
        /// </summary>
        Far
    }

    /// <summary>
    /// Various Formatting Info for PersianDate to format its text values.
    /// </summary>
    public enum FormatInfoTypes
    {
        /// <summary>
        /// PersianDate instance in WrittenDate format equals calling ToString("d"). This is the default value
        /// when using ToString() overload.
        /// </summary>
        ShortDate,

        /// <summary>
        /// PersianDate instance in WrittenDate format equals calling ToString("g")
        /// </summary>
        DateShortTime,

        /// <summary>
        /// PersianDate instance in WrittenDate format equals calling ToString("G")
        /// </summary>
        FullDateTime
    }

    /// <summary>
    /// Specifies the state DrawTab command is in.
    /// </summary>
    public enum ItemState
    {
        /// <summary>
        /// Specifies the command is in default state.
        /// </summary>
        Normal,

        /// <summary>
        /// Specifies command is being hot tracked.
        /// </summary>
        HotTrack,

        /// <summary>
        /// Specifies command is user pressing it down.
        /// </summary>
        Pressed,

        /// <summary>
        /// Specifies command is has been opened.
        /// </summary>
        Open
    }

    public enum StringID
    {
        Empty,

        FADateTextBox_InvalidDate,
        FADateTextBox_Required,

        FAMonthView_None,
        FAMonthView_Today,

        Numbers_0,
        Numbers_1,
        Numbers_2,
        Numbers_3,
        Numbers_4,
        Numbers_5,
        Numbers_6,
        Numbers_7,
        Numbers_8,
        Numbers_9,

        PersianDate_InvalidDateFormat,
        PersianDate_InvalidDateTime,
        PersianDate_InvalidDateTimeLength,
        PersianDate_InvalidDay,
        PersianDate_InvalidEra,
        PersianDate_InvalidFourDigitYear,
        PersianDate_InvalidHour,
        PersianDate_InvalidLeapYear,
        PersianDate_InvalidMinute,
        PersianDate_InvalidMonth,
        PersianDate_InvalidMonthDay,
        PersianDate_InvalidSecond,
        PersianDate_InvalidMillisecond,
        PersianDate_InvalidTimeFormat,
        PersianDate_InvalidYear,

        Validation_Cancel,
        Validation_NotValid,
        Validation_Required,
        Validation_NullText,

        MessageBox_Ok,
        MessageBox_Cancel,
        MessageBox_Yes,
        MessageBox_No,
        MessageBox_Abort,
        MessageBox_Retry,
        MessageBox_Ignore
    }

    /// <summary>
    /// Office 2003 predefined colors.
    /// </summary>
    public enum Office2003Color
    {
        Border, Button1, Button2, Button1Hot, Button2Hot,
        Button1Pressed, Button2Pressed, ButtonDisabled, Text, TextDisabled, Header, Header2, GroupRow,
        TabPageForeColor, TabBackColor1, TabBackColor2, TabPageBackColor1, TabPageBackColor2, TabPageBorderColor,
        NavBarBackColor1, NavBarBackColor2, NavBarLinkTextColor, NavBarLinkHightlightedTextColor, NavBarLinkDisabledTextColor, NavBarGroupClientBackColor,
        NavBarGroupCaptionBackColor1, NavBarGroupCaptionBackColor2, NavBarExpandButtonRoundColor, NavPaneBorderColor,
        NavBarNavPaneHeaderBackColor, LinkBorder
    }

    /// <summary>
    /// Specifies Theme types of WindowsXP.
    /// </summary>
    public enum XPThemeType
    {
        Unknown,
        NormalColor,
        Homestead,
        Metallic
    }

    /// <summary>
    /// Specifies themes supported by UI Controls.
    /// </summary>
    public enum ThemeTypes : int
    {
        /// <summary>
        /// Office 2000 theme and style.
        /// </summary>
        Office2000 = 0,

        /// <summary>
        /// WindowsXP theme and style.
        /// </summary>
        WindowsXP = 1,

        /// <summary>
        /// Office 2003 theme and style.
        /// </summary>
        Office2003 = 2
    }

}
