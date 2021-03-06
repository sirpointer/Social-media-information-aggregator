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
using SocialMediaInformationAggregator.DatabaseInteraction;
using SocialMediaInformationAggregator.FindPeople;

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

            for (int i = 14; i <= 80; i++)
            {
                FromYearCB.Items.Add(i.ToString());
                ToYearCB.Items.Add(i.ToString());
            }

            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                MessageBox.Show("Подключение к интернету отсутствует.");
        }

        /// <summary>
        /// Возвращает значение указывающее, обязатен ли год. 
        /// </summary>
        public bool YearFromChecked
        {
            get
            {
                if (YearFromOption.Text.Equals("+"))
                    return true;
                else
                    return false;
            }
        }

        public bool YearToChecked
        {
            get
            {
                if (!YearFromChecked || YearToOption.Text.Equals("-"))
                    return false;
                else
                    return true;
            }
        }

        public bool CityChecked
        {
            get
            {
                if (CityOption.Text.Equals("+"))
                    return true;
                else
                    return false;
            }
        }

        public bool EducationChecked
        {
            get
            {
                if (UniversityOption.Text.Equals("+"))
                    return true;
                else
                    return false;
            }
        }

        public bool SchoolChecked
        {
            get
            {
                if (SchoolOption.Text.Equals("+"))
                    return true;
                else
                    return false;
            }
        }

        private void OptionTB_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock tb = sender as TextBlock;
            tb.Text = tb.Text == "+" ? tb.Text = "-" : tb.Text = "+";
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            NotFoundTextBlock.Visibility = Visibility.Collapsed;

            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show("Подключение к интернету отсутствует.");
                return;
            }

            TrimAll();

            if (!NameCheck())
                return;
            
            FindPeople.SearchOptions options = new FindPeople.SearchOptions()
            {
                Name = NameComboBox.Text,
                LastName = LastNameComboBox.Text
            };
            SetSerachOptions(options);

            try
            {
                AddFieldsToDb();
            }
            catch { }
            
            WebDriverWorks(options);

            if (App.PersonInformation.Count < 1 || App.PersonInformation == null)
            {
                NotFoundTextBlock.Visibility = Visibility.Visible;
                return;
            }

            foreach (var ui in (Application.Current.MainWindow.Content as Grid).Children)
            {
                if (ui is Frame)
                    (ui as Frame).Navigate(new Uri("ListOfPeoplePage.xaml", UriKind.Relative));
            }
        }

        private void TrimAll()
        {
            NameComboBox.Text = NameComboBox.Text.Trim();
            LastNameComboBox.Text = LastNameComboBox.Text.Trim();
            CityComboBox.Text = CityComboBox.Text.Trim();
            UniversityComboBox.Text = UniversityComboBox.Text.Trim();
            SchoolComboBox.Text = SchoolComboBox.Text.Trim();
        }

        private void AddFieldsToDb()
        {
            if (App.CurrentUserLogin != null)
            {
                try
                {
                    DatabaseInteraction.PeopleFromDb.SetFoundFirstName(App.CurrentUserLogin, NameComboBox.Text);
                }
                catch { }

                try
                {
                    DatabaseInteraction.PeopleFromDb.SetFoundLastName(App.CurrentUserLogin, LastNameComboBox.Text);
                }
                catch { }

                if (CityChecked && !string.IsNullOrWhiteSpace(CityComboBox.Text))
                {
                    try
                    {
                        DatabaseInteraction.PeopleFromDb.SetFoundCity(App.CurrentUserLogin, CityComboBox.Text);
                    }
                    catch { }
                }
                if (EducationChecked && !string.IsNullOrWhiteSpace(UniversityComboBox.Text))
                {
                    try
                    {
                        DatabaseInteraction.PeopleFromDb.SetFoundUniversity(App.CurrentUserLogin, UniversityComboBox.Text);
                    }
                    catch { }
                }
                if (SchoolChecked && !string.IsNullOrWhiteSpace(SchoolComboBox.Text))
                {
                    try
                    {
                        DatabaseInteraction.PeopleFromDb.SetFoundSchool(App.CurrentUserLogin, SchoolComboBox.Text);
                    }
                    catch { }
                }
            }
        }

        private bool NameCheck()
        {
            if (string.IsNullOrWhiteSpace(NameComboBox.Text) || string.IsNullOrWhiteSpace(LastNameComboBox.Text))
            {
                NameErrorTextBlock.Visibility = Visibility.Visible;
                return false;
            }
            else
            {
                NameErrorTextBlock.Visibility = Visibility.Collapsed;
                return true;
            }
        }

        private static void WebDriverWorks(FindPeople.SearchOptions options)
        {
            App.PersonInformation = new List<FindPeople.PersonInformation>();

            IWebDriver webDriver;

            try
            {
                webDriver = new ChromeDriver();
                webDriver.Manage().Window.Maximize();
            }
            catch
            {
                MessageBox.Show("Браузер Google Chrome не найден.");
                return;
            }

            IFindPeople find = new FindPeople.FindPeople();

            bool vkIsOk = true;
            bool okIsOk = true;
            
            #if DEBUG

            find.FindPeopleOnVK(webDriver, options);
            find.FindPeopleOnOK(webDriver, options);
            
            #else

            try
            {
                find.FindPeopleOnVK(webDriver, options);
            }
            catch
            {
                vkIsOk = false;
            }

            try
            {
                find.FindPeopleOnOK(webDriver, options);
            }
            catch
            {
                okIsOk = false;
            }

            #endif
            
            if (vkIsOk && find.PeopleFromVK != null)
            {
                foreach (var person in find.PeopleFromVK)
                    App.PersonInformation.Add(person);
            }
            
            if (okIsOk && find.PeopleFromOK != null)
            {
                foreach (var person in find.PeopleFromOK)
                    App.PersonInformation.Add(person);
            }

            webDriver.Quit();
        }


        private void SetSerachOptions(FindPeople.SearchOptions options)
        {
            YearsCheck(options);
            CityCheck(options);
            UniversityCheck(options);
            SchoolCheck(options);
        }

        private void SchoolCheck(FindPeople.SearchOptions options)
        {
            if (SchoolChecked)
            {
                if (!string.IsNullOrWhiteSpace(SchoolComboBox.Text))
                    options.Schools = SchoolComboBox.Text;
                else
                    options.Schools = null;
            }
            else
                options.Schools = null;
        }

        private void UniversityCheck(FindPeople.SearchOptions options)
        {
            if (EducationChecked)
            {
                if (!string.IsNullOrWhiteSpace(UniversityComboBox.Text))
                    options.Education = UniversityComboBox.Text;
                else
                    options.Education = null;
            }
            else
                options.Education = null;
        }

        private void CityCheck(FindPeople.SearchOptions options)
        {
            if (CityChecked)
            {
                if (!string.IsNullOrWhiteSpace(CityComboBox.Text))
                    options.City = CityComboBox.Text;
                else
                    options.City = null;
            }
            else
                options.City = null;
        }

        private void YearsCheck(FindPeople.SearchOptions options)
        {
            if (YearFromChecked)
            {
                if (!string.IsNullOrWhiteSpace(FromYearCB.Text))
                    options.YearOfBirth = Convert.ToInt32(FromYearCB.Text);
                else
                    options.YearOfBirth = null;

                YearToCheck(options);
            }
            else
            {
                options.YearOfBirth = null;
                options.ForThisYear = null;
            }
        }

        private void YearToCheck(FindPeople.SearchOptions options)
        {
            if (YearToChecked && !string.IsNullOrWhiteSpace(ToYearCB.Text.Trim()))
            {
                var firstYear = Convert.ToInt32(ToYearCB.Text.Trim());
                var secondYear = Convert.ToInt32(FromYearCB.Text.Trim());

                if (firstYear < secondYear)
                {
                    options.YearOfBirth = firstYear;
                    options.ForThisYear = secondYear;
                }
                else
                {
                    options.YearOfBirth = secondYear;
                    options.ForThisYear = firstYear;
                }
            }
            else
                options = null;
        }

        private void InputComboBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (App.CurrentUserLogin != null)
            {
                ComboBox cb = sender as ComboBox;

                switch (cb.Name)
                {
                    case "LastNameComboBox":
                        SetLastNameTooltips(cb);
                        break;
                    case "NameComboBox":
                        SetFirstNameTooltips(cb);
                        break;
                    case "CityComboBox":
                        SetCityTooltips(cb);
                        break;
                    case "UniversityComboBox":
                        SetEducationTooltips(cb);
                        break;
                    case "SchoolComboBox":
                        SetSchoolTooltips(cb);
                        break;
                }

                if (cb.Items.Count != 0)
                    (sender as ComboBox).IsDropDownOpen = true;
                else
                    (sender as ComboBox).IsDropDownOpen = false;
            }
        }

        private void InputComboBox_LostFocus(object sender, RoutedEventArgs e)
        {
            (sender as ComboBox).IsDropDownOpen = false;
        }


        private void LastNameComboBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (App.CurrentUserLogin != null)
            {
                var box = sender as ComboBox;

                switch (box.Name)
                {
                    case "LastNameComboBox":
                        SetLastNameTooltips(box);
                        break;
                    case "NameComboBox":
                        SetFirstNameTooltips(box);
                        break;
                    case "CityComboBox":
                        SetCityTooltips(box);
                        break;
                    case "EducationComboBox":
                        SetEducationTooltips(box);
                        break;
                }
            }
        }

        private static void SetLastNameTooltips(ComboBox box)
        {
            List<string> tips = new List<string>();
            List<string> tipsFromDB;

            try
            {
                tipsFromDB = DatabaseInteraction.PeopleFromDb.GetFoundLastNamea(App.CurrentUserLogin);
            }
            catch
            {
                tipsFromDB = new List<string>();
            }

            foreach (var tip in tipsFromDB)
            {
                if (!string.IsNullOrWhiteSpace(tip.Trim()))
                    tips.Add(tip.Trim());
            }

            box.Items.Clear();

            foreach (var tip in tips)
            {
                box.Items.Add(tip);
            }
        }

        private static void SetFirstNameTooltips(ComboBox box)
        {
            List<string> tips = new List<string>();
            List<string> tipsFromDB;

            try
            {
                tipsFromDB = DatabaseInteraction.PeopleFromDb.GetFoundFirstNames(App.CurrentUserLogin);
            }
            catch
            {
                tipsFromDB = new List<string>();
            }

            foreach (var tip in tipsFromDB)
            {
                if (!string.IsNullOrWhiteSpace(tip.Trim()))
                    tips.Add(tip.Trim());
            }

            box.Items.Clear();

            foreach (var tip in tips)
            {
                box.Items.Add(tip);
            }
        }

        private static void SetCityTooltips(ComboBox box)
        {
            List<string> tips = new List<string>();
            List<string> tipsFromDb;

            try
            {
                tipsFromDb = DatabaseInteraction.PeopleFromDb.GetFoundCities(App.CurrentUserLogin);
            }
            catch
            {
                tipsFromDb = new List<string>();
            }

            foreach (var tip in tipsFromDb)
            {
                if (!string.IsNullOrWhiteSpace(tip.Trim()))
                    tips.Add(tip.Trim());
            }

            box.Items.Clear();

            foreach (var tip in tips)
            {
                box.Items.Add(tip);
            }
        }

        private static void SetEducationTooltips(ComboBox box)
        {
            List<string> tips = new List<string>();
            List<string> tipsFromDb;

            try
            {
                tipsFromDb = DatabaseInteraction.PeopleFromDb.GetFoundUniversities(App.CurrentUserLogin);
            }
            catch
            {
                tipsFromDb = new List<string>();
            }

            foreach (var tip in tipsFromDb)
            {
                if (!string.IsNullOrWhiteSpace(tip.Trim()))
                    tips.Add(tip.Trim());
            }

            box.Items.Clear();

            foreach (var tip in tips)
            {
                box.Items.Add(tip);
            }
        }

        private static void SetSchoolTooltips(ComboBox box)
        {
            List<string> tips = new List<string>();
            List<string> tipsFromDb;

            try
            {
                tipsFromDb = DatabaseInteraction.PeopleFromDb.GetFoundSchools(App.CurrentUserLogin);
            }
            catch
            {
                tipsFromDb = new List<string>();
            }

            foreach (var tip in tipsFromDb)
            {
                if (!string.IsNullOrWhiteSpace(tip.Trim()))
                    tips.Add(tip.Trim());
            }

            box.Items.Clear();

            foreach (var tip in tips)
            {
                box.Items.Add(tip);
            }
        }


        private void ComboBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!e.Text.All(x => (x >= 'А' && x <= 'Я') || (x >= 'а' && x <= 'я') || x == '-'))
                e.Handled = true;
        }

        private void UniversityComboBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!e.Text.All(x => x == '№' || char.IsDigit(x) || (x >= 'А' && x <= 'Я') || (x >= 'а' && x <= 'я') || x == '-'))
                e.Handled = true;
        }

        private void UniversityComboBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!CityChecked || string.IsNullOrWhiteSpace(CityComboBox.Text))
            {
                e.Handled = true;
                EmptyCityErrorTextBlock.Visibility = Visibility.Visible;
            }
            else
                EmptyCityErrorTextBlock.Visibility = Visibility.Hidden;
        }
    }
}
