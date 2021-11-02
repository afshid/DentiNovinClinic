using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;
using System.Collections;

namespace DentiNovin.Common
{
    public class ToothTreatment : IEquatable<ToothTreatment>
    {
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

        public TreatmentStatus Status { get; set; }

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

        public Appointment Appointment { get; set; }

        public Int64 AppointmentID { get; set; }

        public Int64 PatientTreatmentID { get; set; }

        public bool IsRootTreatment { get; set; }

        public Roots RootsTreatment { get; set; }

        private bool SurfaceContain(TreatmentSurface currentSurface)
        {
            return Surface.Contains(currentSurface);
        }

        public ToothTreatment()
        {
        }
        
        //public ToothTreatment(SerializationInfo info, StreamingContext context)
        //{
        //    if (info == null)
        //        throw new ArgumentNullException("info");

        //    Tooth = (Tooth)info.GetValue("Tooth", typeof(Tooth));
        //    Treatment = (Treatment)info.GetValue("Treatment", typeof(Treatment));
        //    Status = (TreatmentStatus)info.GetValue("Status", typeof(TreatmentStatus));
        //    Appointment = (Appointment)info.GetValue("Appointment", typeof(Appointment));
        //    Surface = (List<TreatmentSurface>)info.GetValue("Surface", typeof(List<TreatmentSurface>));
        //}
        
        public bool Equals(ToothTreatment other)
        {
            bool _visitTimeIsEquals=true;
            if (other.Status == TreatmentStatus.Completed)
                if (other.AppointmentID.Equals(this.AppointmentID))
                    _visitTimeIsEquals = true;
                else
                    _visitTimeIsEquals = false;
        //    return (other != null && other.Tooth.Number.Equals(this.Tooth.Number) && other.Tooth.Direction.Equals(this.Tooth.Direction) && other.Treatment.TreatmentServiceID.Equals(this.Treatment.TreatmentServiceID) && other.Status.Equals(this.Status));
            return (other != null && (other.Tooth.Equals(this.Tooth) || (other.Treatment.TreatmentArea == (int)TreatmentArea.Maxillary || other.Treatment.TreatmentArea == (int)TreatmentArea.Mandibular)) && other.Treatment.TreatmentServiceID.Equals(this.Treatment.TreatmentServiceID) && other.Status.Equals(this.Status) && _visitTimeIsEquals);
       
        }


        public override bool Equals(object obj)
        {
            ToothTreatment other = (ToothTreatment)obj;
            bool _visitTimeIsEquals = true;
            if (other.Status == TreatmentStatus.Completed)
                if (other.AppointmentID.Equals(this.AppointmentID))
                    _visitTimeIsEquals = true;
                else
                    _visitTimeIsEquals = false;
            //return (other != null && other.Tooth.Number.Equals(this.Tooth.Number) && other.Tooth.Direction.Equals(this.Tooth.Direction) && other.Tooth.Type.Equals(this.Tooth.Type) && other.Treatment.TreatmentServiceID.Equals(this.Treatment.TreatmentServiceID) && other.Status.Equals(this.Status));
            return (other != null && (other.Tooth.Equals(this.Tooth) || (other.Treatment.TreatmentArea == (int)TreatmentArea.Maxillary || other.Treatment.TreatmentArea == (int)TreatmentArea.Mandibular)) && other.Treatment.TreatmentServiceID.Equals(this.Treatment.TreatmentServiceID) && other.Status.Equals(this.Status) && _visitTimeIsEquals);

        }


        //#region ISerializable Members

        //public void GetObjectData(SerializationInfo info, StreamingContext context)
        //{

        //    info.AddValue("Tooth", Tooth);
        //    info.AddValue("Treatment", Treatment);
        //    info.AddValue("Surface", Surface);
        //    info.AddValue("Status", Status);
        //    info.AddValue("Appointment", Appointment);
        //}

        //#endregion
    }
}
