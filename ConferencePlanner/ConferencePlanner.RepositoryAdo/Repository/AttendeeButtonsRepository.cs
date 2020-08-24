using ConferencePlanner.Abstraction.Repository;
using Microsoft.Toolkit.Forms.UI.Controls;
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

        public void Attend(string email, string barcode)
        {
            string commandText = "insert into Attendee values (@ConferenceId, @AttendeeEmail , " +
                "@StatusId ,@EmailCode)";
            int confId = 2;
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
            sqlCommand.ExecuteNonQuery();
            //aici mai trebuie dat drop la table si apelata metoda de select 
        }

        public void WithdrawnCommand(String email, int conferenceId)
        {
            int newConferenceId = 3;
            string commandText = "update Attendee set StatusId = @NewStatusId where StatusId = @Id and AttendeeEmail = @Email";
            SqlCommand sqlCommand = new SqlCommand(commandText, _sqlConnection);
            sqlCommand.Parameters.Add("@Id", SqlDbType.Int);
            sqlCommand.Parameters["@Id"].Value = conferenceId;
            sqlCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 4000);
            sqlCommand.Parameters["@Email"].Value = email;
            sqlCommand.Parameters.AddWithValue("@NewStatusId", newConferenceId);
            sqlCommand.ExecuteNonQuery();
            //aici mai trebuie dat drop la table si apelata metoda de select 
        }

        public void JoinCommand(String email, int newConferenceId)
        {
            int conferenceId = 3;
            string commandText = "update Attendee set StatusId = @NewStatusId where StatusId = @Id and AttendeeEmail = @Email";
            SqlCommand sqlCommand = new SqlCommand(commandText, _sqlConnection);
            sqlCommand.Parameters.Add("@Id", SqlDbType.Int);
            sqlCommand.Parameters["@Id"].Value = conferenceId; 
            sqlCommand.Parameters.Add("@Email", SqlDbType.NVarChar,4000);
            sqlCommand.Parameters["@Email"].Value = email;
            sqlCommand.Parameters.AddWithValue("@NewStatusId", newConferenceId);
            sqlCommand.ExecuteNonQuery();
        }

      
    }
}
