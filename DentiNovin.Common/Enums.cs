using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace DentiNovin.Common
{
    /// <summary>
    /// Determines each day of week
    /// </summary>
    public enum PersianDayOfWeek
    {
        Saturday = 0,
        Sunday = 1,
        Monday = 2,
        Tuesday = 3,
        Wednesday = 4,
        Thursday = 5,
        Friday = 6
    }

    public enum PageMode
    {
        Mode_edit = 0,
        Mode_new = 1,
    }

    public enum ProgramMessageID
    {
        PM_actinsuccess = 0
    }
    public enum TreatmentStatus
    {
        None = 0,
        Completed = 1,
        Planned = 2,
        Condition = 3,
        Declined = 4,
        referred = 5
    }
    public enum TreatmentSurface
    {
        F = 0,
        B = 1,
        D = 2,
        M = 3,
        O = 4,
        I = 5,
        L = 6,
        L5 = 7,
        F5 = 8,
        B5 = 9,
        OutOfArea = 11
    }

    public enum ToothSurface
    {
        Mesial = 0,
        Occlusal = 1,
        Incisal = 2,
        Distal = 3,
        Linqual = 4,
        Buccal = 5,
        Facial = 6,
        Class5 = 7
    }
    public enum TreatmentSurfaceView
    {
        None = 0,
        RootCanal = 1,//
        Remove = 2,//X
        Impacted = 3,// <---   ---->
        Abcess = 4,//ellipse
        WatchTooth = 5,//rectangle on toothNumber
        CrackedTooth = 6,//  ^^^^^
        Caries = 7, // 7 Areas Bold
        Composite = 8,// 7 Areas empty
        OpenContact = 9,//  |>   <|
        HyperSensetive = 10,//    //  \\
        Recession = 11,//     ---------
        Abrasion = 12,// Out Circle empty
        CrownHorizontal = 13,// HatchBrush Horizontal
        CrownVertical = 14,// HatchBrush Vertical
        CrownCross = 15,// HatchBrush Cross
        CrownForwardDiagonal = 16, // HatchBrush Forward Diagonal
        Pontic = 17,//Circle and rectangle Bold
        DentureAll = 18,//two parallel line
        DentureSingle = 19,//two parallel line
        Implant = 20,//pich
        Porcelain = 21,//
        Veneer = 22,//arc

    }

    public enum TreatmentDrawType
    {
        None = 0,
        Fill = 1,
        Implant = 2,
        [Description("Root Canal")]
        RootCanal = 3,
        [Description("Arrow Mesial")]
        ArrowMesial = 4,
        [Description("Arrow Distal")]
        ArrowDistal = 5,
        [Description("Circled Root")]
        CircledRoot = 6,
        [Description("Highlight Number")]
        HighlightNumber = 7,
        [Description("Hypersensitive Line")]
        HypersensitiveLine = 8,
        Recession = 9,
        Crack = 10,
        [Description("Open Contact Mesial")]
        OpenContactMesial = 11,
        [Description("Open Contact Distal")]
        OpenContactDistal = 12,
        [Description("Circled Occlusal")]
        CircledOcclusal = 13,
        [Description("Vertical Lines")]
        VerticalLines = 14,
        Crown = 15,
        [Description("Surface Outline")]
        SurfaceOutline = 16,
        S = 17,
        [Description("Half Root Canal")]
        HalfRootCanal = 18,
        Denture = 19,
        Bridge = 20,
        X = 21,
        [Description("Hide Tooth")]
        HideTooth = 22,
        Veneer = 23,
        Resection = 24

    }

    public enum TreatmentArea
    {
        Surface = 1,
        Tooth = 2,
        Root = 3,
        Mouth = 4,
        Quadrant = 5,
        Maxillary = 6,//up
        Mandibular = 7//down
    }

    public enum TreatmentClass
    {
        Diagnostic = 1,
        Preventive = 2,
        Restorative = 3,
        Endodontics = 4,
        Periodontics = 5,
        Prosthremov = 6,
        MaxilloProsth = 7,
        ImplantServ = 8,
        Prosthofixed = 9,
        OralSurgery = 10,
        Orthodontics = 11,
        AdjunctServ = 12,
        Conditions = 13,
        Other = 14
    }

    public enum MultiCodeMode
    {
        None = 0,
        AlternateRootCode = 1,
        MultiplesurfaceCode = 2
    }

    public enum ToothRootType
    {
        None = 0,
        Anterior = 1,
        Bicuspid = 2,
        Molar = 3
    }

    public enum ToothType
    {
        Permanent = 0,
        Primary = 1
    }

    public enum ToothTypeChangeMode
    {
        None = 0,
        Single2Permanent = 1,
        Single2Primary = 2,
        All2Permanent = 3,
        All2Primary = 4
    }

    public enum DrawingBrushType
    {
        Solid = 1,
        [Description("Horizontal Lines")]
        HorizontalLines = 2,
        [Description("Vertical Lines")]
        VerticalLines = 3,
        Diagonal = 4,
        [Description("Cross Lines")]
        CrossLines = 5,
        [Description("Diagonal Cross")]
        DiagonalCross = 6

    }

    public enum ActionMode
    {
        None = 0,
        Add = 1,
        Remove = 2,
        update = 3,
        cancel = 4
    }

    public enum NumberingSystem
    {
        UniversalSystem = 0,
        PalmerSystem = 1,
        FdiSystem = 2
    }

    public enum ServiceFilterType
    {
        ShowAll = 0,
        OnlyTrue = 1,
        OnlyFalse = 2,
        OnlyNotRelated=3
    }

    public enum DentiReport
    {
        PatientTreatmentReport = 0,
        [Description("لیست مراجعات بیماران")]
        PatientsVisitsReport = 1,
        [Description("لیست صورتحساب - بیماران")]
        PatientsBillReport = 2,
        [Description("لیست صورتحساب(به تفکیک کد حساب) - بیماران")]
        PatientsBillWithIDReport = 3,
        [Description("لیست صورتحساب - پزشکان")]
        DoctorsBillReport = 4,
        [Description("لیست صورتحساب(به تفکیک کد حساب) - پزشکان")]
        DoctorsBillWithIDReport = 5,
        [Description("لیست درمانهای بیماران")]
        PatientTreatmentListReport = 6,
    }

    public enum AssuranceType
    {
        None = 0,
        Taamin = 1,
        Mosallah = 2,
        Khadamat = 3,
        Emdad = 4
    }


}
