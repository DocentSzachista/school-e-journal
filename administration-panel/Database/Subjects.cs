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
            return DataType.Zajecia;
        }

        public override void InsertData(string[] data)
        {
            _connection.Open();
            using(SqlCommand insertProcedure = new SqlCommand("SP_DML_SUBJECT", _connection))
            {
                insertProcedure.CommandType = CommandType.StoredProcedure;
                insertProcedure.Parameters.AddWithValue("@teacherId", int.Parse(data[0]) );
                insertProcedure.Parameters.AddWithValue("@subjectName", data[1]);
                insertProcedure.Parameters.AddWithValue("@className",data[2]);
                insertProcedure.Parameters.AddWithValue("@ACTION", "INSERT");
                insertProcedure.ExecuteNonQuery();
            }

            _connection.Close();
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

