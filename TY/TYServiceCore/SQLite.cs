using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace TYServiceCore
{
    public class SQLite
    {
        public SQLite()
        {
            //解析程序集失败的时候调用加载资源文件中的dll, 这句必须写在构造里面 InitializeComponent之前.
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }
        /// <summary>
        /// 读取资源中的dll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string dllName = args.Name.Contains(",") ? args.Name.Substring(0, args.Name.IndexOf(',')) : args.Name.Replace(".dll", "");
            dllName = dllName.Replace(".", "_");
            if (dllName.EndsWith("_resources")) return null;
            System.Resources.ResourceManager rm = new System.Resources.ResourceManager(GetType().Namespace + ".Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());
            byte[] bytes = (byte[])rm.GetObject(dllName);
            return System.Reflection.Assembly.Load(bytes);
        }
        /// <summary>
        /// 数据库
        /// </summary>
        public static string dataBasePath;

        public static string dataBasePasssord;

        /// <summary>
        /// 获取连接
        /// </summary>
        /// <returns></returns>
        private static SQLiteConnection GetSQLiteConnection()
        {
            SQLiteConnection conn = null;
            try
            {
                conn = new SQLiteConnection();
                SQLiteConnectionStringBuilder connStr = new SQLiteConnectionStringBuilder
                {
                    DataSource = dataBasePath,
                    Password = dataBasePasssord
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
            int iResult = -1;
            using (SQLiteConnection conn = GetSQLiteConnection())
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
            int iResult = -1;
            using (SQLiteConnection conn = GetSQLiteConnection())
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    try
                    {
                        SqlParameter parameter = new SqlParameter("@content", SqlDbType.NText)
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
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public static int ExecuteSql(string sql, params SqlParameter[] sqlParams)
        {
            int iResult = -1;
            using (SQLiteConnection conn = GetSQLiteConnection())
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
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
            DataSet dsResult = null;
            using (SQLiteConnection conn = GetSQLiteConnection())
            {
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn))
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
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public static DataSet Query(string sql, params SqlParameter[] sqlParams)
        {
            DataSet dsResult = null;
            using (SQLiteConnection conn = GetSQLiteConnection())
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
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
            object oResult = null;
            using (SQLiteConnection conn = GetSQLiteConnection())
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
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
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public static object GetSingle(string sql, params SqlParameter[] sqlParams)
        {
            object oResult = null;
            using (SQLiteConnection conn = GetSQLiteConnection())
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
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
            using (SQLiteConnection conn = GetSQLiteConnection())
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
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteSqlTran(List<string> sqlList)
        {
            int iResult = -1;
            using (SQLiteConnection conn = GetSQLiteConnection())
            {
                using (SQLiteTransaction tran = conn.BeginTransaction())
                {
                    using (SQLiteCommand cmd = new SQLiteCommand())
                    {
                        try
                        {
                            conn.Open();
                            cmd.Connection = conn;
                            cmd.Transaction = tran;
                            foreach (string sql in sqlList)
                            {
                                if (!string.IsNullOrEmpty(sql))
                                {
                                    cmd.CommandText = sql;
                                    iResult += cmd.ExecuteNonQuery();
                                }
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
            using (SQLiteConnection conn = GetSQLiteConnection())
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
                                SqlParameter[] cmdParams = (SqlParameter[])de.Value;
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
            int iResult = -1;
            using (SQLiteConnection conn = GetSQLiteConnection())
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    try
                    {
                        SqlParameter sqlParam = new SqlParameter("@fs", SqlDbType.Image)
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

        private static void PrepareCommand(SQLiteConnection conn, SQLiteCommand cmd, SQLiteTransaction tran, string sql, SqlParameter[] sqlParams)
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
                foreach (SqlParameter param in sqlParams)
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
            SQLiteDataReader rResult = null;
            using (SQLiteConnection conn = GetSQLiteConnection())
            {
                using (SQLiteCommand cmd = BuildQueryCommand(conn, storedProcName, dataParams))
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
            DataSet dsResult = null;
            using (SQLiteConnection conn = GetSQLiteConnection())
            {
                using (SQLiteDataAdapter da = new SQLiteDataAdapter())
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
            int iResult = -1;
            using (SQLiteConnection conn = GetSQLiteConnection())
            {
                try
                {
                    SQLiteCommand cmd = BuildIntCommand(conn, storedProcName, dataParams);
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
            SQLiteCommand cmd = BuildQueryCommand(conn, storedProcName, dataParams);
            cmd.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
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
            SQLiteCommand cmd = new SQLiteCommand(storedProcName, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter param in dataParams)
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
