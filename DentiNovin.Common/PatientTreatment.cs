using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace DentiNovin.Common
{
    public class PatientTreatment :BaseClass, IEquatable<PatientTreatment>
    {
        public int PatientID { get; set; }
        
        public Int64 PatientTreatmentID { get; set; }

        public int DoctorID { get; set; }
        
        private Treatment _treatment;
        public Treatment Treatment
        {
            get
            {
                if (_treatment == null)
                    _treatment = new Treatment();
                return _treatment;
            }
            set
            {
                _treatment = value;
            }
        }

        private Tooth _tooth;
        public Tooth Tooth
        {
            get
            {
                if (_tooth == null)
                    _tooth = new Tooth();
                return _tooth;
            }
            set
            {
                _tooth = value;
            }
        }

        public Appointment Appointment { get; set; }//dar soorate adame niaz hazf shavad equale ham update shavad.

        public Int64 AppointmentID { get; set; }

        private ArrayList _surface;
        public ArrayList Surface
        {
            get
            {
                if (_surface == null)
                    _surface = new ArrayList();
                return _surface;
            }
            set
            { _surface = value; }
        }


        public TreatmentStatus Status { get; set; }

        public string SurfaceCode { get; set; }

        public int SurfaceCount { get; set; }
        
        public bool IsRootTreatment { get; set; }

        private List<Roots> _rootsTreatment;
        public List<Roots> RootsTreatment
        {
            get
            {
                if (_rootsTreatment == null)
                    _rootsTreatment = new List<Roots>();
                return _rootsTreatment;
            }
            set { _rootsTreatment = value; }
        }
        
        public string Description { get; set; }

        public string RegisterDate { get; set; }

        private bool SurfaceContain(TreatmentSurface currentSurface)
        {
            return Surface.Contains(currentSurface);
        }

        public bool Equals(PatientTreatment other)
        {
            bool _visitTimeIsEquals = true;
            if (other.Status == TreatmentStatus.Completed)
                if (other.AppointmentID.Equals(this.AppointmentID))
                    _visitTimeIsEquals = true;
                else
                    _visitTimeIsEquals = false;
            //    return (other != null && other.Tooth.Number.Equals(this.Tooth.Number) && other.Tooth.Direction.Equals(this.Tooth.Direction) && other.Treatment.TreatmentServiceID.Equals(this.Treatment.TreatmentServiceID) && other.Status.Equals(this.Status));
            return (other != null && (other.Tooth.Equals(this.Tooth) || (other.Treatment.TreatmentArea == (int)TreatmentArea.Maxillary || other.Treatment.TreatmentArea == (int)TreatmentArea.Mandibular || (other.Treatment.TreatmentArea == (int)TreatmentArea.Quadrant && IsSameQuadrant(other.Tooth, this.Tooth)))) && other.Treatment.TreatmentServiceID.Equals(this.Treatment.TreatmentServiceID) && other.Status.Equals(this.Status) && _visitTimeIsEquals);

        }

        public override bool Equals(object obj)
        {
            PatientTreatment other = (PatientTreatment)obj;
            bool _visitTimeIsEquals = true;
            if (other.Status == TreatmentStatus.Completed)
                if (other.AppointmentID.Equals(this.AppointmentID))
                    _visitTimeIsEquals = true;
                else
                    _visitTimeIsEquals = false;
            //return (other != null && other.Tooth.Number.Equals(this.Tooth.Number) && other.Tooth.Direction.Equals(this.Tooth.Direction) && other.Tooth.Type.Equals(this.Tooth.Type) && other.Treatment.TreatmentServiceID.Equals(this.Treatment.TreatmentServiceID) && other.Status.Equals(this.Status));
            return (other != null && (other.Tooth.Equals(this.Tooth) || (other.Treatment.TreatmentArea == (int)TreatmentArea.Maxillary || other.Treatment.TreatmentArea == (int)TreatmentArea.Mandibular || (other.Treatment.TreatmentArea == (int)TreatmentArea.Quadrant && IsSameQuadrant(other.Tooth, this.Tooth)))) && other.Treatment.TreatmentServiceID.Equals(this.Treatment.TreatmentServiceID) && other.Status.Equals(this.Status) && _visitTimeIsEquals);

        }

        private bool IsSameQuadrant(Tooth otherTooth, Tooth objTooth)
        {
            return (GetToothDirectionInt((Byte)otherTooth.Code) == GetToothDirectionInt((Byte)objTooth.Code));
        }

        private Int16 GetToothDirectionInt(Byte toothCode)
        {
            Int16 ToothProp = 0;
            if (toothCode < 9)
                ToothProp = 2;
            else
                if (toothCode < 17)
                    ToothProp = 1;
                else
                    if (toothCode < 25)
                        ToothProp = 4;
                    else
                        ToothProp = 3;

            return ToothProp;
        }
    }
}
