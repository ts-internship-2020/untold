using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConferencePlanner.Repository.Ado.Repository
{
    public class GetDemoRepository : IGetDemoRepository
    {
        private readonly SqlConnection _sqlConnection;

        public GetDemoRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public List<DemoModel> GetDemo(string name)
        {
            SqlCommand sqlCommand = _sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select * from Conference";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<DemoModel> demos = new List<DemoModel>();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    demos.Add(new DemoModel() { Id = sqlDataReader.GetInt32("ConferenceId"), Name = sqlDataReader.GetString("ConferenceName") });
                }
            }

            sqlDataReader.Close();

            return demos;
        }

        public String BarcodeGenerator ()
        {
            Random random = new Random();
            int length = 16;
            var rString = "";
            for (var i = 0; i < length; i++)
            {
                rString += ((char)(random.Next(1, 26) + 64)).ToString().ToLower();
            }
            return rString;
        }

        public void AddEmail(string email)
        {
            string commandText = "insert into Attendee values (@ConferenceId, @AttendeeEmail , " +
                "@StatusId ,@EmailCode)";
            string barcode = BarcodeGenerator();
            int confId = 1;
            //statusId va fi hardcodat pentru ca 1 este pentru attend in tabela DictionaryStatus
            int statusId = 1;

            SqlCommand sqlCommand = new SqlCommand(commandText, _sqlConnection);
            sqlCommand.Parameters.Add("@ConferenceId", SqlDbType.Int);
            sqlCommand.Parameters["@ConferenceId"].Value = confId;
            sqlCommand.Parameters.Add("@AttendeeEmail", SqlDbType.NVarChar,4000);
            sqlCommand.Parameters["@AttendeeEmail"].Value = "abcd@yahoo.com";
            sqlCommand.Parameters.Add("@StatusId", SqlDbType.Int);
            sqlCommand.Parameters["@StatusId"].Value = statusId;
            sqlCommand.Parameters.Add("@EmailCode", SqlDbType.NVarChar,4000);
            sqlCommand.Parameters["@EmailCode"].Value = barcode;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            sqlDataReader.Close();
        }


        //public List<ConferenceModel> GetOrganizers(string name)
        //{
        //    SqlCommand sqlCommand = _sqlConnection.CreateCommand();
        //    sqlCommand.CommandText = "select * from vwConferenceDetails ";
        //    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

        //    List<DemoModel> demos = new List<ConferenceModel>();

        //    if (sqlDataReader.HasRows)
        //    {
        //        while (sqlDataReader.Read())
        //        {
        //            demos.Add(new ConferenceModel() { 
        //                Id = sqlDataReader.GetInt32("ConferenceId"), 
        //                Name = sqlDataReader.GetString("ConferenceName") });
        //                //Category = sqlDataReader.GetString("ConferenceCategoryName") });
        //    }
        //    }

        //    sqlDataReader.Close();

        //    return demos;
        //}
    }
}

