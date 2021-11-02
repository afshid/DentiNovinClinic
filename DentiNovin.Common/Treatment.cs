using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DentiNovin.Common
{
    public class Treatment : BaseClass
    {
        public int TreatmentServiceID { get; set; }

        public int TreatmentClassID { get; set; }

        public string Code { get; set; }

        public string PersianName { get; set; }

        public string LatinName { get; set; }

        public string AbbreviationName { get; set; }

        [DisplayFormat(DataFormatString = "{0:0}")] 
        public decimal Price { get; set; }

        public int TreatmentArea { get; set; }

        private List<int> _relateCode;
        public List<int> RelateCode
        {
            get
            {
                if (_relateCode == null)
                    _relateCode = new List<int>() ;
                return _relateCode;
            }
            set
            { _relateCode = value; }
        }

        public int DrawType { get; set; }

        public int BrushType { get; set; }

        public bool ShowInToolBox { get; set; }

        public Int16 ToolBoxImageIndex { get; set; }

        public TreatmentSurfaceView SurfaceView { get; set; }

        public string DateOfRegister { get; set; }

        public int BrushColor { get; set; }

        public bool ShowRootInfoForm { get; set; }

        public bool MarkToothMissing { get; set; }

    }
}
