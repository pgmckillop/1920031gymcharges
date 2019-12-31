using System;
using System.Collections.Generic;
using System.Text;

/*
 * Title:   Utility
 * Author:  Paul McKillop
 * Date:    28 Decmeber 2019
 * Purpose: handlers and app wide processors.
 */

namespace GymTracking
{
    public class Utility
    {
        #region String is found in list

        /// <summary>
        /// Check if a string is already in a list
        /// </summary>
        /// <param name="listToSearch"></param>
        /// <param name="stringToFind"></param>
        /// <returns>Boolean</returns>
        public static bool StringFound(List<string> listToSearch, string stringToFind)
        {
            //-- tracker variable
            bool stringFound = false;
            //-- Loop through all
            foreach (string value in listToSearch)
            {
                if (value == stringToFind)
                {
                    stringFound = true;
                    return stringFound;
                }
            }

            //-- return true or false: in list, or not
            return stringFound;
        }

        #endregion

        public static float CalculateActivityRate(string machine, string level, string duration)
        {
            float valueTemp = 0;

            return valueTemp;
        }

        //-- Calculate minutes as a proportion of an hour to work out relevant rate
        public static float MinutesFractionOfHour(int minutes)
        {
            return minutes / 60;
        }
    }
}
