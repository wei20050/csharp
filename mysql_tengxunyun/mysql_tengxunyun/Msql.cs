using MySql.Data.MySqlClient;

namespace mysql_tengxunyun
{
    public class Msql
    {
        #region  建立MySql数据库连接
        /// <summary>
        /// 建立数据库连接.
        /// </summary>
        /// <returns>返回MySqlConnection对象</returns>
        public MySqlConnection Getmysqlcon()
        {
            const string mStrSqlcon = "server=localhost;user id=root;password=;database=yxdb"; //根据自己的设置
            var myCon = new MySqlConnection(mStrSqlcon);
            return myCon;
        }
        #endregion

        #region  执行MySqlCommand命令
        /// <summary>
        /// 执行MySqlCommand
        /// </summary>
        /// <param name="mStrSqlstr">SQL语句</param>
        public void Getmysqlcom(string mStrSqlstr)
        {
            var mysqlcon = Getmysqlcon();
            mysqlcon.Open();
            var mysqlcom = new MySqlCommand(mStrSqlstr, mysqlcon);
            mysqlcom.ExecuteNonQuery();
            mysqlcom.Dispose();
            mysqlcon.Close();
            mysqlcon.Dispose();
        }
        #endregion

        #region  创建MySqlDataReader对象
        /// <summary>
        /// 创建一个MySqlDataReader对象
        /// </summary>
        /// <param name="mStrSqlstr">SQL语句</param>
        /// <returns>返回MySqlDataReader对象</returns>
        public MySqlDataReader Getmysqlread(string mStrSqlstr)
        {
            var mysqlcon = Getmysqlcon();
            var mysqlcom = new MySqlCommand(mStrSqlstr, mysqlcon);
            mysqlcon.Open();
            var mysqlread = mysqlcom.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            return mysqlread;
        }
        #endregion

    }
}
