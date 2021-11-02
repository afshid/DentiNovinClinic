using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DentiNovin.Common.DateConvert;
using DentiNovin.BaseClasses;
using DentiNovin.Common;

namespace DentiNovin.Controls
{
    public partial class AppointmentControl : UserControl
    {
        ContextMenuStrip aContextMenuStrip = new ContextMenuStrip();
        private const int DEF_WEEK_DAY_HEIGHT = 20;

        private PersianCalendar pc;
        private AppointmentShowMode aSM = 0;
        public string selectedPersianDate;
        private int iYear;
        private int iMonth;
        private int iDay;
        private int iCurrentYear;
        private int iCurrentMonth;
        private int iCurrentDay;
        private int numDays;
        private int numDayOfMonth = 0;
        private int numDayOfWeek = 0;
        private int totalAppointmentCountThisMonth = 0;
        private int totalAppointmentCountThisWeek = 0;
        private int totalAppointmentCountToday = 0;
        private bool selectedDateIsCurrentDate = true;
        private int nowCellIndex = -1;
        // private DataRow dr;

        private bool cellFormating = true;
        private VisitNode selectedNodes;
        //DataTable dt = new DataTable();
        //public DataSet ds = new DataSet();

        private string[] _weekDayName;
        private string[] _weekDayDate;

        private Int32 _daysNumber;
        [Browsable(false)]
        public Int32 DaysNumber
        {
            get { return _daysNumber; }
            set { _daysNumber = value; }
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

        private Boolean _registerable;
        [Browsable(false)]
        public Boolean Registerable
        {
            get { return _registerable; }
            set { _registerable = value; }
        }

        public Int32 CurrentPatientID { get; set; }

        public bool IsOutOfRange { get; set; }
        private bool _patientEnterClicked = false;
        public AppointmentStatus AptStatus { get; set; }

        public event VisitNodeEventHandler RegisterClicked;
        public event VisitNodeEventHandler UnRegisterClicked;
        public event VisitNodeEventHandler PatientEnterClicked;
        public event VisitNodeEventHandler ShowDossierClicked;
        public event VisitNodeEventHandler ShowBillClicked;
        public event EventHandler DayChanged;
        public event EventHandler MonthChanged;
        public event EventHandler YearChanged;
        public event EventHandler SelectedDateTimeChanged;
        public event EventHandler RefreshRequested;
        int firstDay = 0;

        public AppointmentControl()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            dateBarControl1.SelectedDateTime = DateTime.Now;
            pc = new PersianCalendar();
            iCurrentYear = pc.GetYear(DateTime.Now);
            iCurrentMonth = pc.GetMonth(DateTime.Now);
            selectedDateIsCurrentDate = true;
        }

