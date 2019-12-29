using System;
using System.Collections.Generic;
using System.Text;

/*
 * Title:   Person
 * Author:  Paul McKillop
 * Date:    28 December 2019
 * Purpose: Hold data for Person Entity
 */

namespace GymTracking
{
    public class Person
    {       
        //-- Class data members
        private string personName;

        public string PersonName
        {
            get { return personName; }
            set { personName = value; }
        }

        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        private float weight;

        public float Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        //-- **********************************
        //-- No class method members implmented
        //-- **********************************

    }
}
