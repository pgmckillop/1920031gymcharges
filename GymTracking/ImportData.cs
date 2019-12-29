using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;

/*
 * Title:   ImportData
 * Author:  Paul McKillop
 * Date:    28 December 2019
 * Purpose: Create a DataTable object using text file data
 */

namespace GymTracking
{
    public class ImportData
    {
        public static DataTable GetTextFileData(string strFilePath)
        {
            StreamReader sr = new StreamReader(strFilePath);
            // Read the first line only for column headers
            // and use these to create the DataTable columns
            string[] headers = sr.ReadLine().Split(',');
            DataTable dt = new DataTable();

            //- headers
            foreach (string header in headers)
            {
                dt.Columns.Add(header);
            }

            // Read the reamining data into the DataTable
            // to the EndOfStream
            while (!sr.EndOfStream)
            {
                // Regex with escape caharacters
                string[] rows = Regex.Split(sr.ReadLine(), ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                DataRow dr = dt.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                dt.Rows.Add(dr);
            }

            // return the DataTable from the method
            return dt;
        }
    }
}
