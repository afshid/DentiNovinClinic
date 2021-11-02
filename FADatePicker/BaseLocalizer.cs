using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FADatePicker
{
    public abstract class BaseLocalizer
    {
        #region Abstract Methods

        public abstract string GetLocalizedString(StringID id);

        #endregion
    }
}
