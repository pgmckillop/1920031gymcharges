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

            //-- Hide the inclined controls by defailt unless Treadmill selected
            InclinedCheckBoxLabel.Visibility = Visibility.Hidden;
            InclinedCheckBox.Visibility = Visibility.Hidden;

        }

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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //-- confirm the person data has been received
            MessageBox.Show("Person data received for " + person.PersonName);
        }

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
