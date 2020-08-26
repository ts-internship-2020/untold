using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConferencePlanner.Repository.Ado.Repository
{
    public class SpeakerRepository : ISpeakerRepository
    {
        private readonly SqlConnection _sqlConnection;

        public SpeakerRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }


        public SpeakerModel GetSpeakerByName(string[] names)
        {
            string commandText = "select Nationality, Rating, ImagePath from Speaker where FirstName =  @firstName and LastName = @lastName" ;

            SqlCommand sqlCommand = new SqlCommand(commandText, _sqlConnection);
            sqlCommand.Parameters.Add("@firstName", SqlDbType.NVarChar);
            sqlCommand.Parameters["@firstName"].Value = names[0];
            sqlCommand.Parameters.Add("@lastName", SqlDbType.NVarChar);
            sqlCommand.Parameters["@lastName"].Value = names[1];


            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            SpeakerModel speaker = new SpeakerModel();
            sqlDataReader.Read();

            speaker.FirstName = names[0];
            speaker.LastName = names[1];
            speaker.Nationality = sqlDataReader.GetString("Nationality");
            //speaker.Rating= sqlDataReader.GetSqlDouble("Rating");
            //speaker.ImagePath = sqlDataReader.GetString("ImagePath");

            sqlDataReader.Close();

            return speaker;
        }
        public SpeakerModel GetSpeakerById(int id)
        {
            string commandText = "with ConferencesForPagination AS( SELECT ROW_NUMBER() OVER( ORDER BY ConferenceId) row_num, ConferenceId, ConferenceName, " +
                "SpeakerName, ConferenceCategoryName, ConferenceTypeName, LocationName, ConferencePeriod " +
                "FROM vwConferenceDetails " +
                "where EmailOrganizer = @Email) select * from ConferencesForPagination " +
                "where row_num >= @startIndex and row_num < @endIndex";

            SqlCommand sqlCommand = new SqlCommand(commandText, _sqlConnection);
            //sqlCommand.Parameters.Add("@Email", SqlDbType.NVarChar);
            //sqlCommand.Parameters["@Email"].Value = email;
            //sqlCommand.Parameters.Add("@startIndex", SqlDbType.Int);
            //sqlCommand.Parameters["@startIndex"].Value = startIndex;
            //sqlCommand.Parameters.Add("@endIndex", SqlDbType.Int);
            //sqlCommand.Parameters["@endIndex"].Value = endIndex;

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            SpeakerModel speaker = new SpeakerModel();




            sqlDataReader.Close();

            return speaker;
        }







    }
    }

