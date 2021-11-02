using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Design;

namespace DentiNovin.BaseClasses
{
    public class DateTimeCollectionEditor : CollectionEditor
    {
        public DateTimeCollectionEditor(Type type)
            : base(type)
        {
        }

        protected override Type CreateCollectionItemType()
        {
            return typeof(DateTime);
        }

        protected override Type[] CreateNewItemTypes()
        {
            return new Type[] { typeof(DateTime) };
        }

        protected override object CreateInstance(Type itemType)
        {
            DateTime dt = (DateTime)base.CreateInstance(itemType);
            return dt;
        }
    }
}
