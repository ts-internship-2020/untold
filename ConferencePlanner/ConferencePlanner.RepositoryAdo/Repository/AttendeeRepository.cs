using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConferencePlanner.Repository.Ado.Repository
{
    public class AttendeeRepository : IAttendeeRepository
    {
        private readonly SqlConnection _sqlConnection;
        public AttendeeRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }


        public List<AttendeeModel> AttendeeConferences(string name)
        {
            SqlCommand sqlCommand = _sqlConnection.CreateCommand();
            sqlCommand.CommandText = "SELECT ConferenceName,StartDate,EndDate,ConferenceTypeName,ConferenceCategoryName,CountryName,CountyName,CityName,FirstName,LastName FROM vwConferenceDetails as vw JOIN Attendee a ON a.ConferenceId = vw.ConferenceId";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<AttendeeModel> attendees = new List<AttendeeModel>();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    attendees.Add(new AttendeeModel()
                    {
                        //ConferenceId = sqlDataReader.GetInt32("ConferenceId"),
                        ConferenceName = sqlDataReader.GetString("ConferenceName"),
                        StartDate= sqlDataReader.GetDateTime("StartDate"),
                        EndDate = sqlDataReader.GetDateTime("EndDate"),
                        ConferenceTypeName = sqlDataReader.GetString("ConferenceTypeName"),
                        ConferenceCategoryName = sqlDataReader.GetString("ConferenceCategoryName"),
                        CountryName = sqlDataReader.GetString("CountryName"),
                        CountyName = sqlDataReader.GetString("CountyName"),
                        CityName = sqlDataReader.GetString("CityName"),
                        SpeakerFirstName = sqlDataReader.GetString("FirstName"),
                        SpeakerLastName = sqlDataReader.GetString("LastName")
                    });
                    
                }
            }

            sqlDataReader.Close();

            return attendees;

        }
    }
}
