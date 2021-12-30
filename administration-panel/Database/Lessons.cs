using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Database.Enums;
using System.Data;

namespace Database
{
	class Lessons : IDAO
	{
		public override void DeleteData(int index)
		{
			throw new NotImplementedException();
		}

		public override DataType GetDataType()
		{
			throw new NotImplementedException();
		}

		public override void InsertData(string[] data)
		{
			throw new NotImplementedException();
		}

		public override DataTable ReadData()
		{
			throw new NotImplementedException();
		}

		public override void UpdateData(string[] data, int index)
		{
			throw new NotImplementedException();
		}

		public DataTable GetSubjectLessons(int subjectId)
		{
			_connection.Open();
			string readQuery = $"SELECT Topic, StartTime, SubjectName, EndTime FROM Lessons " +
							   $"JOIN Subjects ON Subjects.SubjectId = Lessons.SubjectId " +
							   $"WHERE Lessons.SubjectId={subjectId};";
			SqlDataAdapter dataAdapter = new SqlDataAdapter(readQuery, _connection);
			DataTable dataTable = new DataTable();
			dataAdapter.Fill(dataTable);
			_connection.Close();
			return dataTable;
		}
	}
}
