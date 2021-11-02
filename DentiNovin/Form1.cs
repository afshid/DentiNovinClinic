using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DentiClinic.Common;
using DentiClinic.BaseClasses;
using DentiClinic.BusinessLogic;
using DentiClinic.Common.DateConvert;

namespace DentiClinic
{
    public partial class Form1 : Form
    {
        private Group _oGroup;
        public Group oGroup
        {
            get
            {
                if (_oGroup == null)
                    _oGroup = new Group();
                return _oGroup;
            }
            set { _oGroup = value; }
        }

        private List<TimesWeek> _lTimesWeek;
        public List<TimesWeek> LTimesWeek
        {
            get { return _lTimesWeek; }
            set { _lTimesWeek = value; }
        }

        private ReservationBLL _fTimesFormBLL;
        public ReservationBLL FTimesFormBLL
        {
            get
            {
                if (_fTimesFormBLL == null)
                    _fTimesFormBLL = new ReservationBLL();
                return _fTimesFormBLL;
            }
            set
            {
                _fTimesFormBLL = value;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }
        //List<string> colorList = new List<string>();
        private void Form1_Load(object sender, EventArgs e)
        {
            //ToothTreatment book = new ToothTreatment();
            //book = SerializationTester.RoundTrip(book);
            GetGroup("1390/11/13");
            
        }


        private void GetGroup(string SelectedDate)
        {
            oGroup.DoctorID = 1;
            oGroup.GroupCode = 1;
            oGroup.GroupID = 1;


            FTimesFormBLL.oGroup = this.oGroup;
            FTimesFormBLL.GetGroup(SelectedDate);
            visitTable1.oGroup = this.oGroup;
            visitTable1.DSTimesWeek = GetTimesWeek(SelectedDate);
        }


        private DataSet GetTimesWeek(string SelectedDate)
        {
            DataSet aDataSet = new DataSet();
            return FTimesFormBLL.GetTimesWeek(SelectedDate);
        }

        private void visitTable1_RegisterClicked(object sender, VisitNode e)
        {

            TimesWeek aTimesWeek = new TimesWeek();
            aTimesWeek.PatientID = 10;
            aTimesWeek.GroupID = 1;
            aTimesWeek.DoctorID = 1;

            aTimesWeek.YearNumber = Convert.ToInt16(visitTable1.selectedPersianDate.Substring(0, 4));
            aTimesWeek.MonthNumber = Convert.ToInt16(visitTable1.selectedPersianDate.Substring(5, 2));
            aTimesWeek.DayNumber = e.DayNumber +1;

            aTimesWeek.VisitDate = visitTable1.selectedPersianDate.Substring(0, 4) + "/" + visitTable1.selectedPersianDate.Substring(5, 2) + "/" + Utilities.toDouble(aTimesWeek.DayNumber);


            TimeSpan aTimeSpan = new TimeSpan(e.TimeIndex * this.oGroup.PeriodLength / 60, e.TimeIndex * this.oGroup.PeriodLength % 60, 0);

            aTimesWeek.StartTime = this.oGroup.StartTime + aTimeSpan;
            aTimesWeek.Index = e.TimeIndex;

            FTimesFormBLL.TimesWeek = aTimesWeek;
            FTimesFormBLL.InsertNewTimesWeek();
            FTimesFormBLL.oGroup = this.oGroup;
            visitTable1.DSTimesWeek = GetTimesWeek(visitTable1.selectedPersianDate);
            // FilldgvPatientTimesWeek(OPatient.PatientID);
            //visitTable1.Refresh();
            //dataGridView1.DataSource = visitTable1.ds.Tables[0];
        }

    }
}
