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
    public partial class PageActivity : Page
    {
        //-- Object to handle person data after passed
        Person person = new Person();

        //-- include the Person data passed from PagePerson as a parameter 
        //-- for the Constructor of the page
        public PageActivity(Person personPassed)
        {
            InitializeComponent();
            //-- assign the passed data to the module wide variable
            person = personPassed;
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
    }
}
