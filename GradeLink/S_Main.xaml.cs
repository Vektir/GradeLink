﻿using System;
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
    /// Interaction logic for S_Main.xaml
    /// </summary>
    public partial class S_Main : Window
    {
		string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\viktor\\source\\repos\\GradeLink\\GradeLink\\Database1.mdf;Integrated Security=True";

		string Student_ID;
		public S_Main(string student_ID)
        {
            InitializeComponent();
			Student_ID = student_ID;
			Update_Grid();
        }


        public void Update_Grid()
        {
            string query = $"SELECT teachers.id, teachers.subject, teachers.name, AVG(grades.value)\r\nFROM teachers\r\nJOIN grades\r\nON teachers.id = grades.teacher\r\nJOIN students\r\nON grades.student = students.id\r\nWHERE students.id = {Student_ID}\r\nGROUP BY teachers.id, teachers.subject, teachers.name;\r\n";
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

		private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var row = (DataRowView)dataGrid.SelectedItem;
			var value1 = row[0];

			new S_Subject_Details(Student_ID,value1.ToString()).Show();
			Close();
		}
	}
}
