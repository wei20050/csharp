using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Objects.DataClasses;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;


namespace TYDB
{
    /// <summary>
    /// 数据库操作类
    /// </summary>
    public class DbHelper
    {
        /// <summary>
        /// 带连接字符串名称的构造
        /// </summary>
        /// <param name="dbConnectionName">数据库连接字符串Name</param>
        public DbHelper(string dbConnectionName)
        {
            var cm = ConfigurationManager.ConnectionStrings[dbConnectionName];
            var pn = cm.ProviderName.ToLower();
            if (pn.Contains("sqlite"))
            {
                _mDbType = DbType.Sqlite;
            }
            else if (pn.Contains("mysql"))
            {
                _mDbType = DbType.Mysql;
            }
            else if (pn.Contains("mssql"))
            {
                _mDbType = DbType.Mssql;
            }
            else if (pn.Contains("oracle"))
            {
                _mDbType = DbType.Oracle;
            }
            else
            {
                _mDbType = DbType.Sqlite;
            }
            _mConnectionString = cm.ToString();
            _mParameterMark = GetParameterMark();
        }
        private enum DbType
        {
            Sqlite = 0,
            Mysql = 1,
            Mssql = 2,
            Oracle = 3
        }
        #region 变量

        /// <summary>
        /// 数据库类型
        /// </summary>
        private readonly DbType _mDbType;

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private readonly string _mConnectionString;
        /// <summary>
        /// 事务
        /// </summary>
        [ThreadStatic]
        private static DbTransaction _mTran;
        /// <summary>
        /// 带参数的SQL插入和修改语句中，参数前面的符号
        /// </summary>
        private readonly string _mParameterMark;
        #endregion

        #region 生成变量
        #region 生成 IDbCommand
        /// <summary>
        /// 生成 IDbCommand
        /// </summary>
        private DbCommand GetCommand()
        {
            DbCommand command;
            switch (_mDbType)
            {
                case DbType.Oracle:
#pragma warning disable 618
                    command = new OracleCommand();
#pragma warning restore 618
                    break;
                case DbType.Mssql:
                    command = new SqlCommand();
                    break;
                case DbType.Mysql:
                    command = new MySqlCommand();
                    break;
                case DbType.Sqlite:
                    command = new SQLiteCommand();
                    break;
                default:
                    command = new SQLiteCommand();
                    break;
            }
            return command;
        }
        /// <summary>
        /// 生成 IDbCommand
        /// </summary>
        private DbCommand GetCommand(string sql, DbConnection conn)
        {
            DbCommand command;
            switch (_mDbType)
            {
                case DbType.Oracle:
#pragma warning disable 618
                    command = new OracleCommand(sql);
#pragma warning restore 618
                    break;
                case DbType.Mssql:
                    command = new SqlCommand(sql);
                    break;
                case DbType.Mysql:
                    command = new MySqlCommand(sql);
                    break;
                case DbType.Sqlite:
                    command = new SQLiteCommand(sql);
                    break;
                default:
                    command = new SQLiteCommand(sql);
                    break;
            }
            command.Connection = conn;
            return command;
        }
        #endregion

        #region 生成 IDbConnection
        /// <summary>
        /// 生成 IDbConnection
        /// </summary>
        private DbConnection GetConnection()
        {
            DbConnection conn;
            switch (_mDbType)
            {
                case DbType.Oracle:
#pragma warning disable 618
                    conn = new OracleConnection(_mConnectionString);
#pragma warning restore 618
                    break;
                case DbType.Mssql:
                    conn = new SqlConnection(_mConnectionString);
                    break;
                case DbType.Mysql:
                    conn = new MySqlConnection(_mConnectionString);
                    break;
                case DbType.Sqlite:
                    conn = new SQLiteConnection(_mConnectionString);
                    break;
                default:
                    conn = new SQLiteConnection(_mConnectionString);
                    break;
            }
            return conn;
        }
        #endregion

