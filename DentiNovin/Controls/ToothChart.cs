using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using DentiNovin.Common;
using System.Collections;
using DentiNovin.BusinessLogic;
using DentiNovin.BaseClasses;

namespace DentiNovin.Controls
{
    public partial class ToothChart : UserControl
    {
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
                if (_patientTreatmentList.Count == 0)
                    return;
                ApplyExistTreatmentList();
            }
        }

        private Dictionary<int, ToothView> ToothContainer = null;
        private Dictionary<int, ToothView> ToothTypeChangeList = null;
        private Dictionary<int, Tooth> ToothChartDic = null;

        private string _currentPatientName;
        public string CurrentPatientName
        {
            set
            {
                _currentPatientName = value;
                lblCurrentPatientName.Text =_currentPatientName;
            }
        }

        private string _currentTreatment;
        public string CurrentTreatment
        {
            get
            {
                return _currentTreatment;
            }
            set
            {
                _currentTreatment = value;
                lblCurrentTreatment.Text = _currentTreatment;
            }
        }
        public int[] PermanetToothNumberList { get; set; }
        public string[] PrimaryToothNumberList { get; set; }

        //private Treatment _currentTreatment;
        //public Treatment CurrentTreatment
        //{
        //    get { return _currentTreatment; }
        //    set
        //    {
        //        _currentTreatment = value;
        //        // GetMultipleTreatment();
        //    }
        //}

        public Appointment _currentAppointment;
        public Appointment CurrentAppointment
        {
            get { return _currentAppointment; }
            set { _currentAppointment = value; }
        }

        public PatientTreatment _currentPatientTreatment;
        public PatientTreatment CurrentPatientTreatment
        {
            get
            {
                return _currentPatientTreatment;
            }
            set { _currentPatientTreatment = value; }
        }

        public TreatmentStatus TreatmentStatusSelected { get; set; }

        public DataSet ThisPatientToothTypeList { get; set; }

        public bool AllowContinue { get; set; }

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

        private ActionMode _tActionMode;
        public ActionMode TActionMode
        {
            get { return _tActionMode; }
            set { _tActionMode = value; }
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

        private PatientToothType _oPatientToothType;
        public PatientToothType OPatientToothType
        {
            get
            {
                if (_oPatientToothType == null)
                    _oPatientToothType = new PatientToothType();
                return _oPatientToothType;
            }

            set
            {
                _oPatientToothType = value;
            }

        }

        public event EventHandler TreatmentCompleted;
        private void OnTreatmentCompleted()
        {
            if (TreatmentCompleted != null)
                TreatmentCompleted(this, null);
        }

        public event EventHandler ShowTreatmentsForAllClicked;
        public event ToothSelectedEventHandlet ShowTreatmentsForThisClicked;
        public event EventHandler ToothClicked;
        private void OnToothClicked()
        {
            if (ToothClicked != null)
                ToothClicked(this, null);
        }

        public event ToothTypeChangeEventHandler ToothTypeChange;
        private void OnToothTypeChange()
        {
            if (ToothTypeChange != null)
                ToothTypeChange(null, OPatientToothType);
        }

        //ok
        public ToothChart()
        {
            InitializeComponent();

            ToothContainer = new Dictionary<int, ToothView>()
                {
                    {1,toothView1},{2,toothView2},{3,toothView3},{4,toothView4},{5,toothView5}
                    ,{6,toothView6},{7,toothView7},{8,toothView8},{9,toothView9},{10,toothView10}
                    ,{11,toothView11},{12,toothView12},{13,toothView13},{14,toothView14},{15,toothView15}
                    ,{16,toothView16},{17,toothView17},{18,toothView18},{19,toothView19},{20,toothView20}
                    ,{21,toothView21},{22,toothView22},{23,toothView23},{24,toothView24},{25,toothView25}
                    ,{26,toothView26},{27,toothView27},{28,toothView28},{29,toothView29},{30,toothView30}
                    ,{31,toothView31},{32,toothView32}
                };
            ToothChartDic = new Dictionary<int, Tooth>()
                {
                    {1,new Tooth(1,2,ToothRootType.Molar)},{2,new Tooth(2,2,ToothRootType.Molar)},{3,new Tooth(3,2,ToothRootType.Molar)},{4,new Tooth(4,2,ToothRootType.Bicuspid)},{5,new Tooth(5,2,ToothRootType.Bicuspid)}
                    ,{6,new Tooth(6,2,ToothRootType.Anterior)},{7,new Tooth(7,2,ToothRootType.Anterior)},{8,new Tooth(8,2,ToothRootType.Anterior)},{9,new Tooth(9,1,ToothRootType.Anterior)},{10,new Tooth(10,1,ToothRootType.Anterior)}
                    ,{11,new Tooth(11,1,ToothRootType.Anterior)},{12,new Tooth(12,1,ToothRootType.Bicuspid)},{13,new Tooth(13,1,ToothRootType.Bicuspid)},{14,new Tooth(14,1,ToothRootType.Molar)},{15,new Tooth(15,1,ToothRootType.Molar)}
                    ,{16,new Tooth(16,1,ToothRootType.Molar)},{17,new Tooth(17,4,ToothRootType.Molar)},{18,new Tooth(18,4,ToothRootType.Molar)},{19,new Tooth(19,4,ToothRootType.Molar)},{20,new Tooth(20,4,ToothRootType.Bicuspid)}
                    ,{21,new Tooth(21,4,ToothRootType.Bicuspid)},{22,new Tooth(22,4,ToothRootType.Anterior)},{23,new Tooth(23,4,ToothRootType.Anterior)},{24,new Tooth(24,4,ToothRootType.Anterior)},{25,new Tooth(25,3,ToothRootType.Anterior)}
                    ,{26,new Tooth(26,3,ToothRootType.Anterior)},{27,new Tooth(27,3,ToothRootType.Anterior)},{28,new Tooth(28,3,ToothRootType.Bicuspid)},{29,new Tooth(29,3,ToothRootType.Bicuspid)},{30,new Tooth(30,3,ToothRootType.Molar)}
                    ,{31,new Tooth(31,3,ToothRootType.Molar)},{32,new Tooth(32,3,ToothRootType.Molar)}
                };
            //for (int i = 0; i < ToothContainer.Count; i++)
            //{
            //    ToothContainer[i + 1].CurrentTooth = ToothChartDic[i + 1];
            //    ToothContainer[i + 1].CurrentTooth.Number = this.PermanetToothNumberList[i];
            //    ToothContainer[i + 1].CurrentTooth.PrimaryNumber = this.PrimaryToothNumberList[i];
            //    ToothContainer[i + 1].DrawToothNumber();
            //}

        }

        private void ApplySurfaceView(PatientTreatment selectedPatientTreatment, int toothCode)
        {
            // int _toothCode = selectedPatientTreatment.Tooth.Code;
            try
            {
            ToothView _selectedTooth = ToothContainer[toothCode];
            if (_selectedTooth != null)
            {
                _selectedTooth.CompletedColor = CompletedColor;
                _selectedTooth.PlannedColor = PlannedColor;
                _selectedTooth.ConditionsColor = ConditionsColor;
                _selectedTooth.ApplySurfaceView(selectedPatientTreatment);
            }
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1090");
                MessageBox.Show(".بروز خطا در انتخاب دندان درمان شده", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void ToothChart_Load(object sender, EventArgs e)
        {
            //for (int i = 0; i < ToothContainer.Count; i++)
            //{
            //    ToothContainer[i + 1].CurrentTooth = ToothChartDic[i + 1];
            //    if (PermanetToothNumberList != null && PrimaryToothNumberList != null)
            //    {
            //        ToothContainer[i + 1].CurrentTooth.PermanentNumber = this.PermanetToothNumberList[i];
            //        ToothContainer[i + 1].CurrentTooth.PrimaryNumber = this.PrimaryToothNumberList[i];
            //        ToothContainer[i + 1].DrawToothNumber();
            //    }
            //}
            // ApplyExistTreatmentList();
        }

        public void DrawTeethNumber()
        {
            for (int i = 0; i < ToothContainer.Count; i++)
            {
                ToothContainer[i + 1].CurrentTooth = ToothChartDic[i + 1];
                if (PermanetToothNumberList != null && PrimaryToothNumberList != null)
                {
                    ToothContainer[i + 1].CurrentTooth.PermanentNumber = this.PermanetToothNumberList[i];
                    ToothContainer[i + 1].CurrentTooth.PrimaryNumber = this.PrimaryToothNumberList[i];
                    ToothContainer[i + 1].DrawToothNumber();
                }
            }
        }

        private void toothView_ToothClicked(object sender, EventArgs e)
        {
            ((ToothView)sender).AllowContinue = false;
            //DeselectToothChart();
            OnToothClicked();

            if (!this.AllowContinue)
                return;

            ((ToothView)sender).AllowContinue = true;
            ((ToothView)sender).CompletedColor = CompletedColor;
            ((ToothView)sender).PlannedColor = PlannedColor;
            ((ToothView)sender).ConditionsColor = ConditionsColor;

            ((ToothView)sender).PatientTreatmentList = this.PatientTreatmentList;
            this.TActionMode = ActionMode.None;
            ((ToothView)sender).TActionMode = this.TActionMode;
            this.CurrentPatientTreatment.PatientTreatmentID = 0;
            this.CurrentPatientTreatment.Tooth = ((ToothView)sender).CurrentTooth;
            //this.CurrentPatientTreatment.Treatment = this.CurrentTreatment;
            //this.CurrentPatientTreatment.Appointment = this.CurrentAppointment;
            if (this.CurrentPatientTreatment.Treatment.TreatmentClassID == (int)TreatmentClass.Conditions)
                this.CurrentPatientTreatment.Status = TreatmentStatus.Condition;
            else
                this.CurrentPatientTreatment.Status = TreatmentStatusSelected;

            this.CurrentPatientTreatment.Surface.Clear();
            ((ToothView)sender).CurrentPatientTreatment = this.CurrentPatientTreatment;
            Int16 startToothCode = 1;
            bool Contains = false;
            int treatmentCodeTemp = 0;
            if (this.CurrentPatientTreatment.Treatment.TreatmentArea == (int)TreatmentArea.Maxillary || this.CurrentPatientTreatment.Treatment.TreatmentArea == (int)TreatmentArea.Mandibular)
            {
                if (this.CurrentPatientTreatment.Treatment.TreatmentArea == (int)TreatmentArea.Mandibular)
                    startToothCode = 17;

                // treatmentCodeTemp = this.CurrentPatientTreatment.Tooth.Code;
                // this.CurrentPatientTreatment.Tooth.Code = 0;

                foreach (PatientTreatment tt in PatientTreatmentList)
                {
                    if (tt.Equals(this.CurrentPatientTreatment))
                    {
                        this.CurrentPatientTreatment.PatientTreatmentID = tt.PatientTreatmentID;
                        PatientTreatmentList.Remove(this.CurrentPatientTreatment);

                        ((ToothView)sender).TActionMode = ActionMode.Remove;
                        // this.CurrentPatientTreatment.Tooth.Code = treatmentCodeTemp;
                        this.ApplyExistTreatmentList();
                        //for (int i = 0; i < 16; i++)
                        //{
                        //    ToothContainer[i + startToothCode].PatientTreatmentList = PatientTreatmentList;
                        //    ToothContainer[i + startToothCode].ApplyExistTreatmentList();
                        //}
                        Contains = true;
                        break;
                    }
                }
                if (!Contains)
                {
                    PatientTreatmentList.Add(this.CurrentPatientTreatment);
                    ((ToothView)sender).TActionMode = ActionMode.Add;
                    //this.CurrentPatientTreatment.Tooth.Code = treatmentCodeTemp;
                    this.ApplyExistTreatmentList();
                }
            }
            if (this.CurrentPatientTreatment.Treatment.TreatmentArea == (int)TreatmentArea.Quadrant)
            {
                Contains = false;
                startToothCode = 1;
                switch (UtilMethods.GetToothDirectionInt((Byte)this.CurrentPatientTreatment.Tooth.Code))
                {
                    case 1:
                        startToothCode = 9;
                        break;
                    case 2:
                        startToothCode = 1;
                        break;
                    case 3:
                        startToothCode = 25;
                        break;
                    case 4:
                        startToothCode = 17;
                        break;
                }
                foreach (PatientTreatment tt in PatientTreatmentList)
                {
                    if (tt.Equals(this.CurrentPatientTreatment))
                    {
                        this.CurrentPatientTreatment.PatientTreatmentID = tt.PatientTreatmentID;
                        PatientTreatmentList.Remove(this.CurrentPatientTreatment);

                        ((ToothView)sender).TActionMode = ActionMode.Remove;
                        // this.CurrentPatientTreatment.Tooth.Code = treatmentCodeTemp;
                        for (int i = 0; i < 8; i++)
                        {
                            ToothContainer[i + startToothCode].PatientTreatmentList = PatientTreatmentList;
                            ToothContainer[i + startToothCode].ApplyExistTreatmentList();
                        }
                        Contains = true;
                        break;
                    }
                }
                if (!Contains)
                {
                    PatientTreatmentList.Add(this.CurrentPatientTreatment);
                    ((ToothView)sender).TActionMode = ActionMode.Add;
                    //this.CurrentPatientTreatment.Tooth.Code = treatmentCodeTemp;
                    this.ApplyExistTreatmentList();
                }
            }
            if (this.CurrentPatientTreatment.Treatment.TreatmentArea == (int)TreatmentArea.Mouth)
            {
                ((ToothView)sender).TActionMode = ActionMode.Add;
            }

        }

        private void toothView_ToothDarwingCompleted(object sender, EventArgs e)
        {
            this.TActionMode = ((ToothView)sender).TActionMode;
            OnTreatmentCompleted();
        }

        public void ApplyExistTreatmentList()
        {
            ResetToothChart();

            foreach (PatientTreatment currentTT in PatientTreatmentList)
            {
                if (currentTT.Treatment.DrawType != (int)TreatmentDrawType.None)
                {
                    if (currentTT.Status == TreatmentStatus.Declined)
                        continue;
                    if (currentTT.Treatment.TreatmentArea == (int)TreatmentArea.Maxillary)// || currentTT.Treatment.TreatmentArea == (int)TreatmentArea.Mandibular)
                    {
                        for (int i = 0; i < 16; i++)
                        {
                            ApplySurfaceView(currentTT, i + 1);
                        }
                    }
                    else
                    {
                        if (currentTT.Treatment.TreatmentArea == (int)TreatmentArea.Mandibular)
                        {
                            for (int i = 0; i < 16; i++)
                            {
                                ApplySurfaceView(currentTT, i + 17);
                            }
                        }
                        else
                            if (currentTT.Treatment.TreatmentArea == (int)TreatmentArea.Quadrant)
                            {
                                Int16 startToothCode = 1;
                                switch (UtilMethods.GetToothDirectionInt((Byte)currentTT.Tooth.Code))
                                {
                                    case 1:
                                        startToothCode = 9;
                                        break;
                                    case 2:
                                        startToothCode = 1;
                                        break;
                                    case 3:
                                        startToothCode = 25;
                                        break;
                                    case 4:
                                        startToothCode = 17;
                                        break;
                                }
                                for (int i = 0; i < 8; i++)
                                {
                                    ApplySurfaceView(currentTT, i + startToothCode);
                                }
                            }
                            else
                                ApplySurfaceView(currentTT, currentTT.Tooth.Code);
                    }

                }
            }
        }

        //public void applyTreatmentDeclined(int toothCode)
        //{
        //    ToothView _selectedTooth = ToothContainer[toothCode];
        //    _selectedTooth.ApplyExistTreatmentList();
        //}

        private void ResetToothChart()
        {
            foreach (ToothView tv in ToothContainer.Values)
            {
                tv.ResetSurfacesView();
            }
        }

        private void toothView_ToothTypeChanging(object sender, ToothTypeChangeMode e)
        {
            OPatientToothType.ToothCode = ((ToothView)sender).CurrentTooth.Code;
            ((ToothView)sender).PatientTreatmentList = this.PatientTreatmentList;
            switch ((ToothTypeChangeMode)e)
            {
                case ToothTypeChangeMode.None:
                    break;
                case ToothTypeChangeMode.Single2Permanent:
                    OPatientToothType.ToothType = ToothType.Permanent;
                    OnToothTypeChange();
                    ((ToothView)sender).ChangeToothType(ToothType.Permanent);
                    break;
                case ToothTypeChangeMode.Single2Primary:
                    OPatientToothType.ToothType = ToothType.Primary;
                    OnToothTypeChange();
                    ((ToothView)sender).ChangeToothType(ToothType.Primary);
                    break;
                case ToothTypeChangeMode.All2Permanent:
                    OPatientToothType.ToothCode = 0;
                    OPatientToothType.ToothType = ToothType.Permanent;
                    OnToothTypeChange();
                    foreach (ToothView tv in ToothContainer.Values)
                    {
                        tv.PatientTreatmentList = this.PatientTreatmentList;
                        tv.ChangeToothType(ToothType.Permanent);
                    }
                    break;
                case ToothTypeChangeMode.All2Primary:
                    OPatientToothType.ToothCode = 0;
                    OPatientToothType.ToothType = ToothType.Primary;
                    OnToothTypeChange();
                    foreach (ToothView tv in ToothContainer.Values)
                    {
                        tv.PatientTreatmentList = this.PatientTreatmentList;
                        tv.ChangeToothType(ToothType.Primary);
                    }
                    break;
                default:
                    break;
            }
        }

        public void ApplyExistToothTypeList()
        {
            if (ThisPatientToothTypeList.Tables[0] == null)
                return;
            ToothTypeChangeList = new Dictionary<int, ToothView>();
            int _toothCode;
            ToothView _selectedTooth;
            for (int i = 0; i < ThisPatientToothTypeList.Tables[0].Rows.Count; i++)
            {
                _toothCode = (byte)ThisPatientToothTypeList.Tables[0].Rows[i]["ToothCode"];
                if (_toothCode != 0)
                {
                    _selectedTooth = ToothContainer[_toothCode];
                    if (_selectedTooth != null)
                    {
                        _selectedTooth.PatientTreatmentList = this.PatientTreatmentList;
                        //_selectedTooth.ChangeToothType((ToothType)((byte)ThisPatientToothTypeList.Tables[0].Rows[i]["ToothType"]));
                        _selectedTooth.CurrentTooth.Type = (ToothType)((byte)ThisPatientToothTypeList.Tables[0].Rows[i]["ToothType"]);
                        _selectedTooth.ResetSurfacesView();
                        ToothTypeChangeList.Add(_selectedTooth.CurrentTooth.Code, _selectedTooth);
                    }
                }
                else
                {
                    if ((ToothType)((byte)ThisPatientToothTypeList.Tables[0].Rows[i]["ToothType"]) == ToothType.Permanent)
                        continue;
                    foreach (ToothView tv in ToothContainer.Values)
                    {
                        if (ToothTypeChangeList.ContainsKey(tv.CurrentTooth.Code))
                            continue;
                        tv.PatientTreatmentList = this.PatientTreatmentList;
                        //tv.ChangeToothType((ToothType)((byte)ThisPatientToothTypeList.Tables[0].Rows[i]["ToothType"]));
                        tv.CurrentTooth.Type = (ToothType)((byte)ThisPatientToothTypeList.Tables[0].Rows[i]["ToothType"]);
                        tv.ResetSurfacesView();
                    }
                }
            }

        }

        public Bitmap PrintToGraphics(Graphics graphics, Rectangle bounds)
        {
            Color colorTemp = this.BackColor;
            this.BackColor = Color.White;
            string currentTreatmentTemp = string.Empty;
            currentTreatmentTemp = this.CurrentTreatment;
            this.CurrentTreatment = string.Empty;
            Bitmap bitmap = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
            Rectangle target = new Rectangle(0, 0, bounds.Width, bounds.Height);
            double xScale = (double)bitmap.Width / bounds.Width;
            double yScale = (double)bitmap.Height / bounds.Height;
            if (xScale < yScale)
                target.Width = (int)(xScale * target.Width / yScale);
            else
                target.Height = (int)(yScale * target.Height / xScale);
            graphics.PageUnit = GraphicsUnit.Display;
            graphics.DrawImage(bitmap, target);
            this.BackColor = colorTemp;
            this.CurrentTreatment = currentTreatmentTemp;
            return bitmap;
        }

        public void SelectTooth(int toothCode)
        {
            DeselectToothChart();
            ToothView _selectedTooth = ToothContainer[toothCode];
            if (_selectedTooth != null)
            {
                _selectedTooth.SelectTooth();
            }
        }

        public void DeselectToothChart()
        {
            foreach (ToothView tv in ToothContainer.Values)
            {
                tv.DeselectTooth();
            }
        }

        private void toothView_ShowTreatmentsForAllClicked(object sender, EventArgs e)
        {
            OnShowTreatmentsForAllClicked();
        }

        private void toothView_ShowTreatmentsForThisClicked(object sender, EventArgs e)
        {
            OnShowTreatmentsForThisClicked((ToothView)sender);
        }

        private void OnShowTreatmentsForAllClicked()
        {
            if (ShowTreatmentsForAllClicked != null)
                ShowTreatmentsForAllClicked(this, null);
        }

        private void OnShowTreatmentsForThisClicked(ToothView selTooth)
        {
            if (ShowTreatmentsForThisClicked != null)
                ShowTreatmentsForThisClicked(this, selTooth.CurrentTooth);
        }
    }
}
            
