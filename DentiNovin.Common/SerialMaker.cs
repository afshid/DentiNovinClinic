using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DentiNovin.Common
{
   public class SerialMaker
    {
        private string _BaseString;
        private string _Password;
        private string _softName;
        private string _RegFilePath;
        private string _HideFilePath;
        private string _Text;
        private string _identifier;

        public SerialMaker(string softwareName, string identifier)
        {
            _softName = softwareName;
            _identifier = identifier;
            SetDefaults();
        }
    }
}
