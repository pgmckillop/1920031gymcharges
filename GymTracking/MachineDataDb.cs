using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

/*
 * Title:   MachineDataDb
 * Author:  Paul McKillop
 * Date:    31 December 2019
 * Purpose: Get a list of MachineData as a DataTable
 */

namespace GymTracking
{
    public class MachineDataDb
    {
        /// <summary>
        /// Get MachineData from the text file database
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable GetMachineData()
        {
            //-- handler variables
            var path = @"C:\gymdata";
            var dt = new DataTable();

            //--- Use try .. catch to trap errors
            try
            {
                dt = ImportData.GetTextFileData(path);
            }
            catch (Exception)
            {

                throw;
            }

            //-- return the procedure as a DataTable
            return dt;
        }
    }
}
