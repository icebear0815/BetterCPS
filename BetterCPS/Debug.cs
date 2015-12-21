using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterCPS
{
    class Debug
    {
        private static Debug instance = null;
        private bool flag;

        public bool DebugOn
        {
            get { return flag; }
            set { flag = value; }
        }
        public static Debug GetInstance()
        {
            if (instance == null)
                instance = new Debug();
            return instance;
        }

        
    }
}
