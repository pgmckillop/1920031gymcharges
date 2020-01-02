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

namespace GymTracking
{
    /// <summary>
    /// Interaction logic for PageSummary.xaml
    /// </summary>
    public partial class PageSummary : Page
    {

        public PageSummary()
        {
            InitializeComponent();
        }


 /******************************
 *  ACTION NEEDED
 * **************************** 
 *  Re-asign person data on back button
 *  when there is an object to work with
 *  After PageActivity complete
 ******************************/

        //-- Back to activity page
        private void SummaryPageBackButton_Click(object sender, RoutedEventArgs e)
        {
            var pageActivity = new PageActivity();
            this.NavigationService.Navigate(pageActivity);
        }

        //-- Close the application down completely
        private void SummaryPageExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
