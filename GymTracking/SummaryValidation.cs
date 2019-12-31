using System;
using System.Collections.Generic;
using System.Text;

/*
 * Title:   SummaryValidation
 * Author:  Paul McKillop
 * Date:    31 December 2019
 * Purpose: Validate number activities mneets the rules set in the brief
 */

namespace GymTracking
{
    public class SummaryValidation
    {
        //-- Parameters centrally located
        internal static int numberActivitiesMinimum = 2;
        internal static int numberActivitiesMaximum = 6;

        //-- Validate number of activities
        public static bool NumberActivitiesValid(int activities)
        {
            return activities >= numberActivitiesMinimum && activities <= numberActivitiesMaximum;
        }
        
    }
}