        #region 生成 IDbDataAdapter
        /// <summary>
        /// 生成 IDbDataAdapter
        /// </summary>
        private DbDataAdapter GetDataAdapter(DbCommand cmd)
        {
            DbDataAdapter dataAdapter;

            switch (_mDbType)
            {
                case DbType.Oracle:
#pragma warning disable 618
                    dataAdapter = new OracleDataAdapter();
#pragma warning restore 618
                    break;
                case DbType.Mssql:
                    dataAdapter = new SqlDataAdapter();
                    break;
                case DbType.Mysql:
                    dataAdapter = new MySqlDataAdapter();
                    break;
                case DbType.Sqlite:
                    dataAdapter = new SQLiteDataAdapter();
                    break;
                default:
                    dataAdapter = new SQLiteDataAdapter();
                    break;
            }
            dataAdapter.SelectCommand = cmd;
            return dataAdapter;
        }
        #endregion

        #region 生成 m_ParameterMark
        /// <summary>
        /// 生成 m_ParameterMark
        /// </summary>
        private string GetParameterMark()
        {
            switch (_mDbType)
            {
                case DbType.Oracle:
                    return ":";
                case DbType.Mssql:
                    return "@";
                case DbType.Mysql:
                    return "@";
                case DbType.Sqlite:
                    return ":";
                default:
                    return ":";
            }
        }
        #endregion

        #region 生成 DbParameter
        /// <summary>
        /// 生成 DbParameter
        /// </summary>
        private DbParameter GetDbParameter(string name, object vallue)
        {
            DbParameter dbParameter;

            switch (_mDbType)
            {
                case DbType.Oracle:
                    dbParameter = new OracleParameter(name, vallue);
                    break;
                case DbType.Mssql:
                    dbParameter = new SqlParameter(name, vallue);
                    break;
                case DbType.Mysql:
                    dbParameter = new MySqlParameter(name, vallue);
                    break;
                case DbType.Sqlite:
                    dbParameter = new SQLiteParameter(name, vallue);
                    break;
                default:
                    dbParameter = new SQLiteParameter(name, vallue);
                    break;
            }

            return dbParameter;
        }
        #endregion
        #endregion

        #region 基础方法
        #region  执行简单SQL语句
        #region Exists
        public bool Exists(string sqlString)
        {
            SqlFilter(ref sqlString);
            using (var conn = GetConnection())
            {
                using (var cmd = GetCommand(sqlString, conn))
                {
                    try
                    {
                        conn.Open();
                        var obj = cmd.ExecuteScalar();
                        return !Equals(obj, null) && !Equals(obj, DBNull.Value);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        return false;
                    }
                    finally
                    {
                        cmd.Dispose();
                        conn.Close();
                    }
                }
            }
        }
        #endregion

        #region 执行SQL语句，返回影响的记录数
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="sqlString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public int ExecuteSql(string sqlString)
        {
            SqlFilter(ref sqlString);
            var conn = _mTran == null ? GetConnection() : _mTran.Connection;
            using (var cmd = GetCommand(sqlString, conn))
            {
                try
                {
                    if (conn.State != ConnectionState.Open) conn.Open();
                    if (_mTran != null) cmd.Transaction = _mTran;
                    var rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    cmd.Dispose();
                    if (_mTran == null) conn.Close();
                }
            }
        }
        #endregion

        #region 执行一条计算查询结果语句，返回查询结果
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）
        /// </summary>
        /// <param name="sqlString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public object GetSingle(string sqlString)
        {
            SqlFilter(ref sqlString);
            using (var conn = GetConnection())
            {
                using (var cmd = GetCommand(sqlString, conn))
                {
                    try
                    {
                        if (conn.State != ConnectionState.Open) conn.Open();
                        var obj = cmd.ExecuteScalar();
                        if (Equals(obj, null) || Equals(obj, DBNull.Value))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        return false;
                    }
                    finally
                    {
                        cmd.Dispose();
                    }
                }
            }
        }
        #endregion

