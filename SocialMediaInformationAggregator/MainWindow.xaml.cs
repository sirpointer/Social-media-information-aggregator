﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Configuration;


namespace SocialMediaInformationAggregator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string connectionString;
        public MainWindow()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
        }

        public void InsertUserIntoDb()
        {
            /// подключаемся к базе данны и записываем пользователя в таблицу
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                string query = string.Format("INSERT INTO Пользователи (Логин, Пароль, [e-mail], Имя, Фамилия) VALUES(@login, @password, @mail, @name, @firstname)");
                using (SqlCommand comm = new SqlCommand(query, conn))
                {
                    comm.Parameters.AddWithValue("@login", TextBoxLogin.Text);
                    comm.Parameters.AddWithValue("@password", TextBoxPassword.Text);
                    comm.Parameters.AddWithValue("@mail", TextBoxmail.Text);
                    comm.Parameters.AddWithValue("@name", TextBoxName.Text);
                    comm.Parameters.AddWithValue("@firstname", TextBoxFirstName.Text);
                    comm.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool PasswordIsCorrect()
        /// проверяем, соответствует ли пароль требованиям надежности
        {
            int buf = 0;
            int buf_1 = 0;
            int buf_2 = 0;
            int buf_3 = 0;
            int buf_4 = 0;
            int buf_5 = 0;
            if (TextBoxPassword.Text.ToCharArray().Count() >= 6)
            {
                foreach (var k in TextBoxPassword.Text.ToCharArray())
                {
                    if (Char.IsDigit(k)) buf = 1;
                    if (Char.IsLetter(k)) buf_1 = 1;
                    if (Char.IsLower(k)) buf_2 = 1;
                    if (Char.IsUpper(k)) buf_3 = 1;
                    if (Char.IsSymbol(k)) buf_4 = 1;
                    if (Char.IsWhiteSpace(k)) buf_5 = 1;
                }
                if (buf + buf_1 + buf_2 + buf_3 + buf_4 + buf_5 >= 2)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Пароль должен соответствовать хотя бы 3-м из следующих требований: \n" +
                                    "- содержать цифры \n" +
                                    "- содержать буквы \n" +
                                    "- содержать символы в верхнем регистре \n" +
                                    "- содержить символы в нижнем регистре \n" +
                                    "- содержать специальные символы \n" +
                                    "- содержать пробелы");
                    return false;
                }

            }
            else
            {
                MessageBox.Show("Пароль должен состоять минимум из 6 символов!");
                return false;
            }
        }

        public bool EmailISUnique()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                string query = "SELECT [e-mail] FROM Пользователи";
                using (SqlCommand comm = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = comm.ExecuteReader();
                    List<string> emails = new List<string>();

                    while (reader.Read())
                    {
                        emails.Add(reader.GetValue(0).ToString());
                    }
                    int k = emails.Where(a => a == TextBoxmail.Text).Count();
                    if (k != 0)
                    {
                        MessageBox.Show("Данный адрес электронной почты уже используется!");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        public bool LoginISUnique()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                string query = "SELECT [Логин] FROM Пользователи";
                using (SqlCommand comm = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = comm.ExecuteReader();
                    List<string> logins = new List<string>();

                    while (reader.Read())
                    {
                        logins.Add(reader.GetValue(0).ToString());
                    }
                    int k = logins.Where(a => a == TextBoxLogin.Text).Count();
                    if (k != 0)
                    {
                        MessageBox.Show("Данный адрес логин уже используется!");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordIsCorrect() == true && EmailISUnique() == true && LoginISUnique() == true)
            {
                if (TextBoxPassword.Text == TextBoxRepeat.Text)
                {
                    InsertUserIntoDb();
                    Questions questions = new Questions(TextBoxLogin.Text, connectionString);
                    questions.Show();


                }
                else
                {
                    MessageBox.Show("Пароли не идентичны!");
                }
            }
        }
    }
}
