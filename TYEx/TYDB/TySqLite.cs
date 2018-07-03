using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using TYPublicCore;

namespace TYDB
{
    public class TySqLite
    {
        /// <summary>
        /// 数据库地址
        /// </summary>
        public static string DataBasePath;
        /// <summary>
        /// 数据库密码
        /// </summary>
        public static string DataBasePasssord;
        /// <summary>
        /// 数据库初始化
        /// </summary>
        /// <param name="errMessage">初始化异常提示</param>
        /// <returns></returns>
        public static bool Init(out string errMessage)
        {
            if (!File.Exists("DBComfig.txt"))
            {
                File.WriteAllText("DBComfig.txt", "dataBasePath=D:\\mydb.db,dataBasePasssord=123456");
                errMessage = "数据库配置不存在,已经自动创建,请配置好数据库后重启服务器 !";
                return false;
            }
            var dbStr = File.ReadAllText("DBComfig.txt");
            var db = dbStr.Split(',');
            if (db.Length != 2)
            {
                errMessage = "数据库配置配置异常,请配置好数据库后重启服务器 !";
                return false;
            }
            var dbPath = db[0].Split('=');
            var dbPwd = db[1].Split('=');
            if (dbPath.Length != 2 || dbPwd.Length != 2)
            {
                errMessage = "数据库配置配置异常,请配置好数据库后重启服务器 !";
                return false;
            }
            DataBasePath = Path.GetFullPath(dbPath[1].Trim());
            DataBasePasssord = dbPwd[1].Trim();
            errMessage = string.Empty;
            return Test();
        }
        /// <summary>
        /// 测试数据库连接情况
        /// </summary>
        private static bool Test() {
            try
            {
                Query("select name from sqlite_master");
                return true;
            }
            catch (Exception ex)
            {
                TyLog.Wlog(ex);
                throw new Exception("连接数据库异常:" + ex.Message);
            }
        } 
        /// <summary>
        /// 修改数据库密码
        /// </summary>
        /// <param name="pwd">不给此参数是删除密码</param>
        /// <returns></returns>
        public static bool ChangePwd(string pwd = "")
        {
            using (SQLiteConnection conn = GetSqLiteConnection())
            {
                try
                {
                    conn.Open();
                    conn.ChangePassword(pwd);
                }
                catch (Exception ex)
                {
                    TyLog.Wlog(ex);
                    throw new Exception("连接数据库异常:" + ex.Message);
                }
            }            
            return true;
        }
        /// <summary>
        /// Dictionary 转 SQLiteParameter
        /// </summary>
        /// <param name="dic">Dictionary</param>
        /// <returns></returns>
        private static SQLiteParameter[] D2P(Dictionary<string,object> dic)
        {
            SQLiteParameter[] sqlParams = new SQLiteParameter[dic.Count];
            int i = 0;
            foreach (var item in dic)
            {
                sqlParams[i] = new SQLiteParameter(item.Key, item.Value);
                i++;
            }
            return sqlParams;
        }
        /// <summary>
        /// 获取连接
        /// </summary>
        /// <returns></returns>
        private static SQLiteConnection GetSqLiteConnection()
        {
            SQLiteConnection conn;
            try
            {
                conn = new SQLiteConnection();
                var connStr = new SQLiteConnectionStringBuilder
                {
                    DataSource = DataBasePath,
                    Password = DataBasePasssord
                };
                conn.ConnectionString = connStr.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("连接数据库异常:" + ex.Message);
            }
            return conn;
        }

        #region 执行查询

