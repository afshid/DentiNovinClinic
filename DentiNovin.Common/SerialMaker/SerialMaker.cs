using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DentiNovin.Common.SerialMaker
{
    public class SerialMaker
    {
        private string _systemID;
        private string _serial;
        private string _softName;
        private string _regFilePath;
        private string _hideFilePath;
        private string _identifier;
        public string SystemID { get { return _systemID; } set { _systemID = value; } }

        public SerialMaker(string softwareName, string regFilePath, string hideFilePath, string identifier)
        {
            _softName = softwareName;
            _identifier = identifier;

            SetDefaults();

            _regFilePath = regFilePath;
            _hideFilePath = hideFilePath;
        }

        private void SetDefaults()
        {
            SystemInfo.UseBaseBoardManufacturer = false;
            SystemInfo.UseBaseBoardProduct = true;
            SystemInfo.UseBiosManufacturer = false;
            SystemInfo.UseBiosVersion = true;
            SystemInfo.UseDiskDriveSignature = true;
            SystemInfo.UsePhysicalMediaSerialNumber = false;
            SystemInfo.UseProcessorID = true;
            SystemInfo.UseVideoControllerCaption = false;
            SystemInfo.UseWindowsSerialNumber = false;

            SystemID = Encryption.Boring(Encryption.InverseByBase(SystemInfo.GetSystemInfo(_softName), 10));
            _serial = Encryption.MakePassword(_systemID, _identifier);
        }

        public RunTypes CheckStatus()
        {
            if (CheckRegister() == true)
                return RunTypes.Full;
            else
                return RunTypes.Expired;
        }

        private bool CheckRegister()
        {
            string Serial = FileReadWrite.ReadFile(_regFilePath);

            if (_serial == Serial)
                return true;
            else
                return false;
        }

        public RunTypes RegisterSoftware(string serialEntered)
        {
            if (serialEntered == _serial)
            {
                MakeRegFile();
                MakeHideFile();
                return RunTypes.Full;
            }
            return RunTypes.Expired;
        }

        private void MakeRegFile()
        {
            FileReadWrite.WriteFile(_regFilePath, _serial);
        }

        private void MakeHideFile()
        {
            string HideInfo;
            HideInfo = DateTime.Now.Ticks + ";";
            HideInfo += SystemID + ";";
            HideInfo += _serial;
            FileReadWrite.WriteFile(_hideFilePath, HideInfo);
        }

        private int CheckHideFile()
        {
            string[] HideInfo;
            HideInfo = FileReadWrite.ReadFile(_hideFilePath).Split(';');
            if (_systemID == HideInfo[3])
            {

            }
            return 0;
        }

        public enum RunTypes
        {
            Trial = 0,
            Full,
            Expired,
            UnKnown
        }

        public byte[] TripleDESKey
        {
            get
            {
                return FileReadWrite.key;
            }
            set
            {
                FileReadWrite.key = value;
            }
        }

        public bool UseProcessorID
        {
            get
            {
                return SystemInfo.UseProcessorID;
            }
            set
            {
                SystemInfo.UseProcessorID = value;
            }
        }

        public bool UseBaseBoardProduct
        {
            get
            {
                return SystemInfo.UseBaseBoardProduct;
            }
            set
            {
                SystemInfo.UseBaseBoardProduct = value;
            }
        }

        public bool UseBaseBoardManufacturer
        {
            get
            {
                return SystemInfo.UseBiosManufacturer;
            }
            set
            {
                SystemInfo.UseBiosManufacturer = value;
            }
        }

        public bool UseDiskDriveSignature
        {
            get
            {
                return SystemInfo.UseDiskDriveSignature;
            }
            set
            {
                SystemInfo.UseDiskDriveSignature = value;
            }
        }

        public bool UseVideoControllerCaption
        {
            get
            {
                return SystemInfo.UseVideoControllerCaption;
            }
            set
            {
                SystemInfo.UseVideoControllerCaption = value;
            }
        }

        public bool UsePhysicalMediaSerialNumber
        {
            get
            {
                return SystemInfo.UsePhysicalMediaSerialNumber;
            }
            set
            {
                SystemInfo.UsePhysicalMediaSerialNumber = value;
            }
        }

        public bool UseBiosVersion
        {
            get
            {
                return SystemInfo.UseBiosVersion;
            }
            set
            {
                SystemInfo.UseBiosVersion = value;
            }
        }

        public bool UseBiosManufacturer
        {
            get
            {
                return SystemInfo.UseBiosManufacturer;
            }
            set
            {
                SystemInfo.UseBiosManufacturer = value;
            }
        }

        public bool UseWindowsSerialNumber
        {
            get
            {
                return SystemInfo.UseWindowsSerialNumber;
            }
            set
            {
                SystemInfo.UseWindowsSerialNumber = value;
            }
        }



    }
}
