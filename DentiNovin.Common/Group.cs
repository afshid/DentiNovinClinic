using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DentiNovin.Common
{
    public class Group : BaseClass, IEquatable<Group>
    {

        public Group()
        {
            RowEffected = false;
        }
        
        private int _groupID;
        public int GroupID
        {
            get { return _groupID; }
            set { _groupID = value; }
        }

        private int _groupCode;
        public int GroupCode
        {
            get { return _groupCode; }
            set { _groupCode = value; }
        }

        private Int32 _doctorID;
        public Int32 DoctorID
        {
            get { return _doctorID; }
            set { _doctorID = value; }
        }

        private string _name;
        public string Name
                {
                    get { return _name; }
                    set { _name = value; }
        }

        private TimeSpan _startTime;
        public TimeSpan StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        private TimeSpan _endTime;
        public TimeSpan EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        private string _startActiveDate;
        public string StartActiveDate
        {
            get { return _startActiveDate; }
            set { _startActiveDate = value; }
        }

        //private string _endActiveDate;
        //public string EndActiveDate
        //{
        //    get { return _endActiveDate; }
        //    set { _endActiveDate = value; }
        //}

        private int _periodLength;
        public int PeriodLength
                {
                    get { return _periodLength; }
                    set { _periodLength = value; }
        }

        //public static Boolean operator ==(Group aGroup, Group bGroup)
        //{
        //    return aGroup.GroupCode == bGroup.GroupCode;
        //}

        //public static  Boolean operator !=(Group aGroup, Group bGroup)
        //{
        //    return aGroup.GroupCode != bGroup.GroupCode;
        //}


        #region IEquatable<Group> Members

        public bool Equals(Group other)
        {
            return (other != null && other.GroupID == this.GroupID);
        }

        #endregion
    }


}
