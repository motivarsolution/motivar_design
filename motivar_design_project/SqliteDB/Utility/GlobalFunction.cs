using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteDB.Utility
{
    public static class GlobalFunction
    {
        public static void ShowOutput(string msg)
        {
            Debug.WriteLine("Message ::: " + msg);
        }
    }
}
