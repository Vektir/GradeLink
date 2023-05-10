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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace GradeLink
{
	/// <summary>
	/// Interaction logic for T_Main.xaml
	/// </summary>
	public partial class T_Main : Window
	{
		string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\viktor\\source\\repos\\GradeLink\\GradeLink\\Database1.mdf;Integrated Security=True";
		string ID;
		public T_Main(string iD)
		{
			InitializeComponent();
			ID = iD;

			Update_Datagrid();
		}


		public void Update_Datagrid()
		{
			string query = $"SELECT students.name, ROUND(AVG(grades.[value]),2), students.ID\r\nFROM students\r\nLEFT JOIN grades\r\nON students.id = grades.student AND grades.teacher = 2\r\nGROUP BY students.name, students.ID;\r\n";
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

		private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var row = (DataRowView)dataGrid.SelectedItem;
			var value1 = row[2];

            System.Windows.MessageBox.Show(value1.ToString());
			new T_Student_Details(ID, value1.ToString()).Show();
			Close();

		}
	}
}
