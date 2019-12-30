using System;
using System.Collections.Generic;
using System.Text;

/*
 * Title:   MachineData
 * Author:  Paul McKillop
 * Date:    29 December 2019
 * Purpose: Data for each machine : Name, Level, Rate
 */

namespace GymTracking
{
    public class MachineData
    {
        private string machineName;

        public string MachineName
        {
            get { return machineName; }
            set { machineName = value; }
        }

        private string level;

        public string Level
        {
            get { return level; }
            set { level = value; }
        }

        private float rate;

        public float Rate
        {
            get { return rate; }
            set { rate = value; }
        }



    }
}
