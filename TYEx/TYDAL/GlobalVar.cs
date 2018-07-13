using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBHelper;
using System.Configuration;

namespace DAL
{
    public static class GlobalVar
    {
        //public static DbHelper SqliteHelp = new DbHelper(DbHelper.DbType.Sqlite, ConfigurationManager.ConnectionStrings["SqliteConnection"].ToString());
        public static DbHelper SqliteHelp = new DbHelper("DbConnection");
        
    }
}
