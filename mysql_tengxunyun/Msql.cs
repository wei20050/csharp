using MySql.Data.MySqlClient;
using System.Data;

namespace mysql_tengxunyun
{
    public class Msql
    {
        #region  建立MySql数据库连接
        /// <summary>
        /// 建立数据库连接.
        /// </summary>
        /// <returns>返回MySqlConnection对象</returns>
        public static MySqlConnection GetMysqlCon()
        {
            string mStrSqlcon = Common.RCfg("mysqlstr"); //根据自己的设置
            var myCon = new MySqlConnection(mStrSqlcon);
            return myCon;
        }
        #endregion

        #region  执行MySqlCommand命令
        /// <summary>
        /// 执行MySqlCommand
        /// </summary>
        /// <param name="mStrSqlstr">SQL语句</param>
        /// <returns>返回受影响的行数</returns>
        public static int Getmysqlcom(string mStrSqlstr)
        {
            var mysqlcon = GetMysqlCon();
            mysqlcon.Open();
            var mysqlcom = new MySqlCommand(mStrSqlstr, mysqlcon);
            int ret = mysqlcom.ExecuteNonQuery();
            mysqlcom.Dispose();
            mysqlcon.Close();
            mysqlcon.Dispose();
            return ret;
        }
        #endregion

        /// <summary>
        /// 创建一个适配器
        /// </summary>
        /// <param name="mStrSqlstr">SQL语句</param>
        /// <returns>适配器返回</returns>
        public static DataTable GetMysql(string mStrSqlstr)
        {
            var mysqlcon = GetMysqlCon();
            mysqlcon.Open();
            MySqlDataAdapter mysqladapt = new MySqlDataAdapter(mStrSqlstr, mysqlcon);
            mysqladapt.SelectCommand.CommandTimeout = 0;
            DataTable dt = new DataTable();
            mysqladapt.Fill(dt);
            return dt;
        }
    }
}
