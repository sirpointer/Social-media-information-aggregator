﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для PersonPage.xaml
    /// </summary>
    public partial class PersonPage : Page
    {
        public PersonPage()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            if (App.VkPerson != null)
            {
                App.OkPerson = WorkingWithPeople.WorkingWithPeople.GetSimilarPerson(App.VkPerson, App.PersonInformation);
            }
            else
            {
                App.VkPerson = WorkingWithPeople.WorkingWithPeople.GetSimilarPerson(App.OkPerson, App.PersonInformation);
            }

            if (App.VkPerson != null)
            {
                FindPeople.PersonInformation person = App.VkPerson;

                this.FullNameTextBlock.Text = person.Name + " " + person.LastName;

                if (person.YearOfBirth == null)
                    this.YearTextBlock.Text = "Нет данных";
                else
                    this.YearTextBlock.Text = person.YearOfBirth.ToString();


                if (!string.IsNullOrWhiteSpace(person.ProfileLink))
                {
                    this.VkHyperLink.NavigateUri = new Uri(person.ProfileLink);
                }

                foreach (var ed in person.Education)
                    if (!string.IsNullOrWhiteSpace(ed))
                        EducationVkStackPanel.Children.Add(GetVkTextBlock(ed));

                foreach (var city in person.Cities)
                    if (!string.IsNullOrWhiteSpace(city))
                        CitiesVkStackPanel.Children.Add(GetVkTextBlock(city));
            }
            else
            {
                VkTextBlock.Visibility = Visibility.Hidden;
                EducationVkStackPanel.Visibility = Visibility.Hidden;
                CitiesVkStackPanel.Visibility = Visibility.Hidden;
            }

            if (App.OkPerson != null)
            {
                FindPeople.PersonInformation person = App.OkPerson;

                this.FullNameTextBlock.Text = person.Name + " " + person.LastName;

                if (person.YearOfBirth == null)
                    this.YearTextBlock.Text = "Нет данных";
                else
                    this.YearTextBlock.Text = person.YearOfBirth.ToString();

                if (!string.IsNullOrWhiteSpace(person.ProfileLink))
                {
                    this.OkHyperLink.NavigateUri = new Uri(person.ProfileLink);
                }


                foreach (var ed in person.Education)
                    if (!string.IsNullOrWhiteSpace(ed))
                        EducationOkStackPanel.Children.Add(GetOkTextBlock(ed));
                
                foreach (var city in person.Cities)
                    if (!string.IsNullOrWhiteSpace(city))
                        CitiesOkStackPanel.Children.Add(GetOkTextBlock(city));
            }
            else
            {
                OkTextBlock.Visibility = Visibility.Hidden;
                EducationOkStackPanel.Visibility = Visibility.Hidden;
                CitiesOkStackPanel.Visibility = Visibility.Hidden;
            }
        }

        public static TextBlock GetVkTextBlock(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return new TextBlock() { Text = string.Empty, Visibility = Visibility.Collapsed };
            else
            {
                return new TextBlock()
                {
                    Text = text,
                    TextWrapping = TextWrapping.Wrap,
                    Margin = new Thickness(5),
                    Foreground = Brushes.Blue,
                    HorizontalAlignment = HorizontalAlignment.Center
                };
            }
        }

        public static TextBlock GetOkTextBlock(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return new TextBlock() { Text = string.Empty, Visibility = Visibility.Collapsed };
            else
            {
                return new TextBlock()
                {
                    Text = text,
                    TextWrapping = TextWrapping.Wrap,
                    Margin = new Thickness(5),
                    Foreground = Brushes.OrangeRed,
                    HorizontalAlignment = HorizontalAlignment.Center
                };
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (App.CurrentUserLogin != null)
            {
                SaveTextBlock.Visibility = Visibility.Hidden;
                SaveErrorTextBlock.Visibility = Visibility.Hidden;
                
#if DEBUG
                DatabaseInteraction.PeopleFromDb.AddFoundPerson(App.VkPerson, App.OkPerson);
#else
                try
                {
                    DatabaseInteraction.PeopleFromDb.AddFoundPerson(App.VkPerson, App.OkPerson);
                    SaveTextBlock.Visibility = Visibility.Visible;
                }
                catch
                {
                    SaveErrorTextBlock.Visibility = Visibility.Visible;
                }
#endif
            }
            else
                MessageBox.Show("Для сохранения данных нужно авторизироваться.");
        }

        private void VkHyperLink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(e.Uri.ToString());
            e.Handled = true;
        }
    }
}
