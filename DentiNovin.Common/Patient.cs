using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace DentiNovin.Common
{
    public class Patient : BaseClass, ICloneable
    {

        public int PatientID { get; set; }

        public int DoctorID { get; set; }

        public int FileNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        private string _identityNumber;
        
        public string IdentityNumber
        {
            get
            {
                if (_identityNumber == null)
                    _identityNumber = string.Empty;
                return _identityNumber;
            }
            set
            {
                _identityNumber = value;
            }
        }

        public string NationalCode { get; set; }

        public int? Age { get; set; }

        public bool Sex { get; set; }

        public string Profession { get; set; }

        public string Telephone { get; set; }

        public string Portable { get; set; }

        private BindingList<PatientAssurance> _patientAssuranceList;
        public BindingList<PatientAssurance> PatientAssuranceList
        {
            get {
                if (_patientAssuranceList == null)
                    _patientAssuranceList = new BindingList<PatientAssurance>();
                return _patientAssuranceList; }
            set { _patientAssuranceList = value; }
        }

        public string Address { get; set; }

        public int Malady { get; set; }

        public Boolean Surgery { get; set; }

        public string SurgeryDesc { get; set; }

        public Boolean Drug { get; set; }

        public string DrugDesc { get; set; }

        public Boolean Pregnancy { get; set; }

        public string PregnancyDesc { get; set; }

        public Boolean Alert { get; set; }

        //public string AlertDesc { get; set; }

        public string DateOfRegister { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }

        //public List<Doctor> LDoctors { get; set; }
        public static void CopyProperties(Patient fPatient, Patient tPatient)
        {
            foreach (System.Reflection.PropertyInfo fprop in fPatient.GetType().GetProperties())
            {
                foreach (System.Reflection.PropertyInfo tprop in tPatient.GetType().GetProperties())
                {
                    if (tprop.Name == fprop.Name)
                        tprop.SetValue(tPatient, fprop.GetValue(fPatient, null), null);
                }
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
