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
    public class ConferenceRepository : IConferenceRepository
    {
        private readonly SqlConnection _sqlConnection;

        public ConferenceRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        //public List<ConferenceModel> FilterConferences(string emal, string sDate, string eDate)
        //{
        //    throw NotImplementedException;
        //}



        public List<ConferenceModel> GetConferencesByOrganizer(string email)
        {
        
            SqlCommand sqlCommand = _sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select * from vwConferenceDetails where EmailOrganizer = '"+email + "'";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<ConferenceModel> demos = new List<ConferenceModel>();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    demos.Add(new ConferenceModel()
                    {
                        ConferenceId = sqlDataReader.GetInt32("ConferenceId"),
                        ConferenceName = sqlDataReader.GetString("ConferenceName"),
                        ConferenceCategoryName = sqlDataReader.GetString("ConferenceCategoryName"),
                        ConferenceTypeName = sqlDataReader.GetString("ConferenceTypeName"),
                        LocationName = sqlDataReader.GetString("LocationName"),
                        SpeakerName = sqlDataReader.GetString("SpeakerName"),
                        Period = sqlDataReader.GetString("ConferencePeriod")
                    });
                  
                }
            }

            sqlDataReader.Close();

            return demos;
            }
        public List<ConferenceModel> AttendeeConferences(string email)
        {
            //SqlCommand sqlCommand = _sqlConnection.CreateCommand();
            string commandText = "exec returnconflist @AttendeeEmail";
            SqlCommand sqlCommand = new SqlCommand(commandText, _sqlConnection);
            sqlCommand.Parameters.Add("@AttendeeEmail", SqlDbType.NVarChar, 4000);
            sqlCommand.Parameters["@AttendeeEmail"].Value = email;
            sqlCommand.ExecuteNonQuery();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            var moreResults = true;
            

                    
                    List<ConferenceModel> attendees = new List<ConferenceModel>();

                    if (sqlDataReader.HasRows)
                    { 
                        
                        while (moreResults)
                        {
                            
                            while (sqlDataReader.Read())
                            {
                                
                                attendees.Add(new ConferenceModel()
                                {
                                    //ConferenceId = sqlDataReader.GetInt32("ConferenceId"),
                                    ConferenceName = sqlDataReader.GetString("ConferenceName"),
                                    ConferenceTypeName = sqlDataReader.GetString("ConferenceTypeName"),
                                    ConferenceCategoryName = sqlDataReader.GetString("ConferenceCategoryName"),
                                    LocationName = sqlDataReader.GetString("LocationName"),

                                    SpeakerName = sqlDataReader.GetString("SpeakerName"),

                                    Period = sqlDataReader.GetString("ConferencePeriod"),
                                });

                            }
                    moreResults = sqlDataReader.NextResult();
                        }
                    }

            sqlDataReader.Close();

            return attendees;

        }

        public List<ConferenceModel> FilterConferences(string name)
        {
            throw new NotImplementedException();
        }

        public ConferenceModel GetConferenceById(int id)
        {
            string commandText = "select ConferenceName, LocationName, ConferencePeriod from vwConferenceDetails where ConferenceId = @Id ";

            SqlCommand sqlCommand = new SqlCommand(commandText, _sqlConnection);
            sqlCommand.Parameters.Add("@Id", SqlDbType.Int);
            sqlCommand.Parameters["@Id"].Value =id;
            
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();


            ConferenceModel conference = new ConferenceModel();
            //Console.WriteLine(sqlDataReader);
            sqlDataReader.Read();
            conference.ConferenceName = sqlDataReader.GetString("ConferenceName");

            conference.LocationName = sqlDataReader.GetString("LocationName");
            conference.Period = sqlDataReader.GetString("ConferencePeriod");

            sqlDataReader.Close();

            return conference;

        }
    }
    }

