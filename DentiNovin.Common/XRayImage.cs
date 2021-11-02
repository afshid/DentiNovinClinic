using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DentiNovin.Common
{
    public class XRayImage : BaseClass
    {
        public Int64 XRayImageID { get; set; }

        public Int32 PatientID { get; set; }

        public string DateOfRegister { get; set; }

        public Image Image { get; set; }

        public byte[] Imagebyte { get; set; }
    }
}
