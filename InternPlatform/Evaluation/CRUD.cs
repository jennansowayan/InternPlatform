using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace InternPlatform.Evaluation
{
    internal class CRUD
    {
        private SqlCommand cmd;
        private DataTable dt;
        private DataSet ds;
        private DataView dv;

        public static string conStr = WebConfigurationManager.ConnectionStrings["Connect"].ConnectionString;
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["Connect"].ConnectionString);

        public SqlDataReader getDrPassSql(string mySql, Dictionary<string, object> myPara)
        {
            SqlDataReader dr;
            using (SqlCommand cmd = new SqlCommand(mySql, con))
            {
                foreach (KeyValuePair<string, object> p in myPara)
                {
                    // can put validation here to see if the value is empty or not
                    cmd.Parameters.AddWithValue(p.Key, p.Value);
                }
                con.Open();
                dr = cmd.ExecuteReader();
                return dr;
            }
        }

        public int InsertUpdateDelete(string sqlCmd, Dictionary<string, object> myPara)
        {
            int rtn = 0;
            using (SqlCommand cmd = new SqlCommand(sqlCmd, con))
            {
                cmd.CommandType = CommandType.Text;
                foreach (KeyValuePair<string, object> p in myPara)
                {
                    cmd.Parameters.AddWithValue(p.Key, p.Value);
                }
                using (con)
                {
                    con.Open();
                    rtn = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return rtn;
        }

        public SqlDataReader getDrPassSql(string mySql)
        {
            SqlDataReader dr;
            using (SqlCommand cmd = new SqlCommand(mySql, con))
            {
                //foreach (KeyValuePair<string, object> p in myPara)
                //{
                //    // can put validation here to see if the value is empty or not
                //    cmd.Parameters.AddWithValue(p.Key, p.Value);
                //}
                con.Open();
                dr = cmd.ExecuteReader();
                return dr;
            }
        }

        public int InsertUpdateDelete(string sqlCmd)
        {
            int rtn = 0;
            using (SqlCommand cmd = new SqlCommand(sqlCmd, con))
            {
                cmd.CommandType = CommandType.Text;
                using (con)
                {
                    con.Open();
                    rtn = cmd.ExecuteNonQuery();  // -1    > = 1
                    con.Close();
                }
            }
            return rtn;
        }

        public SqlDataAdapter dataAdapt(string mySql)
        {
            SqlDataAdapter adp = new SqlDataAdapter();
            using (SqlCommand cmd = new SqlCommand(mySql, con))
            {
                cmd.Connection = con;
                adp.SelectCommand = cmd;

            }

            return adp;
        }
    }
}