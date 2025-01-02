using System;
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

namespace TastyGo
{
    public partial class MainWindow : Window
    {
        public static string LoggedInUserFullName { get; private set; }
        public static string LoggedInUserFirstName { get; private set; }
        public static string LoggedInUserLastName { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        public void LogInButton(object sender, RoutedEventArgs e)
        {
            TextBox fullNameTextBox = MainGrid.Children.OfType<TextBox>().FirstOrDefault(tb => tb.Name == "FullNameTextBox");
            PasswordBox passwordBox = MainGrid.Children.OfType<PasswordBox>().FirstOrDefault(pb => pb.Name == "PasswordBox");

            if (fullNameTextBox != null && passwordBox != null)
            {
                string fullName = fullNameTextBox.Text;
                string password = passwordBox.Password;

                if (string.IsNullOrWhiteSpace(fullName) && string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Enter your name-surname and password.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (string.IsNullOrWhiteSpace(fullName))
                {
                    MessageBox.Show("Enter your name and surname.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Enter your password.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    string connectionString = @"Data Source=ARDA;Initial Catalog=TastyGo;Integrated Security=True;";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();

                            string query = "SELECT NameSurname FROM Users WHERE Username = @Username AND Password = @Password";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Username", fullName.Replace(" ", "").ToLower());
                                command.Parameters.AddWithValue("@Password", password);

                                SqlDataReader reader = command.ExecuteReader();
                                if (reader.Read())
                                {
                                    LoggedInUserFullName = reader["NameSurname"].ToString();
                                    var names = LoggedInUserFullName.Split(' ');
                                    if (names.Length > 1)
                                    {
                                        LoggedInUserFirstName = names[0];
                                        LoggedInUserLastName = names[1];
                                    }
                                    MainGrid.Children.Clear();
                                    MainGrid.Background = new SolidColorBrush(Colors.White);
                                    MainMenu mainMenu = new MainMenu();
                                    MainGrid.Children.Add(mainMenu);
                                }
                                else
                                {
                                    MessageBox.Show("User not found. Please sign up.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                                reader.Close();
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

        public void SignUpButton(object sender, RoutedEventArgs e)
        {
            SignUpWindow signUpWindow = new SignUpWindow();
            signUpWindow.ShowDialog();
        }
    }
}
