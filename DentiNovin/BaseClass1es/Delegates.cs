using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using DentiNovin.Controls;
using DentiNovin.Common;

namespace DentiNovin.BaseClasses
{
    #region CollectionChangedEventArgs

    /// <summary>
    /// Specifies change type of the collection.
    /// </summary>
    public class CollectionChangedEventArgs : EventArgs
    {
        private CollectionChangeType changeType = CollectionChangeType.Other;

        public CollectionChangedEventArgs(CollectionChangeType type)
        {
            changeType = type;
        }

        public CollectionChangeType ChangeType
        {
            get { return changeType; }
        }
    }

    #endregion
    #region CalendarButtonClickedEventArgs

    public class CalendarButtonClickedEventArgs : EventArgs
    {
        #region Fields

        private FAMonthViewButtons button;

        #endregion

        #region Ctor

        public CalendarButtonClickedEventArgs(FAMonthViewButtons button)
        {
            this.button = button;
        }

        #endregion

        #region Props

        public FAMonthViewButtons Button
        {
            get { return button; }
        }

        #endregion
    }

    #endregion

    public class VisitTableButtonClickedEventArgs : EventArgs
    {

    }

    public delegate void CalendarButtonClickedEventHandler(object sender, CalendarButtonClickedEventArgs e);

    public delegate void VisitTableButtonClickedEventHandler(object sender, ArrayList Node);

    public delegate void ToothTypeChangingEventHandler(object sender, ToothTypeChangeMode e);

    public delegate void ToothTypeChangeEventHandler(object sender, PatientToothType e);

    public delegate void VisitNodeEventHandler(object sender, VisitNode e);

    public delegate void PaymentEventHandler(object sender, decimal e);

    public delegate void PatientSelectEventHandler(object sender, Patient e);

    //public delegate void TeethButtonSelectedEventHandler(object sender,List<cTooth> teeth);

    //public delegate void ToothButtonSelectedEventHandler(object sender,cTooth tooth);

    public delegate void ToothSelectedEventHandlet(object sender,Tooth e);
}

