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
	/// Interaction logic for S_Subject_Details.xaml
	/// </summary>
	public partial class S_Subject_Details : Window
	{
		string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\viktor\\source\\repos\\GradeLink\\GradeLink\\Database1.mdf;Integrated Security=True";
		string Student_ID;
		string Teacher_ID;
		public S_Subject_Details(string student_ID, string teacher_ID)
		{
			InitializeComponent();
			Student_ID = student_ID;
			Teacher_ID = teacher_ID;

			Update_Grid();
		}

		private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

        }

		public void Update_Grid()
		{
			string query = $"select grades.name, grades.value from grades where student = {Student_ID} and teacher = {Teacher_ID}";
			SqlConnection sqlCon = new SqlConnection(connection);
			sqlCon.Open();
			try
			{
				DataTable dataTable = new DataTable();

				SqlDataAdapter dataAdapter = new SqlDataAdapter(query, sqlCon);
				dataAdapter.Fill(dataTable);

				dataGrid.ItemsSource = dataTable.DefaultView;

			}
			catch (Exception ex)
			{
				System.Windows.MessageBox.Show(ex.ToString());
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			new S_Main(Student_ID).Show();
			Close();
		}
	}
}
