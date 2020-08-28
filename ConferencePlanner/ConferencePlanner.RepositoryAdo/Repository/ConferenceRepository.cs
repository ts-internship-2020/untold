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

        public List<ConferenceModel> FilterConferencesByDate(string email, string sDate, string eDate)
        {
            string commandText = "select C.ConferenceId, C.ConferenceName, vw.SpeakerName, vw.ConferenceCategoryName, vw.ConferenceTypeName, vw.LocationName, vw.ConferencePeriod from vwConferenceDetails vw " +
                "join Conference C on C.ConferenceId = vw.ConferenceId " +
                "where C.EmailOrganizer = @Email and C.StartDate >= @StartDate and C.EndDate <= @EndDate ";

            SqlCommand sqlCommand = new SqlCommand(commandText, _sqlConnection);
            sqlCommand.Parameters.Add("@Email", SqlDbType.NVarChar);
            sqlCommand.Parameters["@Email"].Value = email;
            sqlCommand.Parameters.Add("@StartDate", SqlDbType.NVarChar);
            sqlCommand.Parameters["@StartDate"].Value = sDate;
            sqlCommand.Parameters.Add("@EndDate", SqlDbType.NVarChar);
            sqlCommand.Parameters["@EndDate"].Value = eDate;

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<ConferenceModel> conferences = new List<ConferenceModel>();


            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    conferences.Add(new ConferenceModel()
                    {
                        ConferenceId = sqlDataReader.GetInt32("ConferenceId"),
                        ConferenceName = sqlDataReader.GetString("ConferenceName"),
                        ConferenceCategoryName = sqlDataReader.GetString("ConferenceCategoryName"),
                        ConferenceTypeName = sqlDataReader.GetString("ConferenceTypeName"),
                        Location = sqlDataReader.GetString("LocationName"),
                        Speaker = sqlDataReader.GetString("SpeakerName"),
                        Period = sqlDataReader.GetString("ConferencePeriod")
                    });

                }
            }

            sqlDataReader.Close();

            return conferences;
        }

        public List<ConferenceModel> GetConferencesByPage(string email, int startIndex, int endIndex, string sDate, string eDate)
        {
            string commandText = "with ConferencesForPagination AS(SELECT ROW_NUMBER() OVER(ORDER BY vw.ConferenceId) row_num,vw.ConferenceId, vw.ConferenceName, " +
                "vw.SpeakerName, vw.ConferenceCategoryName, vw.ConferenceTypeName, vw.LocationName, vw.ConferencePeriod, " +
                "C.StartDate, C.EndDate " +
                "FROM vwConferenceDetails vw " +
                "join Conference C on vw.ConferenceId = C.ConferenceId " +
                "where C.EmailOrganizer = @Email and C.StartDate >= @startDate and C.EndDate <= @endDate) " +
                "select * from ConferencesForPagination " +
                "where row_num >= @startIndex and row_num< @endIndex";

            SqlCommand sqlCommand = new SqlCommand(commandText, _sqlConnection);
            sqlCommand.Parameters.Add("@Email", SqlDbType.NVarChar);
            sqlCommand.Parameters["@Email"].Value = email;
            sqlCommand.Parameters.Add("@startIndex", SqlDbType.Int);
            sqlCommand.Parameters["@startIndex"].Value = startIndex;
            sqlCommand.Parameters.Add("@endIndex", SqlDbType.Int);
            sqlCommand.Parameters["@endIndex"].Value = endIndex;
            sqlCommand.Parameters.Add("@startDate", SqlDbType.NVarChar);
            sqlCommand.Parameters["@startDate"].Value = sDate;
            sqlCommand.Parameters.Add("@endDate", SqlDbType.NVarChar);
            sqlCommand.Parameters["@endDate"].Value = eDate;

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<ConferenceModel> conferences = new List<ConferenceModel>();


            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    conferences.Add(new ConferenceModel()
                    {
                        ConferenceId = sqlDataReader.GetInt32("ConferenceId"),
                        ConferenceName = sqlDataReader.GetString("ConferenceName"),
                        ConferenceCategoryName = sqlDataReader.GetString("ConferenceCategoryName"),
                        ConferenceTypeName = sqlDataReader.GetString("ConferenceTypeName"),
                        Location = sqlDataReader.GetString("LocationName"),
                        Speaker = sqlDataReader.GetString("SpeakerName"),
                        Period = sqlDataReader.GetString("ConferencePeriod")
                    });

                }
            }

            sqlDataReader.Close();

            return conferences;
        }

        public List<ConferenceModel> GetAttendeesByPage(string email, int startIndex, int endIndex)
        {
            string commandText = "with AttendeesForPagination AS(select ROW_NUMBER() OVER(ORDER BY a.StatusId DESC) row_num,isnull(StatusId, 0) StatusId,vw.ConferenceId,vw.ConferenceName,vw.ConferencePeriod,vw.ConferenceTypeName,vw.ConferenceCategoryName,vw.LocationName,vw.SpeakerName from  vwConferenceDetails vw " +
            "left join Attendee a on a.ConferenceId = vw.ConferenceId and a.AttendeeEmail = @Email "+
            "where isnull(a.StatusId, 0)!= 3 "+
            "order by StatusId desc OFFSET 0 ROWS)SELECT* FROM AttendeesForPagination WHERE row_num >= @startIndex and row_num < @endIndex";

            SqlCommand sqlCommand = new SqlCommand(commandText, _sqlConnection);
            sqlCommand.Parameters.Add("@Email", SqlDbType.NVarChar);
            sqlCommand.Parameters["@Email"].Value = email;
            sqlCommand.Parameters.Add("@startIndex", SqlDbType.Int);
            sqlCommand.Parameters["@startIndex"].Value = startIndex;
            sqlCommand.Parameters.Add("@endIndex", SqlDbType.Int);
            sqlCommand.Parameters["@endIndex"].Value = endIndex;

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<ConferenceModel> attendees = new List<ConferenceModel>();


            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    
                    attendees.Add(new ConferenceModel()
                    {
                        
                        RowNum = sqlDataReader.GetInt64("row_num"),
                        StatusId = sqlDataReader.GetInt32("StatusId"),
                        ConferenceId = sqlDataReader.GetInt32("ConferenceId"),
                        ConferenceName = sqlDataReader.GetString("ConferenceName"),
                        Period = sqlDataReader.GetString("ConferencePeriod"),
                        ConferenceTypeName = sqlDataReader.GetString("ConferenceTypeName"),
                        ConferenceCategoryName = sqlDataReader.GetString("ConferenceCategoryName"),                  
                        Location = sqlDataReader.GetString("LocationName"),
                        Speaker = sqlDataReader.GetString("SpeakerName")
                        
                    });

                }
            }

            sqlDataReader.Close();
            return attendees;
        }
       




        public List<ConferenceModel> GetConferencesByOrganizer(string email)
        {
            
        
            
            string commandText = "select ConferenceId, ConferenceName, ConferenceCategoryName, ConferenceTypeName, " +
                "LocationName, SpeakerName, ConferencePeriod from vwConferenceDetails where EmailOrganizer = @Email";
            
            SqlCommand sqlCommand = new SqlCommand(commandText, _sqlConnection);
            sqlCommand.Parameters.Add("@Email", SqlDbType.NVarChar);
            sqlCommand.Parameters["@Email"].Value = email;

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<ConferenceModel> conferences = new List<ConferenceModel>();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    conferences.Add(new ConferenceModel()
                    {
                        ConferenceId = sqlDataReader.GetInt32("ConferenceId"),
                        ConferenceName = sqlDataReader.GetString("ConferenceName"),
                        ConferenceCategoryName = sqlDataReader.GetString("ConferenceCategoryName"),
                        ConferenceTypeName = sqlDataReader.GetString("ConferenceTypeName"),
                        Location = sqlDataReader.GetString("LocationName"),
                        Speaker = sqlDataReader.GetString("SpeakerName"),
                        Period = sqlDataReader.GetString("ConferencePeriod")
                    });
                  
                }
            }

            sqlDataReader.Close();

            return conferences;
            }


        public List<ConferenceModel> AttendeeConferences(string email)
        {
            //SqlCommand sqlCommand = _sqlConnection.CreateCommand();
            string commandText = "select isnull(StatusId,0),vw.ConferenceId,vw.ConferenceName,vw.ConferencePeriod,vw.ConferenceTypeName,vw.ConferenceCategoryName,vw.LocationName,vw.SpeakerName from  vwConferenceDetails vw "+
                        "left join Attendee a on a.ConferenceId = vw.ConferenceId and a.AttendeeEmail = @AttendeeEmail "+
                        "where isnull(a.StatusId, 0)!= 3 "+
                        "order by StatusId desc";
            SqlCommand sqlCommand = new SqlCommand(commandText, _sqlConnection);
            sqlCommand.Parameters.Add("@AttendeeEmail", SqlDbType.NVarChar, 4000);
            sqlCommand.Parameters["@AttendeeEmail"].Value = email;
            sqlCommand.ExecuteNonQuery();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            var moreResults = true;
            

                    
                    List<ConferenceModel> attendees = new List<ConferenceModel>();

                     
                        while (moreResults)
                        {
                            
                            while (sqlDataReader.Read())
                            {
                                
                                attendees.Add(new ConferenceModel()
                                {
                                  
                                    ConferenceId = sqlDataReader.GetInt32("ConferenceId"),
                                    ConferenceName = sqlDataReader.GetString("ConferenceName"),
                                    Period = sqlDataReader.GetString("ConferencePeriod"),
                                    ConferenceTypeName = sqlDataReader.GetString("ConferenceTypeName"),
                                    ConferenceCategoryName = sqlDataReader.GetString("ConferenceCategoryName"),
                                    Location = sqlDataReader.GetString("LocationName"),

                                    Speaker = sqlDataReader.GetString("SpeakerName"),

                                    
                                });

                            }
                    moreResults = sqlDataReader.NextResult();
                        }
                    

            sqlDataReader.Close();

            return attendees;

        }

        public List<ConferenceModel> FilterConfAttendeeByDate(string email, string sDate, string eDate)
        {
            var conferences = AttendeeConferences(email);



            return conferences;
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

            conference.Location = sqlDataReader.GetString("LocationName");
            conference.Period = sqlDataReader.GetString("ConferencePeriod");

            sqlDataReader.Close();

            return conference;

        }

        void IConferenceRepository.DeleteConferenceById(int id)
        {
            string commandText = "delete from Conference where ConferenceId = @Id";
            SqlCommand sqlCommand = new SqlCommand(commandText, _sqlConnection);
            sqlCommand.Parameters.Add("@Id", SqlDbType.Int);
            sqlCommand.Parameters["@Id"].Value = id;

            //sqlCommand.ExecuteNonQuery();

        }
    }
    }

