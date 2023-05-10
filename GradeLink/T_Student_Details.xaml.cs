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
	/// Interaction logic for T_Student_Details.xaml
	/// </summary>
	public partial class T_Student_Details : Window
	{
		string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\viktor\\source\\repos\\GradeLink\\GradeLink\\Database1.mdf;Integrated Security=True";

		string Teacher_ID;
		string Student_ID;

		public T_Student_Details(string teacher_ID, string student_ID)
		{
			InitializeComponent();
			Teacher_ID = teacher_ID;
			Student_ID = student_ID;
			Update_Datagrid();
		}

		private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var row = (DataRowView)dataGrid.SelectedItem;
			var value1 = row[2];

			new T_Edit_Grade(Teacher_ID, Student_ID, value1.ToString()).Show();
			Close();

		}
		public void Update_Datagrid()
		{
			string query = $"SELECT grades.name, grades.value, grades.ID\r\nFROM grades\r\nJOIN students\r\nON grades.student = students.id\r\nJOIN teachers\r\nON grades.teacher = teachers.id\r\nWHERE students.id = {Student_ID} AND teachers.id = {Teacher_ID};";
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
			new T_New_Grade(Teacher_ID, Student_ID).Show();
			Close();
		}

		private void Back(object sender, RoutedEventArgs e)
		{
			new T_Main(Teacher_ID).Show();
			Close();
		}
	}
}
