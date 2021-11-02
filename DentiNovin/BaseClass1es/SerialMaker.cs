using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.IO;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using DentiNovin.Common;

namespace DentiNovin.BaseClasses
{
    public class SerialMaker
    {
        private string _BaseString;
        private string _Password;
        private string _SoftName;
        private string _RegFilePath;
        private string _HideFilePath;
        private string _Text;
        private string _Identifier;

        public SerialMaker(string SoftwareName,
            string RegFilePath, string HideFilePath,
            string Text,
            string Identifier)
        {
            _SoftName = SoftwareName;
            _Identifier = Identifier;

            SetDefaults();

            _RegFilePath = RegFilePath;
            _HideFilePath = HideFilePath;
            _Text = Text;
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

            MakeBaseString();
            MakePassword();
        }

        private void MakeBaseString()
        {
            _BaseString = Encryption.Boring(Encryption.InverseByBase(SystemInfo.GetSystemInfo(_SoftName), 10));
        }

        private void MakePassword()
        {
            _Password = Encryption.MakePassword(_BaseString, _Identifier);
        }

        public RunTypes ShowDialog()
        {
            if (CheckRegister() == true)
                return RunTypes.Full;

            //RegistrationForm aRegistrationForm = new RegistrationForm(_BaseString, _Password, _Text);
            RegistrationForm aRegistrationForm = new RegistrationForm(_BaseString, _Text);
            
            MakeHideFile();

            DialogResult DR = aRegistrationForm.ShowDialog();

            if (DR == System.Windows.Forms.DialogResult.OK)
            {
                MakeRegFile();
                MakeHideFile();
                return RunTypes.Full;
            }
            else
                return RunTypes.Expired;
        }

        public RunTypes CheckStatus()
        {
            if (CheckRegister() == true)
                return RunTypes.Full;
            else
                return RunTypes.Expired;
        }

        private void MakeRegFile()
        {
            FileReadWrite.WriteFile(_RegFilePath, _Password);
        }

        private bool CheckRegister()
        { 
            string Password = FileReadWrite.ReadFile(_RegFilePath);

            if (_Password == Password)
                return true;
            else
                return false;
        }

        private void MakeHideFile()
        {
            string HideInfo;
            HideInfo = DateTime.Now.Ticks + ";";
            HideInfo += _BaseString + ";";
            HideInfo += _Password;
            FileReadWrite.WriteFile(_HideFilePath, HideInfo);
        }

        private int CheckHideFile()
        {
            string[] HideInfo;
            HideInfo = FileReadWrite.ReadFile(_HideFilePath).Split(';');
            if (_BaseString == HideInfo[3])
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

        public string RegFilePath
        {
            get
            {
                return _RegFilePath;
            }
            set
            {
                _RegFilePath = value;
            }
        }

        public string HideFilePath
        {
            get
            {
                return _HideFilePath;
            }
            set
            {
                _HideFilePath = value;
            }
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