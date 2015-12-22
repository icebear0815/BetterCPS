using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data.Common;

namespace BetterCPS
{
    class DBAccess
    {
        SQLiteConnection db = null;
        private static DBAccess dbAccess;
        public DBAccess()
        {
            db = new SQLiteConnection("Data Source=CPSManager.db;FailIfMissing=True;");
            db.Open();
        }

        public static DBAccess GetInstance()
        {
            if (dbAccess == null)
            {
                dbAccess = new DBAccess();
            }
            return dbAccess;
        }

        public void test()
        {
            
        }
    }
}
