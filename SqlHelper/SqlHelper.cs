using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;//sqlserver
using System.Data.SQLite;//sqlite
using MySql.Data;
using MySql.Data.MySqlClient;//mysql
using System.Data.OleDb;//access.mdb
using System.Data.OracleClient;//oracle

namespace SqlHelper
{
    class SqlHelper
    {
        #region 定义数据库链接字符串 //在这里做一个远程的修改
        private static readonly string _connMySql = ConfigurationManager.ConnectionStrings["connMySql"].ConnectionString;
        private static readonly string _connSqlite = ConfigurationManager.ConnectionStrings["connSqlite"].ConnectionString;
        private static readonly string _connAccess = ConfigurationManager.ConnectionStrings["connAccess"].ConnectionString;
        private static readonly string _connOracle = ConfigurationManager.ConnectionStrings["connOracle"].ConnectionString;
        private static readonly string _connSQLServer = ConfigurationManager.ConnectionStrings["connSQLServer"].ConnectionString;
        #endregion

        #region 封装ExecuteNonQuery 命名规则ExecuteNonQuery+链接字符串
        /// <summary>
        /// ExecuteNonQuery_connMySql 传递非查询Sql语句，返回执行行数。参数使用@parameter
        /// </summary>
        /// <param name="cmdStr">SQL语句</param>
        /// <param name="parameters">MySqlParameter参数数组</param>
        /// <returns>int result</returns>
        public static int ExecuteNonQuery_connMySql(string cmdStr, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn_connMySql = new MySqlConnection(_connMySql))
            {
                using (MySqlCommand cmd_connMySql = conn_connMySql.CreateCommand())
                {
                    conn_connMySql.Open();
                    cmd_connMySql.CommandText = cmdStr;
                    cmd_connMySql.Parameters.AddRange(parameters);
                    return cmd_connMySql.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// ExecuteNonQuery_connSqlite 传递非查询Sql语句，返回执行行数。参数使用@parameter
        /// </summary>
        /// <param name="cmdStr">SQL语句</param>
        /// <param name="parameters">SQLiteParameter参数数组</param>
        /// <returns>int result</returns>
        public static int ExecuteNonQuery_connSqlite(string cmdStr, params SQLiteParameter[] parameters)
        {
            using (SQLiteConnection conn_connSqlite = new SQLiteConnection(_connSqlite))
            {
                using (SQLiteCommand cmd_connSqlite = conn_connSqlite.CreateCommand())
                {
                    conn_connSqlite.Open();
                    cmd_connSqlite.CommandText = cmdStr;
                    cmd_connSqlite.Parameters.AddRange(parameters);
                    return cmd_connSqlite.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// ExecuteNonQuery_connAccess 传递非查询Sql语句，返回执行行数。参数使用@parameter
        /// </summary>
        /// <param name="cmdStr">SQL语句</param>
        /// <param name="parameters">OleDbParameter参数数组</param>
        /// <returns>int result</returns>
        public static int ExecuteNonQuery_connAccess(string cmdStr, params OleDbParameter[] parameters)
        {
            using (OleDbConnection conn_connAccess = new OleDbConnection(_connAccess))
            {
                using (OleDbCommand cmd_connAccess = conn_connAccess.CreateCommand())
                {
                    conn_connAccess.Open();
                    cmd_connAccess.CommandText = cmdStr;
                    cmd_connAccess.Parameters.AddRange(parameters);
                    return cmd_connAccess.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// ExecuteNonQuery_connOracle 传递非查询Sql语句，返回执行行数。参数使用@parameter
        /// </summary>
        /// <param name="cmdStr">SQL语句</param>
        /// <param name="parameters">OracleParameter参数数组</param>
        /// <returns>int result</returns>
        public static int ExecuteNonQuery_connOracle(string cmdStr, params OracleParameter[] parameters)
        {
            using (OracleConnection conn_connOracle = new OracleConnection(_connOracle))
            {
                using (OracleCommand cmd_connOracle = conn_connOracle.CreateCommand())
                {
                    conn_connOracle.Open();
                    cmd_connOracle.CommandText = cmdStr;
                    cmd_connOracle.Parameters.AddRange(parameters);
                    return cmd_connOracle.ExecuteNonQuery();
                }
            }
            return 1;
        }
        /// <summary>
        /// ExecuteNonQuery_connSQLServer 传递非查询Sql语句，返回执行行数。参数使用@parameter
        /// </summary>
        /// <param name="cmdStr">SQL语句</param>
        /// <param name="parameters">SqlParameter参数数组</param>
        /// <returns>int result</returns>
        public static int ExecuteNonQuery_connSQLServer(string cmdStr, params SqlParameter[] parameters)
        {
            using (SqlConnection conn_connSQLServer = new SqlConnection(_connSQLServer))
            {
                using (SqlCommand cmd_connSQLServer = conn_connSQLServer.CreateCommand())
                {
                    conn_connSQLServer.Open();
                    cmd_connSQLServer.CommandText = cmdStr;
                    cmd_connSQLServer.Parameters.AddRange(parameters);
                    return cmd_connSQLServer.ExecuteNonQuery();
                }

            }
            return 1;
        }
        #endregion

        #region 封装ExecuteScalar 命名规则ExecuteScalar+连接字符串
        /// <summary>
        /// 返回MySql查询结果中第一行第一列的值 T
        /// </summary>
        /// <param name="cmdStr">SQL语句</param>
        /// <param name="parameters">MySqlParameter参数数组</param>
        /// <returns>T型结果</returns>
        public static T ExecuteScalar_connMySql<T>(string cmdStr, params MySqlParameter[] parameters)

        #region MyRegion
        //where T:new()     必须有默认构造函数
        //where T:class     必须是类
        //where T:UserInfo  必须继承自某个类
        {
            using (MySqlConnection conn_connMySql = new MySqlConnection(_connMySql))
            {
                using (MySqlCommand cmd_connMySql = conn_connMySql.CreateCommand())
                {
                    conn_connMySql.Open();
                    cmd_connMySql.CommandText = cmdStr;
                    cmd_connMySql.Parameters.AddRange(parameters);
                    return (T)cmd_connMySql.ExecuteScalar();
                }
            }
        }
        #endregion
        /// <summary>
        /// 返回SQLite查询结果中第一行第一列的值 T
        /// </summary>
        /// <typeparam name="T">Genericity</typeparam>
        /// <param name="cmdStr">SQL string</param>
        /// <param name="parameters">SQLiteParameter Array</param>
        /// <returns>Type T Result</returns>
        public static T ExecuteScalar_connSqlite<T>(string cmdStr, params SQLiteParameter[] parameters)
        {
            using (SQLiteConnection conn_connSqlite = new SQLiteConnection(_connSqlite))
            {
                using (SQLiteCommand cmd_connSqlite = conn_connSqlite.CreateCommand())
                {
                    conn_connSqlite.Open();
                    cmd_connSqlite.CommandText = cmdStr;
                    cmd_connSqlite.Parameters.AddRange(parameters);
                    return (T)cmd_connSqlite.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// 返回Access查询结果中第一行第一列的值 T
        /// </summary>
        /// <typeparam name="T">Genericity</typeparam>
        /// <param name="cmdStr">SQL string</param>
        /// <param name="parameters">OleDbParameter Array</param>
        /// <returns>Type T Result</returns>
        public static T ExecuteScalar_connAccess<T>(string cmdStr, params OleDbParameter[] parameters)
        {
            using (OleDbConnection conn_connAccess = new OleDbConnection(_connAccess))
            {
                using (OleDbCommand cmd_connAccess = conn_connAccess.CreateCommand())
                {
                    conn_connAccess.Open();
                    cmd_connAccess.CommandText = cmdStr;
                    cmd_connAccess.Parameters.AddRange(parameters);
                    return (T)cmd_connAccess.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// 返回Oracle查询中第一行第一列的值 T
        /// </summary>
        /// <typeparam name="T">genericity</typeparam>
        /// <param name="cmdStr">SQL string</param>
        /// <param name="parameters">OracleParameter array</param>
        /// <returns>Type T Result</returns>
        public static T ExecuteScalar_connOracle<T>(string cmdStr, params OracleParameter[] parameters)
        {
            using (OracleConnection conn_connOracle = new OracleConnection(_connOracle))
            {
                using (OracleCommand cmd_connOracle = conn_connOracle.CreateCommand())
                {
                    conn_connOracle.Open();
                    cmd_connOracle.CommandText = cmdStr;
                    cmd_connOracle.Parameters.AddRange(parameters);
                    return (T)cmd_connOracle.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// 返回SqlServer查询结果中第一行第一列的值 T
        /// </summary>
        /// <typeparam name="T">genericity</typeparam>
        /// <param name="cmdStr">SQL string</param>
        /// <param name="parameters">SqlParameter Array</param>
        /// <returns>Type TResult</returns>
        public static T ExecuteScalar_connSQLServer<T>(string cmdStr, params SqlParameter[] parameters)
        {
            using (SqlConnection conn_connSQLServer = new SqlConnection(_connSQLServer))
            {
                using (SqlCommand cmd_connSQLServer = conn_connSQLServer.CreateCommand())
                {
                    conn_connSQLServer.Open();
                    cmd_connSQLServer.CommandText = cmdStr;
                    cmd_connSQLServer.Parameters.AddRange(parameters);
                    return (T)cmd_connSQLServer.ExecuteScalar();
                }
            }
        }
        #endregion

        #region 封装ExecuteDataTable 命名规则封装ExecuteDataTable+连接字符串

        /// <summary>
        /// 以DataTable形式返回MySql查询结果
        /// </summary>
        /// <param name="cmdStr">SQL查询</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteDataTable_connMySql(string cmdStr, params MySqlParameter[] parameters)
        {
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmdStr, _connMySql))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// 以DataTable的形式返回SQLite查询结果
        /// </summary>
        /// <param name="cmdStr">SQL语句</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteDataTable_connSqlite(string cmdStr, params SQLiteParameter[] parameters)
        {
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmdStr, _connSqlite))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// 以DataTable的形式返回Access的查询结果
        /// </summary>
        /// <param name="cmdStr">SQL语句</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteDataTable_connAccess(string cmdStr, params OleDbParameter[] parameters)
        {
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmdStr, _connAccess))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// 以DataTable的形式返回Oracle的查询结果
        /// </summary>
        /// <param name="cmdStr">SQL语句</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteDtatTable_connOracle(string cmdStr, params OracleParameter[] parameters)
        {
            using (OracleDataAdapter adapter = new OracleDataAdapter())
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// 以DataTable的形式返回SqlServer的查询结果
        /// </summary>
        /// <param name="cmdStr">SQL语句</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteDataTable_connSQLServer(string cmdStr, params SqlParameter[] parameters)
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmdStr, _connSQLServer))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }


        #endregion

        #region 封装ExecuteReader 命名规则ExecuteReader+连接字符串
        //**DataReader要求，它读取数据的时候，他要独占connection对象，而且connection必须是open状态的

        /// <summary>
        /// 返回一个reader
        /// </summary>
        /// <param name="cmdStr">SQL语句</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>reader</returns>
        public static MySqlDataReader ExecuteReader_connMySql(string cmdStr, params MySqlParameter[] parameters)
        {
            MySqlConnection conn_connMySql = new MySqlConnection(_connMySql);
            MySqlCommand cmd_connMySql = conn_connMySql.CreateCommand();
            conn_connMySql.Open();
            cmd_connMySql.CommandText = cmdStr;
            cmd_connMySql.Parameters.AddRange(parameters);
            return cmd_connMySql.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// 返回一个reader
        /// </summary>
        /// <param name="cmdStr">SQL语句</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>reader</returns>
        public static SQLiteDataReader ExecuteReader_connSqlite(string cmdStr, params SQLiteParameter[] parameters)
        {
            SQLiteConnection conn_connSqlite = new SQLiteConnection(_connSqlite);
            SQLiteCommand cmd_connSqlite = conn_connSqlite.CreateCommand();
            conn_connSqlite.Open();
            cmd_connSqlite.CommandText = cmdStr;
            cmd_connSqlite.Parameters.AddRange(parameters);
            return cmd_connSqlite.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// 返回一个reader
        /// </summary>
        /// <param name="cmdStr">SQL语句</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>reader</returns>
        public static OleDbDataReader ExecuteReader_connAccess(string cmdStr, params OleDbParameter[] parameters)
        {
            OleDbConnection conn_connAccess = new OleDbConnection(_connAccess);
            OleDbCommand cmd_connAccess = conn_connAccess.CreateCommand();
            conn_connAccess.Open();
            cmd_connAccess.CommandText = cmdStr;
            cmd_connAccess.Parameters.AddRange(parameters);
            return cmd_connAccess.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// 返回一个reader
        /// </summary>
        /// <param name="cmdStr">SQL语句</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>reader</returns>
        public static OracleDataReader ExecuteReader_connOracle(string cmdStr, params OracleParameter[] parameters)
        {
            OracleConnection conn_connOracle = new OracleConnection(_connOracle);
            OracleCommand cmd_connOracle = conn_connOracle.CreateCommand();
            conn_connOracle.Open();
            cmd_connOracle.CommandText = cmdStr;
            cmd_connOracle.Parameters.AddRange(parameters);
            return cmd_connOracle.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// 返回一个reader
        /// </summary>
        /// <param name="cmdStr">SQL语句</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>reader</returns>
        public static SqlDataReader ExecuteReader_connSQLServer(string cmdStr,params SqlParameter[] parameters)
        {
            SqlConnection conn_connSQLServer = new SqlConnection(_connSQLServer);
            SqlCommand cmd_connSQLServer = conn_connSQLServer.CreateCommand();
            conn_connSQLServer.Open();
            cmd_connSQLServer.CommandText = cmdStr;
            cmd_connSQLServer.Parameters.AddRange(parameters);
            return cmd_connSQLServer.ExecuteReader(CommandBehavior.CloseConnection);
        }
        #endregion


    }
}
