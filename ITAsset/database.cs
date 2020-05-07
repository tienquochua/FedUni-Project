using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ITAsset
{
    class database
    {
        string strConn;
        SqlConnection conn;
        SqlDataAdapter da;
        public database(string strConn)
        {
            this.strConn = strConn;
        }
        public DataTable ReadData(string strSql)
        {
            conn = new SqlConnection(strConn);
            da = new SqlDataAdapter(strSql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Dispose();
            return dt;
        }
        public void UpdateData(DataTable dt, string strSql)
        {
            conn = new SqlConnection(strConn);
            da = new SqlDataAdapter(strSql, conn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(dt);
            conn.Dispose();
        }
    }
}
