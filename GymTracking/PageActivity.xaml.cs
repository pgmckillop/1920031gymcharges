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
    /// Interaction logic for PageActivity.xaml
    /// </summary>
    public partial class PageActivity : Page
    {
        public PageActivity()
        {
            InitializeComponent();
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
    }
}
