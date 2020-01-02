using System;
using System.Collections.Generic;
using System.Text;

/*
 * Title:   SActivity
 * Author:  Paul McKillop
 * Date:    31 December 2019
 * Purpose: Hold activity data when recorded by user
 */

namespace GymTracking
{
    public class Activity
    {
        //-- Data members
        public string MachineName { get; set; }
        public String Level { get; set; }
        public bool Weighted { get; set; }
        public int Duration { get; set; }
        //-- Hold corrected rate
        public double Used { get; set; }
    }
}
