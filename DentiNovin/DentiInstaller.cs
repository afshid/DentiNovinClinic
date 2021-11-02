using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.IO;
using Microsoft.Win32;
using System.Security.Cryptography;
using System.Text;


namespace DentiNovin
{
    [RunInstaller(true)]
    public partial class DentiInstaller : Installer
    {
        public DentiInstaller()
        {
            InitializeComponent();
        }

        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
            stateSaver.Add("TargetDir", Context.Parameters["DP_TargetDir"].ToString());
        }

        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);
            try
            {
                RegistryKey DentiReg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows");
               if(DentiReg.OpenSubKey("SOFTWARE\\Microsoft\\Windows")==null)
                   DentiReg.SetValue("rgDte", Encrypt(DateTime.Now.ToShortDateString()));
            }
            catch (Exception ex)
            {

            }
        }

        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
            String _TargetDir;

            _TargetDir = savedState["TargetDir"].ToString();

            if (File.Exists(_TargetDir + "log.txt") == true)
            {
                File.Delete(_TargetDir + "log.txt");
            }
        }

        private byte[] Encrypt(string DecryptedData)
        {
            // Csp: Crytographic Service Provider 
            // Create a CspParameters object to store our keys permanently in this machine 
            CspParameters persistantCsp = new CspParameters();
            persistantCsp.KeyContainerName = "myAsymmetricKey";

            // Create an instance of the RSA algorithm object 
            RSACryptoServiceProvider myRSA = new RSACryptoServiceProvider(persistantCsp);

            // Specify that the private key should be stored in the CSP 
            myRSA.PersistKeyInCsp = true;

            // Create a new RSAParameters object with the private key 
            RSAParameters privateKey = myRSA.ExportParameters(true);

            // Showing keys 
            //MessageBox.Show(myRSA.ToXmlString(true)); 

            // Now, encrypting data 
            byte[] encBytes = Encoding.Unicode.GetBytes(DecryptedData);

            // Encrypt 
            byte[] encData = myRSA.Encrypt(encBytes, false);

            return encData;
        }

        private string Decrypt(byte[] EncryptedData)
        {
            // Csp: Crytographic Service Provider 
            // Create a CspParameters object to store our keys permanently in this machine 
            CspParameters persistantCsp = new CspParameters();
            persistantCsp.KeyContainerName = "myAsymmetricKey";

            // Create an instance of the RSA algorithm object 
            RSACryptoServiceProvider myRSA = new RSACryptoServiceProvider(persistantCsp);

            // Specify that the private key should be stored in the CSP 
            myRSA.PersistKeyInCsp = true;

            // Create a new RSAParameters object with the private key 
            RSAParameters privateKey = myRSA.ExportParameters(true);


            // Decrypt 
            byte[] decBytes = myRSA.Decrypt(EncryptedData, false);

            // Showing results 
            return Encoding.Unicode.GetString(decBytes);
        }

    }
}
