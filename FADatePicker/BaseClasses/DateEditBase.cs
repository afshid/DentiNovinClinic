using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FADatePicker.BaseClasses
{
    [ToolboxItem(false)]
    public class DateEditBase : TextEditBase
    {
        #region Fields

        private FormatInfoTypes format;

        #endregion

        #region Props

        /// <summary>
        /// FormatInfoTypes instance, used to format date to string representation.
        /// </summary>
        [Description("FormatInfoTypes instance, used to format date to string representation.")]
        [DefaultValue(typeof(FormatInfoTypes), "ShortDate")]
        public FormatInfoTypes FormatInfo
        {
            get { return format; }
            set
            {
                if (format == value)
                    return;

                format = value;
                UpdateTextValue();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Updates text representation of the selected value.
        /// </summary>
        public virtual void UpdateTextValue()
        {
        }

        /// <summary>
        /// Returns a string representation of the FormatInfoTypes.
        /// </summary>
        /// <param name="fi"></param>
        /// <returns></returns>
        protected internal string GetFormatByFormatInfo(FormatInfoTypes fi)
        {
            switch (fi)
            {
                case FormatInfoTypes.DateShortTime:
                    return "g";

                case FormatInfoTypes.FullDateTime:
                    return "G";

                case FormatInfoTypes.ShortDate:
                default:
                    return "d";
            }
        }

        #endregion

    }
}
