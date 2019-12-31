using System;
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

        //-- all the activities recorded for the session
        //-- The activities and their contyent have to be validated before they get here
        private List<Activity> activities = new List<Activity>();

        public List<Activity> Activities
        {
            get { return activities = new List<Activity>(); }
            set { activities = value; }
        }

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

            sb.Append(mySummary.SessionPerson.PersonName).Append(" ").Append(mySummary.SessionPerson.Age).Append(" ").Append(mySummary.SessionPerson.Weight);
            sb.AppendLine();

            foreach(Activity activity in mySummary.Activities)
            {
                sb.Append(activity.MachineName).Append(" Duration: ").AppendLine(activity.Duration.ToString());
            }

            //-- StringBuilder has to be converted to a string for return and use in the GUI
            return sb.ToString();
        }


    }
}
