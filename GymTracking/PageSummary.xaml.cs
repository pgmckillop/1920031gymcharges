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
        //-- Handler object
        Summary summary = new Summary();
        public PageSummary(Summary summaryPassed)
        {
            InitializeComponent();

            //-- Assign the data to the object
            summary = summaryPassed;

            string person = summary.SessionPerson.PersonName;
            string numberOfActivities = summary.NumberOfActivities.ToString();
            string minutesOfExercise = summary.MinutesOfExercise.ToString();
            string totalUsed = summary.TotalUsed.ToString();
            

            //-- Populate the information controls

            PersonTextBlock.Text = person;

            NumberActitiesTextBlock.Text = numberOfActivities;

            MinutesExerciseTextBlock.Text = minutesOfExercise;

            TotalUsedTextBlock.Text = totalUsed;




            //-- Display the summary
            //SummaryTextBlock.Text = CreateSummaryText(summary);
        }

        ////-- Display text preparation
        //private static string CreateSummaryText(Summary mySummary)
        //{
        //    var tempString = string.Empty;
        //    var sb = new StringBuilder();

        //    var hoursAndMinutes = Utility.HoursAndMinutes(mySummary.MinutesOfExercise);

        //    sb.AppendLine("Session Summary for:");
        //    sb.AppendLine();
        //    sb.AppendLine(mySummary.SessionPerson.PersonName);
        //    sb.Append("Number Activities: ").Append("\t").AppendLine(mySummary.NumberOfActivities.ToString());
        //    sb.Append("Minutes Exercise: ").Append("\t").AppendLine(mySummary.MinutesOfExercise.ToString());
        //    sb.Append("Total in Hrs and Min: ").Append("\t").AppendLine(hoursAndMinutes);
        //    sb.AppendLine();
        //    sb.AppendLine(); 
        //    sb.AppendLine();
        //    sb.Append("TOTAL USED").Append("\t").AppendLine(mySummary.TotalUsed.ToString());
        //    return tempString;
        //}
            
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
