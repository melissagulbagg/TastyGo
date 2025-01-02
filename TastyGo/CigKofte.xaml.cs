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
    public partial class CigKofte : UserControl
    {
        private static int likeCount = 0;
        private static int dislikeCount = 0;
        private static bool hasLiked = false;
        private static bool hasDisliked = false;

        public CigKofte()
        {
            InitializeComponent();
            LoadCigKofteData(); 
            UpdateUI(); 
        }

        
        private void LoadCigKofteData()
        {
            string connectionString = @"Data Source=ARDA;Initial Catalog=TastyGo;Integrated Security=True;";
            string query = "SELECT FoodName, CuisineType, Location, FoodPrice, LikeCount, DislikeCount FROM Restaurants WHERE FoodName = 'Çiğ Köfte'";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            FoodNameTextBlock.Text = reader["FoodName"].ToString();
                            CuisineTypeTextBlock.Text = reader["CuisineType"].ToString();
                            AddressTextBlock.Text = reader["Location"].ToString();
                            PriceTextBlock.Text = $"{reader["FoodPrice"]} ₺"; 
                            likeCount = reader["LikeCount"] != DBNull.Value ? Convert.ToInt32(reader["LikeCount"]) : 0;
                            dislikeCount = reader["DislikeCount"] != DBNull.Value ? Convert.ToInt32(reader["DislikeCount"]) : 0;
                            LikeTextBlock.Text = likeCount.ToString();
                            DislikeTextBlock.Text = dislikeCount.ToString();
                        }
                        else
                        {
                            MessageBox.Show("No data found for 'Çiğ Köfte'.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

       
        private void UpdateReviewCounts()
        {
            string connectionString = @"Data Source=ARDA;Initial Catalog=TastyGo;Integrated Security=True;";
            string query = "UPDATE Restaurants SET LikeCount = @LikeCount, DislikeCount = @DislikeCount WHERE FoodName = 'Çiğ Köfte'";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LikeCount", likeCount);
                        command.Parameters.AddWithValue("@DislikeCount", dislikeCount);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating review counts: {ex.Message}");
            }
        }

        
        private void Like(object sender, RoutedEventArgs e)
        {
            if (!hasLiked)
            {
                likeCount++;
                LikeTextBlock.Text = likeCount.ToString();
                if (hasDisliked)
                {
                    dislikeCount--;
                    DislikeTextBlock.Text = dislikeCount.ToString();
                    hasDisliked = false;
                }
                hasLiked = true;
                UpdateReviewCounts(); 
            }
        }

        
        private void Dislike(object sender, RoutedEventArgs e)
        {
            if (!hasDisliked)
            {
                dislikeCount++;
                DislikeTextBlock.Text = dislikeCount.ToString();
                if (hasLiked)
                {
                    likeCount--;
                    LikeTextBlock.Text = likeCount.ToString();
                    hasLiked = false;
                }
                hasDisliked = true;
                UpdateReviewCounts(); 
            }
        }

        
        private void BackButton(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.MainGrid.Children.Clear();
                parentWindow.MainGrid.Children.Add(new MainMenu());
            }
        }

        
        private void UpdateUI()
        {
            LikeTextBlock.Text = likeCount.ToString();
            DislikeTextBlock.Text = dislikeCount.ToString();
        }

        
        private void CartButton(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                
                var cartControl = new Cart();

                
                parentWindow.MainGrid.Children.Clear();
                parentWindow.MainGrid.Children.Add(cartControl);
            }
        }
    }
}
