using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaceDetection.Constant;
namespace FaceDetection.Config
{
    class ConnectDB
    {

        SqlConnection con;
        SqlCommand sqlcom;
        SqlDataReader sqldr;
        public ConnectDB()
        {
            SqlConnection con = new SqlConnection(DataBaseConstant.dbString);

        }
        public SqlConnection getConnect()
        {
            return new SqlConnection(DataBaseConstant.dbString);
        }
        public DataTable getTable(string sql)
        {
            con = getConnect();
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
    }
}
