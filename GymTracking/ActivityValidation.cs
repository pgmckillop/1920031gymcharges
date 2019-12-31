
using System;
using System.Collections.Generic;
using System.Text;

/*
 * Title:   ActivityValidation
 * Author:  Paul McKillop
 * Date:    28 December 2019
 * Purpose: Check activity duration rules
 */

namespace GymTracking
{
    public class ActivityValidation
    {
        //-- Parameters centrally located
        internal static int activityDurationMinimum = 5;
        internal static int activityDurationMaximum = 60;

        //-- Validate activity length
        public static bool ActivityDurationValid(int duration)
        {
            return duration >= activityDurationMinimum && duration <= activityDurationMaximum;
        }
    }
}
