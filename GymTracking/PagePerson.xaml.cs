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
 * Title:   PageActivity CS
 * Author:  Paul McKillop
 * Date:    01 January 2020
 * Purpose: Code behind for functionality
 */

namespace GymTracking
{
    /// <summary>
    /// Interaction logic for PagePerson.xaml
    /// </summary>
    public partial class PagePerson : Page
    {
        internal bool formDataValid = false;
        
        public PagePerson()
        {
            InitializeComponent();

            PersonNameTextBox.Text = string.Empty;
            PersonAgeTextBox.Text = string.Empty;
            PersonWeightTextBox.Text = string.Empty;
        }

        private void ActivitiesButton_Click(object sender, RoutedEventArgs e)
        {
            //-- Get the form's data by using private method below
            //-- populate a Person object with the data gathered to pass on
            //-- to page PageActivity
            var personData = HarvestForm();
            //-- Form data valid?
            if (formDataValid)
            {
            //-- Now have the data required.
            //-- can pass this to the Activity page
            //-- Include as an argument on the Navigate method
            var pageActivity = new PageActivity(personData);
            this.NavigationService.Navigate(pageActivity);
            }
            
        }

        //-- Clear text box controls
        private void PagePersonClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearControls();
        }


        /// <summary>
        /// Clear controls aand set to empty strin.
        /// Good practice to separate from button event call so that
        /// all controls in one place in case more are added
        /// </summary>
        private void ClearControls()
        {
            PersonNameTextBox.Text = string.Empty;
            PersonAgeTextBox.Text = string.Empty;
            PersonWeightTextBox.Text = string.Empty;

            //-- set focus to name box. Logical GUI control.
            //-- Help the user where you can.
            PersonNameTextBox.Focus();
        }

        //-- Harvest form data
        private Person HarvestForm()
        {
            //-- data handler variables
            var tempPerson = new Person();
            var countOfValidFields = 0;
            
            //-- set the rule in one place
            var requiredValidFields = 3;

            
            //-- Use try .. catch block to trap any errors.
            try
            {
                //-- validate the name data and assign if there
                if (!string.IsNullOrEmpty(PersonNameTextBox.Text))
                {
                    tempPerson.PersonName = PersonNameTextBox.Text;
                    countOfValidFields += 1;
                }
                else
                {
                    MessageBox.Show("You must enter a name");
                }

                //-- validate the Age data
                if (!string.IsNullOrEmpty(PersonAgeTextBox.Text))
                {
                    tempPerson.Age = Convert.ToInt32(PersonAgeTextBox.Text);
                    countOfValidFields += 1;
                }
                else
                {
                    MessageBox.Show("You must enter your Age");

                }

                //-- Validate the weight data
                if (!string.IsNullOrEmpty(PersonWeightTextBox.Text))
                {
                    tempPerson.Weight = float.Parse(PersonWeightTextBox.Text);
                    countOfValidFields += 1;
                }
                else
                {
                    MessageBox.Show("You must enter your Weight");
                }
            }
            catch (Exception)
            {

                throw;
            }

            //-- Check if all required data present.
            if(countOfValidFields == requiredValidFields)
            {
                formDataValid = true;
                return tempPerson;
            } else
            {
                MessageBox.Show("Form data is not valid");
                PersonNameTextBox.Focus();
            }

            return tempPerson;
        }
    }
}
