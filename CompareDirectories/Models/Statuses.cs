using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareDirectories
{
    public class Statuses
    {
        private static readonly string status1 = "File is existing only in the first directory";
        private static readonly string status2 = "File is existing only in the second directory";
        private static readonly string status3 = "File is existing in both directories and is the same size";
        private static readonly string status4 = "File is existing in both directories and isn't the same size";

       public static string[] Status { get { return new string[] { status1, status2, status3, status4 }; } }
    }
}
