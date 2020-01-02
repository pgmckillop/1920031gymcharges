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
            var path = Lists.dataPath;
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

        /// <summary>
        /// Get all data columns for a particular machine
        /// </summary>
        /// <param name="machineName"></param>
        /// <returns>List<MachineData>()</MachineData></returns>
        public  static List<MachineData> GetIndividualMachineData(string machineName)
        {
            var tempList = new List<MachineData>();

            var dt = MachineDataDb.GetMachineData();

            foreach(DataRow row in dt.Rows)
            {
                var data = new MachineData()
                {
                    MachineName = row.Field<string>(0),
                    Level = row.Field<string>(1),
                    Rate = float.Parse(row.Field<string>(2))
                };

                if(data.MachineName == machineName)
                {
                    tempList.Add(data);
                };
            }

            return tempList;
        }

        public static int GetRate(string machineName, string level)
        {
            float tempRate = 0;

            List<MachineData> machineData = GetIndividualMachineData(machineName);

            foreach(MachineData data in machineData)
            {
                if(data.Level == level)
                {
                    tempRate = data.Rate;
                }
            }

            return Convert.ToInt32(tempRate);
        }

    }
}
