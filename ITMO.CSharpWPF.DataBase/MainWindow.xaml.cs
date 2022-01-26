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
using System.Data.SqlClient;

namespace ITMO.CSharpWPF.DataBase
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowSharePrices_Click(object sender, RoutedEventArgs e)
        {
            ShareIDPriceDateBox.Items.Clear();

            using (SqlConnection cn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ApressFinancial;Data Source=.\\SQLexpress"))
            { 
                cn.Open();

                using (SqlCommand cmd = new SqlCommand("select ShareID,Price,PriceDate from ApressFinancial.ShareDetails.SharePrices order by ShareID", cn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ShareIDPriceDateBox.Items.Add("ShareID "+ reader[0] + " Price " + reader[1]+" Time "+ reader[2]);
                        }
                    }
                              
                }  

            }
        }

        private void InsertPrice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ApressFinancial;Data Source=.\\SQLexpress"))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("insert into ApressFinancial.ShareDetails.SharePrices(ShareID, Price, PriceDate) values(@IDShare, @PrShare, getdate())", cn);
                    cmd.Parameters.AddWithValue("@IDShare", InsIDBox.Text);
                    cmd.Parameters.AddWithValue("@PrShare", InsPriceBox.Text);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                MessageBox.Show("Запись добавлена");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  
            }


         }

        private void DeleteShare_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ApressFinancial;Data Source=.\\SQLexpress"))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("delete from ApressFinancial.ShareDetails.SharePrices where ShareID = @IDDel", cn);
                    cmd.Parameters.AddWithValue("@IDDel", InsIDDelShareBox.Text);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                MessageBox.Show("Запись удалена");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
