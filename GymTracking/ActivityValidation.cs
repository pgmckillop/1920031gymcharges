
using System;
using System.Collections.Generic;
using System.Text;

/*
 * Title:   ActivityValidation
 * Author:  Paul McKillop
 * Date:    28 December 2019
 * Purpose: Check activity rules
 */

namespace GymTracking
{
    public class ActivityValidation
    {
        //-- Parameters centrally located
        internal static int numberActivitiesMinimum = 2;
        internal static int numberActivitiesMaximum = 6;
    
        internal static int activityDurationMinimum = 5;
        internal static int activityDurationMaximum = 60;

        //-- Validate number of activities
        public static bool NumberActivitiesValid(int activities)
        {
            return activities >= numberActivitiesMinimum && activities <= numberActivitiesMaximum;
        }

        //-- Validate activity length
        public static bool ActivityDurationValid(int duration)
        {
            return duration >= activityDurationMinimum && duration <= activityDurationMaximum;
        }
    }
}
