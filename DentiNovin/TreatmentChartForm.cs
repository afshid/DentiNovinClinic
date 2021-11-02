using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DentiNovin.Common;
using Silver.UI;
using System.Collections;
using DentiNovin.BusinessLogic;
using DentiNovin.Common.DateConvert;
using System.IO;
using DentiNovin.Properties;
using System.Configuration;
using System.Collections.Specialized;
using DentiNovin.BaseClasses;

namespace DentiNovin
{
    public partial class TreatmentChartForm : BaseForm
    {

        //private Treatment _currentTreatment;
        //public Treatment CurrentTreatment
        //{
        //    get
        //    {
        //        if (_currentTreatment == null)
        //            _currentTreatment = new Treatment();
        //        return _currentTreatment;
        //    }
        //    set { _currentTreatment = value; }
        //}

        private Patient _oPatient;
        public Patient oPatient
        {
            get { return _oPatient; }
            set { _oPatient = value; }
        }

        private DoctorBll _fDoctorBLL;
        public DoctorBll FDoctorBLL
        {
            get
            {
                if (_fDoctorBLL == null)
                    _fDoctorBLL = new DoctorBll();
                return _fDoctorBLL;
            }
            set
            {
                _fDoctorBLL = value;
            }
        }

        private Int64 _appointmentSelectedID;
        public Int64 AppointmentSelectedID
        {
            get { return _appointmentSelectedID; }
            set { _appointmentSelectedID = value; }
        }

        private PatientTreatmentBLL _fPatientTreatmentBLL;
        public PatientTreatmentBLL FPatientTreatmentBLL
        {
            get
            {
                if (_fPatientTreatmentBLL == null)
                    _fPatientTreatmentBLL = new PatientTreatmentBLL();
                return _fPatientTreatmentBLL;
            }
            set
            {
                _fPatientTreatmentBLL = value;
            }
        }

        private TreatmentBLL _fTreatmentBLL;
        public TreatmentBLL FTreatmentBLL
        {
            get
            {
                if (_fTreatmentBLL == null)
                    _fTreatmentBLL = new TreatmentBLL();
                return _fTreatmentBLL;
            }
            set
            {
                _fTreatmentBLL = value;
            }
        }

        public Color _conditionsColor;
        public Color ConditionsColor
        {
            get { return _conditionsColor; }
            set { _conditionsColor = value; }
        }

        public Color _plannedColor;
        public Color PlannedColor
        {
            get { return _plannedColor; }
            set { _plannedColor = value; }
        }

        public Color _completedColor;
        public Color CompletedColor
        {
            get { return _completedColor; }
            set { _completedColor = value; }
        }

        private DataSet aDataSet;

        private Appointment _currentAppointment;
        public Appointment CurrentAppointment
        {
            get
            {
                _currentAppointment = ((MainForm)this.MdiParent).CurrentAppointment;
                return _currentAppointment;
            }
            set
            {
                _currentAppointment = value;
                // btnShowAppointment.Text = _currentAppointment.VisitDate;
            }
        }

        private TreatmentStatus _treatmentStatusSelected = TreatmentStatus.Planned;

        private ArrayList _patientTreatmentList;
        public ArrayList PatientTreatmentList
        {
            get
            {
                if (_patientTreatmentList == null)
                    _patientTreatmentList = new ArrayList();
                return _patientTreatmentList;
            }

            set
            {
                _patientTreatmentList = value;
            }
        }

        private DataSet _thisPatientToothTypeList = new DataSet();

        private PatientTreatment _oPatientTreatment;
        public PatientTreatment OPatientTreatment
        {
            get
            {
                if (_oPatientTreatment == null)
                    _oPatientTreatment = new PatientTreatment();
                return _oPatientTreatment;
            }
            set { _oPatientTreatment = value; }
        }

        private PatientTreatment _currentPatientTreatment;
        public PatientTreatment CurrentPatientTreatment
        {
            get
            {
                if (_currentPatientTreatment == null)
                    _currentPatientTreatment = new PatientTreatment();
                return _currentPatientTreatment;
            }
            set { _currentPatientTreatment = value; }
        }

        //public int[] PermanetToothNumberList { get; set; }
        //public string[] PrimaryToothNumberList { get; set; }

        //public int[] FdiPermanetToothNumberList { get; set; }
        //public string[] FdiPrimaryToothNumberList { get; set; }

        //public int[] PlrPermanetToothNumberList { get; set; }
        //public string[] PlrPrimaryToothNumberList { get; set; }

        //public int[] SelectedPETNSList { get; set; }
        //public string[] SelectedPRTNSList { get; set; }

        private Int64 _patientTreatmentID;
        private Int64 _lastPatientTreatmentIDChanged;
        private int _patientTreatmentToothCode;
        private int _patientTreatmentStatus;

        private int _newPatientTreatmentStatus;
        private bool _toolBoxItemsCreated = false;
        private bool _existTreatmentApplied = false;
        private int[] status = new int[4];
        private string kinOfListString = "لیست درمانهای تمامی دندانها";
        private Int16 selectedToothForShowList = 0;

        private int[] SelectedPETNSList;
        private string[] SelectedPRTNSList;
        private NumberingSystem _selectedNumberingSystem;
        private bool _showPersianName = true;
        private StringCollection _toolTapCaptions;
        private ToolBoxItem editedItem;
        private int selectedTabIndex = 0;
        Dictionary<string, DataTable> reportDataSource;
        TreatmentServiceSelector aTreatmentServiceSelector;

        public TreatmentChartForm()
        {
            InitializeComponent();
            _toolTapCaptions = (StringCollection)Settings.Default["ToolTapCaptions"];
            _showPersianName = (bool)Settings.Default["ShowPersianName"];
            CreateToolbox();
        }

