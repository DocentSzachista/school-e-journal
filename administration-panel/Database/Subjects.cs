using Database.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Globalization;

namespace Database
{
    class Subjects : IDAO
    {
        public override void DeleteData(int index)
        {
            _connection.Open();
            using (SqlCommand deleteProcedure = new SqlCommand("SP_DML_SUBJECT", _connection))
            {
                deleteProcedure.CommandType = CommandType.StoredProcedure;
                deleteProcedure.Parameters.AddWithValue("@ACTION", "DELETE");
                deleteProcedure.Parameters.AddWithValue("@subjectId", index);
                deleteProcedure.ExecuteNonQuery();
            }
            _connection.Close();
        }

        public override DataType GetDataType()
        {
            return DataType.Zajecia;
        }

        public override void InsertData(string[] data)
        {
            string spCommand = "SP_DML_SUBJECT";
            _connection.Open();
            if(data.Length > 3)
            {
                spCommand = "SP_DML_SUBJ_WITH_LESSONS";
            }
            using (SqlCommand insertProcedure = new SqlCommand(spCommand, _connection))
            {
                insertProcedure.CommandType = CommandType.StoredProcedure;
                insertProcedure.Parameters.AddWithValue("@teacherId", int.Parse(data[0]) );
                insertProcedure.Parameters.AddWithValue("@subjectName", data[1]);
                insertProcedure.Parameters.AddWithValue("@className",data[2]);
                
                if(data.Length > 3)
                {

                    // Niepoprawny format wejściowy idk why 
                    insertProcedure.Parameters.AddWithValue("@startDate", data[3]);
                    insertProcedure.Parameters.AddWithValue("@endDay", data[4]);
                    insertProcedure.Parameters.AddWithValue("@endDate", data[5]);
                }


                insertProcedure.Parameters.AddWithValue("@ACTION", "INSERT");
                insertProcedure.ExecuteNonQuery();
            }

            _connection.Close();
        }

        public override DataTable ReadData()
        {
            _connection.Open();
            string readQuery = "SELECT * FROM DisplaySubjectInfo;";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(readQuery, _connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            _connection.Close();
            return dataTable;
        }

        public override void UpdateData(string[] data, int index)
        {
            _connection.Open();
            string spCommand = "SP_DML_SUBJECT";
            if (data.Length > 3)
            {
                spCommand = "SP_DML_SUBJ_WITH_LESSONS";
            }
            using (SqlCommand updateSql = new SqlCommand(spCommand, _connection))
            {
                updateSql.CommandType = CommandType.StoredProcedure;
                updateSql.Parameters.AddWithValue("@subjectId", index);
                updateSql.Parameters.AddWithValue("@subjectName", data[1]);
                updateSql.Parameters.AddWithValue("@className", data[2]);
                updateSql.Parameters.AddWithValue("@teacherId", int.Parse(data[0]));
                if (data.Length > 3)
                {
                    updateSql.Parameters.AddWithValue("@startDate", data[3]);
                    updateSql.Parameters.AddWithValue("@endDay", data[4]);
                    updateSql.Parameters.AddWithValue("@endDate", data[5]);
                }
                updateSql.Parameters.AddWithValue("@ACTION", "UPDATE");
                updateSql.ExecuteNonQuery();
            }
            _connection.Close();
        }
    }
}

