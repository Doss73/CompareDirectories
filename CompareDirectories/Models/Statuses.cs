using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareDirectories
{
    /// <summary>
    /// Provides set of statuses for files
    /// </summary>
    public class Statuses
    {
        /// <summary>
        /// String represention status when file is existing only in the first directory
        /// </summary>
        private static readonly string status1 = "File is existing only in the first directory";
        /// <summary>
        /// String represention status when file is existing only in the second directory
        /// </summary>
        private static readonly string status2 = "File is existing only in the second directory";
        /// <summary>
        /// String represention status when file is existing in both directories and is the same size
        /// </summary>
        private static readonly string status3 = "File is existing in both directories and is the same size";
        /// <summary>
        /// String represention status when file is existing in both directories and isn't the same size
        /// </summary>
        private static readonly string status4 = "File is existing in both directories and isn't the same size";
        /// <summary>
        /// Set of statuses for selecting neccessary
        /// </summary>
        public static readonly string[] status = new string[] { status1, status2, status3, status4 }; 
    }
}