        private void TreatmentChartForm_Load(object sender, EventArgs e)
        {
            _selectedNumberingSystem = (NumberingSystem)Settings.Default["NumberingSystem"];
            switch (_selectedNumberingSystem)
            {
                case NumberingSystem.UniversalSystem:
                    this.SelectedPETNSList = ((MainForm)this.MdiParent).PermanetToothNumberList;
                    this.SelectedPRTNSList = ((MainForm)this.MdiParent).PrimaryToothNumberList;
                    break;
                case NumberingSystem.FdiSystem:
                    this.SelectedPETNSList = ((MainForm)this.MdiParent).FdiPermanetToothNumberList;
                    this.SelectedPRTNSList = ((MainForm)this.MdiParent).FdiPrimaryToothNumberList;
                    break;
                case NumberingSystem.PalmerSystem:
                    this.SelectedPETNSList = ((MainForm)this.MdiParent).PlrPermanetToothNumberList;
                    this.SelectedPRTNSList = ((MainForm)this.MdiParent).PlrPrimaryToothNumberList;
                    break;
                default:
                    break;
            }
            toothChart1.PermanetToothNumberList = this.SelectedPETNSList;
            toothChart1.PrimaryToothNumberList = this.SelectedPRTNSList;
            toothChart1.DrawTeethNumber();
            this.BringToFront();
            cboTreatmentStatus.SelectedIndex = 1;
            this.WindowState = FormWindowState.Maximized;
            dgvPatientTreatment.AutoGenerateColumns = false;
            this.oPatient = ((MainForm)this.MdiParent).oPatient;
            toothChart1.CurrentPatientName = this.oPatient.LastName + "  " + this.oPatient.FirstName;
            this.CurrentAppointment = ((MainForm)this.MdiParent).CurrentAppointment;
            if (oPatient.Image != null)
                pbPatientPicture.Image = byteArrayToImage(oPatient.Image);
            else
                pbPatientPicture.Image = DentiNovin.Properties.Resources.noPerson;

            for (int i = 0; i < 4; i++)
            {
                status[i] = i + 1;
            }

            try
            {
                GetDoctorList();
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1059");
                MessageBox.Show("بروز خطا در بارگزاری لیست پزشکان", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                GetPatientToothTypeList();
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1060");
                MessageBox.Show("بروز خطا در بارگزاری نوع دندان بیمار", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.CurrentAppointment.AppointmentID != 0)
                cboDoctor.SelectedValue = this.CurrentAppointment.DoctorID;
            else
                cboDoctor.SelectedValue = oPatient.DoctorID;
            //if (cboDoctor.SelectedIndex == -1)
            //    cboDoctor.SelectedIndex = 0;

            if ((bool)Settings.Default["MultiColorDrawing"])
            {
                cpConditions.Enabled = false;
                cpPlanned.Enabled = false;
                cpCompleted.Enabled = false;
            }
            else
            {
                cpConditions.AddStandardColors();
                cpConditions.SelectedValue = (Color)Settings.Default["ConditionColor"];
                cpPlanned.AddStandardColors();
                cpPlanned.SelectedValue = (Color)Settings.Default["PlannedColor"];
                cpCompleted.AddStandardColors();
                cpCompleted.SelectedValue = (Color)Settings.Default["CompletedColor"];
            }
            lblKinOfList.Text = kinOfListString;
            FilldgvPatientTreatment(selectedToothForShowList);
            SetPatientTreatmentList(aDataSet.Tables[1]);
            toothChart1.ThisPatientToothTypeList = this._thisPatientToothTypeList;
            toothChart1.ApplyExistToothTypeList();
            toothChart1.PatientTreatmentList = this.PatientTreatmentList;
            toothChart1.CurrentPatientTreatment = this.CurrentPatientTreatment;
            _existTreatmentApplied = true;
            toothChart1.TreatmentStatusSelected = _treatmentStatusSelected;
            if (oPatient.Alert == true)
            {
                AlertForm aAlertForm = new AlertForm();
                aAlertForm.oPatient = this.oPatient;
                aAlertForm.TopMost = true;
                aAlertForm.ShowDialog();
            }
        }

        private void GetPatientToothTypeList()
        {
            _thisPatientToothTypeList = FPatientTreatmentBLL.GetPatientToothTypeList(oPatient.PatientID);
        }

        private void CreateToolbox()
        {
            Image image = DentiNovin.Properties.Resources.TreatmentBarTRed;

            toolBox1.SetImageList(image, new Size(27, 27), Color.Magenta, true);
            toolBox1.SmallItemSize = new Size(27, 27);

            toolBox1.DeleteAllTabs(false);
            for (int i = 0; i < (_toolTapCaptions).Count; i++)
            {
                toolBox1.AddTab((_toolTapCaptions)[i], -1);
                toolBox1[i].View = GetTooolItemMode((Int16)Settings.Default["ToolBoxViewMode"]);
            }
            toolBox1.AutoSize = false;
            GetTreatmentServiceListForTreatmentBox();
            toolBox1[5].Selected = true;
        }

        private ViewMode GetTooolItemMode(Int16 itmint)
        {
            switch (itmint)
            {
                case 0:
                    return ViewMode.List;
                    break;
                case 1:
                    return ViewMode.SmallIcons;
                    break;
                case 2:
                    return ViewMode.LargeIcons;
                    break;

                default:
                    return ViewMode.List;
                    break;
            }
        }

        private void cpConditions_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default["ConditionColor"] = cpConditions.SelectedValue;
            Settings.Default.Save();
            this.ConditionsColor = cpConditions.SelectedValue;
            this.toothChart1.ConditionsColor = this.ConditionsColor;
            if (_existTreatmentApplied)
                this.toothChart1.ApplyExistTreatmentList();
        }

        private void cpPlanned_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default["PlannedColor"] = cpPlanned.SelectedValue;
            Settings.Default.Save();
            this.PlannedColor = cpPlanned.SelectedValue;
            this.toothChart1.PlannedColor = this.PlannedColor;
            if (_existTreatmentApplied)
                this.toothChart1.ApplyExistTreatmentList();
        }

        private void cpCompleted_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default["CompletedColor"] = cpCompleted.SelectedValue;
            Settings.Default.Save();
            this.CompletedColor = cpCompleted.SelectedValue;
            this.toothChart1.CompletedColor = this.CompletedColor;
            if (_existTreatmentApplied)
                this.toothChart1.ApplyExistTreatmentList();
        }