        public void InitialDataGridView()
        {
            //aSM = AppointmentShowMode.Weekly;
            DataGridViewColumn dgvc;
            dgv.DataSource = null;
            numDays = 1;
            if (aSM== AppointmentShowMode.Monthly)
                    numDays = pc.GetDaysInMonth(iYear, iMonth);
            else
               if (aSM== AppointmentShowMode.Weekly)
                    numDays = 7;
            numDayOfMonth = pc.GetDayOfMonth(DateTime.Now);
            numDayOfWeek =GetDayOfWeek(DateTime.Now);//persian Index
            DateTime dtStartOfMonth = new DateTime(iYear, iMonth, 1, 0, 0, 0, pc);
            firstDay = GetFirstDayOfMonth(dtStartOfMonth);//Persian Index
            //int k;
            _weekDayName = new string[numDays];
            _weekDayDate = new string[numDays];
            if (aSM == AppointmentShowMode.Monthly)
            {
                for (int i = 0; i < numDays; i++)
                {
                    string strDayWeek = GetWeekDayName((i + firstDay) % 7);

                    string strDayDate = Utilities.toDouble(iMonth) + "/" + Utilities.toDouble(i + 1);
                    _weekDayName[i] = strDayWeek;
                    _weekDayDate[i] = strDayDate;
                }
            }
            else
                if (aSM == AppointmentShowMode.Weekly)
                {
                    for (int i = 0; i < numDays; i++)
                    {
                        string strDayWeek = GetWeekDayName(i);

                        string strDayDate = PersianDateConverter.ToPersianDate(DateTime.Now.AddDays(i - numDayOfWeek)).ToString("md", null);
                        _weekDayName[i] = strDayWeek;
                        _weekDayDate[i] = strDayDate;
                    }
                }

            if ((oGroup != null) && (oGroup.GroupID != 0))
            {
                int COLUMNS_COUNT = 0;
                TimeSpan diff = (oGroup.StartTime - oGroup.EndTime).Duration();

                if (oGroup.EndTime < oGroup.StartTime)
                    COLUMNS_COUNT = System.Convert.ToInt32((new TimeSpan(24,0,0).TotalMinutes-(oGroup.StartTime - oGroup.EndTime).TotalMinutes) / oGroup.PeriodLength) + 1;
                else
                    COLUMNS_COUNT = System.Convert.ToInt32((oGroup.EndTime - oGroup.StartTime).TotalMinutes / oGroup.PeriodLength) + 1;

                dgv.Columns.Clear();
                dgvc = new DataGridViewComplexColumn();
                //dgvc = new DataGridViewTextBoxColumn();
                dgvc.ContextMenuStrip = aContextMenuStrip;
                dgvc.HeaderText = "ایام هفته";
                dgvc.Name = "Column0";
                dgvc.DataPropertyName = "Column0";
                dgvc.ReadOnly = true;
                dgvc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
                dgvc.Width = 25;
                dgv.Columns.Add(dgvc);
                TimeSpan nextStime;
                TimeSpan tsNodeStime;
                TimeSpan nowTime = DateTime.Now.TimeOfDay;
                nowCellIndex = -1;
                for (int i = 0; i < COLUMNS_COUNT - 1; i++)
                {
                    
                    tsNodeStime = oGroup.StartTime.Add(new TimeSpan(0, oGroup.PeriodLength * i, 0));
                    nextStime = oGroup.StartTime.Add(new TimeSpan(0, oGroup.PeriodLength * (i+1), 0));
                    if (tsNodeStime <= nowTime && nowTime < nextStime)
                        nowCellIndex = i;

                    string strNodeStime = tsNodeStime.ToString();
                    if (tsNodeStime.Days > 0)
                        strNodeStime = tsNodeStime.Subtract(TimeSpan.FromDays(1)).ToString();
                    //dgvc = new DataGridViewTextBoxColumn();
                    dgvc = new DataGridViewComplexColumn();
                    dgvc.ContextMenuStrip = aContextMenuStrip;
                    dgvc.HeaderText = strNodeStime;
                    dgvc.Name = "Column" + i + 1;
                    dgvc.DataPropertyName = "Column" + i + 1;
                    dgvc.ReadOnly = true;
                    dgvc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
                    dgv.Columns.Add(dgvc);
                }

                DvgDataBinding();
                AddContexMenu();
            }

        }

