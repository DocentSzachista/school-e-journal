using Database.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Database
{
    class Subjects : IDAO
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
            _connection.Open();
            string readQuery = "SELECT * FROM DisplaySubjectInfo";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(readQuery, _connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            _connection.Close();
            return dataTable;
        }

        public override void UpdateData(string[] data, int index)
        {
            throw new NotImplementedException();
        }
    }
}
