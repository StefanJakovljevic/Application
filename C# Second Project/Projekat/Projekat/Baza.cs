using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{
   
    class Baza
    {
        OleDbConnection conn;
        public Baza()
        {
            conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\SJ\Desktop\C# Second Project\Prodavnica.accdb";
        }

        public OleDbConnection Conn { get => conn; set => conn = value; }

        public void otvoriKonekciju()
        {
            if (Conn != null)
                Conn.Open();
        }
        public void zatvoriKonekciju()
        {
            if (Conn != null)
                Conn.Close();
        }

    }
}