        public void DvgDataBinding()
        {
            dgv.Rows.Clear();
            for (int i = 0; i < numDays; i++)
            {
                dgv.Rows.Add(new DataGridViewRow());
                //dgv.Rows[i].Height = dgv.Height / numDays;
            }
            int DayIndex;
            int TimeIndex;
            for (int i = 0; i < DSAppointment.Tables[0].Rows.Count; i++)
            {
                DayIndex = System.Convert.ToInt16(DSAppointment.Tables[0].Rows[i][7]) - 1;
                TimeIndex = System.Convert.ToInt16(DSAppointment.Tables[0].Rows[i][9]);
                VisitNode oVisitNode = new VisitNode((int)DSAppointment.Tables[0].Rows[i][1], DSAppointment.Tables[0].Rows[i][12].ToString() + " - " + DSAppointment.Tables[0].Rows[i][13].ToString(), (Int64)DSAppointment.Tables[0].Rows[i][0], System.Convert.ToInt16(DSAppointment.Tables[0].Rows[i][7]), TimeIndex, DSAppointment.Tables[0].Rows[i][4].ToString(), new DateTime().Add(TimeSpan.FromTicks((Int64)DSAppointment.Tables[0].Rows[i][8])).TimeOfDay, System.Convert.ToInt32(DSAppointment.Tables[0].Rows[i][10]));
                if (dgv.Rows[DayIndex].Cells[TimeIndex + 1].Value != null)
                {
                    ((DataGridViewComplexCell)dgv.Rows[DayIndex].Cells[TimeIndex + 1]).ShowPlusSymbol = true;
                    ((DataGridViewComplexCell)dgv.Rows[DayIndex].Cells[TimeIndex + 1]).Count++;
                    continue;
                }
                dgv.Rows[DayIndex].Cells[TimeIndex + 1].ValueType = typeof(VisitNode);
                dgv.Rows[DayIndex].Cells[TimeIndex + 1].Value = oVisitNode;
                dgv.Rows[DayIndex].Cells[TimeIndex + 1].Style.BackColor = Color.Blue;
                dgv.Rows[DayIndex].Cells[TimeIndex + 1].Style.ForeColor = Color.White;
                if (System.Convert.ToInt32(DSAppointment.Tables[0].Rows[i][10]) == (int)AppointmentStatus.Entered)
                    ((DataGridViewComplexCell)dgv.Rows[DayIndex].Cells[TimeIndex + 1]).ShowEnteredSymbol = true;
            }
            if (aSM == AppointmentShowMode.Monthly && selectedDateIsCurrentDate)
            {
                ((DataGridViewComplexCell)dgv.Rows[numDayOfMonth - 1].Cells[0]).ShowSelectSymbol = true;
                ((DataGridViewComplexCell)dgv.Rows[numDayOfMonth - 1].Cells[0]).ShowRectangle = true;
                if(nowCellIndex!=-1)
                    ((DataGridViewComplexCell)dgv.Rows[numDayOfMonth - 1].Cells[nowCellIndex + 1]).ShowRectangle = true;
            }
            dgv.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgv.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);

        }

        private int GetFirstDayOfMonth(DateTime date)
        {
            PersianDate pd = date;
            return (int)pd.DayOfWeek;
        }

