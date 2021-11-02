using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;

namespace DentiNovin.Common
{
    public class Node : BaseClass
    {
        public DateTime VisitDate;
        public TimeSpan VisitTime;
        public Patient oPatient;
        public int nIndex;
        public int dIndex;
        public int rIndex;
        public Group oGroup;
        public Rectangle rcNode { get; set; }
        public Node(Group CurrentGroup, Rectangle rcNodeBase,int NIndex,int DIndex)
        {
            this.oGroup = CurrentGroup;
            this.rcNode = rcNodeBase;
            this.nIndex = NIndex;
            this.dIndex=DIndex;
        }

    }

    public class Day
    {
        public int index;
        public List<Node> Nodes = new List<Node>();
        public Group oGroup;
        public Rectangle rcNodeBase;
        public int NodeCount;

        public Node this[int index]
        {
            get
            {
                return Nodes[index];
            }
        }
        public Day(int DayNum, Group CurrentGroup, Rectangle rcNodeBase)
        {
            this.index = DayNum;
            this.oGroup = CurrentGroup;
            this.rcNodeBase = rcNodeBase;

            int COLUMNS_COUNT =0;
            if (oGroup.EndTime < oGroup.StartTime)
                COLUMNS_COUNT = System.Convert.ToInt32(24 - (oGroup.StartTime - oGroup.EndTime).TotalMinutes / oGroup.PeriodLength) + 1;
            else
                COLUMNS_COUNT = System.Convert.ToInt32((oGroup.EndTime - oGroup.StartTime).TotalMinutes / oGroup.PeriodLength) + 1;

            for (int i = 0; i < COLUMNS_COUNT; i++)
            {
                Nodes.Add(new Node(oGroup, rcNodeBase,i,this.index));
                rcNodeBase.X = rcNodeBase.X + (rcNodeBase.Width)+1;
                this.NodeCount = this.NodeCount + 1;
            }

        }
    }

    public class Month
    {
        //private int _dayCount;
        //public int DayCount
        //{
        //    get { return _dayCount; }

        //    set { _dayCount = value; }
        //}

        public List<Day> Days = new List<Day>();
        public Group oGroup;
        public Rectangle rcNodeBase;


        public Month(int DayCount, Group CurrentGroup, Rectangle rcNodeBase)
        {
            this.oGroup = CurrentGroup;
            this.rcNodeBase = rcNodeBase;

            for (int i = 0; i < DayCount; i++)
            {
                Days.Add(new Day(i, oGroup, rcNodeBase));
                rcNodeBase.Y = rcNodeBase.Y + (rcNodeBase.Height)+1;
            }
        }

        public void DrowMonth(Graphics g, StringFormat OneLineNoTrimming, Font Font)
        {
            string strPatientName = "";
            for (int i = 0; i < this.Days.Count - 1; i++)
            {
                for (int j = 0; j < this.Days[i].NodeCount - 1; j++)
                {
                    if (this.Days[i][j].oPatient != null)
                        strPatientName = this.Days[i][j].oPatient.LastName;
                    else
                        strPatientName = "";
                    g.DrawString(strPatientName, Font, SystemBrushes.WindowText, this.Days[i][j].rcNode, OneLineNoTrimming);
                }
            }

        }

    }

    public class HeaderRow
    {

    }
}
