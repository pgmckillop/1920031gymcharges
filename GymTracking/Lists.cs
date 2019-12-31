using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

/*
 * Title:   Lists
 * Author:  Paul McKillop
 * Date:    31 Decmeber 2019
 * Purpose: Provide lists of items to use in the interface
 */

namespace GymTracking
{
    public class Lists
    {

        /// <summary>
        /// Get list of machines from the text file database
        /// </summary>
        /// <returns>List<string></returns>
        public static List<string> Machines()
        {
            
            //-- Handler variables
            var path = @"c:\gymcharges";
            var tempList = new List<string>();
            var dt = new DataTable();

            //-- Get the data from the database
            dt = ImportData.GetTextFileData(path);

            //-- Use a try .. catch block to trap errors found
            try
            {
            //-- Iterate through the data rows to find unique machine names
                foreach(DataRow row in dt.Rows)
                {
                    //-- use an object to hold the data from each row of the text file as it is found for processing.
                    //-- Intellisense will know valid object fields
                    //-- Use the column indeces to reference the correct Field item in the row of data
                    var lineData = new MachineData {
                        MachineName = row.Field<string>(0),
                        Level = row.Field<string>(1)
                    };

                    if (!Utility.StringFound(tempList, lineData.MachineName))
                    {
                        tempList.Add(lineData.MachineName);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            //-- return the populated list of MachineName items
            return tempList;
        }

        /// <summary>
        /// Get list of levels from the text file database.
        /// </summary>
        /// <returns>List<string></string></returns>
        public static List<string> Levels()
        {
            //-- for structure and purpose comments refwer to procedure Machines() above
            var path = @"c:\gymcharges";
            var tempList = new List<string>();
            var dt = new DataTable();

            //-- Get the data from the database
            dt = ImportData.GetTextFileData(path);

            //-- Use a try .. catch block to trap errors found
            try
            {
                //-- Iterate through the data rows to find unique machine names
                foreach (DataRow row in dt.Rows)
                {
                    //-- use an object to hold the data from each row of the text file as it is found for processing.
                    //-- Intellisense will know valid object fields
                    //-- Use the column indeces to reference the correct Field item in the row of data
                    var lineData = new MachineData
                    {
                        MachineName = row.Field<string>(0),
                        Level = row.Field<string>(1)
                    };

                    if (!Utility.StringFound(tempList, lineData.Level))
                    {
                        tempList.Add(lineData.Level);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            //-- return the populated list of Level items
            return tempList;
        }
    }
}