        /// <summary>
        /// 执行SQL，返回影响的记录数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteSql(string sql)
        {
            int iResult;
            using (SQLiteConnection conn = GetSqLiteConnection())
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();
                        iResult = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("执行SQL，返回影响的记录数异常:" + ex.Message);
                    }
                }
            }
            return iResult;
        }

        /// <summary>
        /// 执行带一个存储过程参数的SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static int ExecuteSql(string sql, string content)
        {
            int iResult;
            using (var conn = GetSqLiteConnection())
            {
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    try
                    {
                        var parameter = new SQLiteParameter("@content", SqlDbType.NText)
                        {
                            Value = content
                        };
                        cmd.Parameters.Add(parameter);
                        conn.Open();
                        iResult = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("执行带一个存储过程参数的SQL语句异常:" + ex.Message);
                    }
                }
            }
            return iResult;
        }

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static int ExecuteSql(string sql,Dictionary<string, object> dic)
        {
            var sqlParams = D2P(dic);
            int iResult;
            using (var conn = GetSqLiteConnection())
            {
                using (var cmd = new SQLiteCommand())
                {
                    try
                    {
                        PrepareCommand(conn, cmd, null, sql, sqlParams);
                        iResult = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("执行SQL语句，返回影响的记录数异常:" + ex.Message);
                    }
                }
            }
            return iResult;
        }

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet Query(string sql)
        {
            DataSet dsResult;
            using (var conn = GetSqLiteConnection())
            {
                using (var da = new SQLiteDataAdapter(sql, conn))
                {
                    try
                    {
                        conn.Open();
                        dsResult = new DataSet();
                        da.Fill(dsResult, "ds");
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("执行查询异常:" + ex.Message);
                    }
                }
            }
            return dsResult;
        }

        /// <summary>
        /// 执行查询语句，参数化查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static DataSet Query(string sql, Dictionary<string, object> dic)
        {
            var sqlParams = D2P(dic);
            DataSet dsResult;
            using (var conn = GetSqLiteConnection())
            {
                using (var cmd = new SQLiteCommand())
                {
                    using (var da = new SQLiteDataAdapter(cmd))
                    {
                        try
                        {
                            PrepareCommand(conn, cmd, null, sql, sqlParams);
                            dsResult = new DataSet();
                            da.Fill(dsResult, "ds");
                            cmd.Parameters.Clear();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("执行查询返回DataSet异常:" + ex.Message);
                        }
                    }
                }
            }
            return dsResult;
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）
        /// 第一行第一列
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object GetSingle(string sql)
        {
            object oResult;
            using (var conn = GetSqLiteConnection())
            {
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();
                        oResult = cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("执行一条计算查询结果语句，返回查询结果（object）异常:" + ex.Message);
                    }
                }
            }
            return oResult;
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static object GetSingle(string sql, Dictionary<string, object> dic)
        {
            var sqlParams = D2P(dic);
            object oResult;
            using (var conn = GetSqLiteConnection())
            {
                using (var cmd = new SQLiteCommand())
                {
                    try
                    {
                        PrepareCommand(conn, cmd, null, sql, sqlParams);
                        oResult = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("执行查询异常:" + ex.Message);
                    }
                }
            }
            return oResult;
        }

        #endregion  执行查询

        #region  执行事务

        /// <summary>
        /// 执行SQL事务操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteSqlTran(string sql)
        {
            int iResult = -1;
            using (SQLiteConnection conn = GetSqLiteConnection())
            {
                using (SQLiteTransaction tran = conn.BeginTransaction())
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn, tran))
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(sql))
                            {
                                conn.Open();
                                iResult = cmd.ExecuteNonQuery();
                                tran.Commit();
                            }
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            throw new Exception("执行SQL事务操作异常:" + ex.Message);
                        }
                    }
                }
            }
            return iResult;
        }

        /// <summary>
        /// 执行多条SQL事务操作
        /// </summary>
        /// <param name="sqlList"></param>
        /// <returns></returns>
        public static int ExecuteSqlTran(List<string> sqlList)
        {
            var iResult = -1;
            using (var conn = GetSqLiteConnection())
            {
                using (var tran = conn.BeginTransaction())
                {
                    using (var cmd = new SQLiteCommand())
                    {
                        try
                        {
                            conn.Open();
                            cmd.Connection = conn;
                            cmd.Transaction = tran;
                            foreach (var sql in sqlList)
                            {
                                if (string.IsNullOrEmpty(sql)) continue;
                                cmd.CommandText = sql;
                                iResult += cmd.ExecuteNonQuery();
                            }
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            throw new Exception("执行多条SQL事务操作异常:" + ex.Message);
                        }
                    }
                }
            }
            return iResult;
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务
        /// </summary>
        /// <param name="sqlHashTable"></param>
        /// <returns></returns>
        public static int ExecuteSqlTran(Hashtable sqlHashTable)
        {
            int iResult = -1;
            using (SQLiteConnection conn = GetSqLiteConnection())
            {
                using (SQLiteTransaction tran = conn.BeginTransaction())
                {
                    using (SQLiteCommand cmd = new SQLiteCommand())
                    {
                        try
                        {
                            conn.Open();
                            foreach (DictionaryEntry de in sqlHashTable)
                            {
                                string cmdSql = de.Key.ToString();
                                SQLiteParameter[] cmdParams = (SQLiteParameter[])de.Value;
                                PrepareCommand(conn, cmd, tran, cmdSql, cmdParams);
                                iResult = cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                                tran.Commit();
                            }
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            throw new Exception("执行多条SQL事务异常:" + ex.Message);
                        }
                    }
                }
            }
            return iResult;
        }



        /// <summary>
        /// 向数据库中插入图像格式字段
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="fs"></param>
        /// <returns></returns>
        public static int ExecuteSqlInsertImg(string sql, byte[] fs)
        {
            int iResult;
            using (var conn = GetSqLiteConnection())
            {
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    try
                    {
                        var sqlParam = new SQLiteParameter("@fs", SqlDbType.Image)
                        {
                            Value = fs
                        };
                        cmd.Parameters.Add(sqlParam);
                        conn.Open();
                        iResult = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("插入图像字段异常:" + ex.Message);
                    }
                }
            }
            return iResult;
        }

        #endregion 执行事务

        #region 私有公共方法

        private static void PrepareCommand(SQLiteConnection conn, SQLiteCommand cmd, SQLiteTransaction tran, string sql, SQLiteParameter[] sqlParams)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandText = sql;

            if (tran != null)
            {
                cmd.Transaction = tran;
            }
            cmd.CommandType = CommandType.Text;

            if (sqlParams != null)
            {
                foreach (SQLiteParameter param in sqlParams)
                {
                    cmd.Parameters.Add(param);
                }
            }
        }

        #endregion 私有公共方法

        #region 存储过程

        /// <summary>
        /// 执行存储过程,返回DataReader
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="dataParams"></param>
        /// <returns></returns>
        public static SQLiteDataReader RunProcedure(string storedProcName, IDataParameter[] dataParams)
        {
            SQLiteDataReader rResult;
            using (var conn = GetSqLiteConnection())
            {
                using (var cmd = BuildQueryCommand(conn, storedProcName, dataParams))
                {
                    try
                    {
                        rResult = cmd.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("执行存储过程异常:" + ex.Message);
                    }
                }
            }
            return rResult;
        }

        /// <summary>
        /// 执行存储过程,返回DataSet
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="dataParams"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] dataParams, string tableName)
        {
            DataSet dsResult;
            using (var conn = GetSqLiteConnection())
            {
                using (var da = new SQLiteDataAdapter())
                {
                    try
                    {
                        dsResult = new DataSet();
                        da.SelectCommand = BuildQueryCommand(conn, storedProcName, dataParams);
                        da.Fill(dsResult, tableName);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("执行存储过程异常:" + ex.Message);
                    }
                }
            }
            return dsResult;
        }

        /// <summary>
        /// 执行存储过程，返回影响的行数
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="dataParams"></param>
        /// <param name="rowsAffected"></param>
        /// <returns></returns>
        public static int RunProcedure(string storedProcName, IDataParameter[] dataParams, out int rowsAffected)
        {
            int iResult;
            using (var conn = GetSqLiteConnection())
            {
                try
                {
                    var cmd = BuildIntCommand(conn, storedProcName, dataParams);
                    rowsAffected = cmd.ExecuteNonQuery();
                    iResult = (int)cmd.Parameters["ReturnValue"].Value;
                }
                catch (Exception ex)
                {
                    throw new Exception("执行存储过程异常:" + ex.Message);
                }
            }
            return iResult;
        }


        /// <summary>
        /// 创建SQLiteCommand对象实例（用来返回一个整数值）
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="storedProcName"></param>
        /// <param name="dataParams"></param>
        /// <returns></returns>
        private static SQLiteCommand BuildIntCommand(SQLiteConnection conn, string storedProcName, IDataParameter[] dataParams)
        {
            var cmd = BuildQueryCommand(conn, storedProcName, dataParams);
            cmd.Parameters.Add(new SQLiteParameter("ReturnValue", DbType.Int32, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return cmd;
        }

        /// <summary>
        /// 构建SqliteCommand对象（用来返回一个结果集，而不是一个整数值）
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="storedProcName"></param>
        /// <param name="dataParams"></param>
        /// <returns></returns>
        private static SQLiteCommand BuildQueryCommand(SQLiteConnection conn, string storedProcName, IDataParameter[] dataParams)
        {
            var cmd = new SQLiteCommand(storedProcName, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var param in dataParams)
                {
                    cmd.Parameters.Add(param);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("构建SQLiteCommand异常:" + ex.Message);
            }
            return cmd;
        }

        #endregion  存储过程
    }
}