        private int GetDayOfWeek(DateTime date)
        {
            PersianDate pd = date;
            return (int)pd.DayOfWeek;
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
            toolStripItem1.Click += new EventHandler(toolStripItem1_Click);

            ToolStripMenuItem toolStripItem2 = new ToolStripMenuItem();
            toolStripItem2.Text = "حذف نوبت";

            ToolStripMenuItem toolStripItem3 = new ToolStripMenuItem();
            toolStripItem3.Text = "مشاهده درمان";
            toolStripItem3.Click += new EventHandler(toolStripItem3_Click);

            ToolStripMenuItem toolStripItem4 = new ToolStripMenuItem();
            toolStripItem4.Text = "مشاهده صورتحساب";
            toolStripItem4.Click += new EventHandler(toolStripItem4_Click);

            ToolStripMenuItem toolStripItem5 = new ToolStripMenuItem();
            toolStripItem5.Text = "عدم حضور بیمار";
            toolStripItem5.Click += new EventHandler(toolStripItem5_Click);

            ToolStripMenuItem toolStripItem6= new ToolStripMenuItem();
            toolStripItem6.Text = "درخواست بیمار";
            toolStripItem6.Click += new EventHandler(toolStripItem6_Click);

            ToolStripMenuItem toolStripItem7 = new ToolStripMenuItem();
            toolStripItem7.Text = "توسط کاربر";
            toolStripItem7.Click += new EventHandler(toolStripItem7_Click);

            ToolStripMenuItem toolStripItem8 = new ToolStripMenuItem();
            toolStripItem8.Text = "ورود بیمار";
            toolStripItem8.Click += new EventHandler(toolStripItem8_Click);
            aContextMenuStrip.Items.Clear();
            aContextMenuStrip.Items.Add(toolStripItem1);
            aContextMenuStrip.Items.Add(toolStripItem2);
            (aContextMenuStrip.Items[1] as ToolStripMenuItem).DropDownItems.Add(toolStripItem5);
            (aContextMenuStrip.Items[1] as ToolStripMenuItem).DropDownItems.Add(toolStripItem6);
            (aContextMenuStrip.Items[1] as ToolStripMenuItem).DropDownItems.Add(toolStripItem7);
            aContextMenuStrip.Items.Add(toolStripItem3);
            aContextMenuStrip.Items.Add(toolStripItem4);
            aContextMenuStrip.Items.Add(toolStripItem8);
            this.dgv.ContextMenuStrip = aContextMenuStrip;
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex != 0)
                return;
            dgv.Rows[e.RowIndex].Cells[0].Value = _weekDayName[e.RowIndex] + " - " + _weekDayDate[e.RowIndex];
            if (!DaysNumber.ToString().Contains((((e.RowIndex + firstDay) % 7) + 1).ToString()))
                ((DataGridViewComplexCell)dgv.Rows[e.RowIndex].Cells[0]).Icon = Properties.Resources.important_y;
            if (_weekDayName[e.RowIndex] == "جمعه")
                dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
            else
                dgv.Rows[e.RowIndex].Cells[0].Style.BackColor = Color.LightGray;
            //if (aSM == AppointmentShowMode.Monthly && selectedDateIsCurrentDate && e.RowIndex + 1 == numDayOfMonth)
            //   // dgv.Rows[e.RowIndex].Cells[0].Style.BackColor = Color.Green;
            //    ((DataGridViewComplexCell)dgv.Rows[e.RowIndex].Cells[0]).ShowSelectSymbol = true;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1 || e.ColumnIndex == 0)
                return;
            if (dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
            {
                IsOutOfRange = false;
                selectedNodes = new VisitNode(0, "", 0, e.RowIndex, e.ColumnIndex - 1, this.selectedPersianDate.Substring(0, 4) + "/" + this.selectedPersianDate.Substring(5, 2) + "/" + Utilities.toDouble(e.RowIndex + 1), new TimeSpan(),0);
                OnRegisterClicked(selectedNodes);
            }
            else
            {
                OnShowDossierClicked((VisitNode)dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            }
        }


        protected internal virtual void OnRegisterClicked(VisitNode e)
        {

            if (!this.Registerable)
                return;
            if (RegisterClicked != null)
            {
                if (IsOutOfRange)
                   e.DayNumber--;// = e.TimeIndex + 1;

                RegisterClicked(this, e);
                
                if (!DaysNumber.ToString().Contains((((e.DayNumber + firstDay) % 7) + 1).ToString()))
                    MessageBox.Show("پزشک معالج انتخاب شده در این روز حضور ندارد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            this.DvgDataBinding();
        }
        
        protected internal virtual void OnUnRegisterClicked(VisitNode e)
        {
            if (UnRegisterClicked != null)
                UnRegisterClicked(this, e);
        }

        protected internal virtual void OnPatientEnterClicked(VisitNode e)
        {
            if (PatientEnterClicked != null)
                PatientEnterClicked(this, e);
        }
        
        protected internal virtual void OnShowDossierClicked(VisitNode e)
        {
            if (ShowDossierClicked != null)
                ShowDossierClicked(this, e);
        }

        protected internal virtual void OnShowBillClicked(VisitNode e)
        {
            if (ShowBillClicked != null)
                ShowBillClicked(this, e);
        }

        private void dateBarControl1_SelectedDateTimeChanged(object sender, EventArgs e)
        {
            this.selectedPersianDate = dateBarControl1.selectedPersianDate;
            this.iYear = dateBarControl1.IYear;
            this.iMonth = dateBarControl1.IMonth;
            this.iDay = dateBarControl1.IDay;
            if (this.iYear == this.iCurrentYear && this.iMonth == this.iCurrentMonth)
                selectedDateIsCurrentDate=true;
            else
                selectedDateIsCurrentDate=false;
            OnSelectedDateTimeChanged(e);
        }

        private void dateBarControl1_MonthChanged(object sender, EventArgs e)
        {
            OnMonthChanged(e);
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

        protected internal virtual void OnRefreshRequested(EventArgs e)
        {
            if (RefreshRequested != null)
                RefreshRequested(this, e);
        }

        private void dateBarControl1_DayChanged(object sender, EventArgs e)
        {
            OnDayChanged(e);
        }

        private void toolStripItem1_Click(object sender, EventArgs args)
        {
                OnRegisterClicked(selectedNodes);
        }

        private void toolStripItem3_Click(object sender, EventArgs args)
        {
            OnShowDossierClicked(selectedNodes);
        }

        private void toolStripItem4_Click(object sender, EventArgs args)
        {
            OnShowBillClicked(selectedNodes);
        }

        void toolStripItem5_Click(object sender, EventArgs e)
        {
            AptStatus = AppointmentStatus.DeletedPatientAbsence;
            OnUnRegisterClicked(selectedNodes);
        }

        void toolStripItem6_Click(object sender, EventArgs e)
        {
            AptStatus = AppointmentStatus.DeletedPatientRequest;
            OnUnRegisterClicked(selectedNodes);
        }

        void toolStripItem7_Click(object sender, EventArgs e)
        {
            AptStatus = AppointmentStatus.DeletedByUser;
            OnUnRegisterClicked(selectedNodes);
        }

        void toolStripItem8_Click(object sender, EventArgs e)
        {
           if(selectedNodes.Status==(int)AppointmentStatus.Entered)
               AptStatus = AppointmentStatus.Normal;
           else
               AptStatus = AppointmentStatus.Entered;

            OnPatientEnterClicked(selectedNodes);
        }

        private void dgv_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1 || e.ColumnIndex == 0)
            {
                aContextMenuStrip.Close();
                return;
            }
            dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
            _patientEnterClicked = false;
            aContextMenuStrip.Items[0].Text = "ثبت نوبت";
            IsOutOfRange = false;
            if (dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
            {
                selectedNodes = new VisitNode(0, "", 0, e.RowIndex, e.ColumnIndex - 1, this.selectedPersianDate.Substring(0, 4) + "/" + this.selectedPersianDate.Substring(5, 2) + "/" + Utilities.toDouble(e.RowIndex + 1), new TimeSpan(),0);
                aContextMenuStrip.Items[0].Enabled = true;
                aContextMenuStrip.Items[1].Enabled = false;
                aContextMenuStrip.Items[2].Visible = false;
                aContextMenuStrip.Items[3].Visible = false;
                aContextMenuStrip.Items[4].Visible = false;
            }
            else
            {
                selectedNodes = (VisitNode)dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (CurrentPatientID != 0 && selectedNodes.PatientID != CurrentPatientID)
                {
                    aContextMenuStrip.Items[0].Enabled = true;
                    aContextMenuStrip.Items[0].Text = "ثبت خارج از نوبت";
                    IsOutOfRange = true;
                }
                else
                    aContextMenuStrip.Items[0].Enabled = false;

                aContextMenuStrip.Items[1].Enabled = true;
                aContextMenuStrip.Items[2].Visible = true;
                aContextMenuStrip.Items[3].Visible = true;
                aContextMenuStrip.Items[4].Visible = true;
            }
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
            //dgv.Columns[e.ColumnIndex].DefaultCellStyle.BackColor = Color.Green;
        }

        private void dgv_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            ////dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            //dgv.Columns[e.ColumnIndex].DefaultCellStyle.BackColor = Color.White;

        }

        private void dgv_MouseUp(object sender, MouseEventArgs e)
        {
          //  aContextMenuStrip.Close();
        }

        private void btnMonthlyView_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            OnRefreshRequested(e);
        }
    }
}
