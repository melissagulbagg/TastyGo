using System;
using System.Data.SqlClient;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TastyGo
{
    public partial class SignUpWindow : Window
    {
        public SignUpWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton(object sender, RoutedEventArgs e)
        {
            string fullName = FullNameTextBox.Text;
            string password = PasswordBox.Password;
            string phone = PhoneNumberTextBox.Text;
            string address = AddressTextBox.Text;

            if (string.IsNullOrWhiteSpace(fullName) && string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter your name, surname and password.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else if (string.IsNullOrWhiteSpace(fullName))
            {
                MessageBox.Show("Please enter your name and surname.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter your password.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string connectionString = @"Data Source=ARDA;Initial Catalog=TastyGo;Integrated Security=True;";
            string username = fullName.Replace(" ", "").ToLower();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@Username", username);

                        int count = (int)checkCommand.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("This name and surname already exist.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }

                    string query = "INSERT INTO Users (Password, Username, NameSurname, Phone, Address) VALUES (@Password, @Username, @NameSurname, @Phone, @Address)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@NameSurname", fullName);

                        if (string.IsNullOrWhiteSpace(phone))
                        {
                            command.Parameters.AddWithValue("@Phone", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Phone", phone);
                        }

                        if (string.IsNullOrWhiteSpace(address))
                        {
                            command.Parameters.AddWithValue("@Address", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Address", address);
                        }

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Registration successful!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Registration failed, please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
