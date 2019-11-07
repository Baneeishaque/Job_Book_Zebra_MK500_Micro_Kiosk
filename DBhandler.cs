using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public class DBhandler
{
    SqlConnection con;

    public DBhandler()
    {
        con = new SqlConnection(@"Data Source=192.168.1.102\MSSQLSER2005;User ID=sa;Password=1;Initial Catalog=job_time_tracker");
    }

    public string SingleInsert(String query)
    {
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            if (result == 1)
            {
                return "1";
            }
        }
        catch (Exception exception)
        {
            return exception.Message;
        }
        return "0";
    }
}





