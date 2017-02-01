using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Collections;

namespace Brandt
{
    class DBCon
    {
        private SqlConnection myConnection = new SqlConnection(@"Server=CV-BB-5323\SQLEXPRESS01;Database=School;Trusted_Connection=True;");

        protected void OpenDB()
        {
            try
            {
                if(myConnection != null && myConnection.State == ConnectionState.Closed)
                {
                    myConnection.Open();
                }
                else
                {
                    if(myConnection == null)
                    {
                        Console.WriteLine("Der er ikke oprettet nogen 'ConnectionStrin'");
                    }
                    else
                    {
                        CloseDB();
                        OpenDB();
                    }
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine("Der kunne ikke oprettes forbindelse til databasen;" + ex.Message);
            }
        }

        private void CloseDB()
        {
            try
            {
                myConnection.Close();
            }
            catch(SqlException ex)
            {
                Console.WriteLine("Der kunne ikke lukkes for forbindelsen til database: " + ex.Message);
            }
        }

        protected string DBReturnString(string strSQL)
        {
            string strRes = "";

            try
            {
                OpenDB();
                using (SqlCommand cmd = new SqlCommand(strSQL, myConnection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        strRes = reader.GetValue(0).ToString();
                    }
                }

                CloseDB();
            }
            catch(SqlException ex)
            {
                Console.WriteLine("Der kunne ikke hente data fra databsen: " + ex.Message);
            }

            return strRes;
        }

        protected List<string> DBReturnStringList(string strSql)
        {
            List<string> listRes = new List<string>();
            try
            {
                OpenDB();
                using (SqlCommand cmd = myConnection.CreateCommand())
                {
                    cmd.CommandText = strSql;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            listRes.Add(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString());
                        }
                    }
                }

                    CloseDB();
            }
            catch(SqlException ex)
            {
                Console.WriteLine("Der kunne ikke hente data fra databsen: " + ex.Message);
            }

            return listRes;
        }

        protected DataTable DBReturnDataTable(string strSQL)
        {
            DataTable dtRes = new DataTable();
            try
            {
                OpenDB();
                using (SqlCommand command = new SqlCommand(strSQL, myConnection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dtRes);
                }

                CloseDB();
            }
            catch(SqlException ex)
            {
                Console.WriteLine("Der kunne ikke hentes data fra databasen: " + ex.Message);
            }

            return dtRes;
        }
    }
}
