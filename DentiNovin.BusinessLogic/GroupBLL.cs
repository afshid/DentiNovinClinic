using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DentiNovin.Common;
using DentiNovin.DataAccess;
using System.Data;

namespace DentiNovin.BusinessLogic
{
    public class GroupBLL
    {
        private Group _oGroup;
        public Group oGroup
        {
            get { return _oGroup; }
            set { _oGroup = value; }
        }

        private GroupDAL _bGroupDAL;
        public GroupDAL BGroupDAL
        {
            get
            {
                if (_bGroupDAL == null)
                    _bGroupDAL = new GroupDAL();
                return _bGroupDAL;
            }
            set
            {
                _bGroupDAL = value;
            }
        }

        public DataSet GetGroupList(Boolean All)
        {
            return BGroupDAL.GetGroupList(All);
        }

        public void InsertNewGroup()
        {
            BGroupDAL.oGroup = this.oGroup;
            BGroupDAL.InsertNewGroup();
        }
        public void UpdateGroup()
        {
            BGroupDAL.oGroup = this.oGroup;
            BGroupDAL.UpdateGroup();
        }

        public void DeleteGroup(int groupID)
        {
            BGroupDAL.DeleteGroup(groupID);
        }
    }
}