        /// <summary>
        /// toolbox Items creator
        /// </summary>
        private void GetTreatmentServiceListForTreatmentBox()
        {
            DataSet aDataSet;
            int _tClassID = 0;
            Int16 _tPIndex = 0;
            int _switchName = 0;
            try
            {
                aDataSet = FTreatmentBLL.GetTreatmentServiceListForTreatmentBox();
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1059");
                MessageBox.Show("بروز خطا در بارگزاری درمانها", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (_showPersianName)
                _switchName = 3;
            else
                _switchName = 4;
            for (int i = 0; i < aDataSet.Tables[0].Rows.Count; i++)
            {
                //if (!(bool)aDataSet.Tables[0].Rows[i][13])
                //    continue;
                _tClassID = (Int16)aDataSet.Tables[0].Rows[i]["TreatmentClassID"];
                if (aDataSet.Tables[0].Rows[i]["ToolBoxImageIndex"] != System.DBNull.Value)
                    _tPIndex = (Int16)aDataSet.Tables[0].Rows[i]["ToolBoxImageIndex"];
                else
                    _tPIndex = 0;

                switch (_tClassID)
                {
                    case (int)TreatmentClass.Diagnostic:
                    case (int)TreatmentClass.Preventive:
                        toolBox1[0].AddItem(aDataSet.Tables[0].Rows[i][_switchName].ToString(), _tPIndex, 0, false, aDataSet.Tables[0].Rows[i]);
                        break;
                    case (int)TreatmentClass.Restorative:
                        toolBox1[1].AddItem(aDataSet.Tables[0].Rows[i][_switchName].ToString(), _tPIndex, 0, false, aDataSet.Tables[0].Rows[i]);
                        break;
                    case (int)TreatmentClass.Prosthofixed:
                    case (int)TreatmentClass.Prosthremov:
                    case (int)TreatmentClass.ImplantServ:
                        toolBox1[2].AddItem(aDataSet.Tables[0].Rows[i][_switchName].ToString(), _tPIndex, 0, false, aDataSet.Tables[0].Rows[i]);
                        break;
                    case (int)TreatmentClass.Periodontics:
                    case (int)TreatmentClass.Endodontics:
                    case (int)TreatmentClass.OralSurgery:
                    case (int)TreatmentClass.Other:
                        toolBox1[3].AddItem(aDataSet.Tables[0].Rows[i][_switchName].ToString(), _tPIndex, 0, false, aDataSet.Tables[0].Rows[i]);
                        break;
                    case (int)TreatmentClass.MaxilloProsth:
                        break;
                    case (int)TreatmentClass.AdjunctServ:
                        break;
                    case (int)TreatmentClass.Conditions:
                        toolBox1[4].AddItem(aDataSet.Tables[0].Rows[i][_switchName].ToString(), _tPIndex, 0, false, aDataSet.Tables[0].Rows[i]);
                        break;

                    case (int)TreatmentClass.Orthodontics:
                    default:
                        break;
                }

            }

            for (int i = 0; i < aDataSet.Tables[1].Rows.Count; i++)
            {
                if (aDataSet.Tables[1].Rows[i]["ToolBoxImageIndex"] != System.DBNull.Value)
                    _tPIndex = (Int16)aDataSet.Tables[1].Rows[i]["ToolBoxImageIndex"];
                else
                    _tPIndex = 0;
                if ((Int64)aDataSet.Tables[1].Rows[i]["UsedCount"] != 0)
                    toolBox1[5].AddItem(aDataSet.Tables[1].Rows[i][_switchName].ToString(), _tPIndex, 0, false, aDataSet.Tables[1].Rows[i]);
            }

            DataRow aDataRow = aDataSet.Tables[0].NewRow();
            aDataRow[0] = 0;
            aDataRow[3] = "سرویسهای دیگر";
            aDataRow[4] = "Other Services";
            toolBox1[6].AddItem(aDataRow[_switchName].ToString(), 118, 0, false, aDataRow);

            //for (int i = 0; i < 6; i++)
            //{
            //    toolBox1[i].View = ViewMode.SmallIcons;
            //    toolBox1[i].Deletable = true;
            //    toolBox1[i].Renamable = false;
            //    toolBox1[i].Movable = true;
            //    toolBox1[i].Selected = false;
            //    toolBox1[i].AddItem("افزودن درمان", 117, 0, false, aDataRow);
            //}
        }

        private void FilldgvPatientTreatment(Int16 toothCode)
        {
            try
            {
                aDataSet = FPatientTreatmentBLL.GetPatientTreatmentList(0, oPatient.PatientID, status, _showPersianName, toothCode);
                DataColumn bDataColumn = new DataColumn("SurfaceCodeList");
                aDataSet.Tables[0].Columns.Add(bDataColumn);
                DataColumn cDataColumn = new DataColumn("StatusConverted");
                aDataSet.Tables[0].Columns.Add(cDataColumn);
                DataColumn dDataColumn = new DataColumn("FaToothDirection");
                aDataSet.Tables[0].Columns.Add(dDataColumn);
                DataColumn eDataColumn = new DataColumn("ToothNumberConverted");
                aDataSet.Tables[0].Columns.Add(eDataColumn);
                for (int i = 0; i < aDataSet.Tables[0].Rows.Count; i++)
                {
                    aDataSet.Tables[0].Rows[i]["SurfaceCodeList"] = SortSurface(aDataSet.Tables[0].Rows[i]["SurfaceCode"].ToString(), (byte)aDataSet.Tables[0].Rows[i]["ToothCode"], new ArrayList()); //GetSurfaceStringList(aDataSet.Tables[0].Rows[i]["SurfaceCode"].ToString());

                    switch ((TreatmentStatus)((Int16)aDataSet.Tables[0].Rows[i]["status"]))
                    {
                        case TreatmentStatus.None:
                            aDataSet.Tables[0].Rows[i]["StatusConverted"] = "-";
                            break;
                        case TreatmentStatus.Completed:
                            aDataSet.Tables[0].Rows[i]["StatusConverted"] = "تکمیل شده";
                            break;
                        case TreatmentStatus.Planned:
                            aDataSet.Tables[0].Rows[i]["StatusConverted"] = "برنامه ریزی شده";
                            break;
                        case TreatmentStatus.Condition:
                            aDataSet.Tables[0].Rows[i]["StatusConverted"] = "شرایط موجود";
                            break;
                        case TreatmentStatus.Declined:
                            aDataSet.Tables[0].Rows[i]["StatusConverted"] = "کنسل شده";
                            break;
                        default:
                            break;
                    }
                    string normalNumberString = string.Empty;
                    if (aDataSet.Tables[0].Rows[i]["ToothCode"] == System.DBNull.Value)
                        aDataSet.Tables[0].Rows[i]["ToothCode"] = 0;
                    if ((byte)aDataSet.Tables[0].Rows[i]["ToothType"] == (int)ToothType.Primary)
                        normalNumberString = this.SelectedPRTNSList[(byte)aDataSet.Tables[0].Rows[i]["ToothCode"] - 1];
                    else
                        normalNumberString = this.SelectedPETNSList[(byte)aDataSet.Tables[0].Rows[i]["ToothCode"] - 1].ToString();

                    aDataSet.Tables[0].Rows[i]["ToothNumberConverted"] = UtilMethods.GetToothNumberString((byte)aDataSet.Tables[0].Rows[i]["ToothCode"], (Int16)aDataSet.Tables[0].Rows[i]["TreatmentArea"], normalNumberString);
                    aDataSet.Tables[0].Rows[i]["FaToothDirection"] = UtilMethods.GetToothDirectionString((Byte)aDataSet.Tables[0].Rows[i]["ToothCode"], (Int16)aDataSet.Tables[0].Rows[i]["TreatmentArea"]);
                }
                dgvPatientTreatment.DataSource = aDataSet.Tables[0];
                if (this._selectedNumberingSystem == NumberingSystem.PalmerSystem)
                    dgvPatientTreatment.Columns[6].Visible = true;
                else
                    dgvPatientTreatment.Columns[6].Visible = false;

            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1061");
                MessageBox.Show("بروز خطا در بارگزاری لیست درمانها", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetPatientTreatmentList(DataTable dt)
        {
            PatientTreatment aPatientTreatment;
            PatientTreatmentList.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                aPatientTreatment = new PatientTreatment();
                aPatientTreatment.PatientTreatmentID = (Int64)dt.Rows[i]["Patient-TreatmentID"];
                aPatientTreatment.Tooth.Direction = (byte)dt.Rows[i]["ToothDirection"];
                aPatientTreatment.Tooth.Code = (byte)dt.Rows[i]["ToothCode"];
                aPatientTreatment.Tooth.Type = (ToothType)((byte)dt.Rows[i]["ToothType"]);
                aPatientTreatment.Treatment.TreatmentServiceID = (Int16)dt.Rows[i]["TreatmentServiceID"];
                aPatientTreatment.AppointmentID = (Int64)dt.Rows[i]["AppointmentID"];
                if (dt.Rows[i]["DrawType"] != System.DBNull.Value)
                    aPatientTreatment.Treatment.DrawType = (Int16)dt.Rows[i]["DrawType"];
                if (dt.Rows[i]["BrushType"] != System.DBNull.Value)
                    aPatientTreatment.Treatment.BrushType = (Int16)dt.Rows[i]["BrushType"];
                if (dt.Rows[i]["BrushColor"] != System.DBNull.Value)
                    aPatientTreatment.Treatment.BrushColor = (int)dt.Rows[i]["BrushColor"];
                foreach (char sc in dt.Rows[i]["SurfaceCode"].ToString())
                {
                    aPatientTreatment.Surface.Add(Convert.ToInt32(sc.ToString()));
                }
                if (dt.Rows[i]["Status"] != System.DBNull.Value)
                    aPatientTreatment.Status = (TreatmentStatus)((Int16)dt.Rows[i]["Status"]);

                aPatientTreatment.Treatment.TreatmentArea = (Int16)dt.Rows[i]["TreatmentArea"];
                aPatientTreatment.Treatment.MarkToothMissing = (bool)dt.Rows[i]["MarkToothMissing"];
                PatientTreatmentList.Add(aPatientTreatment);
            }
        }

        private string SortSurface(string surfaceCode, byte toothCode, ArrayList arrChar)
        {
            string _returnString = string.Empty;
            arrChar.Clear();
            for (int i = 0; i < surfaceCode.Length; i++)
            {
                arrChar.Add(Convert.ToInt16(surfaceCode.Substring(i, 1)));
            }
            Int16 _min;
            if (toothCode < 9)
            {
                for (int i = 0; i < arrChar.Count; i++)
                {
                    switch ((Int16)arrChar[i])
                    {
                        case 1:
                            arrChar[i] = (Int16)3;
                            break;
                        case 3:
                            arrChar[i] = (Int16)1;
                            break;
                    }
                }
            }

            if (toothCode > 16 && toothCode < 25)
            {
                for (int i = 0; i < arrChar.Count; i++)
                {
                    switch ((Int16)arrChar[i])
                    {
                        case 4:
                            arrChar[i] = (Int16)5;
                            break;
                        case 5:
                            arrChar[i] = (Int16)4;
                            break;
                        case 6:
                            arrChar[i] = (Int16)7;
                            break;
                        case 7:
                            arrChar[i] = (Int16)6;
                            break;
                    }
                }
            }

            if (toothCode > 24)
            {
                for (int i = 0; i < arrChar.Count; i++)
                {
                    switch ((Int16)arrChar[i])
                    {
                        case 1:
                            arrChar[i] = (Int16)3;
                            break;
                        case 3:
                            arrChar[i] = (Int16)1;
                            break;
                        case 4:
                            arrChar[i] = (Int16)5;
                            break;
                        case 5:
                            arrChar[i] = (Int16)4;
                            break;
                        case 6:
                            arrChar[i] = (Int16)7;
                            break;
                        case 7:
                            arrChar[i] = (Int16)6;
                            break;
                    }
                }
            }

            for (int j = 0; j < arrChar.Count - 1; j++)
            {
                _min = (Int16)arrChar[j];
                for (int k = j + 1; k < arrChar.Count; k++)
                {
                    if (_min > (Int16)arrChar[k])
                    {
                        _min = (Int16)arrChar[k];
                        arrChar[k] = arrChar[j];
                        arrChar[j] = _min;
                    }

                }
            }
            bool s4Exist = false;
            string temp = string.Empty;
            bool s5Exist = false;
            bool s6Exist = false;
            for (int i = 0; i < arrChar.Count; i++)
            {
                temp = GetAreaSurfaceCode((Int16)arrChar[i], toothCode);
                if ((Int16)arrChar[i] == 4)
                    s4Exist = true;
                if ((Int16)arrChar[i] == 5)
                    s5Exist = true;
                if ((Int16)arrChar[i] == 6)
                {
                    s6Exist = true;
                    if (s4Exist)
                        temp = temp.Substring(temp.Length - 1, 1);
                }
                if ((Int16)arrChar[i] == 7)
                {
                    if (s6Exist && s5Exist)
                        continue;
                    if (s5Exist)
                        temp = temp.Substring(temp.Length - 1, 1);
                    if (s6Exist)
                    {
                        temp = temp.Substring(0, 1);
                        _returnString = _returnString.Insert(_returnString.Length - 1, temp);
                        continue;
                    }
                }
                _returnString = _returnString + temp;
            }

            return _returnString;
        }

        private string GetAreaSurfaceCode(Int16 areaNumber, byte toothCode)
        {
            //switch (areaNumber)
            //{
            //    case 1:
            //        if ((0 < toothCode && toothCode < 9) || (24 < toothCode && toothCode < 33))
            //            return "D";
            //        else
            //            return "M";
            //    case 2:
            //        if ((5 < toothCode && toothCode < 12) || (21 < toothCode && toothCode < 28))
            //            return "I";
            //        else
            //            return "O";
            //    case 3:
            //        if ((0 < toothCode && toothCode < 9) || (24 < toothCode && toothCode < 33))
            //            return "M";
            //        else
            //            return "D";
            //    case 4:
            //        if (0 < toothCode && toothCode < 17)
            //            return "L";
            //        else
            //            if (21 < toothCode && toothCode < 28)
            //                return "F";
            //            else
            //                return "B";
            //    case 5:
            //        if (16 < toothCode && toothCode < 33)
            //            return "L";
            //        else
            //            if (5 < toothCode && toothCode < 12)
            //                return "F";
            //            else
            //                return "B";
            //    case 6:
            //        if (16 < toothCode && toothCode < 33)
            //            return "L5";
            //        else
            //            if (5 < toothCode && toothCode < 12)
            //                return "F5";
            //            else
            //                return "B5";
            //    case 7:
            //        if (0 < toothCode && toothCode < 17)
            //            return "L5";
            //        else
            //            if (21 < toothCode && toothCode < 28)
            //                return "F5";
            //            else
            //                return "B5";
            //    default:
            //        return "";
            //}

            switch (areaNumber)
            {
                case 1:
                    return "M";
                case 2:
                    if ((5 < toothCode && toothCode < 12) || (21 < toothCode && toothCode < 28))
                        return "I";
                    else
                        return "O";
                case 3:
                    return "D";
                case 5:
                    return "L";
                case 4:
                    if ((5 < toothCode && toothCode < 12) || (21 < toothCode && toothCode < 28))
                        return "F";
                    else
                        return "B";
                case 6:
                    if ((5 < toothCode && toothCode < 12) || (21 < toothCode && toothCode < 28))
                        return "F5";
                    else
                        return "B5";
                case 7:
                    return "L5";
                default:
                    return "";
            }



        }

        private void toothChart1_ToothClicked(object sender, System.EventArgs e)
        {
            toothChart1.AllowContinue = false;

            if (this.CurrentPatientTreatment.Treatment.TreatmentServiceID == 0)
            {
                MessageBox.Show("برای ثبت درمان ابتدا نام درمان را مشخص نماببد");
                return;
            }

            if (cboDoctor.SelectedItem == null)
            {
                MessageBox.Show("برای ثبت درمان پزشک معالج را مشخص نماببد");
                return;
            }

            if (this.CurrentAppointment.AppointmentID == 0 && this._treatmentStatusSelected == TreatmentStatus.Completed && this.CurrentPatientTreatment.Treatment.TreatmentClassID != (int)TreatmentClass.Conditions)
            {
                MessageBox.Show("برای ثبت این درمان در وضعیت تکمیل شده ابتدا تاریخ مراجعه بیمار را مشخص نماببد");

                if (((MainForm)this.MdiParent).oAppointmentListDock.IsDisposed)
                    ((MainForm)this.MdiParent).OpenAppointmentListDock();
                else
                    ((MainForm)this.MdiParent).oAppointmentListDock.Activate();
                return;
            }
            toothChart1.AllowContinue = true;

            this.CurrentPatientTreatment.AppointmentID = this.CurrentAppointment.AppointmentID;

        }

        private void toothChart1_TreatmentCompleted(object sender, EventArgs e)
        {
            if (_treatmentStatusSelected == TreatmentStatus.Completed && this.CurrentPatientTreatment.Status != TreatmentStatus.Condition)
                this.CurrentPatientTreatment.AppointmentID = this.CurrentAppointment.AppointmentID;
            this.CurrentPatientTreatment.PatientID = oPatient.PatientID;
            if (cboDoctor.SelectedItem != null)
                this.CurrentPatientTreatment.DoctorID = Convert.ToInt32(((DataRowView)cboDoctor.SelectedItem).Row[0]);
            this.CurrentPatientTreatment.SurfaceCode = "";

            foreach (int item in this.CurrentPatientTreatment.Surface)
            {
                this.CurrentPatientTreatment.SurfaceCode = this.CurrentPatientTreatment.SurfaceCode + item.ToString();
            }
            this.CurrentPatientTreatment.Description = "";
            this.CurrentPatientTreatment.SurfaceCount = toothChart1.CurrentPatientTreatment.Surface.Count;

            if (this.CurrentPatientTreatment.Treatment.TreatmentArea == (int)TreatmentArea.Root)
            {
                switch (this.CurrentPatientTreatment.Tooth.RootType)
                {

                    case ToothRootType.Anterior:
                        this.CurrentPatientTreatment.SurfaceCount = 1;
                        break;
                    case ToothRootType.Bicuspid:
                        this.CurrentPatientTreatment.SurfaceCount = 2;
                        break;
                    case ToothRootType.Molar:
                        this.CurrentPatientTreatment.SurfaceCount = 3;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                if (this.CurrentPatientTreatment.Surface.Contains(7) && this.CurrentPatientTreatment.Surface.Contains(5))
                    this.CurrentPatientTreatment.SurfaceCount -= 1;
                if (this.CurrentPatientTreatment.Surface.Contains(6) && this.CurrentPatientTreatment.Surface.Contains(4))
                    this.CurrentPatientTreatment.SurfaceCount -= 1;

            }

            this.CurrentPatientTreatment.RegisterDate = PersianDateConverter.ToPersianDate(DateTime.Now).ToString("d", null);
            FPatientTreatmentBLL.RunType = ((MainForm)this.MdiParent).RunType;
            FPatientTreatmentBLL.oPatientTreatment = this.CurrentPatientTreatment;
            switch (toothChart1.TActionMode)
            {
                case ActionMode.None:
                    break;
                case ActionMode.Add:
                    try
                    {
                        FPatientTreatmentBLL.InsertNewPatientTreatment();
                        _lastPatientTreatmentIDChanged = this.CurrentPatientTreatment.PatientTreatmentID;
                        FilldgvPatientTreatment(selectedToothForShowList);
                        SetPatientTreatmentList(aDataSet.Tables[1]);
                    }
                    catch (TrialException tex)
                    {
                        MessageBox.Show(tex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SetPatientTreatmentList(aDataSet.Tables[1]);
                        this.toothChart1.ApplyExistTreatmentList();
                    }
                    catch (Exception ex)
                    {
                        UtilMethods.LogError(ex, "1062");
                        MessageBox.Show("بروز خطا در ثبت درمان جدید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SetPatientTreatmentList(aDataSet.Tables[1]);
                        this.toothChart1.ApplyExistTreatmentList();
                    }

                    break;
                case ActionMode.Remove:
                    try
                    {
                        FPatientTreatmentBLL.DeletePatientTreatment();
                        _lastPatientTreatmentIDChanged = this.CurrentPatientTreatment.PatientTreatmentID;
                        FilldgvPatientTreatment(selectedToothForShowList);
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        if (ex.Message == "60090")
                            MessageBox.Show("بدلیل وجود صورتحسابی مرتبط با این درمان امکان حذف وجود ندارد", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SetPatientTreatmentList(aDataSet.Tables[1]);
                        this.toothChart1.ApplyExistTreatmentList();
                    }
                    break;
                case ActionMode.update:
                    try
                    {
                        FPatientTreatmentBLL.UpdatePatientTreatment();
                        _lastPatientTreatmentIDChanged = this.CurrentPatientTreatment.PatientTreatmentID;
                        FilldgvPatientTreatment(selectedToothForShowList);
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        if (ex.Message == "60090")
                            MessageBox.Show("بدلیل وجود صورتحسابی مرتبط با این درمان امکان تغییر وجود ندارد", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SetPatientTreatmentList(aDataSet.Tables[1]);
                        this.toothChart1.ApplyExistTreatmentList();
                    }
                    break;
                default:
                    break;
            }
        }

        private void GetDoctorList()
        {
            DataSet aDataSet;
            aDataSet = FDoctorBLL.GetDoctorList(true);
            cboDoctor.DataSource = aDataSet.Tables[0];
            cboDoctor.DisplayMember = "LastName";
            cboDoctor.ValueMember = "DoctorID";
        }

        private void chkShowConditions_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowConditions.Checked)
                status[2] = 3;
            else
                status[2] = 0;
            FilldgvPatientTreatment(selectedToothForShowList);
            //SetPatientTreatmentList(aDataSet.Tables[1]);
            this.toothChart1.ApplyExistTreatmentList();
        }

        private void chkShowPlanned_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPlanned.Checked)
                status[1] = 2;
            else
                status[1] = 0;
            FilldgvPatientTreatment(selectedToothForShowList);
            //SetPatientTreatmentList(aDataSet.Tables[1]);
            this.toothChart1.ApplyExistTreatmentList();
        }

        private void chkShowCompleted_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowCompleted.Checked)
                status[0] = 1;
            else
                status[0] = 0;
            FilldgvPatientTreatment(selectedToothForShowList);
            //SetPatientTreatmentList(aDataSet.Tables[1]);
            this.toothChart1.ApplyExistTreatmentList();
        }

        private void dgvPatientTreatment_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                contextMenuStrip1.Close();

                return;
            }
            //this.dgvPatientTreatment.ClearSelection();
            //this.dgvPatientTreatment.Rows[e.RowIndex].Selected = true;
            if (e.Button == MouseButtons.Right)
            {
                this.dgvPatientTreatment.Rows[e.RowIndex].Selected = true;
                contextMenuStrip1.Items[1].Visible = true;
                contextMenuStrip1.Items[0].Enabled = false;
                switch ((TreatmentStatus)(Int16)((System.Data.DataRowView)(dgvPatientTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[5])
                {
                    case TreatmentStatus.Completed:
                        contextMenuStrip1.Items[1].Text = "برنامه ریزی";
                        _newPatientTreatmentStatus = (int)TreatmentStatus.Planned;
                        break;
                    case TreatmentStatus.Planned:
                        contextMenuStrip1.Items[0].Enabled = true;
                        contextMenuStrip1.Items[1].Text = "تکمیل";
                        _newPatientTreatmentStatus = (int)TreatmentStatus.Completed;
                        break;
                    case TreatmentStatus.Condition:
                        contextMenuStrip1.Items[1].Visible = false;
                        break;
                    case TreatmentStatus.Declined:

                        contextMenuStrip1.Items[1].Text = "برنامه ریزی";
                        _newPatientTreatmentStatus = (int)TreatmentStatus.Planned;
                        break;
                    default:
                        break;
                }

                _patientTreatmentID = (Int64)((System.Data.DataRowView)(dgvPatientTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[1];
                _patientTreatmentToothCode = (byte)((System.Data.DataRowView)(dgvPatientTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[7];
                // _patientTreatmentStatus = (Int16)((System.Data.DataRowView)(dgvPatientTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[5];
            }
        }

        private void ChangePatientTreatmentStatus(Int64 patientTreatmentID, int newStatus)
        {
            try
            {
                FPatientTreatmentBLL.ChangePatientTreatmentStatus(patientTreatmentID, newStatus);
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1063");
                MessageBox.Show("بروز خطا در تغییر وضعیت درمان", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FilldgvPatientTreatment(selectedToothForShowList);
            SetPatientTreatmentList(aDataSet.Tables[1]);
            toothChart1.PatientTreatmentList = this.PatientTreatmentList;
            //toothChart1.applyTreatmentDeclined(_patientTreatmentToothCode);
        }

        private void tsmiDecline_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("وضعیت درمان به 'کنسل شده' تبدیل خواهد شد آیا مطمئن هستید؟", "اخطار تغییر وضعیت", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ChangePatientTreatmentStatus(_patientTreatmentID, (int)TreatmentStatus.Declined);
            }
        }

        private void tsmiChangeStatus_Click(object sender, EventArgs e)
        {
            ChangePatientTreatmentStatus(_patientTreatmentID, _newPatientTreatmentStatus);
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("درمان انتخاب شده حذف خواهد شد آیا مطمئن هستید؟", "اخطار حذف", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.OPatientTreatment.PatientTreatmentID = _patientTreatmentID;
                FPatientTreatmentBLL.oPatientTreatment = this.OPatientTreatment;
                try
                {
                    FPatientTreatmentBLL.DeletePatientTreatment();
                    FilldgvPatientTreatment(selectedToothForShowList);
                    SetPatientTreatmentList(aDataSet.Tables[1]);
                    this.toothChart1.ApplyExistTreatmentList();
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    if (ex.Message == "60090")
                        MessageBox.Show("بدلیل وجود صورتحسابی مرتبط با این درمان امکان حذف وجود ندارد", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void toothChart1_ToothTypeChange(object sender, PatientToothType e)
        {
            e.PatientID = this.oPatient.PatientID;
            FPatientTreatmentBLL.oPatientToothType = (PatientToothType)e;
            try
            {
                FPatientTreatmentBLL.UpdatePatientToothType();
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1064");
                MessageBox.Show("بروز خطا در تغییر نوع دندان", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printDocument1.PrinterSettings.PrintFileName = "ToothChart";
            printDocument1.PrinterSettings.PrintToFile = true;
            printDocument1.Print();
        }

        private void dgvPatientTreatment_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex != 5)
                return;
            if (e.Value != null)
                try
                {
                    if (_lastPatientTreatmentIDChanged == (Int64)((System.Data.DataRowView)(dgvPatientTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[1])
                    {
                        dgvPatientTreatment.Rows[e.RowIndex].HeaderCell.Value = "E";
                        dgvPatientTreatment.Rows[e.RowIndex].HeaderCell.Style.Font = new Font("Wingdings", 9);
                        dgvPatientTreatment.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                    }
                }
                catch (Exception ex)
                {
                    e.FormattingApplied = false;
                }
        }

        private void toolBox1_TabSelectionChanged(ToolBoxTab sender, EventArgs e)
        {
            if (toolBox1[toolBox1.IndexOfTab(sender)].ItemCount <= 0)
                return;
            //toolBox1[toolBox1.IndexOfTab(sender)][0].Selected = true;
            this.toolBox1.SelectedTab.SelectedItemIndex = 0;
        }

        private void SetCurrentTreatment(DataRow drTreatment)
        {
            this.CurrentPatientTreatment.Treatment = null;
            this.CurrentPatientTreatment.Treatment.TreatmentServiceID = (int)drTreatment["TreatmentServiceID"];
            this.CurrentPatientTreatment.Treatment.TreatmentClassID = (Int16)drTreatment["TreatmentClassID"];
            this.CurrentPatientTreatment.Treatment.Code = drTreatment["Code"].ToString();
            this.CurrentPatientTreatment.Treatment.PersianName = drTreatment["PersianName"].ToString();
            this.CurrentPatientTreatment.Treatment.LatinName = drTreatment["LatinName"].ToString();
            this.CurrentPatientTreatment.Treatment.TreatmentArea = (Int16)drTreatment["TreatmentArea"];
            this.CurrentPatientTreatment.Treatment.DrawType = (Int16)drTreatment["DrawType"];
            this.CurrentPatientTreatment.Treatment.BrushType = (Int16)drTreatment["BrushType"];
            this.CurrentPatientTreatment.Treatment.BrushColor = (int)drTreatment["BrushColor"];
            this.CurrentPatientTreatment.Treatment.ShowRootInfoForm = (bool)drTreatment["ShowRootInfoForm"];
            this.CurrentPatientTreatment.Treatment.MarkToothMissing = (bool)drTreatment["MarkToothMissing"];
        }

        private void dgvPatientTreatment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                if (dgvPatientTreatment.SelectedRows.Count > 0)
                {
                    _patientTreatmentID = (Int64)((System.Data.DataRowView)(dgvPatientTreatment.SelectedRows[0].DataBoundItem)).Row.ItemArray[1];
                    tsmiDelete_Click(null, null);
                }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap img = toothChart1.PrintToGraphics(e.Graphics, e.MarginBounds);
            DataTable aDataTable = new DataTable();
            DataRow aDataRow;
            aDataTable.Columns.Add("ChartImage", System.Type.GetType("System.Byte[]"));
            aDataRow = aDataTable.NewRow();
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);  // save bitmap to a 
            aDataRow[0] = ms.GetBuffer();
            aDataTable.Rows.Add(aDataRow);

            //*****
            string exeFolder = Path.GetDirectoryName(Application.StartupPath);// System.Environment.GetFolderPath(System.Environment.SpecialFolder.) + Path.DirectorySeparatorChar + "Reports" + Path.DirectorySeparatorChar + "TreatmentChartReport.rpt";
            //DentiReportsViewerForm aDentiReportForm = new DentiReportsViewerForm();
            ReportsForm aReportsForm = new ReportsForm(DentiReport.PatientTreatmentReport);
            aReportsForm.oPatient = this.oPatient;
            aReportsForm.ReportDataTable.Add(aDataTable);
            aReportsForm.ReportDataTable.Add(aDataSet.Tables[0]);
            aReportsForm.MdiParent = this.MdiParent;
            aReportsForm.Show();
            ////aDentiReportForm.RVSetupForPTChart(new Microsoft.Reporting.WinForms.ReportDataSource("ds1", aDataSet.Tables[0]), new Microsoft.Reporting.WinForms.ReportDataSource("ds2", aDataTable));
            //reportDataSource = new Dictionary<string, DataTable>();
            //reportDataSource.Add("ds1", aDataSet.Tables[0]);
            //reportDataSource.Add("ds2", aDataTable);
            //aDentiReportForm.SetReportDataSource(reportDataSource);
            //aDentiReportForm.ReportPath = "DentiNovin.Reports.PatientTreatmentReport.rdlc";//@"..\..\Reports\PatientTreatmentReport.rdlc";//Path.Combine(exeFolder ,  @"Reports\PatientTreatmentReport.rdlc");
            //aDentiReportForm.MdiParent = this.MdiParent;
            //aDentiReportForm.Show();
            //*****

            //ReportDocument rd = GetReportDocument();
            //rd.Database.Tables[1].SetDataSource(aDataTable);
            //ReportsForm aReportsForm = new ReportsForm();
            //aReportsForm.MYReportDocument = rd;
            //aReportsForm.Show();
        }

        private void SelectTooth(int toothCode, bool isRootTreatment, Int64 patientTreatmentID)
        {
            toothChart1.SelectTooth(toothCode);
            if (!isRootTreatment)
                return;
            //RootCanalForm aRootCanalForm = new RootCanalForm();
            //aRootCanalForm.PatientTreatmentID = patientTreatmentID;
            //aRootCanalForm.EditMode = true;
            //aRootCanalForm.TopMost = true;
            //aRootCanalForm.ShowDialog();


        }

        private void cboTreatmentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTreatmentStatus.SelectedIndex == 0)
                _treatmentStatusSelected = TreatmentStatus.Planned;
            else
                _treatmentStatusSelected = TreatmentStatus.Completed;

            toothChart1.TreatmentStatusSelected = _treatmentStatusSelected;
        }

        private void dgvPatientTreatment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;
            OPatientTreatment.PatientTreatmentID = (Int64)((System.Data.DataRowView)(dgvPatientTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[1];
            OPatientTreatment.Treatment.Code = ((System.Data.DataRowView)(dgvPatientTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[2].ToString();
            OPatientTreatment.Treatment.PersianName = ((System.Data.DataRowView)(dgvPatientTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[3].ToString();
            OPatientTreatment.Treatment.LatinName = ((System.Data.DataRowView)(dgvPatientTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[3].ToString();
            OPatientTreatment.Status = (TreatmentStatus)((Int16)((System.Data.DataRowView)(dgvPatientTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[5]);

            OPatientTreatment.Tooth.Direction = (byte)((System.Data.DataRowView)(dgvPatientTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[6];
            OPatientTreatment.Tooth.Code = (byte)((System.Data.DataRowView)(dgvPatientTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[7];

            OPatientTreatment.Description = ((System.Data.DataRowView)(dgvPatientTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[9].ToString();
            OPatientTreatment.AppointmentID = (Int64)((System.Data.DataRowView)(dgvPatientTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[12];
            OPatientTreatment.PatientID = (int)((System.Data.DataRowView)(dgvPatientTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[13];
            OPatientTreatment.DoctorID = (Int16)((System.Data.DataRowView)(dgvPatientTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[14];
            OPatientTreatment.Treatment.TreatmentServiceID = (int)((System.Data.DataRowView)(dgvPatientTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[15];
            OPatientTreatment.Treatment.TreatmentArea = (Int16)((System.Data.DataRowView)(dgvPatientTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[18];

            PatientTreatmentDetails aPatientTreatmentDetails = new PatientTreatmentDetails();
            aPatientTreatmentDetails.CurrentPatientTreatment = OPatientTreatment;
            aPatientTreatmentDetails.TratmentStatus = ((System.Data.DataRowView)(dgvPatientTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[20].ToString();
            aPatientTreatmentDetails.ToothDirectionConverted = ((System.Data.DataRowView)(dgvPatientTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[21].ToString();
            aPatientTreatmentDetails.ToothNumberConverted = ((System.Data.DataRowView)(dgvPatientTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[22].ToString();

            aPatientTreatmentDetails.DoctorName = ((System.Data.DataRowView)(dgvPatientTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[4].ToString();
            aPatientTreatmentDetails.VisitDate = ((System.Data.DataRowView)(dgvPatientTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[10].ToString();
            aPatientTreatmentDetails.SurfaceList = ((System.Data.DataRowView)(dgvPatientTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[19].ToString();
            aPatientTreatmentDetails.DetailsChanged += new EventHandler(aPatientTreatmentDetails_DetailsChanged);
            aPatientTreatmentDetails.aPageMode = PageMode.Mode_edit;
            aPatientTreatmentDetails.ShowDialog();
        }

        void aPatientTreatmentDetails_DetailsChanged(object sender, EventArgs e)
        {
            FilldgvPatientTreatment(selectedToothForShowList);
        }

        private void toolBox1_TabMouseUp(ToolBoxTab sender, MouseEventArgs e)
        {
            Point ptPos = Point.Empty;
            ContextMenu cm = null;

            if (e.Button == MouseButtons.Right)
            {
                ptPos.X = e.X;
                ptPos.Y = e.Y;
                cm = CreateContextMenu(true, sender);
                cm.Show(this.toolBox1, ptPos);
            }
        }

        private void toolBox1_ItemMouseUp(ToolBoxItem sender, MouseEventArgs e)
        {
            Point ptPos = Point.Empty;
            ContextMenu cm = null;
            editedItem = sender;
            selectedTabIndex = toolBox1.SelectedTabIndex;
            if ((int)((DataRow)sender.Object)[0] == 0)
            {
                aTreatmentServiceSelector = new TreatmentServiceSelector();
                aTreatmentServiceSelector.ServiceFilter = ServiceFilterType.OnlyNotRelated;
                aTreatmentServiceSelector.TreatmentSelected += new EventHandler(aTreatmentServiceSelector_TreatmentSelected);
                aTreatmentServiceSelector.TopMost = true;
                aTreatmentServiceSelector.ShowDialog();
                return;
            }
            SetCurrentTreatment((DataRow)sender.Object);
            if (e.Button == MouseButtons.Right)
            {
                ptPos.X = e.X;
                ptPos.Y = e.Y;
                cm = CreateContextMenu(false, sender);
                cm.Show(this.toolBox1, ptPos);
                return;
            }

            try
            {
                FTreatmentBLL.oTreatment = this.CurrentPatientTreatment.Treatment;
                FTreatmentBLL.TreatmentUsedCountIncrease();
            }
            catch (Exception ex)
            {

            }
            //if (_showPersianName)
            //    toothChart1.CurrentTreatment = this.CurrentPatientTreatment.Treatment.PersianName;
            //else
            //    toothChart1.CurrentTreatment = this.CurrentPatientTreatment.Treatment.LatinName;
        }


        private ContextMenu CreateContextMenu(bool forTab, ToolBoxItem item)
        {

            ToolBoxTab theTab = null;
            ContextMenu cm = new ContextMenu();

            if (forTab)
            {
                theTab = (ToolBoxTab)item;
            }
            else
            {
                theTab = (ToolBoxTab)item.ParentItem;
            }

            cm.MenuItems.Add(forTab ? "تغییر عنوان" : "حذف درمان");
            if (forTab)
                cm.MenuItems[0].Click += new EventHandler(OnTabRenameClick);
            else
                cm.MenuItems[0].Click += new EventHandler(OnItemDeleteClick);

            if (null != theTab)
            {
                MenuItem[] subMenus = new MenuItem[2];

                subMenus[0] = new MenuItem("لیست");
                subMenus[1] = new MenuItem("جدول");
                //subMenus[2] = new MenuItem("Large Icons");


                cm.MenuItems.Add("-");
                cm.MenuItems.Add("نمایش", subMenus);

                switch (theTab.View)
                {
                    case ViewMode.List:
                        subMenus[0].Checked = true;
                        break;
                    case ViewMode.SmallIcons:
                        subMenus[1].Checked = true;
                        break;
                    case ViewMode.LargeIcons:
                        //subMenus[2].Checked = true;
                        break;
                }
                subMenus[0].Click += new EventHandler(OnItemViewModeChange);
                subMenus[1].Click += new EventHandler(OnItemViewModeChange);
                // subMenus[2].Click += new EventHandler(OnItemViewModeChange);
            }
            editedTab = theTab;
            return cm;
        }
        private ToolBoxTab editedTab;
        private void OnItemViewModeChange(object sender, EventArgs e)
        {
            try
            {
                switch (((MenuItem)sender).Index)
                {
                    case 0:
                        editedTab.View = ViewMode.List;
                        break;
                    case 1:
                        editedTab.View = ViewMode.SmallIcons;
                        break;
                    case 2:
                        editedTab.View = ViewMode.LargeIcons;
                        break;
                }
                Settings.Default["ToolBoxViewMode"] = (Int16)((MenuItem)sender).Index;
                Settings.Default.Save();
            }
            catch
            {
            }
        }

        private void OnTabRenameClick(object sender, EventArgs e)
        {
            editedTab.Rename();

        }

        private void OnItemDeleteClick(object sender, EventArgs e)
        {
            string tempString = string.Empty;
            if (selectedTabIndex == 5)
                tempString = " از لیست درمانهای پر کاربرد";
            else
                tempString = " از جعبه درمان";

            if (MessageBox.Show(string.Format("درمان انتخاب شده{0} حذف خواهد شد آیا مطمئن هستید؟", tempString), "اخطار حذف", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (selectedTabIndex == 5)
                    FTreatmentBLL.TreatmentServiceCountReset(this.CurrentPatientTreatment.Treatment.TreatmentServiceID);
                else
                    FTreatmentBLL.TreatmentServiceShowingStatusChange(this.CurrentPatientTreatment.Treatment.TreatmentServiceID, false);

                ToolBoxTab tab = editedItem.ParentItem as ToolBoxTab;
                tab.DeleteItem(editedItem);
            }
        }

        private void toolBox1_RenameFinished(ToolBoxItem sender, RenameFinishedEventArgs e)
        {
            (_toolTapCaptions)[toolBox1.IndexOfTab(editedTab)] = e.NewCaption;
            Settings.Default.Save();

        }

        private void toothChart1_ShowTreatmentsForAllClicked(object sender, EventArgs e)
        {
            kinOfListString = "لیست درمانهای تمامی دندانها";
            lblKinOfList.Text = kinOfListString;
            selectedToothForShowList = 0;
            FilldgvPatientTreatment(selectedToothForShowList);
            //SetPatientTreatmentList(aDataSet.Tables[1]);
            //this.toothChart1.ApplyExistTreatmentList();
        }

        private void toothChart1_ShowTreatmentsForThisClicked(object sender, Tooth e)
        {
            kinOfListString = "لیست درمانهای دندان : ";
            selectedToothForShowList = e.Code;
            if ((byte)e.Type == (int)ToothType.Primary)
                kinOfListString = kinOfListString + this.SelectedPRTNSList[e.Code - 1];
            else
                kinOfListString = kinOfListString + this.SelectedPETNSList[e.Code - 1].ToString();
            lblKinOfList.Text = kinOfListString;
            FilldgvPatientTreatment(selectedToothForShowList);
            //SetPatientTreatmentList(aDataSet.Tables[1]);
            //this.toothChart1.ApplyExistTreatmentList();
        }

        void aTreatmentServiceSelector_TreatmentSelected(object sender, EventArgs e)
        {
            this.CurrentPatientTreatment.Treatment = null;
            this.CurrentPatientTreatment.Treatment.TreatmentServiceID = aTreatmentServiceSelector.oTreatment.TreatmentServiceID;
            this.CurrentPatientTreatment.Treatment.TreatmentClassID = aTreatmentServiceSelector.oTreatment.TreatmentServiceID;
            this.CurrentPatientTreatment.Treatment.Code = aTreatmentServiceSelector.oTreatment.Code;
            this.CurrentPatientTreatment.Treatment.PersianName = aTreatmentServiceSelector.oTreatment.PersianName;
            this.CurrentPatientTreatment.Treatment.LatinName = aTreatmentServiceSelector.oTreatment.LatinName;
            this.CurrentPatientTreatment.Treatment.TreatmentArea = aTreatmentServiceSelector.oTreatment.TreatmentArea;
            this.CurrentPatientTreatment.Treatment.DrawType = aTreatmentServiceSelector.oTreatment.DrawType;
            this.CurrentPatientTreatment.Treatment.BrushType = aTreatmentServiceSelector.oTreatment.BrushType;
            this.CurrentPatientTreatment.Treatment.BrushColor = aTreatmentServiceSelector.oTreatment.BrushColor;
            this.CurrentPatientTreatment.Treatment.ShowRootInfoForm = aTreatmentServiceSelector.oTreatment.ShowRootInfoForm;
            this.CurrentPatientTreatment.Treatment.MarkToothMissing = aTreatmentServiceSelector.oTreatment.MarkToothMissing;
            if (_showPersianName)
                toolBox1[6].SelectedItem.Caption = "[" + "سرویسهای دیگر" + " [" + this.CurrentPatientTreatment.Treatment.PersianName;
            else
                toolBox1[6].SelectedItem.Caption = "Other Services" + " [" + this.CurrentPatientTreatment.Treatment.LatinName + "]";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printDocument1.PrinterSettings.PrintFileName = "ToothChart";
            printDocument1.PrinterSettings.PrintToFile = true;
            printDocument1.Print();
        }




    }

}
