﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
    /// Логика взаимодействия для QuestionPage.xaml
    /// </summary>
    public partial class QuestionPage : Page
    {
        public QuestionPage()
        {
            App.MakeConnectionString();
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBoxHobby.Text.Trim(' '))
                && !String.IsNullOrWhiteSpace(textBoxPet.Text.Trim(' '))
                && !String.IsNullOrWhiteSpace(textBoxSer.Text.Trim(' ')))
            {
                SqlConnection conn = new SqlConnection(App.ConnectionString);
                try
                {
                    conn.Open();

                    string query = string.Format("UPDATE Users SET [FirstQuestion] = '{0}', [SecondQuestion]='{1}', [ThirdQuestion]='{2}' " +
                                                 "WHERE (Login='{3}')",
                                                 textBoxSer.Text.ToLower().Trim(' '),
                                                 textBoxPet.Text.ToLower().Trim(' '),
                                                 textBoxHobby.Text.ToLower().Trim(' '),
                                                 App.LoginGlobalVeryForMethod.ToLower().Trim(' '));
                    SqlCommand comm = new SqlCommand(query, conn);
                    comm.ExecuteNonQuery();
                    conn.Close();
                    this.NavigationService.Navigate(new Uri("InputPage.xaml", UriKind.Relative));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены!");
            }
        }
    }
}
