using System.Collections.Generic;
using System.Text;

/*
 * Title:   Summary
 * Author:  Paul McKillop
 * Date:    31 December 2019
 * Purpose: To hold session data when transferred between pages
 */

namespace GymTracking
{
    public class Summary
    {
        //-- This is a very advanced technique, but why not!
        //-- A class template can hold a collection of objects made from classes
        //-- rather than default tyes like strings, ints etc.
        private Person person;
        
        //-- Person using the system
        public Person SessionPerson
        {
            get { return person; }
            set { person = value; }
        }

        private int numberOfActivities;

        //-- number of activities recorded
        public int NumberOfActivities
        {
            get { return numberOfActivities; }
            set { numberOfActivities = value; }
        }

        private int minutesOfExercise;

        //-- Total of all time exercise as minutes
        public int MinutesOfExercise
        {
            get { return minutesOfExercise; }
            set { minutesOfExercise = value; }
        }

        private int totalUsed;

        //-- Result of all the exercise
        public int TotalUsed
        {
            get { return totalUsed; }
            set { totalUsed = value; }
        }

        //-- present total exercise time in hours and minutes
        private static string HoursAndMinutes(int minutes)
        {
            var tempString = string.Empty;

            int minutesRemainder = minutes % 60;
            int hours = (int)minutes / 60;

            tempString = hours.ToString() + " Hours and " + minutesRemainder + " minutes";

            return tempString;
        }


    }
}
