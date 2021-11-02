using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using System.Globalization;

namespace DentiClinic
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string headername;
            OleDbConnection oCon = new OleDbConnection();
            oCon.ConnectionString = ConfigurationManager.ConnectionStrings["DentiClinic.Properties.Settings.MNMDentiConnectionString1"].ConnectionString;
            SqlConnection oCon2 = new SqlConnection();
            oCon2.ConnectionString = ConfigurationManager.ConnectionStrings["DentiClinic.Properties.Settings.MNMDentiDBServerConnectionString"].ConnectionString; ;
            SqlCommand oComand2 = new SqlCommand();
           // oComand2.CommandText = "insert into TreatmentHeader (HeaderName) values(" + headername +")";
            oComand2.CommandType = System.Data.CommandType.Text;
            oComand2.Connection = oCon2;

            try
            {
                OleDbCommand oComand = new OleDbCommand();
                oComand.CommandText = "Select name,serviceID,K from ServiceDetail";
                oComand.CommandType = System.Data.CommandType.Text;
                oComand.Connection = oCon;
                oCon.Open();
                OleDbDataReader oreader = oComand.ExecuteReader();
                oCon2.Open();
                while (oreader.Read())
                {
                    headername = oreader[0].ToString();
                    oComand2.CommandText = "INSERT INTO tbl_AssuranceServiceDetails (HeaderID,AssuranceID,DetailsName,KPrice) VALUES (" + (Int16)oreader[1] + ",3,N'" + oreader[0].ToString() + "'," + (Int16)oreader[2] +")";

                    oComand2.ExecuteNonQuery();
                }



            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                if (oCon.State == ConnectionState.Open)
                    oCon.Close();
                if (oCon2.State == ConnectionState.Open)
                    oCon2.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string test = MakeNewPassword("147852", 1392, 09, 10);
        }

        public string MakeNewPassword(string doctorId, short year, short month, short day)
        {
            DateTime time = new DateTime(year, month, day,new PersianCalendar());
            long num = time.ToBinary() / 1000000000L;
            num = num % 100L;
            string str = (long.Parse(doctorId) + num).ToString();
            int num3 = str.Length - 2;
            int num4 = 0;
            string str2 = "";
            while (num3 >= 0)
            {
                char ch = str[num3];
                str2 = str2 + ((char)(((int.Parse(ch.ToString()) * 2) + 97) + num4)).ToString();
                num3 -= 2;
                num4++;
            }
            num3 = str.Length - 1;
            while (num3 >= 0)
            {
                char ch3 = str[num3];
                str2 = str2 + ((char)(((int.Parse(ch3.ToString()) * 2) + 97) + num4)).ToString();
                num3 -= 2;
                num4++;
            }
            string str3 = "";
            for (int i = 1; i <= str2.Length; i++)
            {
                if ((i % 2) == 0)
                {
                    str3 = str3 + str2[i - 1];
                }
                else
                {
                    int num6 = str2[i - 1];
                    num6 -= 96;
                    if (num6 <= 13)
                    {
                        num6 = (num6 + ((13 - num6) * 2)) + 1;
                    }
                    else
                    {
                        num6 = (num6 - ((num6 - 13) * 2)) + 1;
                    }
                    num6 += 96;
                    str3 = str3 + ((char)num6).ToString();
                }
            }
            string str4 = "zaw1sxe2dcr3fvt4gby5hnu6jmi7klp";
            char ch6 = str4[month - 1];
            char ch7 = str4[year - 1369];
            char ch8 = str4[day - 1];
            return str3.Insert(1, ch6.ToString()).Insert(3, ch7.ToString()).Insert(5, ch8.ToString()).ToUpper();
        }


    }



}
