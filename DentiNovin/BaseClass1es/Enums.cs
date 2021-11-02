using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DentiNovin.BaseClasses
{
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
        Node,
    }

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

    public enum CollectionChangeType
    {
        Add,
        Remove,
        Clear,
        Other
    }
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
        WeekDay,
        Node
    } ;
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

    public enum ToothMode
    {
        Adult,
        Child
    }

    public enum ToothSelectMode
    {
        Separate,
        TopDown,
        All
    }


    public enum Colour
    {
        Black,
        White,
        Red,
        Yellow,
        Green,
        Cyan,
        Blue,
        Magenta
    }

    public enum AppointmentStatus
    {
        Normal=0,
        DeletedByUser=1,
        DeletedPatientRequest=2,
        DeletedPatientAbsence=3,
        OutOfRange=4,
        Entered=5
    }

    public enum AppointmentShowMode
    {
        Monthly=0,
        Weekly=1,
        Daily=2
    }

    public enum DentiForms
    {
        None=0,
       UserForm=1,
        PatientForm=2,
        AppointmentForm=3,
        DoctorForm=4,
        GroupForm=5,
        TreatmentForm=6,
        PatientTreatmentForm=7,
        BillList=8,
        SetupForm=9,
        PrescriptionList=10,
        PrerscriptionForm=11,
        BillForm=12,
        ServiceForm=13,
        ReportsForm=14
    }
}
