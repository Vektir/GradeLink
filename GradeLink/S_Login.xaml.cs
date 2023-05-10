using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace GradeLink
{
	/// <summary>
	/// Interaction logic for S_Login.xaml
	/// </summary>
	public partial class S_Login : Window
	{
		string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\viktor\\source\\repos\\GradeLink\\GradeLink\\Database1.mdf;Integrated Security=True";
		public S_Login()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			new S_New_account().Show();
			Close();
        }

		private void Button_Click_1(object sender, object e)
		{
			string query = $"select count(1) from Students where [Name] = '{username.Text}' and \"password\" = '{password.Password}'";
			SqlConnection sqlCon = new SqlConnection(connection);

			try
			{
				sqlCon.Open();
				SqlCommand command = new SqlCommand(query, sqlCon);
				command.CommandType = CommandType.Text;

				int a = Convert.ToInt32(command.ExecuteScalar());
				if (a == 1)
				{
					query = $"select ID from Students where [name] = '{username.Text}'";
					command = new SqlCommand(query, sqlCon);
					command.CommandType = CommandType.Text;
					new S_Main(command.ExecuteScalar().ToString()).Show();
					Close();
				}

			}catch (Exception ex)
			{

			}
		}
	}
}
