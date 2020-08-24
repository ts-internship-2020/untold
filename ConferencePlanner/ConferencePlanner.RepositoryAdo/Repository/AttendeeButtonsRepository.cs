using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConferencePlanner.Repository.Ado.Repository
{
    public class AttendeeButtonsRepository : IAttendeeButtonsRepository
    {
        private readonly SqlConnection _sqlConnection;

        public AttendeeButtonsRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public String BarcodeGenerator()
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
            sqlCommand.Parameters.Add("@AttendeeEmail", SqlDbType.NVarChar, 4000);
            sqlCommand.Parameters["@AttendeeEmail"].Value = email;
            sqlCommand.Parameters.Add("@StatusId", SqlDbType.Int);
            sqlCommand.Parameters["@StatusId"].Value = statusId;
            sqlCommand.Parameters.Add("@EmailCode", SqlDbType.NVarChar, 4000);
            sqlCommand.Parameters["@EmailCode"].Value = barcode;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            sqlDataReader.Close();
        }

      
    }
}
