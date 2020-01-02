using System;
using System.Collections.Generic;
using System.Text;

/*
 * Title:   SummaryPrrsentation
 * Author:  Paul McKillop
 * Date:    02 January 2020
 * Purpose: Lay out the summary text to present in the GUI
 */

namespace GymTracking
{
    public class SummaryPresentation
    {
        /// <summary>
        /// Create all the data as a string that can  be  insterted
        /// into a TextBlock in the GUI
        /// </summary>
        /// <param name="mySummary"></param>
        /// <returns>string</returns>
        public static string PresentSummary(Summary mySummary)
        {
            //-- Handler variable as string builder
            var sb = new StringBuilder();
            var rateRunningTotal = 0;


            //-- add Person data first
            sb.Append(mySummary.SessionPerson.PersonName).Append(" ").Append(mySummary.SessionPerson.Age).Append(" ").Append(mySummary.SessionPerson.Weight);
            sb.AppendLine();

            //-- Use Utility class method CalculateActivityRate and track as looping through each
            foreach (Activity activity in mySummary.Activities)
            {
                sb.Append(activity.MachineName).Append(" Used: ").AppendLine(activity.Used.ToString());
                //-- Rate total tracking
                rateRunningTotal += (int)activity.Used;
            }
            sb.AppendLine();
            sb.AppendLine();

            sb.Append("Total used: ").AppendLine(rateRunningTotal.ToString());

            //-- StringBuilder has to be converted to a string for return and use in the GUI
            return sb.ToString();
        }
    }
}