        #region 执行查询语句，返回IDataReader
        /// <summary>
        /// 执行查询语句，返回IDataReader ( 注意：调用该方法后，一定要对IDataReader进行Close )
        /// </summary>
        /// <param name="sqlString">查询语句</param>
        /// <returns>IDataReader</returns>
        public DbDataReader ExecuteReader(string sqlString)
        {
            SqlFilter(ref sqlString);
            var conn = GetConnection();
            var cmd = GetCommand(sqlString, conn);
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                var myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return myReader;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        #endregion

        #region 执行查询语句，返回DataSet
        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="sqlString">查询语句</param>
        /// <returns>DataSet</returns>
        public DataSet Query(string sqlString)
        {
            SqlFilter(ref sqlString);
            using (var conn = GetConnection())
            {
                var ds = new DataSet();
                try
                {
                    conn.Open();
                    using (var cmd = GetCommand(sqlString, conn))
                    {
                        var adapter = GetDataAdapter(cmd);
                        adapter.Fill(ds, "ds");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    conn.Close();
                }
                return ds;
            }
        }
        #endregion

        #region SQL过滤，防注入
        /// <summary>
        /// SQL过滤，防注入
        /// </summary>
        /// <param name="sql">sql</param>
        public void SqlFilter(ref string sql)
        {
            var keywordList = new List<string>
            {
                "net localgroup",
                "net user",
                "xp_cmdshell",
                "exec",
                "execute",
                "truncate",
                "drop",
                "restore",
                "create",
                "alter",
                "rename",
                "insert",
                "update",
                "delete",
                "select"};
            var ignore = string.Empty;
            var upperSql = sql.ToUpper().Trim();
            foreach (var keyword in keywordList)
            {
                if (upperSql.IndexOf(keyword.ToUpper(), StringComparison.Ordinal) == 0)
                {
                    ignore = keyword;
                }
            }
            sql = (from keyword in keywordList where !string.Equals(ignore, keyword, StringComparison.CurrentCultureIgnoreCase) select new Regex(keyword, RegexOptions.IgnoreCase)).Aggregate(sql, (current, regex) => regex.Replace(current, string.Empty));
        }
        #endregion
        #endregion

        #region 执行带参数的SQL语句
        #region 执行SQL语句，返回影响的记录数

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="sqlString">SQL语句</param>
        /// <param name="cmdParms">参数</param>
        /// <returns>影响的记录数</returns>
        public int ExecuteSql(string sqlString, params DbParameter[] cmdParms)
        {
            var conn = _mTran == null ? GetConnection() : _mTran.Connection;
            using (var cmd = GetCommand())
            {
                try
                {
                    PrepareCommand(cmd, conn, _mTran, sqlString, cmdParms);
                    var rows = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return rows;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return 0;
                }
                finally
                {
                    cmd.Dispose();
                    if (_mTran == null) conn.Close();
                }
            }
        }
        #endregion

        #region 执行查询语句，返回IDataReader

        /// <summary>
        /// 执行查询语句，返回IDataReader ( 注意：调用该方法后，一定要对IDataReader进行Close )
        /// </summary>
        /// <param name="sqlString">查询语句</param>
        /// <param name="cmdParms">参数</param>
        /// <returns>IDataReader</returns>
        public DbDataReader ExecuteReader(string sqlString, params DbParameter[] cmdParms)
        {
            var conn = GetConnection();
            var cmd = GetCommand();
            try
            {
                PrepareCommand(cmd, conn, null, sqlString, cmdParms);
                var myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }
        #endregion

        #region 执行查询语句，返回DataSet

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="sqlString">查询语句</param>
        /// <param name="cmdParms">参数</param>
        /// <returns>DataSet</returns>
        public DataSet Query(string sqlString, params DbParameter[] cmdParms)
        {
            var conn = GetConnection();
            var cmd = GetCommand();
            PrepareCommand(cmd, conn, null, sqlString, cmdParms);
            using (var da = GetDataAdapter(cmd))
            {
                var ds = new DataSet();
                try
                {
                    da.Fill(ds, "ds");
                    cmd.Parameters.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
                return ds;
            }
        }
        #endregion

        #region PrepareCommand
        private void PrepareCommand(DbCommand cmd, DbConnection conn, DbTransaction trans, string cmdText, DbParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open) conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null) cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;
            if (cmdParms == null) return;
            foreach (var parm in cmdParms)
            {
                cmd.Parameters.Add(parm);
            }
        }
        #endregion
        #endregion
        #endregion

        #region 增删改查
        #region 获取最大编号
        /// <summary>
        /// 获取最大编号
        /// </summary>
        /// <typeparam name="T">实体Model</typeparam>
        /// <param name="key">主键</param>
        public int GetMaxId<T>(string key)
        {
            var type = typeof(T);
            var sql = _mDbType.Equals(DbType.Sqlite) ? $"SELECT Max(cast({key} as int)) FROM {type.Name}" : $"SELECT Max({key}) FROM {type.Name}";
            using (var conn = GetConnection())
            {
                using (IDbCommand cmd = GetCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();
                        var obj = cmd.ExecuteScalar();
                        if (Equals(obj, null) || Equals(obj, DBNull.Value))
                        {
                            return 1;
                        }
                        else
                        {
                            return int.Parse(obj.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        return 1;
                    }
                    finally
                    {
                        cmd.Dispose();
                        conn.Close();
                    }
                }
            }
        }
        #endregion

        #region 添加

        /// <summary>
        /// 添加
        /// </summary>
        public void Insert(object obj)
        {
            var strSql = new StringBuilder();
            var type = obj.GetType();
            strSql.Append($"insert into {type.Name}(");

            var propertyInfoList = GetEntityProperties(type);
            var propertyNameList = new List<string>();
            var savedCount = 0;
            foreach (var propertyInfo in propertyInfoList)
            {
                if (propertyInfo.GetCustomAttributes(typeof(IsDBFieldAttribute), false).Length <= 0) continue;
                propertyNameList.Add(propertyInfo.Name);
                savedCount++;
            }

            strSql.Append($"{string.Join(",", propertyNameList.ToArray())})");
            strSql.Append(
                $" values ({string.Join(",", propertyNameList.ConvertAll(a => _mParameterMark + a).ToArray())})");
            var parameters = new DbParameter[savedCount];
            var k = 0;
            for (var i = 0; i < propertyInfoList.Length && savedCount > 0; i++)
            {
                var propertyInfo = propertyInfoList[i];
                if (propertyInfo.GetCustomAttributes(typeof(IsDBFieldAttribute), false).Length <= 0) continue;
                var val = propertyInfo.GetValue(obj, null);
                var param = GetDbParameter(_mParameterMark + propertyInfo.Name, val ?? DBNull.Value);
                parameters[k++] = param;
            }
            ExecuteSql(strSql.ToString(), parameters);
        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改
        /// </summary>
        public void Update(object obj)
        {
            var oldObj = Find(obj);
            if (oldObj == null) throw new Exception("无法获取到旧数据");

            var strSql = new StringBuilder();
            var type = obj.GetType();
            strSql.Append($"update {type.Name} ");

            var propertyInfoList = GetEntityProperties(type);
            var savedCount = 0;
            foreach (var propertyInfo in propertyInfoList)
            {
                if (propertyInfo.GetCustomAttributes(typeof(IsDBFieldAttribute), false).Length <= 0) continue;
                var oldVal = propertyInfo.GetValue(oldObj, null);
                var val = propertyInfo.GetValue(obj, null);
                if (Equals(oldVal, val)) continue;
                new List<string>().Add(propertyInfo.Name);
                savedCount++;
            }

            strSql.Append(" set ");
            var parameters = new DbParameter[savedCount];
            var sbPros = new StringBuilder();
            var k = 0;
            for (var i = 0; i < propertyInfoList.Length && savedCount > 0; i++)
            {
                var propertyInfo = propertyInfoList[i];
                if (propertyInfo.GetCustomAttributes(typeof(IsDBFieldAttribute), false).Length <= 0) continue;
                var oldVal = propertyInfo.GetValue(oldObj, null);
                var val = propertyInfo.GetValue(obj, null);
                if (Equals(oldVal, val)) continue;
                sbPros.Append(string.Format(" {0}={1}{0},", propertyInfo.Name, _mParameterMark));
                var param = GetDbParameter(_mParameterMark + propertyInfo.Name, val ?? DBNull.Value);
                parameters[k++] = param;
            }
            if (sbPros.Length > 0)
            {
                strSql.Append(sbPros.ToString(0, sbPros.Length - 1));
            }
            strSql.Append($" where {GetIdName(obj.GetType())}='{GetIdVal(obj).ToString()}'");

            if (savedCount > 0)
            {
                ExecuteSql(strSql.ToString(), parameters);
            }
        }
        #endregion

        #region 删除
        /// <summary>
        /// 根据Id删除
        /// </summary>
        public void IdDelete<T>(string id)
        {
            var type = typeof(T);
            var sbSql = new StringBuilder();
            var cmdParms = new DbParameter[1];
            cmdParms[0] = GetDbParameter(_mParameterMark + GetIdName(type), id);
            sbSql.Append(string.Format("delete from {0} where {2}={1}{2}", type.Name, _mParameterMark, GetIdName(type)));

            ExecuteSql(sbSql.ToString(), cmdParms);
        }
        /// <summary>
        /// 根据Id集合删除
        /// </summary>
        public void IdBatchDelete<T>(string ids)
        {
            if (string.IsNullOrWhiteSpace(ids)) return;

            var type = typeof(T);
            var sbSql = new StringBuilder();
            var idArr = ids.Split(',');
            var cmdParms = new DbParameter[idArr.Length];
            sbSql.AppendFormat("delete from {0} where {1} in (", type.Name, GetIdName(type));
            for (var i = 0; i < idArr.Length; i++)
            {
                cmdParms[i] = GetDbParameter(_mParameterMark + GetIdName(type) + i, idArr[i]);
                sbSql.AppendFormat("{0}{1}{2},", _mParameterMark, GetIdName(type), i);
            }
            sbSql.Remove(sbSql.Length - 1, 1);
            sbSql.Append(")");

            ExecuteSql(sbSql.ToString(), cmdParms);
        }
        /// <summary>
        /// 根据条件删除
        /// </summary>
        public void Delete<T>(string conditions)
        {
            if (string.IsNullOrWhiteSpace(conditions)) return;

            var type = typeof(T);
            var sbSql = new StringBuilder();
            SqlFilter(ref conditions);
            sbSql.Append($"delete from {type.Name} where {conditions}");

            ExecuteSql(sbSql.ToString());
        }
        #endregion

        #region 获取实体
        #region 根据实体获取实体
        /// <summary>
        /// 根据实体获取实体
        /// </summary>
        private object Find(object obj)
        {
            var type = obj.GetType();

            var result = Activator.CreateInstance(type);
            var hasValue = false;
            IDataReader rd = null;

            var sql = string.Format("select * from {0} where {2}='{1}'", type.Name, GetIdVal(obj), GetIdName(obj.GetType()));

            try
            {
                rd = ExecuteReader(sql);

                var propertyInfoList = GetEntityProperties(type);

                var fcnt = rd.FieldCount;
                var fileds = new List<string>();
                for (var i = 0; i < fcnt; i++)
                {
                    fileds.Add(rd.GetName(i).ToUpper());
                }

                while (rd.Read())
                {
                    hasValue = true;
                    IDataRecord record = rd;

                    foreach (var pro in propertyInfoList)
                    {
                        if (!fileds.Contains(pro.Name.ToUpper()) || record[pro.Name] == DBNull.Value)
                        {
                            continue;
                        }

                        pro.SetValue(result, record[pro.Name] == DBNull.Value ? null : GetReaderValue(record[pro.Name], pro.PropertyType), null);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (rd != null && !rd.IsClosed)
                {
                    rd.Close();
                    rd.Dispose();
                }
            }
            return hasValue ? result : null;
        }
        #endregion

        #region 根据Id获取实体
        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        public T FindById<T>(string id) where T : new()
        {
            var type = typeof(T);
            var result = (T)Activator.CreateInstance(type);
            IDataReader rd = null;
            var hasValue = false;

            var sql = string.Format("select * from {0} where {2}='{1}'", type.Name, id, GetIdName(type));

            try
            {
                rd = ExecuteReader(sql);

                var propertyInfoList = GetEntityProperties(type);

                var fcnt = rd.FieldCount;
                var fileds = new List<string>();
                for (var i = 0; i < fcnt; i++)
                {
                    fileds.Add(rd.GetName(i).ToUpper());
                }

                while (rd.Read())
                {
                    hasValue = true;
                    IDataRecord record = rd;

                    foreach (var pro in propertyInfoList)
                    {
                        if (!fileds.Contains(pro.Name.ToUpper()) || record[pro.Name] == DBNull.Value)
                        {
                            continue;
                        }

                        pro.SetValue(result, record[pro.Name] == DBNull.Value ? null : GetReaderValue(record[pro.Name], pro.PropertyType), null);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (rd != null && !rd.IsClosed)
                {
                    rd.Close();
                    rd.Dispose();
                }
            }

            return hasValue ? result : default(T);
        }
        #endregion

        #region 根据sql获取实体
        /// <summary>
        /// 根据sql获取实体
        /// </summary>
        public T FindBySql<T>(string sql) where T : new()
        {
            var type = typeof(T);
            var result = (T)Activator.CreateInstance(type);
            IDataReader rd = null;
            var hasValue = false;

            try
            {
                rd = ExecuteReader(sql);

                var propertyInfoList = GetEntityProperties(type);

                var fcnt = rd.FieldCount;
                var fileds = new List<string>();
                for (var i = 0; i < fcnt; i++)
                {
                    fileds.Add(rd.GetName(i).ToUpper());
                }

                while (rd.Read())
                {
                    hasValue = true;
                    IDataRecord record = rd;

                    foreach (var pro in propertyInfoList)
                    {
                        if (!fileds.Contains(pro.Name.ToUpper()) || record[pro.Name] == DBNull.Value)
                        {
                            continue;
                        }

                        pro.SetValue(result, record[pro.Name] == DBNull.Value ? null : GetReaderValue(record[pro.Name], pro.PropertyType), null);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (rd != null && !rd.IsClosed)
                {
                    rd.Close();
                    rd.Dispose();
                }
            }

            return hasValue ? result : default(T);
        }
        #endregion
        #endregion

        #region 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        public List<T> FindListBySql<T>(string sql) where T : new()
        {
            var list = new List<T>();
            IDataReader rd = null;

            try
            {
                rd = ExecuteReader(sql);

                if (typeof(T) == typeof(int))
                {
                    while (rd.Read())
                    {
                        list.Add((T)rd[0]);
                    }
                }
                else if (typeof(T) == typeof(string))
                {
                    while (rd.Read())
                    {
                        list.Add((T)rd[0]);
                    }
                }
                else
                {
                    var propertyInfoList = (typeof(T)).GetProperties();

                    var fcnt = rd.FieldCount;
                    var fileds = new List<string>();
                    for (var i = 0; i < fcnt; i++)
                    {
                        fileds.Add(rd.GetName(i).ToUpper());
                    }

                    while (rd.Read())
                    {
                        IDataRecord record = rd;
                        object obj = new T();


                        foreach (var pro in propertyInfoList)
                        {
                            if (!fileds.Contains(pro.Name.ToUpper()) || record[pro.Name] == DBNull.Value)
                            {
                                continue;
                            }

                            pro.SetValue(obj, record[pro.Name] == DBNull.Value ? null : GetReaderValue(record[pro.Name], pro.PropertyType), null);
                        }
                        list.Add((T)obj);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (rd != null && !rd.IsClosed)
                {
                    rd.Close();
                    rd.Dispose();
                }
            }

            return list;
        }
        #endregion

        #region 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        public List<T> FindListBySql<T>(string sql, params DbParameter[] cmdParms) where T : new()
        {
            var list = new List<T>();
            IDataReader rd = null;

            try
            {
                rd = ExecuteReader(sql, cmdParms);

                if (typeof(T) == typeof(int))
                {
                    while (rd.Read())
                    {
                        list.Add((T)rd[0]);
                    }
                }
                else if (typeof(T) == typeof(string))
                {
                    while (rd.Read())
                    {
                        list.Add((T)rd[0]);
                    }
                }
                else
                {
                    var propertyInfoList = (typeof(T)).GetProperties();

                    var fcnt = rd.FieldCount;
                    var fileds = new List<string>();
                    for (var i = 0; i < fcnt; i++)
                    {
                        fileds.Add(rd.GetName(i).ToUpper());
                    }

                    while (rd.Read())
                    {
                        IDataRecord record = rd;
                        object obj = new T();


                        foreach (var pro in propertyInfoList)
                        {
                            if (!fileds.Contains(pro.Name.ToUpper()) || record[pro.Name] == DBNull.Value)
                            {
                                continue;
                            }

                            pro.SetValue(obj, record[pro.Name] == DBNull.Value ? null : GetReaderValue(record[pro.Name], pro.PropertyType), null);
                        }
                        list.Add((T)obj);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (rd != null && !rd.IsClosed)
                {
                    rd.Close();
                    rd.Dispose();
                }
            }

            return list;
        }
        #endregion
        #region 分页语句拼接

        private string GetPageSql(string sql, string orderby, int pageSize, int currentPage)
        {
            var sb = new StringBuilder();
            int startRow;
            int endRow;
            switch (_mDbType)
            {
                case DbType.Oracle:

                    #region 分页查询语句

                    startRow = pageSize * (currentPage - 1);
                    endRow = startRow + pageSize;

                    sb.Append("select * from ( select row_limit.*, rownum rownum_ from (");
                    sb.Append(sql);
                    if (!string.IsNullOrWhiteSpace(orderby))
                    {
                        sb.Append(" ");
                        sb.Append(orderby);
                    }
                    sb.Append(" ) row_limit where rownum <= ");
                    sb.Append(endRow);
                    sb.Append(" ) where rownum_ >");
                    sb.Append(startRow);

                    #endregion

                    break;
                case DbType.Mssql:

                    #region 分页查询语句

                    startRow = pageSize * (currentPage - 1) + 1;
                    endRow = startRow + pageSize - 1;

                    sb.Append(string.Format(@"
                            select * from 
                            (select ROW_NUMBER() over({1}) as rowNumber, t.* from ({0}) t) tempTable
                            where rowNumber between {2} and {3} ", sql, orderby, startRow, endRow));

                    #endregion

                    break;
                case DbType.Mysql:

                    #region 分页查询语句

                    startRow = pageSize * (currentPage - 1);

                    sb.Append(sql);
                    if (!string.IsNullOrWhiteSpace(orderby))
                    {
                        sb.Append(" ");
                        sb.Append(orderby);
                    }
                    sb.AppendFormat(" limit {0},{1}", startRow, pageSize);

                    #endregion

                    break;
                case DbType.Sqlite:
                    #region 分页查询语句

                    startRow = pageSize * (currentPage - 1);

                    sb.Append(sql);
                    if (!string.IsNullOrWhiteSpace(orderby))
                    {
                        sb.Append(" ");
                        sb.Append(orderby);
                    }
                    sb.AppendFormat(" limit {0} offset {1}", pageSize, startRow);

                    #endregion
                    break;
                default:
                    #region 分页查询语句

                    startRow = pageSize * (currentPage - 1);

                    sb.Append(sql);
                    if (!string.IsNullOrWhiteSpace(orderby))
                    {
                        sb.Append(" ");
                        sb.Append(orderby);
                    }
                    sb.AppendFormat(" limit {0} offset {1}", pageSize, startRow);

                    #endregion
                    break;
            }
            return sb.ToString();
        }

        #endregion

        #region 分页获取列表
        /// <summary>
        /// 分页(任意entity，尽量少的字段)
        /// </summary>
        public PagerModel FindPageBySql<T>(string sql, string orderby, int pageSize, int currentPage) where T : new()
        {
            var pagerModel = new PagerModel(currentPage, pageSize);

            using (var connection = GetConnection())
            {
                connection.Open();
                var commandText = $"select count(*) from ({sql}) T";
                IDbCommand cmd = GetCommand(commandText, connection);
                pagerModel.totalRows = int.Parse(cmd.ExecuteScalar().ToString());
                var list = FindListBySql<T>(GetPageSql(sql, orderby, pageSize, currentPage));
                pagerModel.result = list;
            }

            return pagerModel;
        }
        #endregion

        #region 分页获取列表
        /// <summary>
        /// 分页(任意entity，尽量少的字段)
        /// </summary>
        /// <returns></returns>
        public PagerModel FindPageBySql<T>(string sql, string orderby, int pageSize, int currentPage, params DbParameter[] cmdParms) where T : new()
        {
            var pagerModel = new PagerModel(currentPage, pageSize);

            using (var connection = GetConnection())
            {
                connection.Open();
                var commandText = $"select count(*) from ({sql}) T";
                IDbCommand cmd = GetCommand(commandText, connection);
                pagerModel.totalRows = int.Parse(cmd.ExecuteScalar().ToString());
                var list = FindListBySql<T>(GetPageSql(sql, orderby, pageSize, currentPage), cmdParms);
                pagerModel.result = list;
            }

            return pagerModel;
        }


        #endregion

        #region 分页获取列表
        /// <summary>
        /// 分页(任意entity，尽量少的字段)
        /// </summary>
        public DataSet FindPageBySql(string sql, string orderby, int pageSize, int currentPage, out int totalCount, params DbParameter[] cmdParms)
        {
            DataSet ds;
            using (var connection = GetConnection())
            {
                connection.Open();
                var commandText = $"select count(*) from ({sql}) T";
                IDbCommand cmd = GetCommand(commandText, connection);
                totalCount = int.Parse(cmd.ExecuteScalar().ToString());
                ds = Query(GetPageSql(sql, orderby, pageSize, currentPage), cmdParms);
            }
            return ds;
        }
        #endregion

        #region getReaderValue 转换数据
        /// <summary>
        /// 转换数据
        /// </summary>
        private static object GetReaderValue(object rdValue, Type ptype)
        {
            if (ptype == typeof(double))
                return Convert.ToDouble(rdValue);

            if (ptype == typeof(decimal))
                return Convert.ToDecimal(rdValue);

            if (ptype == typeof(int))
                return Convert.ToInt32(rdValue);

            if (ptype == typeof(long))
                return Convert.ToInt64(rdValue);

            if (ptype == typeof(DateTime))
                return Convert.ToDateTime(rdValue);

            if (ptype == typeof(double?))
                return Convert.ToDouble(rdValue);

            if (ptype == typeof(decimal?))
                return Convert.ToDecimal(rdValue);

            if (ptype == typeof(int?))
                return Convert.ToInt32(rdValue);

            if (ptype == typeof(long?))
                return Convert.ToInt64(rdValue);

            return ptype == typeof(DateTime?) ? Convert.ToDateTime(rdValue) : rdValue;
        }
        #endregion

        #region 获取主键名称
        /// <summary>
        /// 获取主键名称
        /// </summary>
        public string GetIdName(Type type)
        {
            var propertyInfoList = GetEntityProperties(type);
            foreach (var propertyInfo in propertyInfoList)
            {
                if (propertyInfo.GetCustomAttributes(typeof(IsIdAttribute), false).Length > 0)
                {
                    return propertyInfo.Name;
                }
            }
            return "Id";
        }
        #endregion

        #region 获取主键值
        /// <summary>
        /// 获取主键名称
        /// </summary>
        public object GetIdVal(object val)
        {
            var idName = GetIdName(val.GetType());
            return !string.IsNullOrWhiteSpace(idName) ? val.GetType().GetProperty(idName)?.GetValue(val, null) : 0;
        }
        #endregion

        #region 获取实体类属性
        /// <summary>
        /// 获取实体类属性
        /// </summary>
        private static PropertyInfo[] GetEntityProperties(Type type)
        {
            var propertyInfoList = type.GetProperties();
            return propertyInfoList.Where(propertyInfo => propertyInfo.GetCustomAttributes(typeof(EdmRelationshipNavigationPropertyAttribute), false).Length == 0 && propertyInfo.GetCustomAttributes(typeof(BrowsableAttribute), false).Length == 0).ToArray();
        }
        #endregion

        #region 获取基类
        /// <summary>
        /// 获取基类
        /// </summary>
        public static Type GetBaseType(Type type)
        {
            while (type.BaseType != null && type.BaseType.Name != typeof(object).Name)
            {
                type = type.BaseType;
            }
            return type;
        }
        #endregion
        #endregion

        #region 事务
        #region 开始事务
        /// <summary>
        /// 开始事务
        /// </summary>
        public void BeginTransaction()
        {
            var conn = GetConnection();
            if (conn.State != ConnectionState.Open) conn.Open();
            _mTran = conn.BeginTransaction();
        }
        #endregion

        #region 提交事务
        /// <summary>
        /// 提交事务
        /// </summary>
        public void CommitTransaction()
        {
            if (_mTran == null) return; //防止重复提交
            var conn = _mTran.Connection;
            try
            {
                _mTran.Commit();
            }
            catch (Exception ex)
            {
                _mTran.Rollback();
                Console.WriteLine(ex);
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                _mTran.Dispose();
                _mTran = null;
            }
        }
        #endregion

        #region 回滚事务(出错时调用该方法回滚)
        /// <summary>
        /// 回滚事务(出错时调用该方法回滚)
        /// </summary>
        public void RollbackTransaction()
        {
            if (_mTran == null) return; //防止重复回滚
            var conn = _mTran.Connection;
            _mTran.Rollback();
            if (conn.State == ConnectionState.Open) conn.Close();
        }
        #endregion
        #endregion
    }
}
