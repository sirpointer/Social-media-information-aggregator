﻿using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SocialMediaInformationAggregator
{
    /// <summary>
    /// Логика взаимодействия для InputPage.xaml
    /// </summary>
    public partial class InputPage : Page
    {
        public InputPage()
        {
            InitializeComponent();

            for (int i = DateTime.Now.Year; i > 1900; i--)
            {
                FromYearCB.Items.Add(i.ToString());
                ToYearCB.Items.Add(i.ToString());
            }
        }

        private void OptionTB_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock tb = sender as TextBlock;
            tb.Text = tb.Text == "+" ? tb.Text = "-" : tb.Text = "+";
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            FindPeople.SearchOptions options = new FindPeople.SearchOptions()
            {
                Name = NameComboBox.Text,
                LastName = LastNameComboBox.Text
            };
            SetSerachOptions(options);

            IWebDriver webDriver;

            try
            {
                webDriver = new EdgeDriver();
            }
            catch
            {
                try
                {
                    webDriver = new FirefoxDriver();
                }
                catch
                {
                    try
                    {
                        webDriver = new ChromeDriver();
                    }
                    catch
                    {
                        webDriver = new InternetExplorerDriver();
                    }
                }
            }
            
            FindPeople.IFindPeople find = new FindPeople.FindPeople();

            find.FindPeopleOnVK(webDriver, options);
            find.FindPeopleOnOK(webDriver, options);
            
            App.PersonInformation = new List<FindPeople.PersonInformation>();
            
            foreach (var person in find.PeopleFromVK)
                App.PersonInformation.Add(person);

            foreach (var person in find.PeopleFromOK)
                App.PersonInformation.Add(person);

            webDriver.Quit();

            foreach (var ui in (Application.Current.MainWindow.Content as Grid).Children)
            {
                if (ui is Frame)
                    (ui as Frame).Navigate(new Uri("ListOfPeoplePage.xaml", UriKind.Relative));
            }
        }

        private void SetSerachOptions(FindPeople.SearchOptions options)
        {
            if (YearFromOption.Text == "+")
                if (FromYearCB.SelectedIndex != -1)
                    options.YearOfBirth = Convert.ToInt32(FromYearCB.SelectedValue);

            if (YearToOption.Text == "+")
                if (ToYearCB.SelectedIndex != -1)
                    options.ForThisYear = Convert.ToInt32(ToYearCB.SelectedValue);

            if (CityOption.Text == "+")
                if (!string.IsNullOrWhiteSpace(CityComboBox.Text))
                    options.City = CityComboBox.Text;

            if (EducationOption.Text == "+")
                if (!string.IsNullOrWhiteSpace(EducationComboBox.Text))
                    options.City = EducationComboBox.Text;
        }

        private void InputComboBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            if (cb.Items.Count != 0)
                (sender as ComboBox).IsDropDownOpen = true;
        }

        private void InputComboBox_LostFocus(object sender, RoutedEventArgs e)
        {
            (sender as ComboBox).IsDropDownOpen = false;
        }
    }
}
