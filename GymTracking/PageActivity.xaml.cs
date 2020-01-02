using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

/*
 * Title:   PageActivity Code behind
 * Author:  Paul McKillop
 * Date:    01 Januray 2020
 * Purpose: Code behind for functionality
 */

namespace GymTracking
{
    /// <summary>
    /// Interaction logic for PageActivity.xaml
    /// </summary>
    /// 

   
    public partial class PageActivity : Page
    { 
        
        //-- handler variables
        internal static string selectedMachine = "";
        internal static string selectedLevel = "";
        internal bool isWeighted = false;
        internal int durationRecorded = 0;
        internal int usageRate = 0;

        //-- Object to handle person data after passed
        internal static Person person = new Person();

        //- Object to hold the Activity data
        internal static Summary summary = new Summary();

        //-- Track the number of activities
        internal static int activitiesRecorded = 0;

        //-- include the Person data passed from PagePerson as a parameter 
        //-- for the Constructor of the page
        public PageActivity(Person personPassed)
        {
            InitializeComponent();
            //-- assign the passed data to the module wide variable
            person = personPassed;

            //-- assign the person to the summary opbject
            summary.SessionPerson = person;

            //-- Hide the inclined controls by defailt unless Treadmill selected
            InclinedCheckBoxLabel.Visibility = Visibility.Hidden;
            InclinedCheckBox.Visibility = Visibility.Hidden;

        }

        //-- Executes on page loaded
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //-- confirm the person data has been received
            MessageBox.Show("Person data received for " + person.PersonName);
        }

        #region Navigation Buttons
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var pagePerson = new PagePerson();
            this.NavigationService.Navigate(pagePerson);
        }

        private void PageSummaryButton_Click(object sender, RoutedEventArgs e)
        {
            var pageSummary = new PageSummary();
            this.NavigationService.Navigate(pageSummary);
        } 
        #endregion


        #region Machines Combo handler methods
        //-- Load the data when the control is loaded to the form
        private void MachinesCombo_Loaded(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;
            combo.ItemsSource = Machines();
            combo.SelectedIndex = 0;
        }

        //-- Update the module wide variable when item selected
        private void MachinesCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedMachineCombo = sender as ComboBox;
            selectedMachine = selectedMachineCombo.SelectedItem as string;

            //-- Control the visibility of the checkbox control label and checkbox
            if (selectedMachine == "Treadmill")
            {
                InclinedCheckBoxLabel.Visibility = Visibility.Visible;
                InclinedCheckBox.Visibility = Visibility.Visible;
            }
            else
            {
                InclinedCheckBoxLabel.Visibility = Visibility.Hidden;
                InclinedCheckBox.Visibility = Visibility.Hidden;
            }

        }
        #endregion

        #region Levels Combo handler methods
        private void LevelsCombo_Loaded(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;
            combo.ItemsSource = Levels();
            combo.SelectedIndex = 0;
        }

        private void LevelsCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedLevelCombo = sender as ComboBox;
            selectedLevel = selectedLevelCombo.SelectedItem as string;

            ////-- DEBUG
            //MessageBox.Show("Selected level is " + selectedLevel);
        }
        #endregion

        //-- Process the data on the form.
        private void AddActivityButton_Click(object sender, RoutedEventArgs e)
        {
            //-- Activity objhect to hold data
            Activity currentActivity = new Activity();

            //-- assign by harvesting form data
            currentActivity = HarvestForm;

            //-- increase the count of activities
            activitiesRecorded++;

            //-- Check that no more than 6 activities recorded
            if (activitiesRecorded <= 6)
            {
                //-- Add the current activity to the summary object
                summary.Activities.Add(currentActivity);
                //-- show that activity is added
                CountOfActivitiesTextBlock.Text = activitiesRecorded.ToString();
            }
            else // Message that limit exceeded
            {
                MessageBox.Show("The maximum number of activities is 6");
            }
        }

        private Activity HarvestForm
        {
            get
            {
                //-- See if weighted
                isWeighted = InclinedCheckBox.IsChecked ?? false;

                //-- Handler variables
                float durationFractionOfHour = 0;
                float usedInActivity = 0;
                float weightingFactor = 1.11F;

                //-- Error check the duration. 
                //-- First, is there a value?
                //-- second, does value meet rules of 5 - 60 minutes?
                //-- Use a nested 'if' construct
                if (!string.IsNullOrEmpty(DurationTextBox.Text))
                {
                    var durationRecordedToCheck = Convert.ToInt32(DurationTextBox.Text);
                    //-- check it meets length rule
                    if (ActivityValidation.ActivityDurationValid(durationRecordedToCheck))
                    {
                        durationRecorded = Convert.ToInt32(DurationTextBox.Text);
                    }
                    else //-- Outcome for value outsdide the rule 5 - 60 minutes
                    {
                        MessageBox.Show(" The activity duration must be between 5 and 60 mminutes");
                    }
                }
                else //-- Outcome for empty duration text box
                {
                    MessageBox.Show("You must enter a duration for the activity");
                }


                //-- convert minutes to a fraction of an hour.
                durationFractionOfHour = Utility.MinutesFractionOfHour(durationRecorded);

                //-- Get the Rate for combination of Machine and Level
                usageRate = MachineDataDb.GetRate(selectedMachine, selectedLevel);

                //-- If the weighted/inlined check box true, usage is increased by 11%
                //-- Else, straughtforward multiplication of Rate per Hour * Fraction of hour recorded
                if (isWeighted)
                {
                    usedInActivity = (usageRate * durationFractionOfHour) * weightingFactor;
                }
                else
                {
                    usedInActivity = usageRate * durationFractionOfHour;
                }

                //-- Assign values to the object to be returned
                Activity tempActivity = new Activity
                {
                    MachineName = selectedMachine,
                    Weighted = isWeighted,
                    Level = selectedLevel,
                    Duration = durationRecorded,
                    Used = usedInActivity
                };

                //-- Return the Activity object constructed from the values
                //-- Harvested from the form.
                return tempActivity;
            }
        }

        #region Data methods for population of Combos
        /// <summary>
        /// Get the list of machines from the text file
        /// </summary>
        /// <returns></returns>
        private List<string> Machines()
        {
            return Lists.Machines();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<string> Levels()
        {
            return Lists.Levels();
        }

        #endregion


    }
}
